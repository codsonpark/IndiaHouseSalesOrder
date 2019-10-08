using IndiaHouse.Core.Models;
using IndiaHouseSalesOrder.Properties;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaHouseSalesOrder
{
    class ExcelExportCustomers
    {
        private List<Customer> _customers;

        public ExcelExportCustomers(List<Customer> customers)
        {
            _customers = customers;
            Export();
        }

        public void Export()
        {
            string templateLocation = Settings.Default.CustomerLabelExcelFileLoc;

            Application excelApp = new Application();

            Workbook excelBook = excelApp.Workbooks.Open(templateLocation); // excelApp.Workbooks.Add(templateLocation);

            Worksheet excelWorksheet = (Worksheet)excelBook.Worksheets[1];

            excelApp.Visible = false;

            //Delete existing data
            string deleteRange = "A2:E10000";
            excelWorksheet.Range[deleteRange].Delete();

            int iRow = 2;

            foreach (Customer inventoryItem in _customers)
            {
                excelWorksheet.Range["A" + iRow].Value = inventoryItem.AccountNumber;
                excelWorksheet.Range["B" + iRow].Value = inventoryItem.Name;
                excelWorksheet.Range["C" + iRow].Value = inventoryItem.Address;
                excelWorksheet.Range["D" + iRow].Value = inventoryItem.Phone;
                excelWorksheet.Range["E" + iRow].Value = inventoryItem.Email;

                iRow++;
            }

            excelBook.Save();
            excelBook.Close();

            //excelApp.Visible = true;

            excelApp.Quit();
        }

    }
}
