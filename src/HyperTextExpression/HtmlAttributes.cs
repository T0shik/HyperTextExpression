namespace HyperTextExpression;

public class HtmlAttributes : List<HtmlAttribute>
{
    public HtmlAttributes() { }
    public HtmlAttributes(IEnumerable<HtmlAttribute> attributes) : base(attributes) { }
}

public record struct HtmlAttribute(string Key, string Value)
{
    public static implicit operator HtmlAttribute((string, string) kv) => new(kv.Item1, kv.Item2);
    public static implicit operator HtmlAttribute(string key) => new(key, "");
    public static implicit operator HtmlAttribute((string, int) kv) => new(kv.Item1, kv.Item2.ToString());
    public static implicit operator HtmlAttribute((string, bool) kv) => new(kv.Item1, kv.Item2 ? "true" : "false");
}