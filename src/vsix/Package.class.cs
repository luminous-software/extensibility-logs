using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace ExtensibilityLogs
{
    using Luminous.Code.VisualStudio.Packages;

    public class PackageClass : AsyncPackageBase
    {
        public PackageClass() : base()
        { }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

        }
    }
}