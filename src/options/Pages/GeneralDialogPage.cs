using Microsoft.VisualStudio.Shell;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ExtensibilityLogs.Options.Pages
{
    using static Core.Constants;
    using static OptionConstants;
    using static OptionGuids;

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    [Guid(GeneralDialogPageString)]
    public class GeneralDialogPage : DialogPage
    {
        [Category(H1 + ExtensibilityLogs)]
        [DisplayName(Enable + Space + Quote + ExtensibilityLogs + Quote)]
        [Description("Enables/disables the whole set of " + Quote + ExtensibilityLogs + Quote + " features")]
        public bool ExtensibilityLogsEnabled { get; set; } = true;

        [Category(H1 + ExtensibilityLogs)]
        [DisplayName(OptionConstants.ExtensibilityLogsVersion)]
        [Description("The version number of " + Quote + ExtensibilityLogs + Quote + " that's currently installed")]
        public string ExtensibilityLogsVersion { get; } = Vsix.Version;
    }
}