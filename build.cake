var solution = "./RichillCapital.TraderStudio.Desktop.sln";
var buildConfiguration = Argument("configuration", "Release");
var publishDirectory = "./publish";

Task("Clean")
    .Does(() =>
    {
        DotNetClean(solution);
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
            solution,
            new DotNetBuildSettings
            {
                Configuration = buildConfiguration,
                NoRestore = true,
            });
    });

Task("Test")
    .Does(() =>
    {
        DotNetTest(
            solution,
            new DotNetTestSettings
            {
                Configuration = buildConfiguration,
                NoBuild = true,
                NoRestore = true,
            });
    });

Task("Publish")
    .Does(() =>
    {
        CleanDirectory(publishDirectory);

        DotNetPublish(
            solution,
            new DotNetPublishSettings
            {
                Configuration = buildConfiguration,
                NoRestore = true,
                NoBuild = true,
                OutputDirectory = publishDirectory,
            });
    });

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Publish");

var target = Argument("target", "Default");
RunTarget(target);