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
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(textBoxCourseID.Text);
            string name = textBoxLabel.Text;
            int hour = Convert.ToInt32(textBoxPeriod.Text);
            string des = textBoxDes.Text;
            COURSES course = new COURSES();
            if (hour<10 || hour >35)
            {
                MessageBox.Show("Period Course must be between 10 and 35 hours", "Invalid hours", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (name.Trim() == "")
                {
                    MessageBox.Show("Add a course name", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            else if (course.checkCourseName(name))
            {
                if (course.insertCourse(cid, name, hour, des))
                {
                    MessageBox.Show("New course inserted", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Course not inserted", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("This course name already exists", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(textBoxCourseID.Text);
            string name = textBoxLabel.Text;
            int hour = Convert.ToInt32(textBoxPeriod.Text);
            string des = textBoxDes.Text;
            COURSES course = new COURSES();
            if (hour < 10 || hour > 35)
            {
                MessageBox.Show("Period Course must be between 10 and 35 hours", "Invalid hours", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (name.Trim() == "")
            {
                MessageBox.Show("Add a course name", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (course.checkCourseName(name))
            {
                if (course.insertCourse(cid, name, hour, des))
                {
                    MessageBox.Show("New course inserted", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Course not inserted", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("This course name already exists", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
        }
    }
}
