using HyperTextExpression;

namespace Htmxin.Endpoints.ExpressionExtension;

public static class HtmlExp
{
    public static HtmlEl HtmxScript = ("script",
            Attrs("src", "https://unpkg.com/htmx.org@1.9.4",
                "integrity", "sha384-zUfuhFKKZCbHTY6aRR46gxiqszMk5tcHjsVFxnUo8VMus4kHGVdIYVbOYYNlKmHV",
                "crossorigin", "anonymous")
        );

    public static HtmlEl HtmxJsonEncScript = ("script",
            Attrs("src", "https://unpkg.com/htmx.org/dist/ext/json-enc.js")
        );
}