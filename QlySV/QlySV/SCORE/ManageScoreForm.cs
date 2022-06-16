using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlySV
{
    public partial class ManageScoreForm : Form
    {
        public ManageScoreForm()
        {
            InitializeComponent();
        }
        SCORES score = new SCORES();
        STUDENT student = new STUDENT();
        COURSES course = new COURSES();
        string data = "score";

        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = score.getStudentsScore();
            comboBoxSelect.DataSource = course.getAllCourses();
            comboBoxSelect.DisplayMember = "label";
            comboBoxSelect.ValueMember = "id";
        }

        private void buttonShowStudent_Click(object sender, EventArgs e)
        {
            data = "std";
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate FROM std");
            dataGridView1.DataSource = student.getStudents(command);
        }

        private void buttonShowScore_Click(object sender, EventArgs e)
        {
            data = "score";
            dataGridView1.DataSource = score.getStudentsScore();
        }
        void getDataFromDatagridView()
        {
            if (data == "std")
            {
                textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            else if (data=="score")
            {
                textBoxID.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBoxSelect.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDatagridView();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(textBoxID.Text);
                int courseID = Convert.ToInt32(comboBoxSelect.SelectedValue);
                float scoreValue = Convert.ToInt32(textBoxScore.Text);
                string description = textBoxDes.Text;
                if (!score.studentScoreExist(studentID, courseID))
                {
                    if (score.insertScore(studentID, courseID, scoreValue, description))
                    {
                        MessageBox.Show("Student score insert", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student score not insert", "And Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The score for this course are already set", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            SCORES score = new SCORES();
            try
            {
                int courseID = Convert.ToInt32(comboBoxSelect.Text);
                int studentID = Convert.ToInt32(textBoxID.Text);
                if ((MessageBox.Show("Are you sure want to delete this course", "Remove course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (score.deleteScore(studentID, courseID))
                    {
                        MessageBox.Show("Course deleted", "Remove course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Course not deleted", "Remove course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter a valid numeric id", "Remove course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAvg_Click(object sender, EventArgs e)
        {
            AvgScoreByCouseForm AvgF = new AvgScoreByCouseForm();
            AvgF.Show(this);
        }
    }
}
