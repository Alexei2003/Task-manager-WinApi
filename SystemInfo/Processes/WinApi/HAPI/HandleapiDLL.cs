using System.Runtime.InteropServices;

namespace SystemInfo.Processes.WinApi.HAPI
{
    public class HandleapiDLL
    {
        [DllImport("handleapi.dll")]
        protected static extern bool CloseHandle(IntPtr hObject);
    }
}
