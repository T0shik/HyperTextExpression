using static HyperTextExpression.HtmlExp;

namespace Test;

public class Main
{
    [Fact]
    public void base_html_doc()
    {
        var expected = """
<!DOCTYPE html>
<html></html>
""";

        var html = Html();
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }

    [Fact]
    public void html_doc_with_head_and_body()
    {
        var expected = """
<!DOCTYPE html>
<html>
    <head></head>
    <body></body>
</html>
""";

        var html = Html(
            head(),
            body()
        );
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }

    [Fact]
    public void head_with_title()
    {
        var expected = """
<!DOCTYPE html>
<html>
    <head>
        <title>Hello World</title>
    </head>
    <body></body>
</html>
""";
        var html = Html(
            head(
                ("title", "Hello World")
            ),
            body()
        );
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }


    [Fact]
    public void body_with_list()
    {
        var expected = """
<!DOCTYPE html>
<html>
    <head>
        <title>Hello World</title>
    </head>
    <body>
        <ul>
            <li>One</li>
            <li>Two</li>
            <li>Three</li>
        </ul>
    </body>
</html>
""";
        var html = Html(
            head(
                ("title", "Hello World")
            ),
            body(
                ("ul", children(
                        ("li", "One"),
                        ("li", "Two"),
                        ("li", "Three")
                    )
                )
            )
        );
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }

    [Fact]
    public void easy_to_use_with_linq()
    {
        var expected = """
<!DOCTYPE html>
<html>
    <body>
        <div>
            <p>1</p>
            <p>2</p>
            <p>3</p>
            <p>4</p>
            <p>5</p>
            <p>6</p>
        </div>
    </body>
</html>
""";
        var html = Html(
            ("body", children(
                    ("div",
                        Enumerable.Range(1, 6)
                            .Select(i => ("p", $"{i}"))
                    )
                )
            )
        );
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }
}