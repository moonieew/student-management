using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlySV
{
    public partial class RemoveScoreForm : Form
    {
        public RemoveScoreForm()
        {
            InitializeComponent();
        }
        SCORES score = new SCORES();
        STUDENT student = new STUDENT();
        COURSES course = new COURSES();
        string data = "score";
        string IdStudent;
        string IdCourse;
        void getDataFromDatagridView()
        {
            if (data == "std")
            {
                IdStudent = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            else if (data == "score")
            {
                IdStudent = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                IdCourse = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDatagridView();
        }

        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = score.getStudentsScore();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            SCORES score = new SCORES();
            try
            {
                int courseID = Convert.ToInt32(IdCourse);
                int studentID = Convert.ToInt32(IdStudent);
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
    }
}
