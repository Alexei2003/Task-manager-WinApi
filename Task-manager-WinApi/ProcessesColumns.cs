using SystemInfo.Processes;

namespace Task_manager_WinApi
{
    internal class ProcessesColumns
    {
        public enum ProcessesColumnsName { Id, Name, FilePath, Description, UserName, Cpu, CountThreads, Memory }
        private string[] processesColumnsNames = new string[] { "Id", "Name", "FilePath", "Description", "UserName", "Cpu", "CountThreads", "Memory(KB)" };

        public string? GetColumeValue(ProcessesColumnsName name, Process process)
        {

            switch (name)
            {
                case ProcessesColumnsName.Id:
                    return $"{process.Id,+10}";
                case ProcessesColumnsName.Name:
                    return $"{process.Name}";
                case ProcessesColumnsName.FilePath:
                    return null;
                case ProcessesColumnsName.Description:
                    return null;
                case ProcessesColumnsName.UserName:
                    return null;
                case ProcessesColumnsName.Cpu:
                    return null;
                case ProcessesColumnsName.CountThreads:
                    return null;
                case ProcessesColumnsName.Memory:
                    return $"{(process.Memory.WorkingSetSize / 1024),+10}";
                default:
                    return null;
            }
        }

        public string? GetColumeName(ProcessesColumnsName name)
        {
            var a = Convert.ToInt32(name);
            if (processesColumnsNames.Length <= Convert.ToInt32(name))
            {
                return null;
            }
            return processesColumnsNames[Convert.ToInt32(name)];
        }
    }
}
