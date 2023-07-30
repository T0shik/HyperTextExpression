using System.Collections.Immutable;

namespace HyperTextExpression;

public static class HtmlConstants
{
    public static readonly HtmlEl[] NoChildren = Array.Empty<HtmlEl>();
    public static readonly IImmutableDictionary<string, string> NoAttributes = ImmutableDictionary<string, string>.Empty;
}