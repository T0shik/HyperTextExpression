using HyperTextExpression;
using HyperTextExpression.AspNetCore;

namespace Htmxin.Endpoints.Samples;

[Sample("/infinite-load", "infinitely loading list of lorem ipsums.")]
public class InfiniteLoad
{
    public static IResult Landing() => HtmlDoc(
            Head(
                ("title", "Infinite List!")
            ),
            Body(
                Attrs("style", "max-width: 800px; margin: auto; margin-bottom: 5rem;"),
                Div(Attrs("id", "lorems"), LoremIpsumMessages),
                LoadMoreBtn,
                HtmxScript
            )
        )
        .ToIResult();

    public static HtmlEl[] LoremIpsumMessages => Enumerable
        .Range(0, 10)
        .Select(x => LoremNET.Lorem.Paragraph(5, 6, 4, 10))
        .Select(paragraph => HtmlEl("p", paragraph))
        .ToArray();

    public static HtmlEl LoadMoreBtn => Div(Attrs("style", "text-align: center;"),
        ("button",
            Attrs("hx-get", "/infinite-load/more",
                "hx-target", "#lorems",
                "hx-swap", "beforeend"
            ),
            "Load More!"
        )
    );

    public static IResult LoadMore() => LoremIpsumMessages.ToIResult();
}