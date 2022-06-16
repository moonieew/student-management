using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QlySV
{
    public partial class ShowFullList : Form
    {
        public ShowFullList()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        private void ShowFullList_Load(object sender, EventArgs e)
        {
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            Contact contact = new Contact();
            SqlCommand command = new SqlCommand("SELECT fname, lname, [Group].Name, phone, email, address, pic FROM [Contact] INNER JOIN [Group] on [Contact].groupid = [Group].Id ");/*WHERE [Contact].userid=@userid*/
            //command.Parameters.Add("@userid", SqlDbType.Int).Value = GlobalUserID.UserID;

            dataGridView1.DataSource = contact.SelectContactList(command);
            
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            for (int i=0;i<dataGridView1.Rows.Count;i++)
            {
                if (Isodd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
            GROUP group = new GROUP();
            listBox1.DataSource = group.getGroups(GlobalUserID.UserID);
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "id";
            listBox1.SelectedItem = null;
            dataGridView1.ClearSelection();
            mydb.openConnection();
            try 
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Ok", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch { }
        }
        public static bool Isodd(int value)
        {
            return value % 2 != 0;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i=0;i<dataGridView1.Rows.Count;i++)
            {
                if (Isodd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Contact contact = new Contact();
                int groupid = (Int32)listBox1.SelectedValue;
                SqlCommand command = new SqlCommand("SELECT fname as 'Frist Name', lname as 'Last Name', [Group].name as 'Group', phone, email, address, pic FROM [Contact] INNER JOIN [Group] on [Contact].groupid=[Group].Id WHERE [Contact].Userid=@userid AND [Contact].groupid=@groupid");
                command.Parameters.Add("@groupid", SqlDbType.Int).Value = groupid;
                command.Parameters.Add("@userid", SqlDbType.Int).Value = GlobalUserID.UserID;
                dataGridView1.DataSource = contact.SelectContactList(command);
                for (int i=0;i< dataGridView1.Rows.Count;i++)
                {
                    if (Isodd(i))
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            catch (Exception)
            { }
            dataGridView1.ClearSelection();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ShowFullList_Load(null, null);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxAddress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception)
            { }
        }
    }
}
