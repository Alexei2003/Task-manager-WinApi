using System;
using System.Data;
using System.Windows.Forms;
using SystemInfo.Processes;

namespace Task_manager_WinApi
{
    public partial class Form1 : Form
    {
        private ListProcesses listProcesses = new();
        private int saveIndex = -1;

        private readonly System.Threading.Timer timer;

        public Form1()
        {
            InitializeComponent();
            ProcessesUpdate();
            tProcessesUpdate.Interval = 5000;
            tProcessesUpdate.Start();
        }

        private void dvgProcesses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            saveIndex = e.RowIndex;
            dvgProcesses.Rows[saveIndex].Selected = true;
        }

        private void tProcessesUpdate_Tick(object sender, EventArgs e)
        {
            ProcessesUpdate();
        }

        private void ProcessesUpdate()
        {
            listProcesses = new ListProcesses();

            var dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Memory");

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = true;
            }

            object[] data = new object[3];
            int index;
            foreach (Process process in listProcesses)
            {
                index = 0;
                data[index++] = process.Name;
                data[index++] = process.Id;
                data[index++] = process.Memory.WorkingSetSize / 1024;
                dataTable.Rows.Add(data);
            }

            dvgProcesses.DataSource = dataTable;

        }

        private void bProcesses_Click(object sender, EventArgs e)
        {
            pProceses.Visible = true;
        }
    }
}