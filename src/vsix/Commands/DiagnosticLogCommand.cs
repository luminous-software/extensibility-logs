﻿using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.Shell;

using static System.IO.Path;

namespace ExtensibilityLogs.Commands
{
    using Luminous.Code.Exceptions.ExceptionExtensions;
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    using static Luminous.Code.VisualStudio.Commands.CommandKeys;

    internal sealed class DiagnosticLogCommand : PackageCommand
    {
        private static int CommandId
            => PackageIds.DiagnosticLogCommand;

        private DiagnosticLogCommand(PackageBase package) : base(package, CommandId)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new DiagnosticLogCommand(package));

        protected override void OnExecute(OleMenuCommand command)
            => ExecuteCommand()
                .ShowProblem()
                .ShowInformation();

        protected override bool CanExecute
            => base.CanExecute && PackageClass.Options.DiagnosticLogCommandEnabled;

        private static CommandResult ExecuteCommand()
        {
            try
            {
                var path = $"{GetTempPath()}";
                var di = new DirectoryInfo(path);
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