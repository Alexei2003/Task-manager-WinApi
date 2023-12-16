using System.Runtime.InteropServices;
using System.Security.Principal;
using SystemInfo.Processes.WinApi.HAPI;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;
using static SystemInfo.Processes.WinApi.PTAPI.ProcessthreadsapiDLL;

namespace SystemInfo.SystemDate.Processes
{
    public class Process
    {
        public uint Id { get; }
        public nint Handle { get; }
        public string Name { get; }
        public string FilePath { get; }
        public string UserName { get; }
        public uint Cpu { get; private set; }
        public int CountThreads { get; private set; } = 0;
        public SystemInfo.Processes.WinApi.PsapiDLL.PROCESS_MEMORY_COUNTERS Memory { get; }


        public Process(uint id, nint handle)
        {
            Id = id;
            Handle = handle;

            var name = PSAPI.GetModuleFileNameEx(Handle);

            var subStr = name.Split("\\");
            FilePath = "";
            for (int i = 0; i < subStr.Length - 1; i++)
            {
                FilePath += "\\" + subStr[i];
            }

            Name = subStr.Last();

            Memory = PSAPI.GetProcessMemoryInfo(Handle);

            UserName = GetUserName();
        }

        private string GetUserName()
        {
            var tokenHandle = PTAPI.OpenProcessToken(Handle, PTAPI.TokenDesiredAccess.Query);

            var tokenInfo = PTAPI.GetTokenInformation(tokenHandle, PTAPI.TOKEN_INFORMATION_CLASS.TokenUser);

            TOKEN_USER tokenUser = (TOKEN_USER)Marshal.PtrToStructure(tokenInfo, typeof(TOKEN_USER));
            SecurityIdentifier sid = new SecurityIdentifier(tokenUser.User.Sid);

            Marshal.FreeHGlobal(tokenInfo);

            return sid.Translate(typeof(NTAccount)).ToString();
        }

        public void IncrementThreadCount()
        {
            CountThreads++;
        }

        public void SetCpu(uint value)
        {
            Cpu = value;
        }

        public void KillProcess()
        {
            PTAPI.TerminateProcess(Handle, 0);
        }


        // Деструктор 
        private void ClearProcess()
        {
            HAPI.CloseHandle(Handle);
        }

        // Деструктор
        ~Process()
        {
            ClearProcess();
        }
    }
}
