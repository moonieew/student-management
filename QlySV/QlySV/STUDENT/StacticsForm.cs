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
    public partial class StacticsForm : Form
    {
        public StacticsForm()
        {
            InitializeComponent();
        }
        Color panTotalColor;
        Color panMaleColor;
        Color panFemaleColor;
        private void StacticsForm_Load(object sender, EventArgs e)
        {
            panTotalColor = PanelTotal.BackColor;
            panMaleColor = PanelMale.BackColor;
            panFemaleColor = PanelFemale.BackColor;
            STUDENT student = new STUDENT();
            double total = Convert.ToDouble(student.totalStudent());
            double totalMale = Convert.ToDouble(student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(student.totalFemaleStudent());
            double maleStudentsPercentage = (totalMale * (100 / total));
            double femaleStudentsPercentage = (totalFemale * (100 / total));
            LabelTotal.Text = "Total Students: ";//("Total Students: "+ total.ToString());
            LabelMale.Text = ("Male: " + (maleStudentsPercentage.ToString("0.00")+"%"));
            LabelFemale.Text = ("Female: " + (femaleStudentsPercentage.ToString("0.00") + "%"));


        }

        private void StacticsForm_Load_1(object sender, EventArgs e)
        {
            panTotalColor = PanelTotal.BackColor;
            panMaleColor = PanelMale.BackColor;
            panFemaleColor = PanelFemale.BackColor;
            STUDENT student = new STUDENT();
            double total = Convert.ToDouble(student.totalStudent());
            double totalMale = Convert.ToDouble(student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(student.totalFemaleStudent());
            double maleStudentsPercentage = (totalMale * (100 / total));
            double femaleStudentsPercentage = (totalFemale * (100 / total));
            LabelTotal.Text = ("Total Students: "+ total.ToString());
            LabelMale.Text = ("Male: " + (maleStudentsPercentage.ToString("0.00") + "%"));
            LabelFemale.Text = ("Female: " + (femaleStudentsPercentage.ToString("0.00") + "%"));

        }

        private void LabelTotal_MouseEnter(object sender, EventArgs e)
        {
            LabelTotal.ForeColor = panTotalColor;
            PanelTotal.BackColor = Color.White;
        }

        private void LabelTotal_MouseLeave(object sender, EventArgs e)
        {
            LabelTotal.ForeColor = Color.White;
            PanelTotal.BackColor = panTotalColor;
        }

        private void LabelMale_MouseLeave(object sender, EventArgs e)
        {
            LabelMale.ForeColor = panMaleColor;
            PanelMale.BackColor = Color.White;
        }

        private void LabelFemale_MouseEnter(object sender, EventArgs e)
        {
            LabelFemale.ForeColor = panFemaleColor;
            PanelFemale.BackColor = Color.White;
        }

        private void LabelFemale_MouseLeave(object sender, EventArgs e)
        {
            LabelFemale.ForeColor = Color.White;
            PanelFemale.BackColor = panFemaleColor;
        }
    }
}
