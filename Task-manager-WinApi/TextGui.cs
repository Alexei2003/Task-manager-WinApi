using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task_manager_WinApi
{
    internal class TextGui
    {
        public string bKillProcess { get; set; }
        public string bChangeVisableColumns { get; set; }
        public string tbSearch { get; set; }
        public string bProcesses { get; set; }
        public string bGlobalStatistics { get; set; }
    }
}
