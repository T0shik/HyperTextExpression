using System.Collections.Immutable;

namespace HyperTextExpression;

public class HtmlExp
{
    public static HtmlEl Html(params HtmlEl[] children) =>
        new HtmlEl(
            "html",
            HtmlConstants.NoAttributes,
            children.Length == 0 ? HtmlConstants.NoChildren : children.ToImmutableArray(),
            ""
        );

    public static HtmlEl body(params HtmlEl[] children) =>
        new HtmlEl(
            "body",
            HtmlConstants.NoAttributes,
            children.Length == 0 ? HtmlConstants.NoChildren : children.ToImmutableArray(),
            ""
        );

    public static HtmlEl head(params HtmlEl[] children) =>
        new(
            "head",
            HtmlConstants.NoAttributes,
            children.Length == 0 ? HtmlConstants.NoChildren : children.ToImmutableArray(),
            ""
        );

    public static HtmlEl[] children(params HtmlEl[] children) => children;
}