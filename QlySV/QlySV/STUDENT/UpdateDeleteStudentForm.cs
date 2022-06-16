using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlySV
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();

        private void Bt_Find_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TextBox_ID.Text);
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = " + id);
            DataTable table = student.getStudents(command);
            if (table.Rows.Count>0)
            {
                TextBox_FirstName.Text = table.Rows[0]["fname"].ToString();
                TextBox_LastName.Text = table.Rows[0]["lname"].ToString();
                DateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];
                if (table.Rows[0]["gender"].ToString()=="Female")
                {
                    RadioButton_Female.Checked = true;
                }
                else
                {
                    RadioButton_male.Checked = true;
                }
                TextBox_Phone.Text = table.Rows[0]["phone"].ToString();
                TextBox_Address.Text = table.Rows[0]["address"].ToString();
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TextBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Bt_uploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog()==DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void bt_Remove_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            try
            {
                int studentId = Convert.ToInt32(TextBox_ID.Text);
                if ((MessageBox.Show("Are you sure you want to delete this student", "Delete student",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes))
                {
                    if (student.deleteStudent(studentId))
                    {
                        MessageBox.Show("Student deleted", "Delete student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBox_ID.Text = "";
                        TextBox_FirstName.Text = "";
                        TextBox_LastName.Text = "";
                        TextBox_Address.Text = "";
                        TextBox_Phone.Text = "";
                        DateTimePicker1.Value = DateTime.Now;
                        pictureBox1.Image = null;
                  
                    }
                    else
                    {
                        MessageBox.Show("Student not deleted", "Delete student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
            }
            catch
            {
                MessageBox.Show("Please enter a valid id", "Delete student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        bool verif()
        {
            if ((TextBox_ID.Text.Trim()=="")
                        || (TextBox_FirstName.Text.Trim()=="")
                        || (TextBox_LastName.Text.Trim()=="")
                        || (TextBox_Address.Text.Trim()=="")
                        || (TextBox_Phone.Text.Trim()=="")
                        || (pictureBox1.Image==null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = TextBox_FirstName.Text;
            string lname = TextBox_LastName.Text;
            DateTime bdate = DateTimePicker1.Value;
            string phone = TextBox_Phone.Text;
            string adrs = TextBox_Address.Text;
            string gender = "Male";
            if (RadioButton_Female.Checked)
            {
                gender = "Female";
            }
            STUDENT student = new STUDENT();
            MemoryStream pic = new MemoryStream();
            int born_year = DateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year-born_year)<10)||((this_year-born_year)>100))
            {
                MessageBox.Show("The student age must be between 10 and 100 year", "Birth date error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(TextBox_ID.Text);
                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if (student.updateStudent(id, fname, lname, bdate, gender, phone, adrs, pic))
                    {
                        MessageBox.Show("Student information update", "Edit student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty fields", "Edit student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM std WHERE id=@id", MY_DB.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            MY_DB db = new MY_DB();
            db.openConnection();
            if ((command.ExecuteNonQuery()==1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool updateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn,lname=@ln,bdate=@bdt,gender=@gdr,phone=@phn,ad" + "dress=@adrs,picture=@pic WHERE id=@ID", MY_DB.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            MY_DB mydb = new MY_DB();
            mydb.openConnection();
            if ((command.ExecuteNonQuery()==1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
