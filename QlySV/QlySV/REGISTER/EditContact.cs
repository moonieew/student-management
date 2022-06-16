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
    public partial class EditContact : Form
    {
        public EditContact()
        {
            InitializeComponent();
        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            GROUP group = new GROUP();
            comboBox1.DataSource = group.getGroups(GlobalUserID.UserID);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Seclect Image(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();

            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string email = textBoxEmail.Text;

            try
            {
                int id = Convert.ToInt32(textBoxId.Text);

                int groupid = (int)comboBox1.SelectedValue;

                MemoryStream pic = new MemoryStream();
                try
                {
                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                }
                catch (Exception ex)
                {

                }
                

                if (contact.UpdateContact(id, fname, lname, phone, address, email, groupid, pic))
                {
                    MessageBox.Show("Contact Inormation UpDated", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SelectContact SelectContactF = new SelectContact(Convert.ToInt32(textBoxId.Text));
            SelectContactF.ShowDialog();

            try
            {

                int contactId = Convert.ToInt32(SelectContactF.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                
                Contact contact = new Contact();
                DataTable table = contact.GetContactById(contactId);
                textBoxId.Text = table.Rows[0]["Id"].ToString();
                textBoxFname.Text = table.Rows[0]["fname"].ToString();
                textBoxLname.Text = table.Rows[0]["lname"].ToString();
                comboBox1.SelectedValue = table.Rows[0]["groupid"];
                textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                textBoxEmail.Text = table.Rows[0]["email"].ToString();
                textBoxAddress.Text = table.Rows[0]["address"].ToString();
                
                byte[] pic = (byte[])table.Rows[0]["pic"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);

            }
            catch (Exception)
            {
                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

