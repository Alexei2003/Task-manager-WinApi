namespace Task_manager_WinApi
{
    partial class fTaskManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvProcesses = new DataGridView();
            tUpdate = new System.Windows.Forms.Timer(components);
            pProceses = new Panel();
            tbSearch = new TextBox();
            bChangeVisableColumns = new Button();
            bKillProcess = new Button();
            bProcesses = new Button();
            bGlobalStatistics = new Button();
            pGlobalStatistics = new Panel();
            tbRam = new TextBox();
            tbCpu = new TextBox();
            tbMainGraph = new TextBox();
            pRam = new Panel();
            pCpu = new Panel();
            pMainGraph = new Panel();
            pSetting = new Panel();
            cbUpdateTime = new ComboBox();
            cbLanguage = new ComboBox();
            tbUpdateTime = new TextBox();
            tbLanguage = new TextBox();
            bSetting = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProcesses).BeginInit();
            pProceses.SuspendLayout();
            pGlobalStatistics.SuspendLayout();
            pSetting.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProcesses
            // 
            dgvProcesses.AllowUserToAddRows = false;
            dgvProcesses.AllowUserToDeleteRows = false;
            dgvProcesses.AllowUserToOrderColumns = true;
            dgvProcesses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProcesses.BorderStyle = BorderStyle.None;
            dgvProcesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProcesses.Location = new Point(10, 43);
            dgvProcesses.MultiSelect = false;
            dgvProcesses.Name = "dgvProcesses";
            dgvProcesses.ReadOnly = true;
            dgvProcesses.RowHeadersWidth = 5;
            dgvProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcesses.Size = new Size(1180, 389);
            dgvProcesses.TabIndex = 0;
            dgvProcesses.CellClick += dvgProcesses_CellClick;
            // 
            // tUpdate
            // 
            tUpdate.Interval = 1000;
            tUpdate.Tick += tUpdate_Tick;
            // 
            // pProceses
            // 
            pProceses.BorderStyle = BorderStyle.FixedSingle;
            pProceses.Controls.Add(tbSearch);
            pProceses.Controls.Add(bChangeVisableColumns);
            pProceses.Controls.Add(bKillProcess);
            pProceses.Controls.Add(dgvProcesses);
            pProceses.Location = new Point(10, 50);
            pProceses.Name = "pProceses";
            pProceses.Size = new Size(1200, 500);
            pProceses.TabIndex = 1;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(416, 12);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Поиск по имени, id";
            tbSearch.Size = new Size(324, 25);
            tbSearch.TabIndex = 5;
            tbSearch.KeyUp += tbSearch_KeyUp;
            // 
            // bChangeVisableColumns
            // 
            bChangeVisableColumns.Location = new Point(116, 438);
            bChangeVisableColumns.Name = "bChangeVisableColumns";
            bChangeVisableColumns.Size = new Size(100, 50);
            bChangeVisableColumns.TabIndex = 7;
            bChangeVisableColumns.Text = "Изменить столбцы";
            bChangeVisableColumns.UseVisualStyleBackColor = true;
            bChangeVisableColumns.Click += bChangeVisableColumns_Click;
            // 
            // bKillProcess
            // 
            bKillProcess.Location = new Point(10, 438);
            bKillProcess.Name = "bKillProcess";
            bKillProcess.Size = new Size(100, 50);
            bKillProcess.TabIndex = 6;
            bKillProcess.Text = "Закрыть процесс";
            bKillProcess.UseVisualStyleBackColor = true;
            bKillProcess.Click += bKillProcess_Click;
            // 
            // bProcesses
            // 
            bProcesses.Location = new Point(10, 0);
            bProcesses.Name = "bProcesses";
            bProcesses.Size = new Size(100, 50);
            bProcesses.TabIndex = 2;
            bProcesses.Text = "Процессы";
            bProcesses.UseVisualStyleBackColor = true;
            bProcesses.Click += bProcesses_Click;
            // 
            // bGlobalStatistics
            // 
            bGlobalStatistics.Location = new Point(116, 0);
            bGlobalStatistics.Name = "bGlobalStatistics";
            bGlobalStatistics.Size = new Size(100, 50);
            bGlobalStatistics.TabIndex = 4;
            bGlobalStatistics.Text = "Производительность";
            bGlobalStatistics.UseVisualStyleBackColor = true;
            bGlobalStatistics.Click += bGlobalStatistics_Click;
            // 
            // pGlobalStatistics
            // 
            pGlobalStatistics.BorderStyle = BorderStyle.FixedSingle;
            pGlobalStatistics.Controls.Add(tbRam);
            pGlobalStatistics.Controls.Add(tbCpu);
            pGlobalStatistics.Controls.Add(tbMainGraph);
            pGlobalStatistics.Controls.Add(pRam);
            pGlobalStatistics.Controls.Add(pCpu);
            pGlobalStatistics.Controls.Add(pMainGraph);
            pGlobalStatistics.Location = new Point(10, 50);
            pGlobalStatistics.Name = "pGlobalStatistics";
            pGlobalStatistics.Size = new Size(1200, 500);
            pGlobalStatistics.TabIndex = 3;
            // 
            // tbRam
            // 
            tbRam.Location = new Point(20, 149);
            tbRam.Name = "tbRam";
            tbRam.ReadOnly = true;
            tbRam.Size = new Size(110, 25);
            tbRam.TabIndex = 8;
            tbRam.Text = "RAM";
            // 
            // tbCpu
            // 
            tbCpu.Location = new Point(20, 12);
            tbCpu.Name = "tbCpu";
            tbCpu.ReadOnly = true;
            tbCpu.Size = new Size(110, 25);
            tbCpu.TabIndex = 7;
            tbCpu.Text = "CPU";
            // 
            // tbMainGraph
            // 
            tbMainGraph.Location = new Point(290, 12);
            tbMainGraph.Name = "tbMainGraph";
            tbMainGraph.ReadOnly = true;
            tbMainGraph.Size = new Size(110, 25);
            tbMainGraph.TabIndex = 2;
            // 
            // pRam
            // 
            pRam.BorderStyle = BorderStyle.FixedSingle;
            pRam.Location = new Point(20, 180);
            pRam.Name = "pRam";
            pRam.Size = new Size(240, 100);
            pRam.TabIndex = 0;
            pRam.Click += pRam_Click;
            pRam.Paint += pRam_Paint;
            // 
            // pCpu
            // 
            pCpu.BorderStyle = BorderStyle.FixedSingle;
            pCpu.Location = new Point(20, 43);
            pCpu.Name = "pCpu";
            pCpu.Size = new Size(240, 100);
            pCpu.TabIndex = 1;
            pCpu.Click += pCpu_Click;
            pCpu.Paint += pCpu_Paint;
            // 
            // pMainGraph
            // 
            pMainGraph.BorderStyle = BorderStyle.FixedSingle;
            pMainGraph.Location = new Point(290, 43);
            pMainGraph.Name = "pMainGraph";
            pMainGraph.Size = new Size(900, 400);
            pMainGraph.TabIndex = 0;
            pMainGraph.Paint += pMainGraph_Paint;
            // 
            // pSetting
            // 
            pSetting.BorderStyle = BorderStyle.FixedSingle;
            pSetting.Controls.Add(cbUpdateTime);
            pSetting.Controls.Add(cbLanguage);
            pSetting.Controls.Add(tbUpdateTime);
            pSetting.Controls.Add(tbLanguage);
            pSetting.Location = new Point(10, 50);
            pSetting.Name = "pSetting";
            pSetting.Size = new Size(1200, 500);
            pSetting.TabIndex = 9;
            // 
            // cbUpdateTime
            // 
            cbUpdateTime.FormattingEnabled = true;
            cbUpdateTime.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbUpdateTime.Location = new Point(382, 12);
            cbUpdateTime.Name = "cbUpdateTime";
            cbUpdateTime.Size = new Size(134, 25);
            cbUpdateTime.TabIndex = 12;
            cbUpdateTime.SelectedIndexChanged += cbUpdateTime_SelectedIndexChanged;
            // 
            // cbLanguage
            // 
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Items.AddRange(new object[] { "English", "Русский" });
            cbLanguage.Location = new Point(126, 12);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Size = new Size(134, 25);
            cbLanguage.TabIndex = 1;
            cbLanguage.SelectedIndexChanged += cbLanguage_SelectedIndexChanged;
            // 
            // tbUpdateTime
            // 
            tbUpdateTime.Location = new Point(266, 12);
            tbUpdateTime.Name = "tbUpdateTime";
            tbUpdateTime.ReadOnly = true;
            tbUpdateTime.Size = new Size(110, 25);
            tbUpdateTime.TabIndex = 11;
            tbUpdateTime.Text = "UpdateTime";
            // 
            // tbLanguage
            // 
            tbLanguage.Location = new Point(10, 12);
            tbLanguage.Name = "tbLanguage";
            tbLanguage.ReadOnly = true;
            tbLanguage.Size = new Size(110, 25);
            tbLanguage.TabIndex = 0;
            tbLanguage.Text = "language";
            // 
            // bSetting
            // 
            bSetting.Location = new Point(1110, 0);
            bSetting.Name = "bSetting";
            bSetting.RightToLeft = RightToLeft.No;
            bSetting.Size = new Size(100, 50);
            bSetting.TabIndex = 10;
            bSetting.Text = "Настройки";
            bSetting.UseVisualStyleBackColor = true;
            bSetting.Click += bSetting_Click;
            // 
            // fTaskManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 562);
            Controls.Add(bSetting);
            Controls.Add(bGlobalStatistics);
            Controls.Add(bProcesses);
            Controls.Add(pProceses);
            Controls.Add(pSetting);
            Controls.Add(pGlobalStatistics);
            DoubleBuffered = true;
            MaximizeBox = false;
            Name = "fTaskManager";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvProcesses).EndInit();
            pProceses.ResumeLayout(false);
            pProceses.PerformLayout();
            pGlobalStatistics.ResumeLayout(false);
            pGlobalStatistics.PerformLayout();
            pSetting.ResumeLayout(false);
            pSetting.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProcesses;
        private System.Windows.Forms.Timer tUpdate;
        private Panel pProceses;
        private Button bProcesses;
        private Button bGlobalStatistics;
        private Panel pGlobalStatistics;
        private Button bKillProcess;
        private Button bChangeVisableColumns;
        private TextBox tbSearch;
        private Panel pMainGraph;
        private TextBox tbMainGraph;
        private Panel pRam;
        private Panel pCpu;
        private TextBox tbRam;
        private TextBox tbCpu;
        private Panel pSetting;
        private Button bSetting;
        private TextBox tbLanguage;
        private ComboBox cbLanguage;
        private ComboBox cbUpdateTime;
        private TextBox tbUpdateTime;
    }
}