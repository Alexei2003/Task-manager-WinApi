using System.Runtime.InteropServices;

namespace SystemInfo.Processes.WinApi.PTAPI
{
    public class ProcessthreadsapiDLL
    {

        [DllImport("kernel32.dll")]
        protected static extern IntPtr OpenProcess(long dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
    }
}
