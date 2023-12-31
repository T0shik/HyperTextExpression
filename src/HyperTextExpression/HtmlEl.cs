namespace HyperTextExpression;

public partial record struct HtmlEl(
    string Name,
    HtmlAttributes Attributes,
    IEnumerable<HtmlEl> Children,
    string Text
)
{
    public override string ToString() => IPrintHtml.ToString(this);


    public static implicit operator HtmlEl(string elName) =>
        new(elName, HtmlConstants.NoAttributes, HtmlConstants.NoChildren, "");

    public static implicit operator HtmlEl((string, string) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, HtmlConstants.NoChildren, el.Item2);

    public static implicit operator HtmlEl((string, HtmlEl) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, new[] { el.Item2 }, "");

    public static implicit operator HtmlEl((string, HtmlEl[]) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2, "");

    public static implicit operator HtmlEl((string, HtmlAttributes) el) =>
        new(el.Item1, el.Item2, HtmlConstants.NoChildren, "");

    public static implicit operator HtmlEl((string, HtmlAttributes, HtmlEl) el) =>
        new(el.Item1, el.Item2, new[] { el.Item3 }, "");

    public static implicit operator HtmlEl((string, HtmlAttributes, HtmlEl[]) el) =>
        new(el.Item1, el.Item2, el.Item3, "");

    public static implicit operator HtmlEl((string, HtmlAttributes, string) el) =>
        new(el.Item1, el.Item2, HtmlConstants.NoChildren, el.Item3);

    #region LINQ: el + children

    public static implicit operator HtmlEl((string, IEnumerable<string>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, IEnumerable<HtmlEl>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2, "");

    public static implicit operator HtmlEl((string, IEnumerable<(string, string)>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, IEnumerable<(string, HtmlEl)>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, IEnumerable<(string, HtmlEl[])>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, IEnumerable<(string, HtmlAttributes)>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, IEnumerable<(string, HtmlAttributes, HtmlEl)>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, IEnumerable<(string, HtmlAttributes, HtmlEl[])>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, IEnumerable<(string, HtmlAttributes, string)>) el) =>
        new(el.Item1, HtmlConstants.NoAttributes, el.Item2.Select(s => (HtmlEl)s), "");

    #endregion

    #region LINQ: el + attrs + children

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<string>) el) =>
        new(el.Item1, el.Item2, el.Item3.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<HtmlEl>) el) =>
        new(el.Item1, el.Item2, el.Item3, "");

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<(string, string)>) el) =>
        new(el.Item1, el.Item2, el.Item3.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<(string, HtmlEl)>) el) =>
        new(el.Item1, el.Item2, el.Item3.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<(string, HtmlEl[])>) el) =>
        new(el.Item1, el.Item2, el.Item3.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<(string, HtmlAttributes)>) el) =>
        new(el.Item1, el.Item2, el.Item3.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<(string, HtmlAttributes, HtmlEl)>) el) =>
        new(el.Item1, el.Item2, el.Item3.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<(string, HtmlAttributes, HtmlEl[])>) el) =>
        new(el.Item1, el.Item2, el.Item3.Select(s => (HtmlEl)s), "");

    public static implicit operator HtmlEl((string, HtmlAttributes, IEnumerable<(string, HtmlAttributes, string)>) el) =>
        new(el.Item1, el.Item2, el.Item3.Select(s => (HtmlEl)s), "");

    #endregion
}