using System.Collections;
using System.ComponentModel.DataAnnotations;
using SystemInfo.Processes.WinApi.HAPI;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;

namespace SystemInfo.Processes
{
    public class ListProcesses : IEnumerable<Process>
    {
        private readonly Process[] processes;

        public int Length { get; }

        public ListProcesses()
        {
            var processesIds = PSAPI.EnumProcesses();

            processes = new Process[processesIds.Length];

            IntPtr processHandle;
            string processName;
            PSAPI.PROCESS_MEMORY_COUNTERS processMemory;

            int indexProcesses = 0;
            for (int indexIds = 0; indexIds < processesIds.Length; indexIds++)
            {
                processHandle = PTAPI.OpenProcess(PTAPI.DesiredAccess.PROCESS_ALL_ACCESS, false, processesIds[indexIds]);
                if (processHandle != IntPtr.Zero)
                {
                    processName = PSAPI.GetProcessImageFileName(processHandle);
                    processMemory = PSAPI.GetProcessMemoryInfo(processHandle);
                    processes[indexProcesses] = new Process(processesIds[indexIds], processHandle, processName, processMemory);
                    indexProcesses++;
                }
            }

            Array.Resize(ref processes, indexProcesses);

            Length = processes.Length;

            processes = processes.OrderBy(p => p.Id).ToArray();
        }

        public Process this[int i]
        {
            get
            {
                return processes[i];
            }
        }

        public IEnumerator<Process> GetEnumerator()
        {
            foreach(var process in processes)
            {
                yield return process;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
