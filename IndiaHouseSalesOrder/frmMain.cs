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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text += (" - " + Application.ProductVersion);

            frmSalesOrder formSalesOrder = new frmSalesOrder();
            formSalesOrder.TopLevel = false;
            formSalesOrder.FormBorderStyle = FormBorderStyle.None;
            formSalesOrder.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(formSalesOrder);
            formSalesOrder.Visible = true;

            frmLabels formItemLabels = new frmLabels();
            formItemLabels.TopLevel = false;
            formItemLabels.FormBorderStyle = FormBorderStyle.None;
            formItemLabels.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(formItemLabels);
            formItemLabels.Visible = true;

            frmCustomersLabel formCustomerLabels = new frmCustomersLabel();
            formCustomerLabels.TopLevel = false;
            formCustomerLabels.FormBorderStyle = FormBorderStyle.None;
            formCustomerLabels.Dock = DockStyle.Fill;
            tabPage3.Controls.Add(formCustomerLabels);
            formCustomerLabels.Visible = true;

            frmCanadaCustomsInvoice formCanadaCustomsInvoice = new frmCanadaCustomsInvoice();
            formCanadaCustomsInvoice.TopLevel = false;
            formCanadaCustomsInvoice.FormBorderStyle = FormBorderStyle.None;
            formCanadaCustomsInvoice.Dock = DockStyle.Fill;
            tabPage4.Controls.Add(formCanadaCustomsInvoice);
            formCanadaCustomsInvoice.Visible = true;

            //frmOrderServer formOrderServer = new frmOrderServer();
            //formOrderServer.TopLevel = false;
            //formOrderServer.FormBorderStyle = FormBorderStyle.None;
            //formOrderServer.Dock = DockStyle.Fill;
            //tabPage5.Controls.Add(formOrderServer);
            //formOrderServer.Visible = true;
        }
    }
}
