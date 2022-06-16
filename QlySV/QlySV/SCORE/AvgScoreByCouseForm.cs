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
    public partial class AvgScoreByCouseForm : Form
    {
        public AvgScoreByCouseForm()
        {
            InitializeComponent();
        }
        SCORES score = new SCORES();

        private void AvgScoreByCouseForm_Load(object sender, EventArgs e)
        {
            dataGridViewAvg.DataSource = score.getAvgScoreByCourse();
        }
    }
}
