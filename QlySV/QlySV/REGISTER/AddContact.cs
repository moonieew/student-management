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
    public partial class AddContact : Form
    {
        public AddContact()
        {
            InitializeComponent();
        }
        bool verif()
        {
            if ((textBoxFname.Text.Trim() == "")
                            || (textBoxLname.Text.Trim() == "")
                            || (textBoxPhone.Text.Trim() == "")
                            || (textBoxEmail.Text.Trim() == "")
                            || (textBoxAddress.Text.Trim() == "")
                            || (pictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Seclect Image(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        Contact contact = new Contact();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string phone = textBoxPhone.Text;
            string adr = textBoxAddress.Text;
            string email = textBoxEmail.Text;
            int userId = GlobalUserID.UserID;  
            try
            {
                int groupId = Convert.ToInt32(cbb_groupList.SelectedValue);
                MemoryStream pic = new MemoryStream();
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                if (contact.checkID(Convert.ToInt32(textBoxID.Text)))
                {
                    if (contact.InsertContact(fname, lname, phone, adr, email, userId, groupId, pic))
                    {
                        MessageBox.Show("New Contact Added", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }   
                    else
                    {
                        MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This ID ALready Exists, Try Another One", "Invalid ID", MessageBoxButtons
                        .OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("One Or More Fields Are Empty", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
        GROUP group = new GROUP();
        private void AddContact_Load(object sender, EventArgs e)
        {
            cbb_groupList.DataSource =group.getGroups(GlobalUserID.UserID);
            cbb_groupList.DisplayMember = "Name";
            cbb_groupList.ValueMember = "Id";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string phone = textBoxPhone.Text;
            string adr = textBoxAddress.Text;
            string email = textBoxEmail.Text;
            int userId = GlobalUserID.UserID;
            try
            {
                int groupId = Convert.ToInt32(cbb_groupList.SelectedValue);
                MemoryStream pic = new MemoryStream();
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                if (contact.checkID(Convert.ToInt32(textBoxID.Text)))
                {
                    if (contact.InsertContact(fname, lname, phone, adr, email, userId, groupId, pic))
                    {
                        MessageBox.Show("New Contact Added", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This ID ALready Exists, Try Another One", "Invalid ID", MessageBoxButtons
                        .OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("One Or More Fields Are Empty", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } 
}
