using System.Text;

namespace SystemInfo.Processes.WinApi.PSAPI
{
    public class PSAPI : PsapiDLL
    {
        /// <summary>
        /// Извлекает идентификатор процесса для каждого объекта процесса в системе.
        /// </summary>
        public static uint[] EnumProcesses()
        {
            const uint COUNT_PROCESS = 100000;

            var result = new uint[COUNT_PROCESS];

            if (!PsapiDLL.EnumProcesses(result, COUNT_PROCESS, out uint realCountProcess))
            {
                return null;
            }
            realCountProcess /= sizeof(uint);

            if (COUNT_PROCESS == realCountProcess)
            {
                return null;
            }

            Array.Resize<uint>(ref result, Convert.ToInt32(realCountProcess));

            return result;
        }

        /// <summary>
        /// Извлекает идентификатор процесса для каждого объекта процесса в системе.
        /// </summary>
        public static string GetProcessImageFileName(IntPtr processHandle)
        {
            const int SIZE_STRING = 1024;

            StringBuilder buffStr = new StringBuilder(SIZE_STRING);

            PsapiDLL.GetProcessImageFileName(processHandle, buffStr, SIZE_STRING);

            var result = buffStr.ToString();

            return result;
        }

        public static PROCESS_MEMORY_COUNTERS GetProcessMemoryInfo(IntPtr processHandle)
        {
            PsapiDLL.GetProcessMemoryInfo(processHandle, out PROCESS_MEMORY_COUNTERS processMemoryCounters, 72);

            return  processMemoryCounters;
        }
    }
}
