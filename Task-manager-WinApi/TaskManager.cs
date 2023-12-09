using System.ComponentModel;
using System.Data;
using System.Reflection;
using SystemInfo.Processes;
using static Task_manager_WinApi.ProcessesColumns;

namespace Task_manager_WinApi
{
    internal partial class TaskManager : Form
    {
        private ListProcesses listProcesses = new();

        private ProcessesColumns processesColumns = new();
        private ProcessesColumnsName[] processesColumnWhitchVisable = new ProcessesColumnsName[]
        {
            ProcessesColumnsName.Id,
            ProcessesColumnsName.Name,
            ProcessesColumnsName.FilePath,
            ProcessesColumnsName.Description,
            ProcessesColumnsName.UserName,
            ProcessesColumnsName.Cpu,
            ProcessesColumnsName.CountThreads,
            ProcessesColumnsName.PageFaultCount,
            ProcessesColumnsName.PeakWorkingSetSize,
            ProcessesColumnsName.WorkingSetSize,
            ProcessesColumnsName.QuotaPeakPagedPoolUsage,
            ProcessesColumnsName.QuotaPagedPoolUsage,
            ProcessesColumnsName.QuotaPeakNonPagedPoolUsage,
            ProcessesColumnsName.QuotaNonPagedPoolUsage,
            ProcessesColumnsName.PagefileUsage,
            ProcessesColumnsName.PeakPagefileUsage
        };
        public ProcessesColumnsName[] TmpProcessesColumnWhitchVisable { get; set; } = null;

        private uint? selectedProcessId = null;

        private ChangeVisableColumns subForm = null;

        public TaskManager()
        {
            InitializeComponent();
            ProcessesUpdate();
            tUpdate.Start();

            HideAllPanelsExcept(pProceses);

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dvgProcesses, new object[] { true });
        }

        private void ProcessesUpdate()
        {
            var sortedColumn = dvgProcesses.SortedColumn;
            var sortOrder = dvgProcesses.SortOrder;
            int IndexFirstRowOnDisplay = dvgProcesses.FirstDisplayedScrollingRowIndex;
            int IndexFirstColumnOnDisplay = dvgProcesses.FirstDisplayedScrollingColumnIndex;

            listProcesses = new ListProcesses();

            if (TmpProcessesColumnWhitchVisable != null)
            {
                dvgProcesses.Columns.Clear();
                processesColumnWhitchVisable = TmpProcessesColumnWhitchVisable;
                TmpProcessesColumnWhitchVisable = null;
            }

            var dataTable = new DataTable();
            foreach (var indexColumn in processesColumnWhitchVisable)
            {
                dataTable.Columns.Add(processesColumns.GetColumeName(indexColumn));
            }

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = true;
            }
            int index;
            object[] data = new object[dataTable.Columns.Count];
            foreach (var process in listProcesses)
            {
                index = 0;
                foreach (var indexColumn in processesColumnWhitchVisable)
                {
                    data[index++] = processesColumns.GetColumeValue(indexColumn, process);
                }
                dataTable.Rows.Add(data);
            }

            dvgProcesses.DataSource = dataTable;

            // положение текста
            for (int i = 0; i < dvgProcesses.Columns.Count; i++)
            {
                if (dvgProcesses.Columns[i].Name == processesColumns.GetColumeName(ProcessesColumnsName.Name) ||
                   dvgProcesses.Columns[i].Name == processesColumns.GetColumeName(ProcessesColumnsName.FilePath) ||
                   dvgProcesses.Columns[i].Name == processesColumns.GetColumeName(ProcessesColumnsName.UserName))
                {
                    dvgProcesses.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                }
                else
                {
                    dvgProcesses.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }
            }

            if (sortedColumn != null && dvgProcesses.Columns.Contains(sortedColumn.Name) && sortOrder != SortOrder.None)
            {
                dvgProcesses.Sort(dvgProcesses.Columns[sortedColumn.Name], (ListSortDirection)sortOrder - 1);
            }

            for (int i = 0; i < dvgProcesses.Rows.Count; i++)
            {
                if (IsSelectedProcess(i))
                {
                    break;
                }
            }

            if (IndexFirstRowOnDisplay > -1 && IndexFirstColumnOnDisplay > -1)
            {
                dvgProcesses.FirstDisplayedScrollingRowIndex = IndexFirstRowOnDisplay;
                dvgProcesses.FirstDisplayedScrollingColumnIndex = IndexFirstColumnOnDisplay;
            }
        }

        private void HideAllPanelsExcept(Panel panel)
        {
            pProceses.Visible = false;
            pGlobalStatistics.Visible = false;

            panel.Visible = true;
        }

        private bool IsSelectedProcess(int index)
        {
            if (Convert.ToUInt32(dvgProcesses.Rows[index].Cells[processesColumns.GetColumeName(ProcessesColumnsName.Id)].Value.ToString()) == Convert.ToUInt32(selectedProcessId))
            {
                dvgProcesses.Rows[Convert.ToInt32(index)].Selected = true;
                return true;
            }
            return false;
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

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            if (pProceses.Visible)
            {
                ProcessesUpdate();
            }
        }

        private void bKillProcess_Click(object sender, EventArgs e)
        {
            if (selectedProcessId != null)
            {
                listProcesses.KillProcessTree(selectedProcessId.Value);
            }
        }

        private void bChangeVisableColumns_Click(object sender, EventArgs e)
        {
            subForm = new ChangeVisableColumns(processesColumnWhitchVisable, processesColumns, this);

            subForm.Visible = true;
        }

        private void dvgProcesses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selectedProcessId = Convert.ToUInt32(dvgProcesses.Rows[e.RowIndex].Cells[processesColumns.GetColumeName(ProcessesColumnsName.Id)].Value);
            }
        }
    }
}