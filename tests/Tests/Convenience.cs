using static HyperTextExpression.HtmlExp;

namespace Test;

public class Convenience
{
    [Fact]
    public void meta_tags()
    {
        Assert.Equal("<meta charset=\"UTF-8\"></meta>", MetaCharset().ToString());
        Assert.Equal("<meta charset=\"UTF-16\"></meta>", MetaCharset("UTF-16").ToString());
        Assert.Equal("<meta name=\"description\" content=\"Hello World\"></meta>", Meta("description", "Hello World").ToString());
        Assert.Equal("<meta property=\"og:title\" content=\"A Title\"></meta>", MetaOg("title", "A Title").ToString());
    }

    [Fact]
    public void style_link()
    {
        var expected = """
                       <link rel="stylesheet" href="https://example.com/main.css"></link>
                       """;

        var html = Styles("https://example.com/main.css");
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }

    [Fact]
    public void scripts_link()
    {
        var expected = """
                       <script src="https://example.com/main.js"></script>
                       """;

        var html = Script("https://example.com/main.js");
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }
}