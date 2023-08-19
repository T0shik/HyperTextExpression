# HyperTextExpression

Same ol' C# with a different way to say what HTML you want.

```csharp
using static HyperTextExpression.HtmlExp;

var html = HtmlDoc(
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

html.ToString(); => <!DOCTYPE html>
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
```
Within ASP.NET Core.
```csharp
app.MapGet("/", () =>
    HtmlDoc(
        Body(
            ("h1", "Hello World")
        ))
        .ToIResult()
);
```

## Motivation
- Template straight in c#
- No need to use/learn `.cshtml` Razor/View and then wait for things like email templating...
- C# structure is MUCH easier to manipulate than an HTML string.
- [hiccup](https://github.com/weavejester/hiccup)
- [tweet](https://twitter.com/DamianEdwards/status/1624230739566018560/photo/1)

## Installation

#### Standalone
```
dotnet add package HyperTextExpression
```

#### AspNetCore Integration
```
dotnet add package HyperTextExpression.AspNetCore
```

## Examples

- If you've never seen Uncle Bob's mythical "tests as documentation", [here you go](./tests/Tests/Main.cs)
- [Samples](./samples/Htmxin) with [Htmx](https://htmx.org)

## Custom Serialization
- [PrintHtmlStringBuilder.cs](./src/HyperTextExpression/PrintHtmlStringBuilder.cs)
- [PrintHtmlPipeWriter.cs](./src/HyperTextExpression.AspNetCore/PrintHtmlPipeWriter.cs)

1. Implement `IPrintHtml`
```csharp
public class MyPrintHtml : IPrintHtml
{
    public void Write(char c) => ...;
    public void Write(char c, int count) => ...;
    public void Write(ReadOnlySpan<char> chars) => ...;
}
```
2. Dump `HtmlEl` to your implementation of `IPrintHtml`
```csharp
var html = HtmlDoc(
        Body(
            ("h1", "Hello World")
        ));
        
var myPrint = new MyPrintHtml();
        
IPrintHtml.To(html, myPrint);
```