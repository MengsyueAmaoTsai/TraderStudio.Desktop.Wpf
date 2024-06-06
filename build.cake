var solution = "./RichillCapital.TraderStudio.Desktop.sln";
var project = "./RichillCapital.TraderStudio.Desktop.csproj";
var buildConfiguration = Argument("configuration", "Release");
var publishDirectory = "./publish";

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(publishDirectory);
        CleanDirectory("./bin");
        CleanDirectory("./obj");
    });

Task("Restore")
    .Does(() =>
    {
        DotNetRestore(solution);
    });

Task("Build")
    .Does(() =>
    {
        DotNetBuild(
            project,
            new DotNetBuildSettings
            {
                Configuration = buildConfiguration,
                NoRestore = true,
            });
    });

Task("Test")
    .Does(() =>
    {
    });


Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test");

var target = Argument("target", "Default");
RunTarget(target);