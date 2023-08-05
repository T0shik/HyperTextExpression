using System.Text;
using Microsoft.AspNetCore.Http;

namespace HyperTextExpression.AspNetCore;

public static class HtmlElExtensions
{
    public static IResult ToIResult(this HtmlEl @this, int statusCode = 200) =>
        new HtmlResult(@this, statusCode);

    public static IResult ToIResult(this HtmlEl @this, Encoding encoding, int statusCode = 200) =>
        new HtmlResult(@this, encoding, statusCode);

    public static IResult ToIResult(this HtmlEl[] @this, int statusCode = 200) =>
        new CollectionHtmlResult(@this, statusCode);

    public static IResult ToIResult(this HtmlEl[] @this, Encoding encoding, int statusCode = 200) =>
        new CollectionHtmlResult(@this, encoding, statusCode);

    public static IResult ToIResult(this IEnumerable<HtmlEl> @this, int statusCode = 200) =>
        new CollectionHtmlResult(@this.ToArray(), statusCode);

    public static IResult ToIResult(this IEnumerable<HtmlEl> @this, Encoding encoding, int statusCode = 200) =>
        new CollectionHtmlResult(@this.ToArray(), encoding, statusCode);
}