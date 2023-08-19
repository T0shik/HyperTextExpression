using HyperTextExpression;
using static HyperTextExpression.HtmlExp;

namespace Test;

public class Convenience
{
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