namespace SystemInfo.Processes
{
    public class Process
    {
        public uint Id { get; }
        public IntPtr Handle { get; }
        public string Name { get; }
        public string FilePath { get; }
        public string Description { get; }

        // status
        public string UserName { get; }
        public int Cpu {  get; }
        public int Memory { get; }
        public int CountThreads {  get; }
        public int Architecture { get; }

        public Process(uint id, IntPtr handle, string name)
        {
            Id = id;
            Handle = handle;

            var subStr = name.Split("\\");
            FilePath = "";
            for(int i = 0; i < subStr.Length-1; i++)
            {
                FilePath += "\\" + subStr[i];
            }

            Name = subStr.Last();
        }
    }
}
