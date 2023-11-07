using SystemInfo.Processes.WinApi.HAPI;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;

namespace SystemInfo.Processes
{
    public class Process
    {
        public uint Id { get; }
        public IntPtr Handle { get; }
        public string Name { get; }
        public string FilePath { get; }
        public string Description { get; }

        public string UserName { get; }
        public int Cpu { get; }
        public int CountThreads { get; }
        public PSAPI.PROCESS_MEMORY_COUNTERS Memory { get; }


        public Process(uint id, IntPtr handle, string name, PSAPI.PROCESS_MEMORY_COUNTERS memory)
        {
            Id = id;
            Handle = handle;

            var subStr = name.Split("\\");
            FilePath = "";
            for (int i = 0; i < subStr.Length - 1; i++)
            {
                FilePath += "\\" + subStr[i];
            }

            Name = subStr.Last();

            Memory = memory;
        }

        public void KillProcess()
        {
            PTAPI.TerminateProcess(Handle, 0);
            HAPI.CloseHandle(Handle);
        }
    }
}
