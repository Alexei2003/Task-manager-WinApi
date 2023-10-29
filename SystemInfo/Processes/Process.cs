using System.Diagnostics;

namespace SystemInfo.Processes
{
    public class Process
    {
        public uint Id { get; }
        public IntPtr Handle { get; }
        public string Name { get; }

        public Process(uint id, IntPtr handle)
        {
            Id = id;
            Handle = handle;
        }
    }
}
