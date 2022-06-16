using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QlySV.RESULT;

namespace QlySV
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            
            InitializeComponent();
        }
        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStdF = new AddStudentForm();
            addStdF.Show(this);
        }

        private void addNewStudentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddStudentForm addStdF = new AddStudentForm();
            addStdF.Show(this);
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentListForm StdList = new StudentListForm();
            StdList.Show(this);
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StacticsForm stacticsForm = new StacticsForm();
            stacticsForm.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm edit = new UpdateDeleteStudentForm();
            edit.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStudentForm print = new PrintStudentForm();
            print.Show(this);
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm StdManageF = new ManageStudentForm();
            StdManageF.Show(this);
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourseForm AddCF = new AddCourseForm();
            AddCF.Show(this);
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourseForm RemoveCF = new RemoveCourseForm();
            RemoveCF.Show(this);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourseForm EditCF = new EditCourseForm();
            EditCF.Show(this);
        }

        private void manageCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCourseForm MangeCF = new ManageCourseForm();
            MangeCF.Show(this);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintCourseForm PrintCF = new PrintCourseForm();
            PrintCF.Show(this);
        }
        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm AddSF = new AddScoreForm();
            AddSF.Show(this);
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoreForm ManageSF = new ManageScoreForm();
            ManageSF.Show(this);
        }

        private void avgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvgScoreByCouseForm Avg = new AvgScoreByCouseForm();
            Avg.Show(this);
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm removeS = new RemoveScoreForm();
            removeS.Show(this);
        }

        private void printToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            PrintScoreForm printS = new PrintScoreForm();
            printS.Show(this);
        }

        private void aVGResultByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultForm resultForm = new ResultForm();
            resultForm.ShowDialog();
        }

        private void staticByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticResultForm staticResultForm = new StaticResultForm();
            staticResultForm.Show(this);
        }
    }
}
