using System.Text;

namespace HyperTextExpression;

public interface IPrintHtml
{
    void Write(char c);
    void Write(char c, int count);
    void Write(ReadOnlySpan<char> chars);

    public static string ToString(HtmlEl el)
    {
        var sb = new StringBuilder();
        To(el, new PrintHtmlStringBuilder(sb));
        return sb.ToString();
    }

    public static void To(HtmlEl el, IPrintHtml print)
    {
        if (el.Name == "html") PrintHtmlDoc(el, print);
        else PrintHtmlEl(el, print);
    }

    private static void PrintHtmlEl(HtmlEl el, IPrintHtml print, int indent = 0)
    {
        print.Write(' ', indent);
        print.Write('<');
        print.Write(el.Name);

        if (!Equals(el.Attributes, HtmlConstants.NoAttributes))
            foreach (var (key, value) in el.Attributes)
            {
                print.Write(' ');
                print.Write(key);
                if (!string.IsNullOrEmpty(value))
                {
                    print.Write('=');
                    print.Write('"');
                    print.Write(value);
                    print.Write('"');
                }
            }

        print.Write('>');

        if (!Equals(el.Children, HtmlConstants.NoChildren))
        {
            if (el.Children is HtmlEl[] arr)
            {
                foreach (var child in arr)
                {
                    print.Write('\n');
                    PrintHtmlEl(child, print, indent + 4);
                }
            }
            else
            {
                foreach (var child in el.Children)
                {
                    print.Write('\n');
                    PrintHtmlEl(child, print, indent + 4);
                }
            }

            print.Write('\n');
            print.Write(' ', indent);
        }
        else if (!string.IsNullOrEmpty(el.Text))
        {
            print.Write(el.Text);
        }

        print.Write('<');
        print.Write('/');
        print.Write(el.Name);
        print.Write('>');
    }

    private static void PrintHtmlDoc(HtmlEl el, IPrintHtml print)
    {
        print.Write("<!DOCTYPE html>\n");
        print.Write("<html");

        if (!Equals(el.Attributes, HtmlConstants.NoAttributes))
            foreach (var (key, value) in el.Attributes)
            {
                print.Write(' ');
                print.Write(key);
                if (!string.IsNullOrEmpty(value))
                {
                    print.Write('=');
                    print.Write('"');
                    print.Write(value);
                    print.Write('"');
                }
            }

        print.Write('>');

        if (!Equals(el.Children, HtmlConstants.NoChildren))
        {
            if (el.Children is HtmlEl[] arr)
            {
                foreach (var child in arr)
                {
                    print.Write('\n');
                    PrintHtmlEl(child, print, 4);
                }
            }
            else
            {
                foreach (var child in el.Children)
                {
                    print.Write('\n');
                    PrintHtmlEl(child, print, 4);
                }
            }

            print.Write('\n');
        }

        print.Write("</html>");
    }
}