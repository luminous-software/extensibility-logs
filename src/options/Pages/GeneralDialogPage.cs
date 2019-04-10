using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace ExtensibilityLogs.Options.Pages
{
    using static Core.Constants;
    using static Guids;
    using static Constants;

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    [Guid(GeneralDialogPageString)]
    public class GeneralDialogPage : DialogPage
    {
        [Category(H1 + ExtensibilityLogs)]
        [DisplayName(Enable + Space + ExtensibilityLogs)]
        [Description("Allows the whole set of " + ExtensibilityLogs + " features to be turned off together")]
        public bool ExtensibilityLogsEnabled { get; set; } = true;

        [Category(H1 + ExtensibilityLogs)]
        [DisplayName(Constants.ExtensibilityLogsVersion)]
        [Description("Installed " + ExtensibilityLogs + " version")]
        public string ExtensibilityLogsVersion { get; } = Vsix.Version;
    }
}