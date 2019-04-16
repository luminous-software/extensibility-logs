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
    [Guid(OtherDialogPageString)]
    public class OtherDialogPage : DialogPage
    {
        [Category(H1 + Other + Space + FeatureSet)]
        [DisplayName(Enable + Space + Other)]
        [Description("Allows the whole set of " + Other + " features to be turned off together")]
        public bool OtherEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + VisualStudioFolder)]
        [Description("Opens the current Visual Studio instance's folder")]
        public bool VisualStudioFolderCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + PathVariables)]
        [Description("Displays Window's current path variables in a tab document")]
        public bool PathVariablesCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + EnvironmentVariables)]
        [Description("Displays Window's current environment variables in a tab document")]
        public bool EnvironmentVariablesCommandEnabled { get; set; } = true;

        //[Category(H2 + Features)]
        //[DisplayName(Enable + Space + EnvironmentVariables + " Filter")]
        //[Description("Environmental variables whose key is specified here is filtered out of the variables")]
        //public Collection<string> EnvironmentVariablesFilter { get; set; }
    }
}