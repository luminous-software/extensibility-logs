using Luminous.Code.VisualStudio.Packages;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace ExtensibilityLogs
{
    using Commands.Logs;
    using Commands.Tools;
    using Options.Pages;

    using static Core.Constants;
    using static PackageGuids;
    using static Vsix;

    [InstalledProductRegistration(Name, Description, Version)]
    [Guid(PackageString)]

    [ProvideOptionPage(typeof(GeneralDialogPage), Name, General, 0, 0, supportsAutomation: false)]
    [ProvideOptionPage(typeof(LogsDialogPage), Name, Logs, 0, 0, supportsAutomation: false)]
    [ProvideOptionPage(typeof(ToolsDialogPage), Name, Tools, 0, 0, supportsAutomation: false)]

    public sealed class PackageClass : PackageBase
    {
        private static GeneralDialogPage _generalOptions;
        private static LogsDialogPage _logsOptions;
        private static ToolsDialogPage _toolsOptions;

        public static GeneralDialogPage GeneralOptions
            => _generalOptions ?? (_generalOptions = GetDialogPage<GeneralDialogPage>());

        public static LogsDialogPage LogsOptions
            => _logsOptions ?? (_logsOptions = GetDialogPage<LogsDialogPage>());

        public static ToolsDialogPage ToolsOptions
            => _toolsOptions ?? (_toolsOptions = GetDialogPage<ToolsDialogPage>());

        public PackageClass() : base(PackageCommandSet, Name, Description)
        { }

        protected override void Initialize()
        {
            base.Initialize();

            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
            InstantiateLogCommands();
            InstantiateToolCommands();
        }

        private void InstantiateLogCommands()
        {
            ActivityLogCommand.Instantiate(this);
            DiagnosticLogCommand.Instantiate(this);
            MefErrorLogCommand.Instantiate(this);
            VsixInstallerLogCommand.Instantiate(this);
        }

        private void InstantiateToolCommands()
        {
            VisualStudioFolderCommand.Instantiate(this);
            PathVariablesCommand.Instantiate(this);
            EnvironmentVariablesCommand.Instantiate(this);
        }
    }
}