using System.Runtime.InteropServices;

namespace SystemInfo.Processes.WinApi.PTAPI
{
    public class ProcessthreadsapiDLL
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        protected static extern IntPtr OpenProcess(long dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        protected static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);
    }
}
