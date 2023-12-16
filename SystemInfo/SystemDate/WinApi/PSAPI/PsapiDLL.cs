using System.Runtime.InteropServices;
using System.Text;

namespace SystemInfo.Processes.WinApi
{
    public class PsapiDLL
    {
        protected const int PROCESS_MEMORY_COUNTERS_SIZE = 2 * sizeof(uint) + 8 * sizeof(UInt64);

        [DllImport("psapi.dll", SetLastError = true)]
        protected static extern bool EnumProcesses(uint[] processIds, uint size, out uint bytesReturned);

        [DllImport("psapi.dll", CharSet = CharSet.Auto)]
        protected static extern int GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, StringBuilder baseName, int size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_MEMORY_COUNTERS
        {
            public uint cb;
            public uint PageFaultCount;
            public UInt64 PeakWorkingSetSize;
            public UInt64 WorkingSetSize;
            public UInt64 QuotaPeakPagedPoolUsage;
            public UInt64 QuotaPagedPoolUsage;
            public UInt64 QuotaPeakNonPagedPoolUsage;
            public UInt64 QuotaNonPagedPoolUsage;
            public UInt64 PagefileUsage;
            public UInt64 PeakPagefileUsage;
        }

        [DllImport("psapi.dll", SetLastError = true)]
        protected static extern bool GetProcessMemoryInfo(IntPtr hProcess, out PROCESS_MEMORY_COUNTERS counters, uint cb);
    }
}
