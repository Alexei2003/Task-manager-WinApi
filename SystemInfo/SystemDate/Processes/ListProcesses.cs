using System.Collections;
using SystemInfo.Processes.WinApi.HAPI;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;
using SystemInfo.Processes.WinApi.THAPI;

namespace SystemInfo.SystemDate.Processes
{
    public class ListProcesses : IEnumerable<Process>
    {
        private readonly Dictionary<uint, Process> processes;

        public int Count { get; }

        private struct ProcessTime
        {
            public ulong ProcessTime1;
            public ulong ProcessTime2;
        }
        public ListProcesses()
        {
            var processesIds = PSAPI.EnumProcesses();

            processes = new Dictionary<uint, Process>();

            if (processesIds != null)
            {
                // Получение Handles
                nint processHandle;
                foreach (uint indexIds in processesIds)
                {
                    processHandle = PTAPI.OpenProcess(PTAPI.ProcessDesiredAccess.PROCESS_ALL_ACCESS, false, indexIds);
                    if (processHandle != nint.Zero)
                    {
                        processes.Add(indexIds, new Process(indexIds, processHandle));
                    }
                }

                var handleProcessSnap = THAPI.CreateToolhelp32Snapshot(THAPI.Flag.TH32CS_SNAPTHREAD, 0);

                // Подсчет потоков
                for (var threadEntry32 = THAPI.Thread32First(handleProcessSnap); threadEntry32 != null; threadEntry32 = THAPI.Thread32Next(handleProcessSnap))
                {
                    if (processes.TryGetValue(threadEntry32.Value.th32OwnerProcessID, out Process process))
                    {
                        process.IncrementThreadCount();
                    }

                }

                var processesTime = new ProcessTime[processes.Count];

                // Подсчет 1вого системного времени процесса
                var systemTime1 = PTAPI.GetSystemTimesAll();

                // Подсчет 1вого времени процесса
                int i = 0;
                foreach (Process process in processes.Values)
                {
                    processesTime[i].ProcessTime1 = PTAPI.GetProcessTimesUse(process.Handle);
                    i++;
                }

                Thread.Sleep(100);

                // Подсчет 2вого системного времени процесса
                var systemTime2 = PTAPI.GetSystemTimesAll();

                // Подсчет 2вого времени процесса
                i = 0;
                foreach (Process process in processes.Values)
                {
                    processesTime[i].ProcessTime2 = PTAPI.GetProcessTimesUse(process.Handle);
                    i++;
                }

                // Подсчет загрузки цп процессами
                var systemTimeDelta = systemTime2 - systemTime1;

                i = 0;
                foreach (var process in processes)
                {
                    var delta = (processesTime[i].ProcessTime2 - processesTime[i].ProcessTime1) * 1.0;
                    process.Value.SetCpu(Convert.ToUInt64(delta / systemTimeDelta * 100));
                    i++;
                }


                HAPI.CloseHandle(handleProcessSnap);
            }

            Count = processes.Count;
        }

        public void KillProcessTree(uint processId)
        {
            var handleProcessSnap = THAPI.CreateToolhelp32Snapshot(THAPI.Flag.TH32CS_SNAPPROCESS, 0);

            uint rootId = processId;
            bool finish;

            // Полученние самого главного родителя
            do
            {
                finish = true;
                for (var processEntry32 = THAPI.Process32First(handleProcessSnap); processEntry32 != null; processEntry32 = THAPI.Process32Next(handleProcessSnap))
                {
                    if (processEntry32.Value.th32ProcessID == rootId)
                    {
                        if (processEntry32.Value.th32ParentProcessID != 0 && processes.ContainsKey(processEntry32.Value.th32ParentProcessID) && processes[processEntry32.Value.th32ParentProcessID].Name == processes[processId].Name)
                        {
                            rootId = processEntry32.Value.th32ParentProcessID;
                            finish = false;
                        }
                        break;
                    }
                }
            } while (!finish);

            processes[rootId].KillProcess();

            HAPI.CloseHandle(handleProcessSnap);
        }

        public Process this[uint processId]
        {
            get
            {
                return processes[processId];
            }
        }

        public IEnumerator<Process> GetEnumerator()
        {
            foreach (var process in processes.Values)
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
