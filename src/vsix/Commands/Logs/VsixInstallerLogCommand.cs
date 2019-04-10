using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.Shell;

using static System.IO.Path;

namespace ExtensibilityLogs.Commands.Logs
{
    using Luminous.Code.Exceptions.ExceptionExtensions;
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    using static ExtensibilityLogs.Options.Constants;

    internal sealed class VsixInstallerLogCommand : LogsCommand
    {
        private static int CommandId
            => PackageIds.VsixInstallerLogCommand;

        private static string Path
            => $"{GetTempPath()}";

        private VsixInstallerLogCommand(PackageBase package) : base(package, CommandId)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new VsixInstallerLogCommand(package));

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem()
                .ShowInformation();

        protected override bool CanExecute
            => base.CanExecute && PackageClass.LogsOptions.VsixInstallerLogCommandEnabled;

        private static CommandResult ExecuteCommand()
        {
            try
            {
                var di = new DirectoryInfo(Path);
                var files = di?.EnumerateFiles("dd_VSIXInstaller_*.log");

                var fi = (
                    from file in files
                    orderby
                        file.CreationTime descending
                    select file
                    ).FirstOrDefault();

                return fi != null
                    ? Package?.OpenFile(fi.FullName, problem: $"Unable to view '{fi.FullName}'")
                    : new InformationResult($"No {VsixInstallerLog} found");
            }
            catch (Exception ex)
            {
                return new ProblemResult(ex.ExtendedMessage());
            }
        }
    }
}