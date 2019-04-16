using System;

namespace ExtensibilityLogs.Options
{
    public static class OptionGuids
    {
        internal const string GeneralDialogPageString = "da6d66ec-edf2-4a86-b201-56267485c482";
        public static Guid GeneralDialogPage = new Guid(GeneralDialogPageString);

        internal const string LogsDialogPageString = "5b42aa24-e633-48e2-9d2e-fbdb0494f36e";
        public static Guid LogsDialogPage = new Guid(LogsDialogPageString);

        internal const string OtherDialogPageString = "edd0f91a-df78-46e0-8479-4897104a127d";
        public static Guid OtherDialogPage = new Guid(OtherDialogPageString);
    }
}