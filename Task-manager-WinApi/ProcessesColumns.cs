﻿using SystemInfo.Processes;

namespace Task_manager_WinApi
{
    internal class ProcessesColumns
    {
        public enum ProcessesColumnsName
        {
            Id,
            Name,
            FilePath,
            Description,
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
        private string[] processesColumnsNames = new string[]
        {
            "Id",
            "Name",
            "FilePath",
            "Description",
            "UserName",
            "Cpu",
            "CountThreads",
            "PageFaultCount",
            "PeakWorkingSetSize(KB)",
            "WorkingSetSize(KB)",
            "QuotaPeakPagedPoolUsage(KB)",
            "QuotaPagedPoolUsage(KB)",
            "QuotaPeakNonPagedPoolUsage(KB)",
            "QuotaNonPagedPoolUsage(KB)",
            "PagefileUsage(KB)",
            "PeakPagefileUsage(KB)"
        };

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
                case ProcessesColumnsName.PageFaultCount:
                    return $"{process.Memory.PageFaultCount}";
                case ProcessesColumnsName.PeakWorkingSetSize:
                    return $"{process.Memory.PeakWorkingSetSize / 1024}";
                case ProcessesColumnsName.WorkingSetSize:
                    return $"{process.Memory.WorkingSetSize / 1024}";
                case ProcessesColumnsName.QuotaPeakPagedPoolUsage:
                    return $"{process.Memory.QuotaPeakPagedPoolUsage / 1024}";
                case ProcessesColumnsName.QuotaPagedPoolUsage:
                    return $"{process.Memory.QuotaPagedPoolUsage / 1024}";
                case ProcessesColumnsName.QuotaPeakNonPagedPoolUsage:
                    return $"{process.Memory.QuotaPeakNonPagedPoolUsage / 1024}";
                case ProcessesColumnsName.QuotaNonPagedPoolUsage:
                    return $"{process.Memory.QuotaNonPagedPoolUsage / 1024}";
                case ProcessesColumnsName.PagefileUsage:
                    return $"{process.Memory.PagefileUsage / 1024}";
                case ProcessesColumnsName.PeakPagefileUsage:
                    return $"{process.Memory.PeakPagefileUsage / 1024}";
                default:
                    return null;
            }
        }

        public string? GetColumeName(ProcessesColumnsName name)
        {
            if (processesColumnsNames.Length <= Convert.ToInt32(name))
            {
                return null;
            }
            return processesColumnsNames[Convert.ToInt32(name)];
        }
    }
}