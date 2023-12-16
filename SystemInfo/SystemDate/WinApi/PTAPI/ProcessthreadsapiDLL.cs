using System.Runtime.InteropServices;
using static SystemInfo.Processes.WinApi.PTAPI.PTAPI;

namespace SystemInfo.Processes.WinApi.PTAPI
{
    public class ProcessthreadsapiDLL
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        protected static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        protected static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);


        [DllImport("advapi32.dll", SetLastError = true)]
        protected static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_USER
        {
            public SID_AND_ATTRIBUTES User;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public int Attributes;
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        protected static extern bool GetTokenInformation(IntPtr TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass, IntPtr TokenInformation, uint TokenInformationLength, out uint ReturnLength);

        [DllImport("kernel32.dll")]
        protected static extern uint GetCurrentProcessId();

        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        };

        [DllImport("kernel32.dll")]
        public static extern bool GetProcessTimes(IntPtr hProcess, out FILETIME lpCreationTime,out FILETIME lpExitTime, out FILETIME lpKernelTime, out FILETIME lpUserTime);

        [DllImport("kernel32.dll")]
        public static extern bool GetSystemTimes(out FILETIME lpIdleTime, out FILETIME lpKernelTime,out FILETIME lpUserTime);
    }
}
