using Microsoft.VisualStudio.Shell;
using Tasks = System.Threading.Tasks;

namespace ExtensibilityLogs.Commands
{
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal sealed class ActivityLogCommand : ExtensibilitiesLogCommand
    {
        private static string Path
            => $"{Package.UserDataPath}\\ActivityLog.xml";

        private ActivityLogCommand(AsyncPackageBase package)
            : base(package, PackageIds.ActivityLogCommand)
        { }

        public async static Tasks.Task InstantiateAsync(AsyncPackageBase package)
            => await InstantiateAsync(new ActivityLogCommand(package));

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