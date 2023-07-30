using System.Text;

namespace HyperTextExpression;

public class PrintHtmlStringBuilder : IPrintHtml
{
    private readonly StringBuilder _sb;

    public PrintHtmlStringBuilder(StringBuilder sb) => _sb = sb;
    public void Write(char c) => _sb.Append(c);
    public void Write(char c, int count) => _sb.Append(c, count);
    public void Write(ReadOnlySpan<char> chars) => _sb.Append(chars);
}