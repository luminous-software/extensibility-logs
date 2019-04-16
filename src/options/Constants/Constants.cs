namespace ExtensibilityLogs.Options
{
    using static Core.Constants;

    public static class Constants
    {
        public const string H1 = "1." + Space;
        public const string H2 = "2." + Space;
        public const string Feature = "Feature";
        public const string Individual = "Individual";
        public const string Features = "Features";
        public const string FeatureSet = "Feature Set";
        public const string Enable = "Enable";
        public const string Enabled = "Enabled";
        public const string EnablesDisables = "Enables/disables";
        public const string EnablesDisablesAll = EnablesDisables + Space + "ALL";

        public const string ExtensibilityLogs = "Extensibility Logs";
        public const string ExtensibilityLogsFeatureSet = ExtensibilityLogs + Space + FeatureSet;
        public const string ExtensibilityLogsVersion = "Version Number";

        public const string ActivityLog = "Activity Log";
        public const string DiagnosticLog = "Diagnostic Failure Log";
        public const string MefErrorLog = "MEF Error Log";
        public const string ServiceHubLog = "Service Hub Log";
        public const string VisualStudioSetupLog = "Visual Studio Setup Log";
        public const string VsixInstallerLog = "VSIX Installer Log";

        public const string EnvironmentVariables = "Environment Variables";
        public const string PathVariables = "Path Variables";
        public const string VisualStudioFolder = "Visual Studio Folder";
    }
}