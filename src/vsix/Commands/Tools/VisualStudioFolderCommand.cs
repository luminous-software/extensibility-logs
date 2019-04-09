using Microsoft.VisualStudio.Shell;
using System.Diagnostics;

namespace ExtensibilityLogs.Commands.Tools
{
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal sealed class VisualStudioFolderCommand : ToolsCommand
    {
        private static string Path
            => $"{Package.UserDataPath}";

        private VisualStudioFolderCommand(PackageBase package)
            : base(package, PackageIds.VisualStudioFolderCommand)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new VisualStudioFolderCommand(package));

        protected override bool CanExecute
            => base.CanExecute && PackageClass.ToolsOptions.VisualStudioFolderCommandEnabled;

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem()
                .ShowInformation();

        private static CommandResult ExecuteCommand()
            => Package?.OpenFolder(Path, problem: "Visual Studio folder not found");
    }
}