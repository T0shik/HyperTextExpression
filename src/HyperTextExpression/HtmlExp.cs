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

    public static HtmlEl Body(params HtmlEl[] children) =>
        new HtmlEl(
            "body",
            HtmlConstants.NoAttributes,
            children.Length == 0 ? HtmlConstants.NoChildren : children.ToImmutableArray(),
            ""
        );

    public static HtmlEl Head(params HtmlEl[] children) =>
        new(
            "head",
            HtmlConstants.NoAttributes,
            children.Length == 0 ? HtmlConstants.NoChildren : children.ToImmutableArray(),
            ""
        );

    public static IDictionary<string, string> Attrs(string key)
    {
        var result = new Dictionary<string, string>();
        result.Add(key, "");
        return result;
    }

    public static IDictionary<string, string> Attrs(params string[] attributeList)
    {
        if (attributeList.Length == 0)
        {
            return HtmlConstants.NoAttributes;
        }

        if (attributeList.Length % 2 == 0)
        {
            throw new ArgumentException($"supplied attribute count needs to be divisible by 2: {string.Join(", ", attributeList)}");
        }

        var result = new Dictionary<string, string>();
        for (var i = 0; i < attributeList.Length; i += 2)
        {
            result.Add(attributeList[i], attributeList[i + 1]);
        }

        return result;
    }

    public static IDictionary<string, string> Attrs(string key, string value)
    {
        var result = new Dictionary<string, string>();
        result.Add(key, value);
        return result;
    }

    public static IDictionary<string, string> Attrs(params (string, string)[] attributes)
    {
        var result = new Dictionary<string, string>();
        foreach (var (key, value) in attributes)
        {
            result.Add(key, value);
        }

        return result;
    }

    public static HtmlEl[] Children(params HtmlEl[] children) => children;
}