using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SystemInfo.Processes;

namespace Task_manager_WinApi
{
    public partial class TaskManager : Form
    {
        private ListProcesses listProcesses = new();
        private int saveIndex = -1;

        private readonly System.Threading.Timer timer;

        public TaskManager()
        {
            InitializeComponent();
            ProcessesUpdate();
            tUpdate.Interval = 5000;
            tUpdate.Start();

            HideAllPanelsExcept(pProceses);
        }

        private void ProcessesUpdate()
        {
            var sortedColumn = dvgProcesses.SortedColumn;
            var sortOrder = dvgProcesses.SortOrder;

            listProcesses = new ListProcesses();

            var dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Memory");

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = true;
            }

            object[] data = new object[dataTable.Columns.Count];
            int index;
            foreach (Process process in listProcesses)
            {
                index = 0;
                data[index++] = process.Name;
                data[index++] = $"{process.Id,+10}";
                data[index++] = $"{(process.Memory.WorkingSetSize / 1024),+10}";
                dataTable.Rows.Add(data);
            }

            dvgProcesses.DataSource = dataTable;
            if (sortedColumn != null && dvgProcesses.Columns.Contains(sortedColumn.Name) && sortOrder != SortOrder.None)
            {
                dvgProcesses.Sort(dvgProcesses.Columns[sortedColumn.Name], (ListSortDirection)sortOrder-1);
            }
        }

        private void HideAllPanelsExcept(Panel panel)
        {
            pProceses.Visible = false;
            pGlobalStatistics.Visible = false;
            pDevicesInfo.Visible = false;

            panel.Visible = true;
        }

        private void dvgProcesses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            saveIndex = e.RowIndex;
            //listProcesses[saveIndex].KillProcess();
        }

        private void bProcesses_Click(object sender, EventArgs e)
        {
            if (!pProceses.Visible)
            {
                ProcessesUpdate();

                HideAllPanelsExcept(pProceses);
            }
        }

        private void bGlobalStatistics_Click(object sender, EventArgs e)
        {
            if (!pGlobalStatistics.Visible)
            {
                HideAllPanelsExcept(pGlobalStatistics);
            }
        }

        private void bDevicesInfo_Click(object sender, EventArgs e)
        {
            if (!pDevicesInfo.Visible)
            {
                HideAllPanelsExcept(pDevicesInfo);
            }
        }
        private void tUpdate_Tick(object sender, EventArgs e)
        {
            if (pProceses.Visible)
            {
                ProcessesUpdate();
            }
        }


    }
}