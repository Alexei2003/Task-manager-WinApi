using System;
using System.Diagnostics;
using SystemInfo.Processes.WinApi.HAPI;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;

namespace SystemInfo.Processes
{
    public class ListProcesses
    {
        private Process[] processes;

        public int Length { get; }

        public ListProcesses()
        {
            var processesIds = PSAPI.EnumProcesses();

            processes = new Process[processesIds.Length];

            IntPtr processHandle;
            string processName;

            int indexProcesses = 0;
            for (int indexIds = 0; indexIds < processesIds.Length; indexIds++)
            {
                processHandle = PTAPI.OpenProcess(PTAPI.DesiredAccess.PROCESS_ALL_ACCESS, true, processesIds[indexIds]);
                if (processHandle != IntPtr.Zero)
                {
                    processName = PSAPI.GetProcessImageFileName(processHandle);
                    processes[indexProcesses] = new Process(processesIds[indexIds], processHandle, processName);
                    indexProcesses++;
                }
            };

            Array.Resize(ref processes, indexProcesses);

            Length = processes.Length;
        }

        public Process this[int i]
        {
            get
            {
                return processes[i];
            }
        }

        ~ListProcesses()
        {
            foreach(var process in processes) 
            { 
                HAPI.CloseHandle(process.Handle);
            };
        }
    }
}
