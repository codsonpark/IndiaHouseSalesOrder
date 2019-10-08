using IndiaHouse.Core.Models;
using IndiaHouse.Core.Repositories;
using IndiaHouseSalesOrder.Properties;
using IndiaHouseSalesOrder.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndiaHouseSalesOrder
{
    public partial class frmCustomersLabel : Form
    {
        public frmCustomersLabel()
        {
            InitializeComponent();
        }

        private void btnLoadCustomers_Click(object sender, EventArgs e)
        {
            List<Customer> _customers = new List<Customer>();

            CustomersHelper customerHelper = new CustomersHelper(SessionManager.NewQBSession());

            _customers = customerHelper.getAllCustomers();

            _customers = _customers.OrderBy(c => c.AccountNumber).ToList();
            Settings.Default.CachedCustomers = _customers;
            Settings.Default.Save();

            dgCustomers.DataSource = _customers;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmLabelsOptions labelOptions = new frmLabelsOptions();
            labelOptions.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select some items to print.", "No item to print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Customer> _selectedCustomers = new List<Customer>();
            //Get selected items 

            foreach (DataGridViewRow row in dgCustomers.SelectedRows)
            {
                Customer customer = (Customer)row.DataBoundItem;
                _selectedCustomers.Add(customer);
            }

            //Sort list
            _selectedCustomers = _selectedCustomers.OrderBy(x => x.Name).ToList();

            //Export all items to excel
            ExcelExportCustomers exportItems = new ExcelExportCustomers(_selectedCustomers); 

            Process.Start(Settings.Default.CustomerLabelBartenderFileLoc);

        }

        private void dgCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i <= dgCustomers.Rows.Count - 1; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgCustomers.Rows[i].Cells[0];

                if (Convert.ToBoolean(chk.EditedFormattedValue) == true)
                    dgCustomers.Rows[i].Selected = true;
                else
                    dgCustomers.Rows[i].Selected = false;
            }
        }

        private void frmCustomersLabel_Load(object sender, EventArgs e)
        {
            if (Settings.Default.CachedCustomers != null)
                dgCustomers.DataSource = Settings.Default.CachedCustomers;
        }
    }
}
