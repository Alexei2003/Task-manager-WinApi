using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text.Json;
using SystemInfo.SystemDate.GlobalStatistics;
using SystemInfo.SystemDate.Processes;
using Task_manager_WinApi.Language;
using static SystemInfo.SystemDate.GlobalStatistics.GlobalStatistics;
using static Task_manager_WinApi.ProcessesColumns;

namespace Task_manager_WinApi
{
    internal partial class fTaskManager : Form
    {
        private ListProcesses listProcesses = new();

        private GlobalStatistics globalStatistics = new();

        private ProcessesColumns processesColumns;
        private ProcessesColumnsName[] processesColumnWhitchVisable =
        [
            ProcessesColumnsName.Id,
            ProcessesColumnsName.Name,
            ProcessesColumnsName.FilePath,
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

        private StatisticsType statisticsType = StatisticsType.Cpu;

        public fTaskManager()
        {
            InitializeComponent();

            cbLanguage.SelectedIndex = 0;
            cbUpdateTime.SelectedIndex = 0;

            ProcessesUpdate();
            tUpdate.Start();

            HideAllPanelsExcept(pProceses);

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dgvProcesses, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, pMainGraph, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, pCpu, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, pRam, new object[] { true });
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
            globalStatistics.Update();
        }

        private void HideAllPanelsExcept(Panel panel)
        {
            pProceses.Visible = false;
            pGlobalStatistics.Visible = false;
            pSetting.Visible = false;

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
            ChangeLanguageProcessesColumns(language);

            ChangeLanguageTextGui(language);
        }

        private void ChangeLanguageProcessesColumns(Localization.Language language)
        {
            processesColumns = new(language);
        }

        private void ChangeLanguageTextGui(Localization.Language language)
        {
            var str = File.ReadAllText($"Language\\{Localization.GetLanguageName(language)}\\TextGui.txt");
            var textGui = JsonSerializer.Deserialize<TextGui>(str);

            Text = textGui.fTaskManager;
            bKillProcess.Text = textGui.bKillProcess;
            bChangeVisableColumns.Text = textGui.bChangeVisableColumns;
            tbSearch.PlaceholderText = textGui.tbSearch;
            bProcesses.Text = textGui.bProcesses;
            bGlobalStatistics.Text = textGui.bGlobalStatistics;
            bSetting.Text = textGui.bSetting;
            tbCpu.Text = textGui.tbCpu;
            tbRam.Text = textGui.tbRam;
            tbLanguage.Text = textGui.tbLanguage;
            tbUpdateTime.Text = textGui.tbUpdateTime;
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
            GlobalStatisticsUpdate();
            if (pGlobalStatistics.Visible)
            {
                pMainGraph.Invalidate();
                pCpu.Invalidate();
                pRam.Invalidate();
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

        private void pMainGraph_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            switch (statisticsType)
            {
                case StatisticsType.Cpu:
                    tbMainGraph.Text = tbCpu.Text;
                    PaintGraph(g, pMainGraph, globalStatistics.CpuUsePercent, Color.Red);
                    break;

                case StatisticsType.Ram:
                    tbMainGraph.Text = tbRam.Text;
                    PaintGraph(g, pMainGraph, globalStatistics.RamUsePercent, Color.Blue);
                    break;
            }
        }

        private static void PaintGraph(Graphics g, Panel panel, Queue<int> queue, Color color)
        {
            var brush = new SolidBrush(color);

            var points = new Point[GlobalStatistics.COUNT_TIME + 3];

            var stepPaintX = panel.Width / GlobalStatistics.COUNT_TIME;
            var stepPaintY = panel.Height / (GlobalStatistics.MAX_PERCENT);

            int i = 0;
            for (; i < GlobalStatistics.COUNT_TIME - queue.Count; i++)
            {
                points[i] = new Point(i * stepPaintX, ((GlobalStatistics.MAX_PERCENT - 0) * stepPaintY));
            }

            foreach (var cpu in queue)
            {
                points[i] = new Point(i * stepPaintX, ((GlobalStatistics.MAX_PERCENT - cpu) * stepPaintY));
                i++;
            }
            points[i] = new Point(i * stepPaintX, points[i - 1].Y);
            i++;
            points[i] = new Point(i * stepPaintX, panel.Height);
            i++;
            points[i] = new Point(0, panel.Height);

            g.FillPolygon(brush, points);

            PaintLines(g, panel);
        }

        private static void PaintLines(Graphics g, Panel panel)
        {
            var pen = new Pen(Color.Black);

            var stepPaintX = panel.Width / GlobalStatistics.COUNT_TIME;
            var stepPaintY = panel.Height / 10;

            for (int i = 1; i < 10; i++)
            {
                g.DrawLine(pen, new Point { X = 0, Y = i * stepPaintY }, new Point { X = panel.Width, Y = i * stepPaintY });
            }

            for (int i = 1; i < GlobalStatistics.COUNT_TIME; i++)
            {
                g.DrawLine(pen, new Point { X = i * stepPaintX, Y = 0 }, new Point { X = i * stepPaintX, Y = panel.Height });
            }
        }

        private void pCpu_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            PaintGraph(g, pCpu, globalStatistics.CpuUsePercent, Color.Red);
        }

        private void pRam_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            PaintGraph(g, pRam, globalStatistics.RamUsePercent, Color.Blue);
        }

        private void pCpu_Click(object sender, EventArgs e)
        {
            statisticsType = StatisticsType.Cpu;
        }

        private void pRam_Click(object sender, EventArgs e)
        {
            statisticsType = StatisticsType.Ram;
        }

        private void bSetting_Click(object sender, EventArgs e)
        {
            HideAllPanelsExcept(pSetting);
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLanguage((Localization.Language)cbLanguage.SelectedIndex);
        }

        private void cbUpdateTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            tUpdate.Interval = Convert.ToInt32(cbUpdateTime.Text) * 1000;
        }
    }
}