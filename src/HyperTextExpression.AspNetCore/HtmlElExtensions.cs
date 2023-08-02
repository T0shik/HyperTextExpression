using System.Text;
using Microsoft.AspNetCore.Http;

namespace HyperTextExpression.AspNetCore;

public static class HtmlElExtensions
{
    public static IResult ToIResult(this HtmlEl @this) => new HtmlResult(@this);

    public static IResult ToIResult(this HtmlEl @this, Encoding encoding) => new HtmlResult(@this, encoding);

    public static IResult ToIResult(this HtmlEl[] @this) => new CollectionHtmlResult(@this);
    public static IResult ToIResult(this HtmlEl[] @this, Encoding encoding) => new CollectionHtmlResult(@this, encoding);
    public static IResult ToIResult(this IEnumerable<HtmlEl> @this) => new CollectionHtmlResult(@this.ToArray());
    public static IResult ToIResult(this IEnumerable<HtmlEl> @this, Encoding encoding) => new CollectionHtmlResult(@this.ToArray(), encoding);
}