using System;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace ExtensibilityLogs
{
    using Luminous.Code.VisualStudio.Packages;

    using static PackageGuids;
    using static Vsix;

    [InstalledProductRegistration(Name, Description, Version, IconResourceID = 400)]
    [Guid(PackageString)]

    public class PackageClass : AsyncPackageBase
    {
        public PackageClass() : base(PackageCommandSet, Name, Description)
        { }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);

            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }
    }
}