using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text.Json;
using SystemInfo.Processes;
using Task_manager_WinApi.Language;
using static Task_manager_WinApi.ProcessesColumns;

namespace Task_manager_WinApi
{
    internal partial class TaskManager : Form
    {
        private ListProcesses listProcesses = new();

        private ProcessesColumns processesColumns;
        private ProcessesColumnsName[] processesColumnWhitchVisable =
        [
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
        ];
        public ProcessesColumnsName[]? TmpProcessesColumnWhitchVisable { get; set; } = null;

        private uint? selectedProcessId = null;

        private ChangeVisableColumns? subForm = null;

        private string? searchProcess;

        public TaskManager()
        {
            ChangeLanguage(Localization.Language.ru);

            InitializeComponent();
            ProcessesUpdate();
            tUpdate.Start();

            HideAllPanelsExcept(pProceses);

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dgvProcesses, new object[] { true });
        }

        private void ProcessesUpdate()
        {
            var sortedColumn = dgvProcesses.SortedColumn;
            var sortOrder = dgvProcesses.SortOrder;
            int indexFirstRowOnDisplay = dgvProcesses.FirstDisplayedScrollingRowIndex;
            int offsetColumOnDisplay = dgvProcesses.HorizontalScrollingOffset;

            listProcesses = new ListProcesses();

            // Скрытие колонок 
            if (TmpProcessesColumnWhitchVisable != null)
            {
                dgvProcesses.Columns.Clear();
                processesColumnWhitchVisable = TmpProcessesColumnWhitchVisable;
                TmpProcessesColumnWhitchVisable = null;
            }

            // Создание колонок в dataTable 
            var dataTable = new DataTable();
            foreach (var indexColumn in processesColumnWhitchVisable)
            {
                dataTable.Columns.Add(processesColumns.GetColumeName(indexColumn));
            }

            // Простановка не изменений текста
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataTable.Columns[i].ReadOnly = true;
            }

            // Занос данныъ в таблицу
            int index;
            object[] data = new object[dataTable.Columns.Count];
            foreach (var process in listProcesses)
            {
                index = 0;

                if (searchProcess != null && !process.Id.ToString().Contains(searchProcess) && !process.Name.ToUpper().Contains(searchProcess.ToUpper()))
                {
                    continue;
                }

                foreach (var indexColumn in processesColumnWhitchVisable)
                {
                    data[index++] = GetColumeValue(indexColumn, process);
                }
                dataTable.Rows.Add(data);
            }

            // Передача данных в dvg
            dgvProcesses.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
            {

                // положение текста
                for (int i = 0; i < dgvProcesses.Columns.Count; i++)
                {
                    if (dgvProcesses.Columns[i].Name == processesColumns.GetColumeName(ProcessesColumnsName.Name) ||
                       dgvProcesses.Columns[i].Name == processesColumns.GetColumeName(ProcessesColumnsName.FilePath) ||
                       dgvProcesses.Columns[i].Name == processesColumns.GetColumeName(ProcessesColumnsName.UserName))
                    {
                        dgvProcesses.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                    }
                    else
                    {
                        dgvProcesses.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    }
                }

                if (sortedColumn != null && dgvProcesses.Columns.Contains(sortedColumn.Name) && sortOrder != SortOrder.None)
                {
                    dgvProcesses.Sort(dgvProcesses.Columns[sortedColumn.Name], (ListSortDirection)sortOrder - 1);
                }

                for (int i = 0; i < dgvProcesses.Rows.Count; i++)
                {
                    if (IsSelectedProcess(i))
                    {
                        break;
                    }
                }

                if (indexFirstRowOnDisplay > -1 && offsetColumOnDisplay > -1)
                {
                    if (dgvProcesses.Rows.Count > indexFirstRowOnDisplay)
                    {
                        dgvProcesses.FirstDisplayedScrollingRowIndex = indexFirstRowOnDisplay;
                    }
                    dgvProcesses.HorizontalScrollingOffset = offsetColumOnDisplay;
                }
            }
        }

        private void GlobalStatisticsUpdate()
        {

        }

        private void HideAllPanelsExcept(Panel panel)
        {
            pProceses.Visible = false;
            pGlobalStatistics.Visible = false;

            panel.Visible = true;
        }

        private bool IsSelectedProcess(int index)
        {
            if (Convert.ToUInt32(dgvProcesses.Rows[index].Cells[processesColumns.GetColumeName(ProcessesColumnsName.Id)].Value.ToString()) == Convert.ToUInt32(selectedProcessId))
            {
                dgvProcesses.Rows[Convert.ToInt32(index)].Selected = true;
                return true;
            }
            return false;
        }

        private void ChangeLanguage(Localization.Language language)
        {
            processesColumns = new(language);

            var str = File.ReadAllText($"Language\\{Localization.GetLanguageName(language)}\\TextGui.txt");
            var textGui = JsonSerializer.Deserialize<TextGui>(str);

            bKillProcess.Text = textGui.bKillProcess;
            bChangeVisableColumns.Text = textGui.bChangeVisableColumns;
            tbSearch.PlaceholderText = textGui.tbSearch;
            bProcesses.Text = textGui.bProcesses;
            bGlobalStatistics.Text = textGui.bGlobalStatistics;
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
                GlobalStatisticsUpdate();

                HideAllPanelsExcept(pGlobalStatistics);
            }
        }

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            if (pProceses.Visible)
            {
                ProcessesUpdate();
            }
            if (pGlobalStatistics.Visible)
            {
                GlobalStatisticsUpdate();
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
                selectedProcessId = Convert.ToUInt32(dgvProcesses.Rows[e.RowIndex].Cells[processesColumns.GetColumeName(ProcessesColumnsName.Id)].Value);
            }
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            searchProcess = tbSearch.Text;

            if (searchProcess == "")
            {
                searchProcess = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeLanguage(Localization.Language.en);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeLanguage(Localization.Language.ru);
        }
    }
}