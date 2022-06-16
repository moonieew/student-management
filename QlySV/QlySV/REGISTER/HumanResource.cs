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
    public partial class HumanResource : Form
    {
        public HumanResource()
        {
            InitializeComponent();
        }
        public void getImageAndUsername()
        {
            MY_DB mydb = new MY_DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE Id=@uid", mydb.GetConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = GlobalUserID.UserID;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if ((table.Rows.Count>0))
            {
                byte[] pic = (byte[])table.Rows[0]["fig"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
                labelWelcome.Text = "Welcome Back ( " + table.Rows[0]["uname"].ToString() + " )";
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void HumanResource_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
        }

        private void buttonAddContact_Click(object sender, EventArgs e)
        {
            AddContact Ac = new AddContact();
            Ac.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditContact Ec = new EditContact();
            Ec.ShowDialog();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SelectContact Sc = new SelectContact(Convert.ToInt32(textBoxSelectContact.Text));
            Sc.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowFullList Fl = new ShowFullList();
            Fl.ShowDialog();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            try
            {
                int courseID = Convert.ToInt32(textBoxSelectContact.Text);
                if ((MessageBox.Show("Are you sure want to delete this contact", "Remove contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (contact.DeleteContact(courseID))
                    {
                        MessageBox.Show("Contact deleted", "Remove contatc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Contact not deleted", "Remove contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter a valid numeric id", "Remove contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        GROUP group = new GROUP();
        private void groupBox2_Enter(object sender, EventArgs e)
        {
            comboBoxSelectGroup.DataSource = group.getGroups(GlobalUserID.UserID);
            comboBoxSelectGroup.DisplayMember = "Name";
            comboBoxSelectGroup.ValueMember = "Id";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            comboBoxSelect.DataSource = group.getGroups(GlobalUserID.UserID);
            comboBoxSelect.DisplayMember = "Name";
            comboBoxSelect.ValueMember = "Id";
        }

        private void buttonRemoveGroup_Click(object sender, EventArgs e)
        {
            GROUP group= new GROUP();
            try
            {
                int courseID = Convert.ToInt32(comboBoxSelect.SelectedValue);
                if ((MessageBox.Show("Are you sure want to delete this group", "Remove group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (group.deleteGroup(courseID))
                    {
                        MessageBox.Show("Group deleted", "Remove group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Group not deleted", "Remove group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter a valid numeric id", "Remove group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEditGroup_Click(object sender, EventArgs e)
        {
            string name = textBoxNewName.Text;
            int id = (int)comboBoxSelectGroup.SelectedValue;
            if (group.updateGroup(id, name))
            {
                MessageBox.Show("Courese update", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Course not update", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            string name = textBoxAddGroup.Text;
            int userId = GlobalUserID.UserID;
            //int id = Convert.ToInt32(textBoxID.Text);
             
                    if (group.insertGroup( name, userId))
                    {
                        MessageBox.Show("New Group Added", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                
            
        }
    }
}
