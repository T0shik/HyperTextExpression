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
            Head(),
            Body()
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
            Head(
                ("title", "Hello World")
            ),
            Body()
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
            Head(
                ("title", "Hello World")
            ),
            Body(
                ("ul", Children(
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
            ("body", Children(
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


    [Fact]
    public void attributes_should_be_just_as_easy()
    {
/*
Razor Syntax For Comparison        
<!DOCTYPE html>
<html>
    <body>
        <article class="body">
            @for(var i = 1; i < 6; i++){
                <p class="paragraph">Lorem Ipsum {i}</p>
            }
        </article>
    </body>
</html>
*/
        var expected = """
<!DOCTYPE html>
<html>
    <body>
        <article class="body">
            <p class="paragraph">Lorem Ipsum 1</p>
            <p class="paragraph">Lorem Ipsum 2</p>
            <p class="paragraph">Lorem Ipsum 3</p>
            <p class="paragraph">Lorem Ipsum 4</p>
            <p class="paragraph">Lorem Ipsum 5</p>
            <p class="paragraph">Lorem Ipsum 6</p>
        </article>
    </body>
</html>
""";
        var html = Html(
            ("body", Children(
                ("article",
                    Attrs("class", "body"),
                    Enumerable.Range(1, 6)
                        .Select(i =>
                            ("p",
                                Attrs("class", "paragraph"),
                                $"Lorem Ipsum {i}")))))
        );
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }

    [Fact]
    public void mixing_attributes_without_keys()
    {
        var expected = """
<!DOCTYPE html>
<html>
    <body>
        <article class="body" show>
            <p class="paragraph">Lorem Ipsum 1</p>
            <p class="paragraph">Lorem Ipsum 2</p>
            <p class="paragraph">Lorem Ipsum 3</p>
            <p class="paragraph">Lorem Ipsum 4</p>
            <p class="paragraph">Lorem Ipsum 5</p>
            <p class="paragraph">Lorem Ipsum 6</p>
        </article>
    </body>
</html>
""";
        var html = Html(
            ("body", Children(
                ("article",
                    Attrs(
                        ("class", "body"),
                        ("show", "")
                    ),
                    Enumerable.Range(1, 6)
                        .Select(i =>
                            ("p",
                                Attrs("class", "paragraph"),
                                $"Lorem Ipsum {i}")))))
        );
        var htmlString = html.ToString();

        Assert.Equal(expected, htmlString);
    }
}