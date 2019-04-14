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
        [Category(H1 + Logs + Space + FeatureSet)]
        [DisplayName(Enable + Space + Logs)]
        [Description("Allows the whole set of " + Logs + " features to be turned off together")]
        public bool LogsEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + ActivityLog)]
        [Description("Opens Visual Studio's " + ActivityLog + " in a tab document")]
        public bool ActivityLogCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + DiagnosticLog)]
        [Description("Opens the latest MSBuild's diagnostic failure log in a tab document")]
        public bool DiagnosticLogCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + MefErrorLog)]
        [Description("Opens Visual Studio's " + MefErrorLog + " in a tab document")]
        public bool MefErrorLogCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + ServiceHubLog)]
        [Description("Opens the latest service hub log in a tab document")]
        public bool ServiceHubLogCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + VisualStudioSetupLog)]
        [Description("Opens the latest " + VisualStudioSetupLog + " in a tab document")]
        public bool VisualStudioSetupLogCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + VsixInstallerLog)]
        [Description("Opens Visual Studio's latest " + VsixInstallerLog + " in a tab document")]
        public bool VsixInstallerLogCommandEnabled { get; set; } = true;
    }
}