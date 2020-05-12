using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug'")]
    readonly Configuration Configuration = Configuration.Debug;

    [Solution]
    readonly Solution Solution;
    [GitRepository]
    readonly GitRepository GitRepository;
    [GitVersion]
    readonly GitVersion GitVersion;

    AbsolutePath SourceDirectory => RootDirectory / "src";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetAssemblyVersion(GitVersion.AssemblySemVer)
                .SetFileVersion(GitVersion.AssemblySemFileVer)
                .SetInformationalVersion(GitVersion.InformationalVersion)
                .EnableNoRestore());
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoBuild());
        });

    Target CI => _ => _
        .DependsOn(Clean, Compile, Test);

    [PathExecutable("java")]
    readonly Tool Java;
    AbsolutePath Antlr => RootDirectory / "antlr" / "antlr-4.8-complete.jar";
    AbsolutePath Grammar => RootDirectory / "grammar" / "OrdinaryForm.g4";
    AbsolutePath ParserPath => SourceDirectory / "OFP.Library" / "Parser" / "Generated";
    const string ParserNamespace = "OFP.Parser.Generated";

    Target Regen => _ => _
        .Executes(() =>
        {
            var env = new Dictionary<string, string>
            {
                ["CLASSPATH"] = Antlr,
            };

            var args = new[]
            {
                "-jar", Antlr,
                "-o", ParserPath,
                "-listener",
                "-package", ParserNamespace,
                "-Dlanguage=CSharp",
                Path.GetFileName(Grammar),
            };

            Java(
                args.Select(x => x.DoubleQuoteIfNeeded()).JoinSpace(),
                Grammar.Parent,
                env);
        });
}
