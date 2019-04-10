using Microsoft.VisualStudio.Shell;
using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;

namespace ExtensibilityLogs.Commands.Logs
{
    internal sealed class MefErrorLogCommand : LogsCommand
    {
        private static string Path
            => $"{Package.UserLocalDataPath}\\ComponentModelCache\\Microsoft.VisualStudio.Default.err";

        private MefErrorLogCommand(PackageBase package) : base(package, PackageIds.MefErrorLogCommand)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new MefErrorLogCommand(package));

        protected override bool CanExecute
            => base.CanExecute && PackageClass.LogsOptions.MefErrorLogCommandEnabled;

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem()
                .ShowInformation();

        private static CommandResult ExecuteCommand()
            => Package?.OpenFile(Path, problem: "No MEF Error log found");
    }
}