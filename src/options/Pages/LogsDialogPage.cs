using Microsoft.VisualStudio.Shell;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ExtensibilityLogs.Options.Pages
{
    using static Constants;
    using static Core.Constants;
    using static Guids;

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    [Guid(LogsDialogPageString)]
    public class LogsDialogPage : DialogPage
    {
        private const string FeatureSetHeading = H1 + Quote + Logs + Quote + Space + FeatureSet;
        private const string IndividualFeaturesHeading = H2 + Individual + Space + Features;

        [Category(FeatureSetHeading)]
        [DisplayName(Enable + Space + Quote + Logs + Quote + Space + Features)]
        [Description("Enables/disables the whole set of " + Quote + Logs + Quote + " features")]
        public bool LogsEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + ActivityLog + Quote)]
        [Description("Enables/disables the " + Quote + ActivityLog + Quote + " feature")]
        public bool ActivityLogCommandEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + DiagnosticLog + Quote)]
        [Description("Enables/disables the " + Quote + DiagnosticLog + Quote + " feature")]
        public bool DiagnosticLogCommandEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + MefErrorLog + Quote)]
        [Description("Enables/disables the " + Quote + MefErrorLog + Quote + " feature")]
        public bool MefErrorLogCommandEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + ServiceHubLog + Quote)]
        [Description("Enables/disables the " + Quote + ServiceHubLog + Quote + " feature")]
        public bool ServiceHubLogCommandEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + VisualStudioSetupLog + Quote)]
        [Description("Enables/disables the " + Quote + VisualStudioSetupLog + Quote + " feature")]
        public bool VisualStudioSetupLogCommandEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + VsixInstallerLog + Quote)]
        [Description("Enables/disables the " + Quote + VsixInstallerLog + Quote + " feature")]
        public bool VsixInstallerLogCommandEnabled { get; set; } = true;
    }
}