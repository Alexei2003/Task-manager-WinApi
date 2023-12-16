using System.Runtime.InteropServices;

namespace SystemInfo.Processes.WinApi.HAPI
{
    public class HandleapiDLL
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        protected static extern bool CloseHandle(IntPtr hObject);
    }
}
