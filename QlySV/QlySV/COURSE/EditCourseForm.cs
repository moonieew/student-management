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
    public partial class EditCourseForm : Form
    {
        public EditCourseForm()
        {
            InitializeComponent();
        }
        COURSES course = new COURSES();

        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            
            
        }
        public void fillCombo(int index)
        {
            comboBoxCourse.DataSource = course.getAllCourses();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "Id";
            comboBoxCourse.SelectedIndex = index;
        }
        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBoxCourse.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseById(id);
                textBoxCourseName.Text = table.Rows[0][1].ToString();
                numericUpDownHours.Value = Int32.Parse(table.Rows[0][2].ToString());
                textBoxDes.Text = table.Rows[0][3].ToString();
            }
            catch { }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string name = textBoxCourseName.Text;
            int hrs = (int)numericUpDownHours.Value;
            string des = textBoxDes.Text;
            int id = Convert.ToInt32(comboBoxCourse.SelectedValue);
            if (!course.checkCourseName(name, Convert.ToInt32(comboBoxCourse.SelectedValue)))
            {
                MessageBox.Show("This course name already exist", "exit course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (course.updateCourse(id, name, hrs, des))
            {
                MessageBox.Show("Courese update", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Course not update", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditCourseForm_Load_1(object sender, EventArgs e)
        {
            comboBoxCourse.DataSource = course.getAllCourses();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "Id";
            //comboBoxCourse.SelectedItem = null;
        }
    }
}
