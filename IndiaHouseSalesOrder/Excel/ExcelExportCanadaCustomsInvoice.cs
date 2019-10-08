using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using IndiaHouseSalesOrder.Properties;
using System.Linq;
using IndiaHouse.Core.Models;

namespace IndiaHouseSalesOrder
{
    public class ExcelExportCanadaCustomsInvoice
    {
        private Invoice _invoice;
        private double _weight;
        private Int64 _packages;

        public ExcelExportCanadaCustomsInvoice(Invoice invoice, double weight, Int64 packages) //Constructor
        {
            _weight = weight;
            _packages = packages;

            _invoice = invoice;
            Export();
        }

        private void Export()
        {
            string templateLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excel\\Canada Customs Invoice.xls");

            Application excelApp = new Application();

            Workbook excelBook = excelApp.Workbooks.Add(templateLocation);

            Worksheet excelWorksheet = (Worksheet)excelBook.Worksheets[1];

            excelApp.Visible = true;

            excelWorksheet.PageSetup.PaperSize = XlPaperSize.xlPaperLetter;
            excelWorksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;

            excelWorksheet.PageSetup.LeftMargin = 0;
            excelWorksheet.PageSetup.RightMargin = 0;
            excelWorksheet.PageSetup.TopMargin = 50;
            excelWorksheet.PageSetup.BottomMargin = 50;
            excelWorksheet.PageSetup.HeaderMargin = 0;
            excelWorksheet.PageSetup.FooterMargin = 0;
            excelWorksheet.PageSetup.CenterHorizontally = true;

            excelWorksheet.Range["A25"].Value = _packages;
            excelWorksheet.Range["B10"].Value = _invoice.CustomerFullName;
            excelWorksheet.Range["B11"].Value = _invoice.BillingAddress;
            excelWorksheet.Range["G5"].Value = _invoice.ShipDate;
            excelWorksheet.Range["G7"].Value = _invoice.PONumber;
            excelWorksheet.Range["G18"].Value = _invoice.Terms;

            excelWorksheet.Range["C32"].Value = _invoice.Number;
            excelWorksheet.Range["I31"].Value = _weight;
            excelWorksheet.Range["J31"].Value = _invoice.Total; 

            int iRow = 23;

            foreach (InventoryItem item in _invoice.InventoryItems)
            {
                //excelWorksheet.Rows["A" + iRow].EntireRow.Insert();
                excelWorksheet.Rows[iRow+1].Insert(XlInsertShiftDirection.xlShiftDown, false);

                excelWorksheet.Range["B" + iRow].Value = item.ItemCode;
                excelWorksheet.Range["C" + iRow].Value = item.Description;
                excelWorksheet.Range["H" + iRow].Value = item.Quantity;
                excelWorksheet.Range["I" + iRow].Value = item.Price;
                excelWorksheet.Range["J" + iRow].Value = item.Amount;

                iRow++;
            }

            excelApp.Visible = true;
            
            //excelApp = null;
        }
    }
}
