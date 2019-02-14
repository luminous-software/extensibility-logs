using System;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

using Luminous.Code.VisualStudio.Packages;

namespace ExtensibilityLogs
{
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