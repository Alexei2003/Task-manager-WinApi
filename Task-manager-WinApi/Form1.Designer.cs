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
            tProcessesUpdate = new System.Windows.Forms.Timer(components);
            pProceses = new Panel();
            bProcesses = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgProcesses).BeginInit();
            pProceses.SuspendLayout();
            SuspendLayout();
            // 
            // dvgProcesses
            // 
            dvgProcesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgProcesses.Location = new Point(10, 10);
            dvgProcesses.MultiSelect = false;
            dvgProcesses.Name = "dvgProcesses";
            dvgProcesses.RowHeadersWidth = 45;
            dvgProcesses.RowTemplate.Height = 27;
            dvgProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgProcesses.Size = new Size(780, 430);
            dvgProcesses.TabIndex = 0;
            dvgProcesses.CellContentClick += dvgProcesses_CellContentClick;
            // 
            // tProcessesUpdate
            // 
            tProcessesUpdate.Interval = 5000;
            tProcessesUpdate.Tick += tProcessesUpdate_Tick;
            // 
            // pProceses
            // 
            pProceses.Controls.Add(dvgProcesses);
            pProceses.Location = new Point(0, 50);
            pProceses.Name = "pProceses";
            pProceses.Size = new Size(800, 450);
            pProceses.TabIndex = 1;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1389, 686);
            Controls.Add(bProcesses);
            Controls.Add(pProceses);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dvgProcesses).EndInit();
            pProceses.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dvgProcesses;
        private System.Windows.Forms.Timer tProcessesUpdate;
        private Panel pProceses;
        private Button bProcesses;
    }
}