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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            if (radio_Student.Checked)
            {
                MY_DB db = new MY_DB();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("SELECT * FROM login WHERE username = @User AND password=@Pass", db.GetConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    //MessageBox.Show("OK, next time will be go to Main Menu of App");
                    int userid = Convert.ToInt16(table.Rows[0][0].ToString());
                    GlobalUserID.SetGlobalUserID(userid);
                    FormLoading frm2 = new FormLoading();
                    frm2.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                    MainForm mf = new MainForm();
                    mf.ShowDialog();
                    //Form1 flogin = new Form1();
                    //if (flogin.ShowDialog() == DialogResult.OK)
                    //{ Application.Run(new MainForm()); }
                    //else
                   // { Application.Exit(); }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //db.closeConnection();
            }
            else if (radio_HR.Checked)
            {
                MY_DB db = new MY_DB();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE uname = @User AND pwd=@Pass", db.GetConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    //MessageBox.Show("OK, next time will be go to Main Menu of App");
                    int userid = Convert.ToInt16(table.Rows[0][0].ToString());
                    GlobalUserID.SetGlobalUserID(userid);
                    //FormLoading frm2 = new FormLoading();
                    //frm2.ShowDialog();
                    //HumanResource hr = new HumanResource();
                    //hr.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                    HumanResource hr = new HumanResource();
                    hr.ShowDialog();
                    //Form1 flogin = new Form1();
                    //if (flogin.ShowDialog() == DialogResult.OK)
                    //{ Application.Run(new HumanResource()); }
                    //else
                    //{ Application.Exit(); }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //db.closeConnection();
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                bt_Login_Click(sender, e);
            }
        }

        private void lbl_register_Click(object sender, EventArgs e)
        {
            // show sign up form
            RegisterForm RF = new RegisterForm();
            RF.ShowDialog();
        }
    }
}
