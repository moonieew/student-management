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
//using COURSE;
namespace QlySV
{
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
        }
        SCORES score = new SCORES();
        STUDENT student = new STUDENT();
        COURSES course = new COURSES();
        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            comboBoxSelect.DataSource = course.getAllCourses();
            comboBoxSelect.DisplayMember = "label";
            comboBoxSelect.ValueMember = "id";
            SqlCommand command = new SqlCommand("SELECT id, fname, lname FROM std");
            dataGridView1.DataSource = student.getStudents(command);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void buttonAddScore_Click(object sender, EventArgs e)
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
    }
}
