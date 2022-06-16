using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlySV
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            if (progressBar1.Enabled == true)
            {
                progressBar1.Enabled = false;               
                timer1.Start();
            }
            else
            {
                progressBar1.Enabled = true;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = false;
                Close();
            }
        }
    }
}
