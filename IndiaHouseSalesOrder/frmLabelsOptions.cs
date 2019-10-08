using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IndiaHouseSalesOrder.Properties;

namespace IndiaHouseSalesOrder
{
    public partial class frmLabelsOptions : Form
    {
        public frmLabelsOptions()
        {
            InitializeComponent();
        }

        private void frmLabelsOptions_Load(object sender, EventArgs e)
        {
            txtItemBartenderFileLocation.Text = Settings.Default.BartenderFileLocation15x2;
            txtItemBartender2x2FileLocation.Text = Settings.Default.BartenderFileLocation2x2;
            txtItemExcelDataSourceLocation.Text = Settings.Default.ExcelDataSourceLocation;

            txtCustomerBartenderFileLocation.Text = Settings.Default.CustomerLabelBartenderFileLoc;
            txtCustomerExcelDataSourceLocation.Text = Settings.Default.CustomerLabelExcelFileLoc;
        }

        private void btnSaveOptions_Click(object sender, EventArgs e)
        {
            Settings.Default.BartenderFileLocation15x2 = txtItemBartenderFileLocation.Text;
            Settings.Default.BartenderFileLocation2x2 = txtItemBartender2x2FileLocation.Text;
            Settings.Default.ExcelDataSourceLocation = txtItemExcelDataSourceLocation.Text;

            Settings.Default.CustomerLabelBartenderFileLoc = txtCustomerBartenderFileLocation.Text;
            Settings.Default.CustomerLabelExcelFileLoc = txtCustomerExcelDataSourceLocation.Text;

            Settings.Default.Save();

            MessageBox.Show("Settings Saved Successful");
        }

        OpenFileDialog bartenderFileDialog = new OpenFileDialog();
        private void btnBrowseBartenderFile_Click(object sender, EventArgs e)
        {
            bartenderFileDialog.Filter = "Bartender File (*.btw)|*.btw";
            if (bartenderFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtItemBartenderFileLocation.Text = bartenderFileDialog.FileName;
            }
        }

        OpenFileDialog excelDataSourceFileDialog = new OpenFileDialog();
        private void btnBrowseExcelDataSource_Click(object sender, EventArgs e)
        {
            excelDataSourceFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
            if (excelDataSourceFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtItemExcelDataSourceLocation.Text = excelDataSourceFileDialog.FileName;
            }
        }

        OpenFileDialog bartender2x2FileDialog = new OpenFileDialog();

        private void btnBrowseBartender2x2File_Click(object sender, EventArgs e)
        {
            bartender2x2FileDialog.Filter = "Bartender File (*.btw)|*.btw";
            if (bartender2x2FileDialog.ShowDialog() == DialogResult.OK)
            {
                txtItemBartender2x2FileLocation.Text = bartender2x2FileDialog.FileName;
            }
        }
    }
}