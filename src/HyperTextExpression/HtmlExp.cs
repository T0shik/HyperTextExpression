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

    public static HtmlEl HtmlEl(string name, HtmlAttributes attributes) =>
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

    public static HtmlEl HtmlEl(string name, HtmlAttributes attributes, params HtmlEl[] children) =>
        new(
            name,
            attributes,
            children,
            ""
        );

    public static HtmlEl HtmlEl(string name, HtmlAttributes attributes, string text) =>
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

    public static HtmlEl HtmlDoc(HtmlAttributes attributes) =>
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

    public static HtmlEl HtmlDoc(IEnumerable<HtmlEl> children) =>
        new(
            "html",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl HtmlDoc(HtmlAttributes attributes, params HtmlEl[] children) =>
        new(
            "html",
            attributes,
            children,
            ""
        );

    public static HtmlEl HtmlDoc(HtmlAttributes attributes, IEnumerable<HtmlEl> children) =>
        new(
            "html",
            attributes,
            children,
            ""
        );

    public static HtmlEl HtmlDoc(HtmlAttributes attributes, string text) =>
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

    public static HtmlEl Head(HtmlAttributes attributes) =>
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

    public static HtmlEl Head(IEnumerable<HtmlEl> children) =>
        new(
            "head",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl Head(HtmlAttributes attributes, params HtmlEl[] children) =>
        new(
            "head",
            attributes,
            children,
            ""
        );

    public static HtmlEl Head(HtmlAttributes attributes, IEnumerable<HtmlEl> children) =>
        new(
            "head",
            attributes,
            children,
            ""
        );

    public static HtmlEl Head(HtmlAttributes attributes, string text) =>
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

    public static HtmlEl Body(HtmlAttributes attributes) =>
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

    public static HtmlEl Body(IEnumerable<HtmlEl> children) =>
        new(
            "body",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl Body(HtmlAttributes attributes, params HtmlEl[] children) =>
        new(
            "body",
            attributes,
            children,
            ""
        );

    public static HtmlEl Body(HtmlAttributes attributes, IEnumerable<HtmlEl> children) =>
        new(
            "body",
            attributes,
            children,
            ""
        );

    public static HtmlEl Body(HtmlAttributes attributes, string text) =>
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

    public static HtmlEl Div(HtmlAttributes attributes) =>
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

    public static HtmlEl Div(IEnumerable<HtmlEl> children) =>
        new(
            "div",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl Div(HtmlAttributes attributes, params HtmlEl[] children) =>
        new(
            "div",
            attributes,
            children,
            ""
        );

    public static HtmlEl Div(HtmlAttributes attributes, IEnumerable<HtmlEl> children) =>
        new(
            "div",
            attributes,
            children,
            ""
        );

    public static HtmlEl Div(HtmlAttributes attributes, string text) =>
        new(
            "div",
            attributes,
            HtmlConstants.NoChildren,
            text
        );

    #endregion

    #region P Element Templating

    public static HtmlEl P() =>
        new(
            "p",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl P(string text) =>
        new(
            "p",
            HtmlConstants.NoAttributes,
            HtmlConstants.NoChildren,
            text
        );

    public static HtmlEl P(HtmlAttributes attributes) =>
        new(
            "p",
            attributes,
            HtmlConstants.NoChildren,
            ""
        );

    public static HtmlEl P(params HtmlEl[] children) =>
        new(
            "p",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl P(IEnumerable<HtmlEl> children) =>
        new(
            "p",
            HtmlConstants.NoAttributes,
            children,
            ""
        );

    public static HtmlEl P(HtmlAttributes attributes, params HtmlEl[] children) =>
        new(
            "p",
            attributes,
            children,
            ""
        );

    public static HtmlEl P(HtmlAttributes attributes, IEnumerable<HtmlEl> children) =>
        new(
            "p",
            attributes,
            children,
            ""
        );

    public static HtmlEl P(HtmlAttributes attributes, string text) =>
        new(
            "p",
            attributes,
            HtmlConstants.NoChildren,
            text
        );

    #endregion

    public static HtmlAttributes Attrs(string attribute) => new HtmlAttributes().Add(attribute);
    public static HtmlAttributes Attrs(HtmlAttribute attribute) => new HtmlAttributes().Add(attribute);
    public static HtmlAttributes Attrs(params HtmlAttribute[] attributes) => new HtmlAttributes(attributes);

    public static HtmlAttributes Attrs(params string[] attributeList)
    {
        if (attributeList.Length == 0)
        {
            return HtmlConstants.NoAttributes;
        }

        if (attributeList.Length % 2 != 0)
        {
            throw new ArgumentException($"supplied attribute count needs to be divisible by 2: {string.Join(", ", attributeList)}");
        }

        var result = new HtmlAttributes();
        for (var i = 0; i < attributeList.Length; i += 2)
        {
            result.Add((attributeList[i], attributeList[i + 1]));
        }

        return result;
    }

    public static HtmlAttributes Attrs(string key, string value) => new HtmlAttributes().Add((key, value));

    public static HtmlEl[] Children(params HtmlEl[] children) => children;
}