using System.Collections.Immutable;

namespace HyperTextExpression;

public partial class HtmlExp
{
    #region Generic Html Element Templating

    public static HtmlEl HtmlEl(string name) =>
        new(
            name,
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl HtmlEl(string name, string text) =>
        new(
            name,
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            text
        );

    public static HtmlEl HtmlEl(string name, IDictionary<string, string> attributes) =>
        new(
            name,
            attributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl HtmlEl(string name, params HtmlEl[] children) =>
        new(
            name,
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl HtmlEl(string name, IDictionary<string, string> attributes, params HtmlEl[] children) =>
        new(
            name,
            attributes,
            children,
            ""
        );

    public static HtmlEl HtmlEl(string name, IDictionary<string, string> attributes, string text) =>
        new(
            name,
            attributes,
            HtmlConstants.NoChildren,
            text
        );

    #endregion

    #region Html Doc Element Templating

    public static HtmlEl HtmlDoc() =>
        new(
            "html",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl HtmlDoc(string text) =>
        new(
            "html",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            text
        );

    public static HtmlEl HtmlDoc(IDictionary<string, string> attributes) =>
        new(
            "html",
            attributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl HtmlDoc(params HtmlEl[] children) =>
        new(
            "html",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl HtmlDoc(IDictionary<string, string> attributes, params HtmlEl[] children) =>
        new(
            "html",
            attributes,
            children,
            ""
        );

    public static HtmlEl HtmlDoc(IDictionary<string, string> attributes, string text) =>
        new(
            "html",
            attributes,
            HtmlConstants.NoChildren,
            text
        );

    #endregion

    #region Head Element Templating

    public static HtmlEl Head() =>
        new(
            "head",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl Head(string text) =>
        new(
            "head",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            text
        );

    public static HtmlEl Head(IDictionary<string, string> attributes) =>
        new(
            "head",
            attributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl Head(params HtmlEl[] children) =>
        new(
            "head",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl Head(IDictionary<string, string> attributes, params HtmlEl[] children) =>
        new(
            "head",
            attributes,
            children,
            ""
        );

    public static HtmlEl Head(IDictionary<string, string> attributes, string text) =>
        new(
            "head",
            attributes,
            HtmlConstants.NoChildren,
            text
        );

    #endregion

    #region Body Element Templating

    public static HtmlEl Body() =>
        new(
            "body",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl Body(string text) =>
        new(
            "body",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            text
        );

    public static HtmlEl Body(IDictionary<string, string> attributes) =>
        new(
            "body",
            attributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl Body(params HtmlEl[] children) =>
        new(
            "body",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl Body(IDictionary<string, string> attributes, params HtmlEl[] children) =>
        new(
            "body",
            attributes,
            children,
            ""
        );

    public static HtmlEl Body(IDictionary<string, string> attributes, string text) =>
        new(
            "body",
            attributes,
            HtmlConstants.NoChildren,
            text
        );

    #endregion

    #region Div Element Templating

    public static HtmlEl Div() =>
        new(
            "div",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl Div(string text) =>
        new(
            "div",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            text
        );

    public static HtmlEl Div(IDictionary<string, string> attributes) =>
        new(
            "div",
            attributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl Div(params HtmlEl[] children) =>
        new(
            "div",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl Div(IDictionary<string, string> attributes, params HtmlEl[] children) =>
        new(
            "div",
            attributes,
            children,
            ""
        );

    public static HtmlEl Div(IDictionary<string, string> attributes, string text) =>
        new(
            "div",
            attributes,
            HtmlConstants.NoChildren,
            text
        );

    #endregion


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