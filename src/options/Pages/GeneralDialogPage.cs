﻿using System.ComponentModel;
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

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + ActivityLog)]
        [Description("Opens Visual Studio's activity log in a tab document")]
        public bool ActivityLogCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + DiagnosticLog)]
        [Description("Opens the latest MSBuild's diagnostic failure log in a tab document")]
        public bool DiagnosticLogCommandEnabled { get; set; } = true;

        [Category(H2 + Features)]
        [DisplayName(Enable + Space + PathVariables)]
        [Description("Displays Window's current path variables in a tab document")]
        public bool PathVariablesCommandEnabled { get; set; } = true;
    }
}