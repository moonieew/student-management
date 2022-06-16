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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void lbl_register_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            User user = new User();
            string fname = txb_fName.Text;
            string lname = txb_lName.Text;
            string username = txb_userName.Text;
            string pass = txb_pwd.Text;
            MemoryStream pic = new MemoryStream();
            if (!user.usernameExist(txb_userName.Text,"register"))
            {
                if (user.insertUser(fname, lname, username, pass, pic))
                {
                    MessageBox.Show("Registration compled Succed","OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This Username Already Exists","Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (verif())
            {
                picBox_avatar.Image.Save(pic, picBox_avatar.Image.RawFormat);
                if (user.insertUser(fname, lname, username, pass , pic))
                {
                    MessageBox.Show("New RegisterForm added", "Add Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty fields", "Add Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if ((txb_fName.Text.Trim()== "")
                            || (txb_lName.Text.Trim() == "")
                            || (txb_userName.Text.Trim() == "")
                            || (txb_pwd.Text.Trim() == "")
                            || (picBox_avatar.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btn_uploadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Seclect Image(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                picBox_avatar.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
