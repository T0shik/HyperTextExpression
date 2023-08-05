using System.Collections;

namespace HyperTextExpression;

public class HtmlAttributes
{
    private readonly List<HtmlAttribute> _attrs;
    public HtmlAttributes() => _attrs = new List<HtmlAttribute>();
    public HtmlAttributes(IEnumerable<HtmlAttribute> attributes) => _attrs = new List<HtmlAttribute>(attributes);

    public HtmlAttributes Add(HtmlAttribute attr)
    {
        if (this == HtmlConstants.NoAttributes) return new HtmlAttributes().Add(attr);

        _attrs.Add(attr);
        return this;
    }

    public HtmlAttributes Concat(HtmlAttributes? attrs)
    {
        if (attrs == null) return this;
        
        var result = new HtmlAttributes();
        foreach (var a in this) result.Add(a);
        foreach (var a in attrs) result.Add(a);
        return result;
    }

    public List<HtmlAttribute>.Enumerator GetEnumerator() => _attrs.GetEnumerator();
}

public record struct HtmlAttribute(string Key, string Value)
{
    public static implicit operator HtmlAttribute((string, string) kv) => new(kv.Item1, kv.Item2);
    public static implicit operator HtmlAttribute(string key) => new(key, "");
    public static implicit operator HtmlAttribute((string, int) kv) => new(kv.Item1, kv.Item2.ToString());
    public static implicit operator HtmlAttribute((string, bool) kv) => new(kv.Item1, kv.Item2 ? "true" : "false");
}