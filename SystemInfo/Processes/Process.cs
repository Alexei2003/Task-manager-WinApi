using System.Runtime.InteropServices;
using System.Security.Principal;
using SystemInfo.Processes.WinApi.HAPI;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;
using SystemInfo.Processes.WinApi.THAPI;
using static SystemInfo.Processes.WinApi.PTAPI.ProcessthreadsapiDLL;

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
        public int CountThreads { get; private set; } = 0;
        public PSAPI.PROCESS_MEMORY_COUNTERS Memory { get; }


        public Process(uint id, IntPtr handle)
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
