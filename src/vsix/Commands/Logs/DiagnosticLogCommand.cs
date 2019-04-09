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

    internal sealed class DiagnosticLogCommand : LogsCommand
    {
        private static string Path
            => $"{GetTempPath()}";

        private DiagnosticLogCommand(PackageBase package) : base(package, PackageIds.DiagnosticLogCommand)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new DiagnosticLogCommand(package));

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem()
                .ShowInformation();

        protected override bool CanExecute
            => base.CanExecute && PackageClass.LogsOptions.DiagnosticLogCommandEnabled;

        private static CommandResult ExecuteCommand()
        {
            try
            {
                var di = new DirectoryInfo(Path);
                var files = di?.EnumerateFiles("*.failure.txt");

                var fi = (
                    from file in files
                    orderby
                        file.CreationTime descending
                    select file
                    ).FirstOrDefault();

                return fi != null
                    ? Package?.OpenTextFile(fi.FullName, problem: $"Unable to view '{fi.FullName}'")
                    : new InformationResult("No diagnostic failure log found");
            }
            catch (Exception ex)
            {
                return new ProblemResult(ex.ExtendedMessage());
            }
        }
    }
}