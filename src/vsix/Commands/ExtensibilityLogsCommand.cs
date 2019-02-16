using System;

namespace ExtensibilityLogs.Commands
{
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal abstract class ExtensibilitiesLogCommand : AsyncDynamicCommand
    {
        protected ExtensibilitiesLogCommand(AsyncPackageBase package, int id) : base(package, id)
        { }
    }
}