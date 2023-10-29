using System.Diagnostics;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;

namespace SystemInfo.Processes
{
    public class ListProcesses
    {
        private Process[] process;

        public int Length { get; }

        public ListProcesses()
        {
            ParallelOptions parallelOptions = new()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var processesIds = PSAPI.EnumProcesses();

            var processesHandles = new IntPtr[processesIds.Length];

            Parallel.For(0, processesIds.Length, parallelOptions, index =>
            {
                processesHandles[index] = PTAPI.OpenProcess(PTAPI.DesiredAccess.PROCESS_ALL_ACCESS, true, processesIds[index]);
            });

            process = new Process[processesIds.Length];

            Parallel.For(0, processesIds.Length, parallelOptions, index => 
            {
                process[index] = new Process(processesIds[index], processesHandles[index]);
            });

            Length = process.Length;
        }

        public Process this[int i]
        {
            get
            {
                return process[i];
            }
        }
    }
}
