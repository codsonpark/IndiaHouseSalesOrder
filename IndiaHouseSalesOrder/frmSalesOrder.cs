using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interop.QBFC13;
using Microsoft.Office;
using IndiaHouseSalesOrder.Properties;
using IndiaHouseSalesOrder.Repositories;
using IndiaHouse.Core.Repositories;
using IndiaHouse.Core.Models;
using IndiaHouse.Core.Helpers;

namespace IndiaHouseSalesOrder
{
    public partial class frmSalesOrder : Form
    {
        public frmSalesOrder()
        {
            InitializeComponent();
        }

        private DataTable dt;
        private SalesOrder _salesOrder;

        #region Connection 

        private QBSessionManager _MySessionManager;
        
        private void disconnectQB()
        {
            if (_MySessionManager != null)
            {
                _MySessionManager.EndSession();
                _MySessionManager.CloseConnection();
            }
        }

        private void frmSalesOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectQB();
        }
        #endregion


        private void btnSearch_Click(object sender, EventArgs e)
        {
            _MySessionManager = SessionManager.NewQBSession();

            if (txtSalesOrderNumberSearch.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Sales Order number to search");
                return;
            }

            try
            {
                int salesOrder = Convert.ToInt32(txtSalesOrderNumberSearch.Text.Trim());
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Please enter numbers only in the Sales Order number textbox");
                return;
            }

            try
            {
                SalesOrderHelper salesOrderHelper = new SalesOrderHelper(_MySessionManager);

                _salesOrder = salesOrderHelper.Populate(txtSalesOrderNumberSearch.Text);

                txtSalesOrderNumber.Text = _salesOrder.Number;
                txtDate.Text = _salesOrder.Date.ToShortDateString();
                txtShipDate.Text = _salesOrder.ShipDate.ToString();
                txtTotalPrice.Text = _salesOrder.Total;
                txtTotalQuantity.Text = _salesOrder.TotalQty.ToString();
                txtCustomerName.Text = _salesOrder.CustomerFullName;
                txtBillingAddress.Text = _salesOrder.BillingAddress;
                txtShippingAddress.Text = _salesOrder.ShippingAddress;

                dgSalesOrder.Columns.Clear();

                dt = new DataTable();
                dt.Columns.Add("Item Code");
                dt.Columns.Add("UPC");
                dt.Columns.Add("Description");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");
                dt.Columns.Add("Amount");

                foreach (InventoryItem item in _salesOrder.InventoryItems)
                {
                    DataRow dr = dt.NewRow();
                    dr["Item Code"] = item.ItemCode;
                    dr["Description"] = item.Description;
                    dr["Quantity"] = item.Quantity;
                    dr["Price"] = item.Price;
                    dr["Amount"] = item.Amount;
                    dr["UPC"] = item.MPN;

                    dt.Rows.Add(dr);
                }

                dgSalesOrder.DataSource = dt;

                dgSalesOrder.Columns[0].Width = 100;
                dgSalesOrder.Columns[1].Width = 100;
                dgSalesOrder.Columns[2].Width = 300;
                dgSalesOrder.Columns[3].Width = 70;
                dgSalesOrder.Columns[4].Width = 70;
                dgSalesOrder.Columns[5].Width = 70;

                Pictures p = new Pictures();
                p.Populate(ref dgSalesOrder, _salesOrder.InventoryItems, Settings.Default.ImagesLocation);
            }
            catch (Exception ex)
            {
                disconnectQB();
                MessageBox.Show(ex.Message, "Error in Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                ExcelExportSalesOrder exp = new ExcelExportSalesOrder(dt, _salesOrder, chkIncludePictures.Checked);
            }
            else
            {
                MessageBox.Show("Sorry, there is no data to export.");
            }
        }

        private void frmSalesOrder_Load(object sender, EventArgs e)
        {
            this.Text += " " + Application.ProductVersion.ToString();
            chkIncludePictures.Checked = Settings.Default.ExportPicturesChecked;
        }

        private void chkIncludePictures_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ExportPicturesChecked = chkIncludePictures.Checked;
            Settings.Default.Save();
        }


