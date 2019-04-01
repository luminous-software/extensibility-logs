﻿using System;
using Microsoft.VisualStudio.Shell;
using Luminous.Code.Exceptions.ExceptionExtensions;
using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;

using static System.Environment;

namespace ExtensibilityLogs.Commands
{
    internal sealed class PathVariablesCommand : PackageCommand
    {
        private PathVariablesCommand(PackageBase package) : base(package, PackageIds.PathVariablesCommand)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new PathVariablesCommand(package));

        protected override bool CanExecute
            => base.CanExecute && PackageClass.Options.PathVariablesCommandEnabled;

        protected override void OnExecute(OleMenuCommand command)
#pragma warning disable VSTHRD010 // Invoke single-threaded types on Main thread
            => ExecuteCommand()
                .ShowProblem()
                .ShowInformation();
#pragma warning restore VSTHRD010 // Invoke single-threaded types on Main thread

        private static CommandResult ExecuteCommand()
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread(nameof(ExecuteCommand));

                const string semi_colon = ";";
                var pane = Package?.PackageOutputPane;
                var colonNewline = semi_colon + NewLine;
                var expanded = ExpandEnvironmentVariables("%path%");
                var text = expanded.Replace(semi_colon, colonNewline);

                text += colonNewline;

                var result = Package?.ActivateOutputWindow();
                if (!result.Succeeded)
                    return result;

                pane?.Activate();
                pane?.Clear();
                pane?.OutputString("Path Variables" + NewLine);
                pane?.OutputString("==============" + NewLine + NewLine);
                pane?.OutputString(text);

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ProblemResult(ex.ExtendedMessage());
            }
        }
    }
}