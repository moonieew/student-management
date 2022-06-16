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
    public partial class RemoveCourseForm : Form
    {
        public RemoveCourseForm()
        {
            InitializeComponent();
        }

        private void buttonRemoveCourse_Click(object sender, EventArgs e)
        {
            COURSES course = new COURSES();
            try
            {
                int courseID = Convert.ToInt32(textBoxSearchCourse.Text);
                if ((MessageBox.Show("Are you sure want to delete this course", "Remove course", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes))
                {
                    if (course.deleteCourse(courseID))
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
