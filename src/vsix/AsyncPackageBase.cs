using System;
using System.Threading;
using System.Threading.Tasks;
using EnvDTE;
using EnvDTE80;
using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

using static Microsoft.VisualStudio.Shell.Interop.__VSPROPID;

namespace Luminous.Code.VisualStudio.Packages
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    public class AsyncPackageBase : AsyncPackage
    {
        protected DTE2 Dte { get; private set; }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            Dte = GetDte();
        }

        public static DTE2 GetDte()
            => GetGlobalService<_DTE, DTE2>();

        public static TTarget GetGlobalService<TSource, TTarget>()
            where TTarget : class
            => (GetGlobalService(typeof(TSource)) as TTarget);

        public T GetService<T>()
            where T : class
            => (GetService(typeof(T)) as T);

        public TTarget GetService<TSource, TTarget>()
            where TSource : class
            where TTarget : class
            => GetService(typeof(TSource)) as TTarget;
    }
}