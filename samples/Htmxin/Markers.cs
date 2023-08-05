namespace Htmxin;

public class SampleAttribute : Attribute
{
    public string Path { get; }
    public string Description { get; }

    public SampleAttribute(
        string Path,
        string Description
    )
    {
        this.Path = Path;
        this.Description = Description;
    }
}