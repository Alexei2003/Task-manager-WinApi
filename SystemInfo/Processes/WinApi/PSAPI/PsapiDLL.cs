using System.Runtime.InteropServices;
using System.Text;

namespace SystemInfo.Processes.WinApi
{
    public class PsapiDLL
    {
        [DllImport("psapi.dll")]
        protected static extern bool EnumProcesses(uint[] processIds, uint size, out uint bytesReturned);

        [DllImport("psapi.dll")]
        protected static extern uint GetProcessImageFileName(IntPtr hProcess, StringBuilder lpImageFileName, uint nSize);
    }
}
