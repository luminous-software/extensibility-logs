using Microsoft.VisualStudio.Shell;

namespace ExtensibilityLogs.Commands
{
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal sealed class ActivityLogCommand : PackageCommand
    {
        private static string Path
            => $"{Package.UserDataPath}\\ActivityLog.xml";

        private ActivityLogCommand(PackageBase package)
            : base(package, PackageIds.ActivityLogCommand)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new ActivityLogCommand(package));

        protected override bool CanExecute
            => base.CanExecute && PackageClass.Options.ActivityLogCommandEnabled;

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem()
                .ShowInformation();

        private static CommandResult ExecuteCommand()
            => Package?.OpenFileInBrowser(Path, problem: "No activity log found");
    }
}