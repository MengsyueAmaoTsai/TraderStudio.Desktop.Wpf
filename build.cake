var solution = "./RichillCapital.TraderStudio.Desktop.sln";
var buildConfiguration = Argument("configuration", "Release");
var publishDirectory = "./publish";

Task("Clean")
    .Does(() =>
    {
        // DotNetClean(solution);
    });

Task("Restore")
    .Does(() =>
    {
        DotNetRestore(solution);
    });

Task("Build")
    .Does(() =>
    {
        // Build WPF project
        var wpfProject = "./RichillCapital.TraderStudio.Desktop.csproj";

        DotNetBuild(
            wpfProject,
            new DotNetBuildSettings
            {
                Configuration = buildConfiguration,
                NoRestore = true,
            });

        // Build Packaging project use MSBuild
    });

Task("Test")
    .Does(() =>
    {
    });

Task("Publish")
    .Does(() =>
    {
    });

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Publish");

var target = Argument("target", "Default");
RunTarget(target);