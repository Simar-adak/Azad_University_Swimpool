using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Globalization;

namespace AzadUni_Pool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure proper encoding for Persian characters
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // Define the folder and file paths
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExcelFiles");
                Directory.CreateDirectory(folderPath);
                string filePath = Path.Combine(folderPath, "MyExcelFile.xlsx");

                // Use a FileInfo object to handle file operations
                FileInfo fileInfo = new FileInfo(filePath);

                using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    // Retrieve or create worksheet
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Count > 0
                        ? excelPackage.Workbook.Worksheets[0]
                        : excelPackage.Workbook.Worksheets.Add("Sheet1");

                    // Ensure headers are present (run once)
                    EnsureHeaders(worksheet);

                    // Find the next empty row
                    int newRow = FindNextEmptyRow(worksheet);

                    // Write values from text boxes to the row
                    WriteDataToRow(worksheet, newRow);

                    // Save Excel package after modifications
                    excelPackage.Save();
                }

                MessageBox.Show($"Data successfully saved to: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ensure headers in the first row (called once when the file is created)
        private void EnsureHeaders(ExcelWorksheet worksheet)
        {
            string[] headers = {
                "تاریخ",
                "شماره کارمندی",
                "نام و نام خانوادگی",
                "هزینه همراه درجه یک",
                "هزینه همراه درجه دو",
                "هزینه همراه درجه سه"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                if (string.IsNullOrEmpty(worksheet.Cells[1, i + 1].Text))
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }
            }
        }

        // Find the next empty row in the worksheet
        private int FindNextEmptyRow(ExcelWorksheet worksheet)
        {
            int row = 12; // Start after the headers
            while (worksheet.Cells[row, 1].Value != null)
            {
                row++;
            }
            return row;
        }

        // Write data from text boxes into the worksheet
        private void WriteDataToRow(ExcelWorksheet worksheet, int row)
        {
            worksheet.Cells[row, 1].Value = textBox1.Text;
            worksheet.Cells[row, 2].Value = textBox2.Text;
            worksheet.Cells[row, 3].Value = textBox3.Text;
            worksheet.Cells[row, 4].Value = textBox4.Text;
            worksheet.Cells[row, 5].Value = textBox5.Text;
            worksheet.Cells[row, 6].Value = textBox6.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generate Persian calendar date and time
            DateTime now = DateTime.Now;
            PersianCalendar persianCalendar = new PersianCalendar();
            string persianTime = $"{persianCalendar.GetYear(now):0000}/{persianCalendar.GetMonth(now):00}/{persianCalendar.GetDayOfMonth(now):00}";
            textBox1.Text = persianTime;
        }

        // Add these empty event handlers to resolve build errors
        private void Form2_Load(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
    }
}
