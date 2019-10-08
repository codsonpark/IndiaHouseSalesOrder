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
using IndiaHouseSalesOrder.Properties;
using IndiaHouseSalesOrder.Repositories;
using IndiaHouse.Core.Models;
using IndiaHouse.Core.Repositories;

namespace IndiaHouseSalesOrder
{
    public partial class frmLabels : Form
    {
        public frmLabels()
        {
            InitializeComponent();
        }

        private void frmLabels_Load(object sender, EventArgs e)
        {
            if (Settings.Default.CachedItems != null)
                dgItems.DataSource = Settings.Default.CachedItems;
        }

        private void btnLoadItems_Click(object sender, EventArgs e)
        {
            try
            {
                List<InventoryItem> _inventoryItems = new List<InventoryItem>();

                InventoryHelper2 inventoryHelper = new InventoryHelper2(SessionManager.NewQBSession());

                _inventoryItems = inventoryHelper.getAllItems();

                _inventoryItems = _inventoryItems.OrderBy(x => x.ItemCode).ToList();
                Settings.Default.CachedItems = _inventoryItems;
                Settings.Default.Save();

                dgItems.DataSource = _inventoryItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select some items to print.", "No item to print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<InventoryItem> _selectedItems = new List<InventoryItem>();
            //Get selected items 

            foreach (DataGridViewRow row in dgItems.SelectedRows)
            {
                InventoryItem item = (InventoryItem)row.DataBoundItem;
                _selectedItems.Add(item);
            }

            //Change all Inner Pack Quantities to REG
            if (rdbRegular.Checked)
                _selectedItems.ForEach(x => x.Inner = "REG");

            //Sort list
            _selectedItems = _selectedItems.OrderBy(x => x.ItemCode).ToList();

            //Export all items to excel
            ExcelExportItems exportItems = new ExcelExportItems(_selectedItems);

            //Open Bartender File.
            if (rdb15x2.Checked)
                Process.Start(Settings.Default.BartenderFileLocation15x2);
            else
                Process.Start(Settings.Default.BartenderFileLocation2x2);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmLabelsOptions labelOptions = new frmLabelsOptions();
            labelOptions.Show();
        }

        private void dgItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            for (int i = 0; i <= dgItems.Rows.Count - 1; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgItems.Rows[i].Cells[0];

                if (Convert.ToBoolean(chk.EditedFormattedValue) == true)
                    dgItems.Rows[i].Selected = true;
                else
                    dgItems.Rows[i].Selected = false;
            }

        }
        ////Important don't delete, for creating price codes
        //private void button1_Click(object sender, EventArgs e)
        //{ 
        //    List<InventoryItem> j = new List<InventoryItem> {
        //            new InventoryItem { ItemCode = "14281", Price3 = 10.00 },
        //            new InventoryItem { ItemCode = "14282", Price3 = 2.00 },
        //            new InventoryItem { ItemCode = "14283", Price3 = 12.20 },
        //            new InventoryItem { ItemCode = "14284", Price3 = 15.55 },
        //            new InventoryItem { ItemCode = "14284", Price3 = 0.95 }
        //    };

        //    foreach (InventoryItem i in j)
        //    {
        //        Console.WriteLine(i.Price3Code);
        //    }
        //}
    }
}
