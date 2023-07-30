using System.IO.Pipelines;
using System.Text;

namespace HyperTextExpression.AspNetCore;

public class PrintHtmlPipeWriter : IPrintHtml
{
    private const int UTF8MaxByteLength = 6;
    private readonly PipeWriter _pipeWriter;
    private readonly Encoder _encoder;

    public PrintHtmlPipeWriter(PipeWriter pipeWriter, Encoder encoder)
    {
        _pipeWriter = pipeWriter;
        _encoder = encoder;
    }

    public void Write(char c)
    {
        var destination = _pipeWriter.GetSpan(1);
        destination.Fill((byte)c);
        _pipeWriter.Advance(1);
    }

    public void Write(char c, int count)
    {
        var size = 1 * count;
        var destination = _pipeWriter.GetSpan(size);
        destination.Fill((byte)c);
        _pipeWriter.Advance(size);
    }

    public void Write(ReadOnlySpan<char> source)
    {
        var completed = false;

        while (!completed)
        {
            var destination = _pipeWriter.GetSpan(UTF8MaxByteLength);
            _encoder.Convert(source, destination, flush: true, out var charsUsed, out var bytesUsed, out completed);

            _pipeWriter.Advance(bytesUsed);
            source = source.Slice(charsUsed);
        }
    }
}