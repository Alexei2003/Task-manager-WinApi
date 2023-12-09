namespace Task_manager_WinApi
{
    partial class TaskManager
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
            dvgProcesses = new DataGridView();
            tUpdate = new System.Windows.Forms.Timer(components);
            pProceses = new Panel();
            tbSearch = new TextBox();
            bChangeVisableColumns = new Button();
            bKillProcess = new Button();
            bProcesses = new Button();
            bGlobalStatistics = new Button();
            pGlobalStatistics = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgProcesses).BeginInit();
            pProceses.SuspendLayout();
            pGlobalStatistics.SuspendLayout();
            SuspendLayout();
            // 
            // dvgProcesses
            // 
            dvgProcesses.AllowUserToAddRows = false;
            dvgProcesses.AllowUserToDeleteRows = false;
            dvgProcesses.AllowUserToOrderColumns = true;
            dvgProcesses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dvgProcesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgProcesses.Location = new Point(10, 43);
            dvgProcesses.MultiSelect = false;
            dvgProcesses.Name = "dvgProcesses";
            dvgProcesses.ReadOnly = true;
            dvgProcesses.RowHeadersWidth = 5;
            dvgProcesses.RowTemplate.Height = 27;
            dvgProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgProcesses.Size = new Size(1180, 389);
            dvgProcesses.TabIndex = 0;
            dvgProcesses.CellClick += dvgProcesses_CellClick;
            // 
            // tUpdate
            // 
            tUpdate.Interval = 3000;
            tUpdate.Tick += tUpdate_Tick;
            // 
            // pProceses
            // 
            pProceses.Controls.Add(tbSearch);
            pProceses.Controls.Add(bChangeVisableColumns);
            pProceses.Controls.Add(bKillProcess);
            pProceses.Controls.Add(dvgProcesses);
            pProceses.Location = new Point(0, 50);
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
            bChangeVisableColumns.Text = "Скрыть столбцы";
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
            pGlobalStatistics.Controls.Add(button1);
            pGlobalStatistics.Location = new Point(0, 556);
            pGlobalStatistics.Name = "pGlobalStatistics";
            pGlobalStatistics.Size = new Size(1200, 450);
            pGlobalStatistics.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(266, 230);
            button1.Name = "button1";
            button1.Size = new Size(83, 25);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // TaskManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 1021);
            Controls.Add(bGlobalStatistics);
            Controls.Add(pGlobalStatistics);
            Controls.Add(bProcesses);
            Controls.Add(pProceses);
            DoubleBuffered = true;
            Name = "TaskManager";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dvgProcesses).EndInit();
            pProceses.ResumeLayout(false);
            pProceses.PerformLayout();
            pGlobalStatistics.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dvgProcesses;
        private System.Windows.Forms.Timer tUpdate;
        private Panel pProceses;
        private Button bProcesses;
        private Button bGlobalStatistics;
        private Panel pGlobalStatistics;
        private Button button1;
        private Button bKillProcess;
        private Button bChangeVisableColumns;
        private TextBox tbSearch;
    }
}