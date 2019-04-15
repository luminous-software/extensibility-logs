namespace ExtensibilityLogs.Commands
{
    using Luminous.Code.VisualStudio.Commands;
    using Luminous.Code.VisualStudio.Packages;

    internal abstract class OtherCommand : DynamicCommand
    {
        protected OtherCommand(PackageBase package, int id) : base(package, id)
        {
        }

        protected override bool CanExecute
           => base.CanExecute && PackageClass.ToolsOptions.ToolsEnabled;
    }
}