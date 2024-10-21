using System.Diagnostics;

namespace AzadUni_Pool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Specify the path to the Excel file
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExcelFiles");
            string filePath = Path.Combine(folderPath, "MyExcelFile.xlsx");

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Open the Excel file using the default program (Excel)
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm2 = new Form4();
            frm2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm4 = new Form5();
            frm4.ShowDialog();
        }
    }
}
