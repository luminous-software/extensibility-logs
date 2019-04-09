using System;

namespace ExtensibilityLogs.Commands
{
    using Luminous.Code.VisualStudio.Packages;
    using Luminous.Code.VisualStudio.Commands;

    internal abstract class PackageCommand : DynamicCommand
    {
        protected PackageCommand(PackageBase package, int id) : base(package, id)
        {
        }

        protected override bool CanExecute
           => PackageClass.GeneralOptions.ExtensibilityLogsEnabled;
    }
}