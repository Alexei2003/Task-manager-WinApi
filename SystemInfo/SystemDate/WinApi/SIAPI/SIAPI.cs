using System.Runtime.InteropServices;

namespace SystemInfo.SystemDate.WinApi.SIAPI
{
    public class SIAPI : SysinfoapiDLL
    {
        public static MEMORYSTATUSEX GlobalMemoryStatusEx()
        {
            var memorySatatusEx = new MEMORYSTATUSEX();
            SysinfoapiDLL.GlobalMemoryStatusEx(memorySatatusEx);
            var a = Marshal.GetLastWin32Error();
            return memorySatatusEx;
        }
    }
}
