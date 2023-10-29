using System;
using SystemInfo.Processes.WinApi.HAPI;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;

namespace SystemInfo.Processes
{
    public class ListProcesses
    {
        private Process[] processes;

        ParallelOptions parallelOptions = new()
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        public int Length { get; }

        public ListProcesses()
        {

            var processesIds = PSAPI.EnumProcesses();

            var processesHandles = new IntPtr[processesIds.Length];
            Parallel.For(0, processesIds.Length, parallelOptions, index =>
            {
                processesHandles[index] = PTAPI.OpenProcess(PTAPI.DesiredAccess.PROCESS_ALL_ACCESS, true, processesIds[index]);
            });

            var processesName = new string[processesIds.Length];

            Parallel.For(0, processesIds.Length, parallelOptions, index =>
            {
                processesName[index] = PSAPI.GetProcessImageFileName(processesHandles[index]);
            });

            processes = new Process[processesIds.Length];
            Parallel.For(0, processesIds.Length, parallelOptions, index =>
            {
                processes[index] = new Process(processesIds[index], processesHandles[index], processesName[index]);
            });

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
            Parallel.ForEach(processes, parallelOptions, processe =>
            {
                HAPI.CloseHandle(processe.Handle);
            });
        }
    }
}
