using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using static HyperTextExpression.HtmlExp;

BenchmarkRunner.Run<Simple>();

[MemoryDiagnoser()]
public class Simple
{
    [Benchmark]
    public string CreateHtmlWithLink()
    {
        return Html(
            ("body", Children(
                    ("div",
                        Enumerable.Range(1, 6)
                            .Select(i => ("p", $"{i}"))
                    )
                )
            )
        ).ToString();
    }
}
