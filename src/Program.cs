using BlazorStatic;
using Microsoft.Extensions.FileProviders;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Zodoc;
using Zodoc.Components;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseStaticWebAssets();

builder.Services.AddBlazorStaticService(opt => {
        opt.SuppressFileGeneration = false;
        opt.IgnoredPathsOnContentCopy.AddRange(new[] { "app.css" });//pre-build version for tailwind
        opt.FrontMatterDeserializer = new DeserializerBuilder()
            .WithTypeConverter(new SingleOrArrayConverter<List<string>>())
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
    }
    )
    .AddBlogService<FrontMatterZodoc>(opt => {
        opt.ContentPath = "Content/Blog/en";
        opt.MediaFolderRelativeToContentPath = "../media";
        opt.AfterBlogParsedAndAddedAction = () => {
            const string path = "Content/Blog/media/imgs_intro";
            //Taking care of intro images
            var extensions = new[] { "*.jpg", "*.png", "*.gif" };
            var imageFiles = extensions.SelectMany(ext => Directory.GetFiles(path, ext));
            var imagesIntro = imageFiles
                .ToDictionary(x=>Path.GetFileNameWithoutExtension(x), Path.GetFileName);


            foreach (Post<FrontMatterZodoc> blogPost in opt.Posts)
            {
                if (imagesIntro.TryGetValue(blogPost.FileNameNoExtension, out var imagePath))
                {
                    blogPost.FrontMatter.ImgIntroUrl = $"{path}/{imagePath ?? "no_image.png"}";
                }
                else
                {
                    Console.WriteLine($"Intro image not found for post {blogPost.FileNameNoExtension} in {path}. Using default image.");
                    blogPost.FrontMatter.ImgIntroUrl =  $"{path}/no_image.png";
                }
            }
        };



    });


// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),
    "Content","media")),
    RequestPath = "/Content/media"
});
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.UseBlog<FrontMatterZodoc>();
app.UseBlazorStaticGenerator(shutdownApp: !app.Environment.IsDevelopment());

app.Run();

public static class WebsiteKeys
{
    public const string BlogPostStorageAddress = "https://github.com/tesar-tech/zodoc/tree/master/src/Content/Blog/";
    public const string GitHubRepo = "https://github.com/tesar-tech/zodoc/";
}

