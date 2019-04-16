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
        private const string FeatureSetHeading = H1 + Quote + Other + Quote + Space + FeatureSet;
        private const string IndividualFeaturesHeading = H2 + Individual + Space + Features;

        [Category(FeatureSetHeading)]
        [DisplayName(Enable + Space + Quote + Other + Quote + Space + Features)]
        [Description("Enables/disables the whole set of " + Quote + Other + Quote + " features")]
        public bool OtherEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + VisualStudioFolder + Quote)]
        [Description("Enables/disables the " + Quote + VisualStudioFolder + Quote + " feature")]
        public bool VisualStudioFolderCommandEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + PathVariables + Quote)]
        [Description("Enables/disables the " + Quote + PathVariables + Quote + " feature")]
        public bool PathVariablesCommandEnabled { get; set; } = true;

        [Category(IndividualFeaturesHeading)]
        [DisplayName(Enable + Space + Quote + EnvironmentVariables + Quote)]
        [Description("Enables/disables the " + Quote + EnvironmentVariables + Quote + " feature")]
        public bool EnvironmentVariablesCommandEnabled { get; set; } = true;

        //[Category(H2 + Features)]
        //[DisplayName(Enable + Space + EnvironmentVariables + " Filter")]
        //[Description("Environmental variables whose key is specified here is filtered out of the variables")]
        //public Collection<string> EnvironmentVariablesFilter { get; set; }
    }
}