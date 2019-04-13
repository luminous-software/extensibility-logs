using Microsoft.VisualStudio.Shell;
using System;
using System.IO;
using System.Linq;
using static System.IO.Path;

namespace ExtensibilityLogs.Commands.Logs
{
    using Luminous.Code.Exceptions.ExceptionExtensions;
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal sealed class ServiceHubLogCommand : LogsCommand
    {
        private static string Path
            => $"{GetTempPath()}\\servicehub\\logs";

        private ServiceHubLogCommand(PackageBase package) : base(package, PackageIds.ServiceHubLogCommand)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new ServiceHubLogCommand(package));

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem()
                .ShowInformation();

        protected override bool CanExecute
            => base.CanExecute && PackageClass.LogsOptions.ServiceHubLogCommandEnabled;

        private static CommandResult ExecuteCommand()
        {
            try
            {
                var di = new DirectoryInfo(Path);
                var files = di?.EnumerateFiles("VsixServiceDiscovery*.log");

                var fi = (
                    from file in files
                    orderby
                        file.LastWriteTime descending
                    select file
                    ).FirstOrDefault();

                return fi != null
                    ? Package?.OpenTextFile(fi.FullName, problem: $"Unable to view '{fi.FullName}'")
                    : new InformationResult("No Service Hub log found");
            }
            catch (Exception ex)
            {
                return new ProblemResult(ex.ExtendedMessage());
            }
        }
    }
}