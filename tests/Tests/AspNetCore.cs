using System.IO.Pipelines;
using System.Security.Claims;
using HyperTextExpression.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using static HyperTextExpression.HtmlExp;

namespace Test;

public class AspNetCore
{
    [Fact]
    public async Task writes_html()
    {
        var expected = """
<div class="message-wrapper">
    <label bold>Author</label>
    <div class="body">Hello World</div>
</div>
""";

        var html = Div(Attrs("class", "message-wrapper"),
            Children(
                ("label", Attrs("bold"), "Author"),
                Div(Attrs("class", "body"), "Hello World")));

        var pipe = new Pipe();
        await new HtmlResult(html, 200).ExecuteAsync(
            new MockHttpContext(new(pipe.Writer))
        );
        
        await pipe.Writer.CompleteAsync();
        
        var htmlString = await new StreamReader(pipe.Reader.AsStream()).ReadToEndAsync();
        
        Assert.Equal(expected, htmlString);
    }
}


    public class MockHttpContext : HttpContext
    {
        public MockHttpContext(MockHttpResponse res)
        {
            Response = res;
        }

        public override void Abort()
        {
        }

        
        public override IFeatureCollection Features { get; }
        public override HttpRequest Request { get; }
        public override HttpResponse Response { get; }
        public override ConnectionInfo Connection { get; }
        public override WebSocketManager WebSockets { get; }
        public override ClaimsPrincipal User { get; set; }
        public override IDictionary<object, object?> Items { get; set; }
        public override IServiceProvider RequestServices { get; set; }
        public override CancellationToken RequestAborted { get; set; }
        public override string TraceIdentifier { get; set; }
        public override ISession Session { get; set; }
    }

    public class MockHttpResponse : HttpResponse
    {
        public MockHttpResponse(PipeWriter writer)
        {
            Headers = new HeaderDictionary();
            BodyWriter = writer;
        }

        public override Task StartAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public override void OnStarting(Func<object, Task> callback, object state)
        {
        }

        public override void OnCompleted(Func<object, Task> callback, object state)
        {
        }

        public override void Redirect(string location, bool permanent)
        {
        }

        public override HttpContext HttpContext { get; }
        public override int StatusCode { get; set; }
        public override IHeaderDictionary Headers { get; }
        public override Stream Body { get; set; }
        public override long? ContentLength { get; set; }
        public override string? ContentType { get; set; }
        public override IResponseCookies Cookies { get; }
        public override bool HasStarted { get; }
        public override PipeWriter BodyWriter { get; }
    }
