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
            bKillProcess = new Button();
            bProcesses = new Button();
            bGlobalStatistics = new Button();
            pGlobalStatistics = new Panel();
            button1 = new Button();
            pDevicesInfo = new Panel();
            button2 = new Button();
            bDevicesInfo = new Button();
            bChangeVisableColumns = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgProcesses).BeginInit();
            pProceses.SuspendLayout();
            pGlobalStatistics.SuspendLayout();
            pDevicesInfo.SuspendLayout();
            SuspendLayout();
            // 
            // dvgProcesses
            // 
            dvgProcesses.AllowUserToAddRows = false;
            dvgProcesses.AllowUserToDeleteRows = false;
            dvgProcesses.AllowUserToOrderColumns = true;
            dvgProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dvgProcesses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dvgProcesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgProcesses.Location = new Point(10, 10);
            dvgProcesses.MultiSelect = false;
            dvgProcesses.Name = "dvgProcesses";
            dvgProcesses.ReadOnly = true;
            dvgProcesses.RowHeadersWidth = 5;
            dvgProcesses.RowTemplate.Height = 27;
            dvgProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgProcesses.Size = new Size(780, 361);
            dvgProcesses.TabIndex = 0;
            dvgProcesses.CellContentClick += dvgProcesses_CellContentClick;
            // 
            // tUpdate
            // 
            tUpdate.Interval = 5000;
            tUpdate.Tick += tUpdate_Tick;
            // 
            // pProceses
            // 
            pProceses.Controls.Add(bChangeVisableColumns);
            pProceses.Controls.Add(bKillProcess);
            pProceses.Controls.Add(dvgProcesses);
            pProceses.Location = new Point(0, 50);
            pProceses.Name = "pProceses";
            pProceses.Size = new Size(800, 450);
            pProceses.TabIndex = 1;
            // 
            // bKillProcess
            // 
            bKillProcess.Location = new Point(10, 388);
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
            pGlobalStatistics.Location = new Point(806, 50);
            pGlobalStatistics.Name = "pGlobalStatistics";
            pGlobalStatistics.Size = new Size(800, 450);
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
            // pDevicesInfo
            // 
            pDevicesInfo.Controls.Add(button2);
            pDevicesInfo.Location = new Point(0, 506);
            pDevicesInfo.Name = "pDevicesInfo";
            pDevicesInfo.Size = new Size(800, 450);
            pDevicesInfo.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(407, 153);
            button2.Name = "button2";
            button2.Size = new Size(83, 25);
            button2.TabIndex = 0;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // bDevicesInfo
            // 
            bDevicesInfo.Location = new Point(222, 0);
            bDevicesInfo.Name = "bDevicesInfo";
            bDevicesInfo.Size = new Size(100, 50);
            bDevicesInfo.TabIndex = 5;
            bDevicesInfo.Text = "Устройства";
            bDevicesInfo.UseVisualStyleBackColor = true;
            bDevicesInfo.Click += bDevicesInfo_Click;
            // 
            // bChangeVisableColumns
            // 
            bChangeVisableColumns.Location = new Point(116, 388);
            bChangeVisableColumns.Name = "bChangeVisableColumns";
            bChangeVisableColumns.Size = new Size(100, 50);
            bChangeVisableColumns.TabIndex = 7;
            bChangeVisableColumns.Text = "Скрыть столбцы";
            bChangeVisableColumns.UseVisualStyleBackColor = true;
            bChangeVisableColumns.Click += bChangeVisableColumns_Click;
            // 
            // TaskManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1623, 985);
            Controls.Add(bDevicesInfo);
            Controls.Add(pDevicesInfo);
            Controls.Add(bGlobalStatistics);
            Controls.Add(pGlobalStatistics);
            Controls.Add(bProcesses);
            Controls.Add(pProceses);
            DoubleBuffered = true;
            Name = "TaskManager";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dvgProcesses).EndInit();
            pProceses.ResumeLayout(false);
            pGlobalStatistics.ResumeLayout(false);
            pDevicesInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dvgProcesses;
        private System.Windows.Forms.Timer tUpdate;
        private Panel pProceses;
        private Button bProcesses;
        private Button bGlobalStatistics;
        private Panel pGlobalStatistics;
        private Panel pDevicesInfo;
        private Button bDevicesInfo;
        private Button button1;
        private Button button2;
        private Button bKillProcess;
        private Button bChangeVisableColumns;
    }
}