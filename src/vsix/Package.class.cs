using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

using Luminous.Code.VisualStudio.Packages;

namespace ExtensibilityLogs
{
    using Commands;
    using Options.Pages;

    using static Core.Constants;
    using static PackageGuids;
    using static Vsix;

    [InstalledProductRegistration(Name, Description, Version)]
    [Guid(PackageString)]

    [ProvideOptionPage(typeof(GeneralDialogPage), Name, General, 0, 0, supportsAutomation: false)]

    public sealed class PackageClass : PackageBase
    {
        private static GeneralDialogPage _generalOptions;

        public static GeneralDialogPage Options
            => _generalOptions ?? (_generalOptions = GetDialogPage<GeneralDialogPage>());

        public PackageClass() : base(PackageCommandSet, Name, Description)
        { }

        protected override void Initialize()
        {
            base.Initialize();

            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
            ActivityLogCommand.Instantiate(this);
            DiagnosticLogCommand.Instantiate(this);
            MefErrorLogCommand.Instantiate(this);
            PathVariablesCommand.Instantiate(this);
        }
    }
}