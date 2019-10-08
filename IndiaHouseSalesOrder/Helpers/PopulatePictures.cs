using IndiaHouse.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IndiaHouseSalesOrder
{
    public class Pictures
    {
        public void Populate(ref DataGridView dgSalesOrder, List<InventoryItem> inventoryItems, string ImagesLocation)
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            
            dgSalesOrder.Columns.Add(img);
            img.HeaderText = "Image";
            img.Name = "Image";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;

            for (int i = 0; i <= dgSalesOrder.Rows.Count - 1; i++)
            {
                string itemName = dgSalesOrder.Rows[i].Cells[0].Value.ToString();

                string listID = inventoryItems.First(x => x.ItemCode ==  itemName).ListID;

                if (listID != null)
                {                   
                    listID = listID.Substring(1, 7);
                    int intListID = Convert.ToInt32(listID, 16);

                    string FileLocation = ImagesLocation + "Image_For_Items_Record_" + intListID + ".jpg";

                    if (System.IO.File.Exists(FileLocation))
                    {
                        Image image = Image.FromFile(FileLocation);
                        dgSalesOrder.Rows[i].Cells["Image"].Value = image;
                    }
                    else
                    {
                        Image image = Image.FromFile(ImagesLocation + "No_Image.png");
                        dgSalesOrder.Rows[i].Cells["Image"].Value = image;
                    }
                }
                else
                {
                    Image image = Image.FromFile(ImagesLocation + "No_Image.png");
                    dgSalesOrder.Rows[i].Cells["Image"].Value = image;
                }
            }
        }
    }
}
