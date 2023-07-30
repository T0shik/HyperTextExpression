# HyperTextExpression

Same ol' C# with a different way to say what HTML you want.

```csharp
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

## Motivation
- Template straight from c#
- No need to use/learn `.cshtml` Razor/View and then wait for things like email templating...
- [hiccup](https://github.com/weavejester/hiccup)
- [tweet](https://twitter.com/DamianEdwards/status/1624230739566018560/photo/1)