using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace QlySV
{
    public partial class PrintCourseForm : Form
    {
        public PrintCourseForm()
        {
            InitializeComponent();
            fillGrid();
        }
        public void fillGrid()
        {
            COURSES course = new COURSES();
            dataGridViewCourse.ReadOnly = true;
            //DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewCourse.RowTemplate.Height = 80;
            dataGridViewCourse.DataSource = course.getAllCourses();
            //picCol = (DataGridViewImageColumn)dataGridViewCourse.Columns[7];
            //picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewCourse.AllowUserToAddRows = false;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        private void buttonToFile_Click(object sender, EventArgs e)
        {
            saveExcelDialog.DefaultExt = "xlsx";
            saveExcelDialog.Filter = "Excel (.xlsx)|*.xlsx";
            saveExcelDialog.ShowDialog();
            _Application app = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            _Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridViewCourse.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewCourse.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridViewCourse.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridViewCourse.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridViewCourse.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs(saveExcelDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
    }
}
