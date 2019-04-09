using System;

namespace ExtensibilityLogs.Commands
{
    using Luminous.Code.VisualStudio.Packages;
    using Luminous.Code.VisualStudio.Commands;

    internal abstract class LogsCommand : DynamicCommand
    {
        protected LogsCommand(PackageBase package, int id) : base(package, id)
        {
        }

        protected override bool CanExecute
           => base.CanExecute && PackageClass.LogsOptions.LogsEnabled;
    }
}