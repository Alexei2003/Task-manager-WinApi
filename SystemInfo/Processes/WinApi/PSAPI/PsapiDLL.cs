using System.Runtime.InteropServices;

namespace SystemInfo.Processes.WinApi
{
    public class PsapiDLL
    {
        [DllImport("psapi.dll")]
        protected static extern bool EnumProcesses(uint[] processIds, uint size, out uint bytesReturned);
    }
}
