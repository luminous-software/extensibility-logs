using System;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Tasks = System.Threading.Tasks;

using Luminous.Code.VisualStudio.Packages;

namespace ExtensibilityLogs
{
    using Commands;
    using Options;

    using static Core.Constants;
    using static PackageGuids;
    using static Vsix;

    [InstalledProductRegistration(Name, Description, Version)]
    [Guid(PackageString)]

    [ProvideOptionPage(typeof(GeneralDialogPage), Name, General, 0, 0, supportsAutomation: false)]

    public class PackageClass : AsyncPackageBase
    {
        private static GeneralDialogPage _generalOptions;

        public static GeneralDialogPage Options
            => _generalOptions ?? (_generalOptions = GetDialogPage<GeneralDialogPage>());

        public PackageClass() : base(PackageCommandSet, Name, Description)
        { }

        protected override async Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);

            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
        }
    }
}