using SystemInfo.Processes.WinApi.Новая_папка;

namespace SystemInfo.Processes.WinApi.THAPI
{
    public class THAPI : Tlhelp32DLL
    {
        public enum Flag : uint
        {
            TH32CS_INHERIT = 0x80000000,

            TH32CS_SNAPHEAPLIST = 0x00000001,
            TH32CS_SNAPMODULE = 0x00000008,
            TH32CS_SNAPMODULE32 = 0x00000010,
            TH32CS_SNAPPROCESS = 0x00000002,
            TH32CS_SNAPTHREAD = 0x00000004
        }

        public static IntPtr CreateToolhelp32Snapshot(Flag flag, uint processId)
        {
            return Tlhelp32DLL.CreateToolhelp32Snapshot(Convert.ToUInt32(flag), processId);
        }

        public static PROCESSENTRY32? Process32First(IntPtr snapshotHandle)
        {
            var processEntry32 = new PROCESSENTRY32();
            if (Tlhelp32DLL.Process32First(snapshotHandle, ref processEntry32))
            {
                return processEntry32;
            }
            else
            {
                return null;
            }
        }

        public static PROCESSENTRY32? Process32Next(IntPtr snapshotHandle)
        {
            var processEntry32 = new PROCESSENTRY32();
            if (Tlhelp32DLL.Process32Next(snapshotHandle, ref processEntry32))
            {
                return processEntry32;
            }
            else
            {
                return null;
            }
        }

        public static THREADENTRY32? Thread32First(IntPtr snapshotHandle)
        {
            var threadEntry32 = new THREADENTRY32();
            if (Tlhelp32DLL.Thread32First(snapshotHandle, ref threadEntry32))
            {
                return threadEntry32;
            }
            else
            {
                return null;
            }
        }

        public static THREADENTRY32? Thread32Next(IntPtr snapshotHandle)
        {
            var threadEntry32 = new THREADENTRY32();
            if (Tlhelp32DLL.Thread32Next(snapshotHandle, ref threadEntry32))
            {
                return threadEntry32;
            }
            else
            {
                return null;
            }
        }
    }
}
