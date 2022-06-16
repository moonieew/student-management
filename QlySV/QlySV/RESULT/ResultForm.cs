using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlySV.RESULT
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            RESULTS result = new RESULTS();
            dtgridview.DataSource = result.GetListStudent("");
        }

        private void dtgridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgridview.CurrentCell.RowIndex;
            txb_studentID.Text = dtgridview.Rows[index].Cells[0].Value.ToString();
            txb_fName.Text = dtgridview.Rows[index].Cells[1].Value.ToString();
            txb_lName.Text = dtgridview.Rows[index].Cells[2].Value.ToString();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            RESULTS result = new RESULTS();
            dtgridview.DataSource = result.GetListStudent(txb_search.Text);
            txb_search.ResetText();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        Bitmap bmp;
        private void btn_print_Click(object sender, EventArgs e)
        {
            //dlg.ShowDialog(); //Hiển thị hộp thoại PrintDialog

            //cau hinh trang
            int height = dtgridview.Height;
            dtgridview.Height = dtgridview.RowCount * dtgridview.RowTemplate.Height * 2;

            //Chuyen datagridview ve file Bitmap de doc hinh anh
            bmp = new Bitmap(dtgridview.Width, dtgridview.Height);
            dtgridview.DrawToBitmap(bmp, new Rectangle(0, 0, dtgridview.Width, dtgridview.Height));
            dtgridview.Height = height;

            //chon ok thi in
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            else
            {
                MessageBox.Show("Cancel printing!");
            }
        }
    }
}
