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
    public partial class StaticResultForm : Form
    {
        public StaticResultForm()
        {
            InitializeComponent();
        }
        SCORES score = new SCORES();
        RESULTS result = new RESULTS(); 
        private void StaticResultForm_Load(object sender, EventArgs e)
        {
            dataGridViewCourse.DataSource = score.getAvgScoreByCourse();
            dataGridViewResult.DataSource = result.getResult("");
        }

    }
}
