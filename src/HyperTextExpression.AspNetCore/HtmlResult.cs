using System.Text;
using Microsoft.AspNetCore.Http;

namespace HyperTextExpression.AspNetCore;

public abstract class BaseHtmlResult : IResult
{
    private readonly Encoder _encoder;
    private readonly int _statusCode;

    public BaseHtmlResult(Encoder encoder, int statusCode)
    {
        _encoder = encoder;
        _statusCode = statusCode;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        var response = httpContext.Response;
        response.StatusCode = _statusCode;
        response.Headers.Add("content-type", "text/html");
        var writer = new PrintHtmlPipeWriter(response.BodyWriter, _encoder);
        await response.StartAsync();

        Print(writer);

        await response.BodyWriter.FlushAsync();
    }

    public abstract void Print(PrintHtmlPipeWriter writer);
}

public class HtmlResult : BaseHtmlResult
{
    private readonly HtmlEl _el;

    public HtmlResult(HtmlEl el, int statusCode)
        : base(Encoding.UTF8.GetEncoder(), statusCode) =>
        _el = el;

    public HtmlResult(HtmlEl el, Encoding encoding, int statusCode)
        : base(encoding.GetEncoder(), statusCode) =>
        _el = el;

    public override void Print(PrintHtmlPipeWriter writer) =>
        IPrintHtml.To(_el, writer);
}

public class CollectionHtmlResult : BaseHtmlResult
{
    private readonly HtmlEl[] _el;

    public CollectionHtmlResult(HtmlEl[] el, int statusCode) :
        base(Encoding.UTF8.GetEncoder(), statusCode) =>
        _el = el;

    public CollectionHtmlResult(HtmlEl[] el, Encoding encoding, int statusCode) :
        base(encoding.GetEncoder(), statusCode) =>
        _el = el;

    public override void Print(PrintHtmlPipeWriter writer)
    {
        foreach (var el in _el)
        {
            IPrintHtml.To(el, writer);
        }
    }
}