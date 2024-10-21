using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AzadUni_Pool
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { // Get the search term from the search TextBox (textBox1)
            string searchTerm = textBox1.Text;

            // Determine which column to search based on the selected RadioButton
            int searchColumn = 1; // Default to Column 1
            if (radioButton1.Checked) searchColumn = 1;
            else if (radioButton2.Checked) searchColumn = 2;
            // Add more columns if needed (continue the pattern)

            // Specify the path to the Excel file
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExcelFiles");
            string filePath = Path.Combine(folderPath, "MyExcelFile.xlsx");

            if (File.Exists(filePath))
            {
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0]; // Access the first worksheet
                    bool found = false;

                    // Loop through the rows in the selected column to find the search term
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Start at row 2 to skip headers
                    {
                        if (worksheet.Cells[row, searchColumn].Text == searchTerm)
                        {
                            // If the search term is found, display data from the corresponding row in the text boxes
                            textBox2.Text = worksheet.Cells[row, 1].Text; // Column 1
                            textBox3.Text = worksheet.Cells[row, 2].Text; // Column 2
                            textBox4.Text = worksheet.Cells[row, 3].Text; // Column 3
                            textBox5.Text = worksheet.Cells[row, 4].Text; // Column 4
                            

                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("مشخصات یافت نشد!");
                    }
                }
            }
            else
            {
                MessageBox.Show("فایل اکسل مشکل دارد");
            }
        }
    }   
}
