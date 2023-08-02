using System.Reflection;
using HyperTextExpression.AspNetCore;

namespace Htmxin.Endpoints;

public class Home
{
    private static IEnumerable<SampleAttribute> Samples =>
        typeof(SampleAttribute)
            .Assembly
            .GetTypes()
            .Select(x => x.GetCustomAttribute<SampleAttribute>())
            .Where(x => x != null)!;

    private static readonly IResult HtmlResult = HtmlDoc(
            Head(
                ("title", "HTMX Samples")
            ),
            Body(
                ("ul", Samples
                    .Select(x =>
                        ("li",
                            Children(
                                ("a", Attrs("href", x.Path), x.Description)
                            ))
                    )
                )
            )
        )
        .ToIResult();

    public static IResult Handle() => HtmlResult;
}