using System.Text;
using Microsoft.AspNetCore.Http;

namespace HyperTextExpression.AspNetCore;

public abstract class BaseHtmlResult : IResult
{
    private readonly Encoder _encoder;

    public BaseHtmlResult(Encoder encoder) => _encoder = encoder;

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        var response = httpContext.Response;
        response.StatusCode = 200;
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

    public HtmlResult(HtmlEl el) : base(Encoding.UTF8.GetEncoder()) =>
        _el = el;

    public HtmlResult(HtmlEl el, Encoding encoding) : base(encoding.GetEncoder()) =>
        _el = el;

    public override void Print(PrintHtmlPipeWriter writer) =>
        IPrintHtml.To(_el, writer);
}

public class CollectionHtmlResult : BaseHtmlResult
{
    private readonly HtmlEl[] _el;

    public CollectionHtmlResult(HtmlEl[] el) : base(Encoding.UTF8.GetEncoder()) =>
        _el = el;

    public CollectionHtmlResult(HtmlEl[] el, Encoding encoding) : base(encoding.GetEncoder()) =>
        _el = el;

    public override void Print(PrintHtmlPipeWriter writer)
    {
        foreach (var el in _el)
        {
            IPrintHtml.To(el, writer);
        }
    }
}