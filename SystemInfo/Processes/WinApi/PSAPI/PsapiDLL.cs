using System.Runtime.InteropServices;
using System.Text;

namespace SystemInfo.Processes.WinApi
{
    public class PsapiDLL
    {
        [DllImport("psapi.dll", SetLastError = true)]
        protected static extern bool EnumProcesses(uint[] processIds, uint size, out uint bytesReturned);

        [DllImport("psapi.dll", SetLastError = true)]
        protected static extern uint GetProcessImageFileName(IntPtr hProcess, StringBuilder lpImageFileName, uint nSize);

        [DllImport("psapi.dll", SetLastError = true)]
        protected static extern bool GetProcessMemoryInfo(IntPtr hProcess, out PROCESS_MEMORY_COUNTERS counters, uint cb);

        [StructLayout(LayoutKind.Sequential, Size = 72)]
        public struct PROCESS_MEMORY_COUNTERS
        {
            public uint cb;
            public uint PageFaultCount;
            public uint PeakWorkingSetSize;
            public uint WorkingSetSize;
            public uint QuotaPeakPagedPoolUsage;
            public uint QuotaPagedPoolUsage;
            public uint QuotaPeakNonPagedPoolUsage;
            public uint QuotaNonPagedPoolUsage;
            public uint PagefileUsage;
            public uint PeakPagefileUsage;
        }
    }
}
