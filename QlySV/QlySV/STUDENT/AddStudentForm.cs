using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlySV
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void bt_cancel_add_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            int id = Convert.ToInt32(TextBox_ID.Text);
            string fname = TextBox_fname.Text;
            string lname = TextBox_lname.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = TextBox_phone.Text;
            string adrs = TextBox_Address.Text;
            string gender = "Male";
            if (radioButton2.Checked)
            {
                gender = "Female";
            }
            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year-born_year)<10 || (this_year-born_year)>100))
            {
                MessageBox.Show("the student age must be between 10 and 100 year", "Invalid birth date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                if (student.insertStudent(id,fname,lname,bdate,gender,phone,adrs,pic))
                {
                    MessageBox.Show("New student added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
                else
                {
                    MessageBox.Show("Error", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty fields", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if ((TextBox_fname.Text.Trim()=="")
                            || (TextBox_lname.Text.Trim()=="")
                            || (TextBox_Address.Text.Trim()=="")
                            || (TextBox_phone.Text.Trim()=="")
                            || (PictureBoxStudentImage.Image==null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void bt_uploadimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Seclect Image(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if ((opf.ShowDialog()==DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
