namespace Task_manager_WinApi
{
    partial class Form1
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
            processesName = new DataGridViewTextBoxColumn();
            processesId = new DataGridViewTextBoxColumn();
            processesMemory = new DataGridViewTextBoxColumn();
            tProcessesUpdate = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dvgProcesses).BeginInit();
            SuspendLayout();
            // 
            // dvgProcesses
            // 
            dvgProcesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgProcesses.Columns.AddRange(new DataGridViewColumn[] { processesName, processesId, processesMemory });
            dvgProcesses.Location = new Point(12, 12);
            dvgProcesses.Name = "dvgProcesses";
            dvgProcesses.RowHeadersWidth = 45;
            dvgProcesses.RowTemplate.Height = 27;
            dvgProcesses.Size = new Size(776, 426);
            dvgProcesses.TabIndex = 0;
            dvgProcesses.CellContentClick += dvgProcesses_CellContentClick;
            // 
            // processesName
            // 
            processesName.HeaderText = "Name";
            processesName.MinimumWidth = 6;
            processesName.Name = "processesName";
            processesName.ReadOnly = true;
            processesName.Width = 110;
            // 
            // processesId
            // 
            processesId.HeaderText = "Id";
            processesId.MinimumWidth = 6;
            processesId.Name = "processesId";
            processesId.ReadOnly = true;
            processesId.Width = 110;
            // 
            // processesMemory
            // 
            processesMemory.HeaderText = "Memory";
            processesMemory.MinimumWidth = 6;
            processesMemory.Name = "processesMemory";
            processesMemory.ReadOnly = true;
            processesMemory.Width = 110;
            // 
            // tProcessesUpdate
            // 
            tProcessesUpdate.Interval = 5000;
            tProcessesUpdate.Tick += tProcessesUpdate_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dvgProcesses);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dvgProcesses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dvgProcesses;
        private DataGridViewTextBoxColumn processesName;
        private DataGridViewTextBoxColumn processesId;
        private DataGridViewTextBoxColumn processesMemory;
        private System.Windows.Forms.Timer tProcessesUpdate;
    }
}