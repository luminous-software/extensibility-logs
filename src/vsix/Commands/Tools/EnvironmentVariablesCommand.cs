using Luminous.Code.Exceptions.ExceptionExtensions;
using Luminous.Code.VisualStudio.Commands;
using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections;
using static System.Environment;

namespace ExtensibilityLogs.Commands.Tools
{
    internal sealed class EnvironmentVariablesCommand : OtherCommand
    {
        private EnvironmentVariablesCommand(PackageBase package) : base(package, PackageIds.EnvironmentVariablesCommand)
        { }

        public static void Instantiate(PackageBase package)
            => Instantiate(new EnvironmentVariablesCommand(package));

        protected override bool CanExecute
            => base.CanExecute && PackageClass.ToolsOptions.EnvironmentVariablesCommandEnabled;

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
                ThreadHelper.ThrowIfNotOnUIThread(nameof(EnvironmentVariablesCommand));

                //const string semi_colon = ";";
                //var colonNewline = semi_colon + NewLine;
                var pane = Package?.PackageOutputPane;
                var variables = GetEnvironmentVariableOutput();

                //text += colonNewline;

                var result = Package?.ActivateOutputWindow();
                if (!result.Succeeded)
                    return result;

                pane?.Activate();
                pane?.Clear();
                pane?.OutputString("Environment Variables" + NewLine);
                pane?.OutputString("=====================" + NewLine + NewLine);
                pane?.OutputString(variables);

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ProblemResult(ex.ExtendedMessage());
            }
        }

        private static string GetEnvironmentVariableOutput()
        {

            var result = "";
            var variables = GetEnvironmentVariables(EnvironmentVariableTarget.Process);

            foreach (DictionaryEntry de in variables)
            {
                var key = de.Key.ToString();
                var text = de.Value.ToString();

                switch (key)
                {
                    case "Path":
                    case "PSModulePath":
                    case "DASHLANE_DLL_DIR":
                        continue;


                    default:
                        result += $"{key} = {text}{NewLine}";
                        break;
                }

            }

            return result;
        }
    }
}