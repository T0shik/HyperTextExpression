using System.Text;

namespace HyperTextExpression;

public static class PrintHtml
{
    public static string ToString(HtmlEl el)
    {
        var sb = new StringBuilder();
        ToStringBuilder(el, sb);
        return sb.ToString();
    }

    public static void ToStringBuilder(HtmlEl el, StringBuilder sb)
    {
        if (el.Name == "html") PrintHtmlDoc(el, sb);
        else PrintHtmlEl(el, sb);
    }

    private static void PrintHtmlEl(HtmlEl el, StringBuilder sb, int indent = 0)
    {
        sb.Append(' ', indent);
        sb.Append('<');
        sb.Append(el.Name);

        if (!Equals(el.Attributes, HtmlConstants.NoAttributes))
            foreach (var (key, value) in el.Attributes)
            {
                sb.Append(' ');
                sb.Append(key);
                if (!string.IsNullOrEmpty(value))
                {
                    sb.Append('=');
                    sb.Append('"');
                    sb.Append(value);
                    sb.Append('"');
                }
            }

        sb.Append('>');

        if (!Equals(el.Children, HtmlConstants.NoChildren))
        {
            if (el.Children is HtmlEl[] arr)
            {
                foreach (var child in arr)
                {
                    sb.Append('\n');
                    PrintHtmlEl(child, sb, indent + 4);
                }
            }
            else
            {
                foreach (var child in el.Children)
                {
                    sb.Append('\n');
                    PrintHtmlEl(child, sb, indent + 4);
                }
            }

            sb.Append('\n');
            sb.Append(' ', indent);
        }
        else if (!string.IsNullOrEmpty(el.Text))
        {
            sb.Append(el.Text);
        }

        sb.Append('<');
        sb.Append('/');
        sb.Append(el.Name);
        sb.Append('>');
    }

    private static void PrintHtmlDoc(HtmlEl el, StringBuilder sb)
    {
        sb.Append("<!DOCTYPE html>\n");
        sb.Append("<html");

        if (!Equals(el.Attributes, HtmlConstants.NoAttributes))
            foreach (var (key, value) in el.Attributes)
            {
                sb.Append(' ');
                sb.Append(key);
                if (!string.IsNullOrEmpty(value))
                {
                    sb.Append('=');
                    sb.Append('"');
                    sb.Append(value);
                    sb.Append('"');
                }
            }

        sb.Append('>');

        if (!Equals(el.Children, HtmlConstants.NoChildren))
        {
            if (el.Children is HtmlEl[] arr)
            {
                foreach (var child in arr)
                {
                    sb.Append('\n');
                    PrintHtmlEl(child, sb, 4);
                }
            }
            else
            {
                foreach (var child in el.Children)
                {
                    sb.Append('\n');
                    PrintHtmlEl(child, sb, 4);
                }
            }

            sb.Append('\n');
        }

        sb.Append("</html>");
    }
}