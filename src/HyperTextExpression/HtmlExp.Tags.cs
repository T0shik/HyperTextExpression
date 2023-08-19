namespace HyperTextExpression;

public partial class HtmlExp
{
    public static HtmlEl MetaCharset(string charSet = "UTF-8") => HtmlEl(
        "meta",
        Attrs(
            "charset", charSet
        )
    );
    
    public static HtmlEl Meta(string name, string content) => HtmlEl(
        "meta",
        Attrs(
            "name", name,
            "content", content
        )
    );
    
    public static HtmlEl MetaOg(string property, string content) => HtmlEl(
        "meta",
        Attrs(
            "property", $"og:{property}",
            "content", content
        )
    );

    public static HtmlEl Styles(string href) => HtmlEl(
        "link",
        Attrs(
            "rel", "stylesheet",
            "href", href
        )
    );

    public static HtmlEl Script(string src, HtmlAttributes? attributes = null)
    {
        var defaultAttributes = Attrs(
            "src", src
        );

        if (attributes != null)
        {
            foreach (var attr in attributes)
            {
                defaultAttributes.Add(attr);
            }
        }

        return HtmlEl("script", defaultAttributes);
    }
}