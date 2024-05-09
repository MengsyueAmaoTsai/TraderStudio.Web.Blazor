var solutionFile = "./RichillCapital.TraderStudio.Web.sln";
var outputDirectory = "./publish";
var configuration = Argument("configuration", "Release");
var project = "./RichillCapital.TraderStudio.Web.csproj";

Task("Clean").Does(() =>
{
    DotNetClean(solutionFile);
    CleanDirectory(outputDirectory);
});

Task("Restore").IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetRestore(solutionFile);
    });

Task("Build").IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetBuild(solutionFile, new DotNetBuildSettings()
        {
            Configuration = configuration,
            NoRestore = true,
        });
    });

Task("Test").IsDependentOn("Build")
    .Does(() =>
    {
        DotNetTest(solutionFile, new DotNetTestSettings()
        {
            Configuration = configuration,
            NoBuild = true,
            NoRestore = true,
        });
    });

Task("Publish").IsDependentOn("Test")
    .Does(() =>
    {
        DotNetPublish(solutionFile, new DotNetPublishSettings()
        {
            Configuration = configuration,
            NoBuild = true,
            NoRestore = true,
            OutputDirectory = outputDirectory,
        });
    });

var target = Argument("target", "Publish");

RunTarget(target);