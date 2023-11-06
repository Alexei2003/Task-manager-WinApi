using System;
using SystemInfo.Processes;

namespace Task_manager_WinApi
{
    public partial class Form1 : Form
    {
        private ListProcesses listProcesses = new();
        private readonly System.Threading.Timer timer;

        public Form1()
        {
            InitializeComponent();
            ProcessesUpdate();
            tProcessesUpdate.Interval = 5000;
            //tProcessesUpdate.Start();
        }

        private void dvgProcesses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tProcessesUpdate_Tick(object sender, EventArgs e)
        {
            ProcessesUpdate();
        }

        private void ProcessesUpdate()
        {
            dvgProcesses.Rows.Clear();
            foreach (Process process in listProcesses)
            {
                dvgProcesses.Rows.Add(process.Name, process.Id, process.Memory.WorkingSetSize / 1024);
            }
        }
    }
}