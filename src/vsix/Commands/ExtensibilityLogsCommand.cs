using System;

namespace ExtensibilityLogs.Commands
{
    using Luminous.Code.VisualStudio.Packages;
    using Luminous.Code.VisualStudio.Commands;

    using Options;

    internal abstract class ExtensibilitiesLogCommand : AsyncDynamicCommand, IDisposable
    {
        protected ExtensibilitiesLogCommand(AsyncPackageBase package, int id) : base(package, id)
        {

        }

        protected override bool CanExecute
           => PackageClass.Options.ExtensibilityLogsEnabled;
    }
}