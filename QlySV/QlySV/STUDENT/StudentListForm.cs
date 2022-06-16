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
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();
        private void StudentListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mY_DBDataSet.std' table. You can move, or remove it, as needed.
            //this.stdTableAdapter.Fill(this.mY_DBDataSet.std);
            SqlCommand command = new SqlCommand("SELECT * FROM std");
            DataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridView1.RowTemplate.Height = 80;
            DataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;
        }

        private void bt_Refresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM std");
            DataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridView1.RowTemplate.Height = 80;
            DataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updateDeleStdF = new UpdateDeleteStudentForm();
            updateDeleStdF.TextBox_ID.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDeleStdF.TextBox_FirstName.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDeleStdF.TextBox_LastName.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            //updateDeleStdF.DateTimePicker1.Value = (Datatime)DataGridView1.CurrentRow.Cells[3].Value;
            DateTime date = (DateTime)DataGridView1.CurrentRow.Cells[3].Value;
            if ((DataGridView1.CurrentRow.Cells[4].Value.ToString()=="Female"))
            {
                updateDeleStdF.RadioButton_Female.Checked = true;   
            }
            updateDeleStdF.TextBox_Phone.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            updateDeleStdF.TextBox_Address.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            byte[] pic;
            pic = (byte[])DataGridView1.CurrentRow.Cells[7].Value;
            System.IO.MemoryStream picture = new MemoryStream(pic);
            updateDeleStdF.pictureBox1.Image = Image.FromStream(picture);
            updateDeleStdF.Show();
        }
    }
}
