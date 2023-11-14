using static Task_manager_WinApi.ProcessesColumns;

namespace Task_manager_WinApi
{
    internal partial class ChangeVisableColumns : Form
    {
        private CheckBox[] checkBoxs;
        private TaskManager taskManager;

        public ChangeVisableColumns(ProcessesColumnsName[] processesColumnWhitchVisable, ProcessesColumns processesColumns, TaskManager taskManager)
        {
            InitializeComponent();
            this.taskManager = taskManager;

            checkBoxs = new CheckBox[processesColumns.Count - 1];

            const int Y_STEP = 30;
            const int X_CHECK_BOX = 10;
            const int Y = 10;

            const int WIDTH_CHECK_BOX = 280;
            const int HEIGHT_CHECK_BOX = 20;


            CheckBox tmpCheckBox;

            for (int i = 0; i < checkBoxs.Length; i++)
            {
                tmpCheckBox = new CheckBox();
                tmpCheckBox.Text = processesColumns.GetColumeName((ProcessesColumnsName)i + 1);
                tmpCheckBox.Location = new Point(X_CHECK_BOX, Y + Y_STEP * i);
                tmpCheckBox.Size = new Size(WIDTH_CHECK_BOX, HEIGHT_CHECK_BOX);
                tmpCheckBox.Name = $"b{i}";
                Controls.Add(tmpCheckBox);

                checkBoxs[i] = tmpCheckBox;
            }

            for (int i = 0; i < checkBoxs.Length; i++)
            {
                if (processesColumnWhitchVisable.Contains((ProcessesColumnsName)i + 1))
                {
                    checkBoxs[i].Checked = true;
                }
            }


            bOk.Location = new Point(bOk.Location.X, checkBoxs.Last().Location.Y + Y_STEP);

            Size = new Size(Size.Width, bOk.Location.Y + bOk.Size.Height * 2);

        }

        private void bOk_Click(object sender, EventArgs e)
        {
            var tmp = new ProcessesColumnsName[checkBoxs.Length + 1];
            int count = 0;

            tmp[count++] = ProcessesColumnsName.Id;

            for (int i = 0; i < checkBoxs.Length; i++)
            {
                if (checkBoxs[i].Checked)
                {
                    tmp[count++] = (ProcessesColumnsName)i + 1;
                }
            }

            Array.Resize(ref tmp, count);


            taskManager.TmpProcessesColumnWhitchVisable = tmp;

            Close();
        }
    }
}
