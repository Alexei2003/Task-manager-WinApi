using System.Text.Json;
using Task_manager_WinApi;
using Task_manager_WinApi.Language;
class Program
{
    static void Main(string[] args)
    {
        // en
        {
            var processesColumnsNames = new Dictionary<ProcessesColumns.ProcessesColumnsName, string>()
            {
                { ProcessesColumns.ProcessesColumnsName.Id,"Id"},
                { ProcessesColumns.ProcessesColumnsName.Name,"Name"},
                { ProcessesColumns.ProcessesColumnsName.FilePath,"File path"},
                { ProcessesColumns.ProcessesColumnsName.UserName,"Username"},
                { ProcessesColumns.ProcessesColumnsName.Cpu,"CPU"},
                { ProcessesColumns.ProcessesColumnsName.CountThreads,"Threads"},
                { ProcessesColumns.ProcessesColumnsName.PageFaultCount,"The number of page faults"},
                { ProcessesColumns.ProcessesColumnsName.PeakWorkingSetSize,"The peak working set size(KB)"},
                { ProcessesColumns.ProcessesColumnsName.WorkingSetSize,"The current working set size(KB)"},
                { ProcessesColumns.ProcessesColumnsName.QuotaPeakPagedPoolUsage,"The peak paged pool usage(KB)"},
                { ProcessesColumns.ProcessesColumnsName.QuotaPagedPoolUsage,"The current paged pool usage(KB)"},
                { ProcessesColumns.ProcessesColumnsName.QuotaPeakNonPagedPoolUsage,"The peak nonpaged pool usage(KB)"},
                { ProcessesColumns.ProcessesColumnsName.QuotaNonPagedPoolUsage,"The current nonpaged pool usage(KB)"},
                { ProcessesColumns.ProcessesColumnsName.PagefileUsage,"The Commit Charge value(KB)"},
                { ProcessesColumns.ProcessesColumnsName.PeakPagefileUsage,"The peak value of the Commit Charge(KB)"}
            };

            var str = JsonSerializer.Serialize(processesColumnsNames);

            File.WriteAllText($"Language\\{Localization.Language.en}\\ProcessesColumnsNames.txt", str);
        }

        //ru
        {
            var processesColumnsNames = new Dictionary<ProcessesColumns.ProcessesColumnsName, string>()
            {
                { ProcessesColumns.ProcessesColumnsName.Id,"ИД"},
                { ProcessesColumns.ProcessesColumnsName.Name,"Имя"},
                { ProcessesColumns.ProcessesColumnsName.FilePath,"Путь к файлу"},
                { ProcessesColumns.ProcessesColumnsName.UserName,"Имя пользователя"},
                { ProcessesColumns.ProcessesColumnsName.Cpu,"ЦП"},
                { ProcessesColumns.ProcessesColumnsName.CountThreads,"Потоки"},
                { ProcessesColumns.ProcessesColumnsName.PageFaultCount,"Количество ошибок страницы"},
                { ProcessesColumns.ProcessesColumnsName.PeakWorkingSetSize,"Максимальный размер рабочего набора(KB)"},
                { ProcessesColumns.ProcessesColumnsName.WorkingSetSize,"Текущий размер рабочего набора(KB)"},
                { ProcessesColumns.ProcessesColumnsName.QuotaPeakPagedPoolUsage,"Пиковое использование выстраивного пула(KB)"},
                { ProcessesColumns.ProcessesColumnsName.QuotaPagedPoolUsage,"Текущее использование выстраивного пула(KB)"},
                { ProcessesColumns.ProcessesColumnsName.QuotaPeakNonPagedPoolUsage,"Пиковое использование непагрегированного пула(KB)"},
                { ProcessesColumns.ProcessesColumnsName.QuotaNonPagedPoolUsage,"Текущее использование непагрегированного пула(KB)"},
                { ProcessesColumns.ProcessesColumnsName.PagefileUsage,"Значение фиксации заряда(KB)"},
                { ProcessesColumns.ProcessesColumnsName.PeakPagefileUsage,"Пиковое значение фиксации заряда(KB)"}
            };

            var str = JsonSerializer.Serialize(processesColumnsNames);

            File.WriteAllText($"Language\\{Localization.Language.ru}\\ProcessesColumnsNames.txt", str);
        }


        /////////////////////////


        // en
        {
            var textGui = new TextGui()
            {
                fTaskManager = "Task Manager",
                bKillProcess = "Close the process",
                bChangeVisableColumns = "Select Columns",
                tbSearch = "Search by name, id",
                bProcesses = "Processes",
                bGlobalStatistics = "Performance",
                bSetting = "Settings",
                tbCpu = "CPU",
                tbRam = "RAM",
                tbLanguage = "Language",
                tbUpdateTime = "Update rate",
                fChangeVisableColumns = "Change columns",
                bOk = "Save"
            };

            var str = JsonSerializer.Serialize(textGui);

            File.WriteAllText($"Language\\{Localization.Language.en}\\TextGui.txt", str);
        }

        //ru
        {
            var textGui = new TextGui()
            {
                fTaskManager = "Диспетчер задача",
                bKillProcess = "Закрыть процесс",
                bChangeVisableColumns = "Выбрать столбцы",
                tbSearch = "Поиск по имени, id",
                bProcesses = "Процессы",
                bGlobalStatistics = "Производительность",
                bSetting = "Настройки",
                tbCpu = "ЦП",
                tbRam = "ОЗУ",
                tbLanguage = "Язык",
                tbUpdateTime = "Скорость обновления",
                fChangeVisableColumns = "изменение столбцов",
                bOk = "Сохранить"
            };

            var str = JsonSerializer.Serialize(textGui);

            File.WriteAllText($"Language\\{Localization.Language.ru}\\TextGui.txt", str);
        }
    }
}
