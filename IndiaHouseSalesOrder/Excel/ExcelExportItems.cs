using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using IndiaHouseSalesOrder.Properties;
using IndiaHouse.Core.Models;

namespace IndiaHouseSalesOrder
{
    public class ExcelExportItems
    {
        private List<InventoryItem> _inventoryItems;

        public ExcelExportItems(List<InventoryItem> inventoryItems)
        {
            _inventoryItems = inventoryItems;
            Export();
        }

        public void Export()
        {
            string templateLocation = Settings.Default.ExcelDataSourceLocation;

            Application excelApp = new Application();

            Workbook excelBook = excelApp.Workbooks.Open(templateLocation); // excelApp.Workbooks.Add(templateLocation);

            Worksheet excelWorksheet = (Worksheet)excelBook.Worksheets[1];

            excelApp.Visible = false;

            //Delete existing data
            string deleteRange = "A2:J10000";
            excelWorksheet.Range[deleteRange].Delete();

            int iRow = 2;

            foreach (InventoryItem inventoryItem in _inventoryItems)
            {
                //format cell as text
                excelWorksheet.Range["A" + iRow].NumberFormat = "@";
                excelWorksheet.Range["A" + iRow].Value = inventoryItem.ItemCode;
                excelWorksheet.Range["B" + iRow].Value = inventoryItem.Description;
                excelWorksheet.Range["C" + iRow].Value = inventoryItem.MPN;
                excelWorksheet.Range["D" + iRow].Value = inventoryItem.Inner;
                excelWorksheet.Range["E" + iRow].Value = inventoryItem.Price.ToString("F2");
                excelWorksheet.Range["F" + iRow].Value = inventoryItem.Case;
                excelWorksheet.Range["G" + iRow].Value = inventoryItem.Price2.ToString("F2");
                excelWorksheet.Range["H" + iRow].Value = inventoryItem.Volume;
                excelWorksheet.Range["I" + iRow].Value = inventoryItem.Price3.ToString("F2");
                excelWorksheet.Range["J" + iRow].Value = inventoryItem.Price3Code;

                iRow++;
            }
            
            excelBook.Save();
            excelBook.Close();

            //excelApp.Visible = true;
            excelApp.Quit();
        }
    }
}