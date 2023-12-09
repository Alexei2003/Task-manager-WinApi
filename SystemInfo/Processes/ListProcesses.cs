﻿using System.Collections;
using System.Diagnostics;
using SystemInfo.Processes.WinApi.HAPI;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;
using SystemInfo.Processes.WinApi.THAPI;

namespace SystemInfo.Processes
{
    public class ListProcesses : IEnumerable<Process>
    {
        private readonly Dictionary<uint, Process> processes;

        public int Count { get; }

        public ListProcesses()
        {
            var processesIds = PSAPI.EnumProcesses();

            processes = new Dictionary<uint, Process>();

            IntPtr processHandle;

            for (int indexIds = 0; indexIds < processesIds.Length; indexIds++)
            {
                processHandle = PTAPI.OpenProcess(PTAPI.ProcessDesiredAccess.PROCESS_ALL_ACCESS, false, processesIds[indexIds]);
                if (processHandle != IntPtr.Zero)
                {
                    processes.Add(processesIds[indexIds], new Process(processesIds[indexIds], processHandle));
                }
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
