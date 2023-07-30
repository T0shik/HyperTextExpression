using System.Text;
using Microsoft.AspNetCore.Http;

namespace HyperTextExpression.AspNetCore;

public class HtmlResult : IResult
{
    private readonly HtmlEl _el;
    private readonly Encoder _encoder;

    public HtmlResult(HtmlEl el)
    {
        _el = el;
        _encoder = Encoding.UTF8.GetEncoder();
    }

    public HtmlResult(HtmlEl el, Encoding encoding)
    {
        _el = el;
        _encoder = encoding.GetEncoder();
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        var response = httpContext.Response;
        response.StatusCode = 200;
        response.Headers.Add("content-type", "text/html");
        var writer = new PrintHtmlPipeWriter(response.BodyWriter, _encoder);
        await response.StartAsync();

        if (_el.Name == "html") IPrintHtml.To(_el, writer);
        else IPrintHtml.To(_el, writer);

        await response.BodyWriter.FlushAsync();
    }
}