        ////Test code
        //public void getCustomFieldsList()
        //{
        //    _MySessionManager = SessionManager.NewQBSession();

        //    IMsgSetRequest msgSetRequest = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

        //    IDataExtDefQuery dataExtDefQuery;
        //    dataExtDefQuery = msgSetRequest.AppendDataExtDefQueryRq();

        //    dataExtDefQuery.ORDataExtDefQuery.OwnerIDList.Add("0");

        //    IMsgSetResponse responseItemRq = _MySessionManager.DoRequests(msgSetRequest);

        //    IResponseList itemResponseList = responseItemRq.ResponseList;

        //    IResponse response = itemResponseList.GetAt(0);

        //    if (response == null)
        //    {
        //        if (response.StatusCode != 0)
        //        {
        //            if (response.StatusCode == 1)
        //                Console.WriteLine("NO DATA EXTENSIONS DEFINED FOR THIS COMPANY FILE");
        //            else
        //                Console.WriteLine("FillDataExts unexpected Error - " + response.StatusMessage);

        //            return;
        //        }
        //    }

        //    //ENResponseType responseType = (ENResponseType)response.Type.GetValue();
        //    IDataExtDefRetList dataExtDefRetList = (IDataExtDefRetList)response.Detail;


        //    for (int i = 0; i <= dataExtDefRetList.Count - 1; i++)
        //    {
        //        IDataExtDefRet dataExtDefRet = dataExtDefRetList.GetAt(i);

        //        if (dataExtDefRet != null)
        //        {
        //            if (dataExtDefRet.DataExtName != null)
        //                Console.WriteLine(dataExtDefRet.DataExtName.GetValue());

        //            if (dataExtDefRet.DataExtType != null)
        //                Console.WriteLine(dataExtDefRet.DataExtType.GetAsString());
        //        }
        //    }
        //}

        //public void getCustomerCustomFields()
        //{
        //    IMsgSetRequest msgSetRequest = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

        //    ICustomerQuery customerQuery = msgSetRequest.AppendCustomerQueryRq();

        //    // set the FullName of the Customer
        //    //customerQuery.ORCustomerListQuery.FullNameList.Add("Ahmad Faiq Ateel");

        //    //0
        //    customerQuery.OwnerIDList.Add("{E09C86CF-9D6E-4EF2-BCBE-4D66B6B0F754}");

        //    IMsgSetResponse responseItemRq = _MySessionManager.DoRequests(msgSetRequest);

        //    IResponseList itemResponseList = responseItemRq.ResponseList;

        //    IResponse response = itemResponseList.GetAt(0);

        //    ICustomerRetList customerRetList = (ICustomerRetList)response.Detail;

        //    for (int i = 0; i <= customerRetList.Count - 1; i++)
        //    {
        //        ICustomerRet customerRet = (ICustomerRet)customerRetList.GetAt(i);

        //        Console.WriteLine(customerRet.FullName.GetValue());

        //        IDataExtRetList dataExtRetList = customerRet.DataExtRetList;

        //        if (dataExtRetList != null)
        //        {
        //            for (int j = 0; j <= dataExtRetList.Count - 1; j++)
        //            {
        //                IDataExtRet dataExtRet = dataExtRetList.GetAt(j);

        //                if (dataExtRet.DataExtName != null)
        //                    Console.WriteLine(dataExtRet.DataExtName.GetValue());

        //                if (dataExtRet.DataExtValue != null)
        //                    Console.WriteLine(dataExtRet.DataExtName.GetValue() + "  =  " + dataExtRet.DataExtValue.GetValue());
        //            }
        //        }
        //    }
        //}

        //Save sales order as batch
        //        List<int> salesOrders = new List<int>
        //            {
        //                170703,
        //170704,
        //170705,
        //170706
        //            };
        //private void button1_Click(object sender, EventArgs e)
        //{
            //            foreach (int so in salesOrders)
            //            {
            //                txtSalesOrderNumberSearch.Text = so.ToString();
            //                btnSearch_Click(sender, e);
            //                btnExportToExcel_Click(sender, e);
            //            }
            //        }
        }


}