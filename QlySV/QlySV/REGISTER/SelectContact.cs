using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlySV
{
    public partial class SelectContact : Form
    {
        private int uid;
        public SelectContact(int id)
        {
            InitializeComponent();
            uid = id;

        }

        private void SelectContact_Load(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            SqlCommand command = new SqlCommand("SELECT  Id ,  fname,  lname,  groupid   FROM  [Contact]  WHERE  userid  = @uid");
            command.Parameters.Add("@uid", SqlDbType.Int).Value = uid;
            dataGridView1.DataSource = contact.SelectContactList(command);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
