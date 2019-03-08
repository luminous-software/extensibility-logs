using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace ExtensibilityLogs.Options
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    [Guid(Guids.GeneralDialogPageString)]
    public class GeneralDialogPage : DialogPage
    {
    }
}