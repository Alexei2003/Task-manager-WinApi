using System.Text.Json;
using SystemInfo.SystemDate.Processes;
using Task_manager_WinApi.Language;

namespace Task_manager_WinApi
{
    public class ProcessesColumns
    {
        public enum ProcessesColumnsName
        {
            Id,
            Name,
            FilePath,
            UserName,
            Cpu,
            CountThreads,
            PageFaultCount,
            PeakWorkingSetSize,
            WorkingSetSize,
            QuotaPeakPagedPoolUsage,
            QuotaPagedPoolUsage,
            QuotaPeakNonPagedPoolUsage,
            QuotaNonPagedPoolUsage,
            PagefileUsage,
            PeakPagefileUsage
        }
        private Dictionary<ProcessesColumnsName, string> processesColumnsNames;

        public int Count { get; }
        public ProcessesColumns(Localization.Language language)
        {
            var str = File.ReadAllText($"Language\\{Localization.GetLanguageName(language)}\\ProcessesColumnsNames.txt");
            processesColumnsNames = JsonSerializer.Deserialize<Dictionary<ProcessesColumnsName, string>>(str);
            Count = processesColumnsNames.Count;
        }

        const int SHIFT = 8;
        public static object GetColumeValue(ProcessesColumnsName name, Process process)
        {
            switch (name)
            {
                case ProcessesColumnsName.Id:
                    return $"{process.Id,+SHIFT}";
                case ProcessesColumnsName.Name:
                    return $"{process.Name}";
                case ProcessesColumnsName.FilePath:
                    return $"{process.FilePath}";
                case ProcessesColumnsName.UserName:
                    return $"{process.UserName}";
                case ProcessesColumnsName.Cpu:
                    return $"{process.Cpu,+SHIFT}";
                case ProcessesColumnsName.CountThreads:
                    return $"{process.CountThreads,+SHIFT}";
                case ProcessesColumnsName.PageFaultCount:
                    return $"{process.Memory.PageFaultCount,+SHIFT}";
                case ProcessesColumnsName.PeakWorkingSetSize:
                    return $"{process.Memory.PeakWorkingSetSize / 1024,+SHIFT}";
                case ProcessesColumnsName.WorkingSetSize:
                    return $"{process.Memory.WorkingSetSize / 1024,+SHIFT}";
                case ProcessesColumnsName.QuotaPeakPagedPoolUsage:
                    return $"{process.Memory.QuotaPeakPagedPoolUsage / 1024,+SHIFT}";
                case ProcessesColumnsName.QuotaPagedPoolUsage:
                    return $"{process.Memory.QuotaPagedPoolUsage / 1024,+SHIFT}";
                case ProcessesColumnsName.QuotaPeakNonPagedPoolUsage:
                    return $"{process.Memory.QuotaPeakNonPagedPoolUsage / 1024,+SHIFT}";
                case ProcessesColumnsName.QuotaNonPagedPoolUsage:
                    return $"{process.Memory.QuotaNonPagedPoolUsage / 1024,+SHIFT}";
                case ProcessesColumnsName.PagefileUsage:
                    return $"{process.Memory.PagefileUsage / 1024,+SHIFT}";
                case ProcessesColumnsName.PeakPagefileUsage:
                    return $"{process.Memory.PeakPagefileUsage / 1024,+SHIFT}";
                default:
                    return null;
            }
        }

        public string? GetColumeName(ProcessesColumnsName name)
        {
            if (processesColumnsNames.TryGetValue(name, out var columeName))
            {
                return columeName;
            }
            return null;
        }
    }
}