namespace HyperTextExpression;

public partial class HtmlExp
{
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
            "src", src,
            "href", "href"
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