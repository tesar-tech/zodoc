namespace Zodoc;

using BlazorStatic;
using YamlDotNet.Serialization;

public class FrontMatterZodoc:IFrontMatter
{ //
    public string Title { get; set; } = "";

    public string Lead { get; set; } = "";

    public DateTime Published { get; set; } = DateTime.Now;

    public List<string> Tags { get; set; } = new();

    public List<string> Prerequisites { get; set; } = new();

    public List<string> Authors { get; set; } = new();
    
    public List<string> DatazooFiles { get; set; } = new();
    
    [YamlIgnore]
    public string? ImgIntroUrl { get; set; } = "";
}

public class ZodocPost : Post<FrontMatterZodoc>
{
    public ZodocPost()
    {
        FrontMatter = new FrontMatterZodoc();
    }
}

