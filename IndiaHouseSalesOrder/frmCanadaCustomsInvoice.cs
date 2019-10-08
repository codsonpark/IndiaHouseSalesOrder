using IndiaHouse.Core.Models;
using IndiaHouse.Core.Repositories;
using IndiaHouseSalesOrder;
using IndiaHouseSalesOrder.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndiaHouseSalesOrder
{
    public partial class frmCanadaCustomsInvoice : Form
    {
        public frmCanadaCustomsInvoice()
        {
            InitializeComponent();
        }

        private void btnCreateCustomsInvoice_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please enter an Invoice number");
                return;
            }

            if (txtNumberOfCases.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Number of Cases");
                return;
            }

            if (txtTotalWeight.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Weight");
                return;
            }

            try
            {
                int salesOrder = Convert.ToInt32(txtInvoiceNumber.Text.Trim());
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Please enter numbers only in the Invoice number textbox");
                return;
            }
            try
            {
                InvoiceHelper invoiceHelper = new InvoiceHelper(SessionManager.NewQBSession());
                Invoice invoice = invoiceHelper.Populate(txtInvoiceNumber.Text);

                ExcelExportCanadaCustomsInvoice exporter = new ExcelExportCanadaCustomsInvoice(invoice,
                                            Convert.ToDouble(txtTotalWeight.Text),
                                            Convert.ToInt64(txtNumberOfCases.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region "Key press procedures"
        private void txtInvoiceNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumberOfCases_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTotalWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

    }
}
