﻿namespace Task_manager_WinApi
{
    partial class fChangeVisableColumns
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bOk = new Button();
            SuspendLayout();
            // 
            // bOk
            // 
            bOk.Location = new Point(90, 218);
            bOk.Name = "bOk";
            bOk.Size = new Size(100, 50);
            bOk.TabIndex = 8;
            bOk.Text = "Схранить";
            bOk.UseVisualStyleBackColor = true;
            bOk.Click += bOk_Click;
            // 
            // fChangeVisableColumns
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 630);
            Controls.Add(bOk);
            Name = "fChangeVisableColumns";
            Text = "ChangeVisableColumns";
            ResumeLayout(false);
        }

        #endregion

        private Button bOk;
    }
}