using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using IndiaHouseSalesOrder.Properties;
using System.Linq;
using IndiaHouse.Core.Models;
using IndiaHouse.Core.Helpers;

namespace IndiaHouseSalesOrder
{
    class ExcelExportSalesOrder
    {
        private System.Data.DataTable _dt;
        private int _startRow = 9;
        private SalesOrder _salesOrder;
        private bool _ExportPictures;

        public ExcelExportSalesOrder(System.Data.DataTable dt, SalesOrder salesOrder, bool ExportPictures) //Constructor
        {
            _dt = dt;
            _salesOrder = salesOrder;
            _ExportPictures = ExportPictures;
            Export();
        }

        private void Export()
        {
            string templateLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excel\\India House Custom Sales Order.xlsx");

            Application excelApp = new Application();

            Workbook excelBook = excelApp.Workbooks.Add(templateLocation);

            Worksheet excelWorksheet = (Worksheet)excelBook.Worksheets[1];

            excelApp.Visible = false;

            excelWorksheet.PageSetup.PaperSize = XlPaperSize.xlPaperLetter;
            excelWorksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;

            excelWorksheet.PageSetup.LeftMargin = 0;
            excelWorksheet.PageSetup.RightMargin = 0;
            excelWorksheet.PageSetup.TopMargin = 50;
            excelWorksheet.PageSetup.BottomMargin = 50;
            excelWorksheet.PageSetup.HeaderMargin = 0;
            excelWorksheet.PageSetup.FooterMargin = 0;
            excelWorksheet.PageSetup.CenterHorizontally = true;
            //excelWorksheet.PageSetup.PrintTitleRows = "$1:$1";

            excelWorksheet.Range["E3"].Value = _salesOrder.ShipDate;
            excelWorksheet.Range["F3"].Value = _salesOrder.Date;
            excelWorksheet.Range["G3"].Value = _salesOrder.Number;

            excelWorksheet.Range["C6"].Value = _salesOrder.BillingAddress;
            excelWorksheet.Range["E6"].Value = _salesOrder.ShippingAddress;

            //Total Price value and formatting
            string totalRange = "E" + (_dt.Rows.Count + _startRow);
            excelWorksheet.Range[totalRange].Value = "Total";
            excelWorksheet.Range[totalRange].Borders.LineStyle = XlLineStyle.xlContinuous;
            excelWorksheet.Range[totalRange].Borders.Color = Color.LightGray;
            excelWorksheet.Range[totalRange].Borders.Weight = 2; 

            string totalValueRange = "F" + (_dt.Rows.Count + _startRow);
            excelWorksheet.Range[totalValueRange].Value = _salesOrder.Total;
            excelWorksheet.Range[totalValueRange].NumberFormat = "$#,###,###.00";
            excelWorksheet.Range[totalValueRange].Borders.LineStyle = XlLineStyle.xlContinuous;
            excelWorksheet.Range[totalValueRange].Borders.Color = Color.LightGray;
            excelWorksheet.Range[totalValueRange].Borders.Weight = 2;
            excelWorksheet.Range[totalValueRange].HorizontalAlignment = XlHAlign.xlHAlignCenter;

            //Total Price quantity and formatting
            string totalQtyRange = "E" + (_dt.Rows.Count + _startRow + 1);
            excelWorksheet.Range[totalQtyRange].Value = "Total Qty";
            excelWorksheet.Range[totalQtyRange].Borders.LineStyle = XlLineStyle.xlContinuous;
            excelWorksheet.Range[totalQtyRange].Borders.Color = Color.LightGray;
            excelWorksheet.Range[totalQtyRange].Borders.Weight = 2; 

            string totalQtyValueRange = "F" + (_dt.Rows.Count + _startRow + 1);
            excelWorksheet.Range[totalQtyValueRange].Value = _salesOrder.TotalQty;
            excelWorksheet.Range[totalQtyValueRange].Borders.LineStyle = XlLineStyle.xlContinuous;
            excelWorksheet.Range[totalQtyValueRange].Borders.Color = Color.LightGray;
            excelWorksheet.Range[totalQtyValueRange].Borders.Weight = 2;
            excelWorksheet.Range[totalQtyValueRange].HorizontalAlignment = XlHAlign.xlHAlignCenter;

            string[] Column = {
    "A", "B", "C",  "D", "E",   "F", "G", "H", "I", "J", "K", "L", "M",  "N", "O", "P", "Q", "R",
    "S", "T", "U", "V", "W",  "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI",
    "AJ", "AK", "AL", "AM","AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY",
    "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO",
    "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ" };

            //Populate Headers
            for (int iCol = 0; iCol <= _dt.Columns.Count - 1; iCol++)
            {
                excelWorksheet.Range[Column[iCol] + (_startRow - 1)].Value = _dt.Columns[iCol].ColumnName;
                //excelWorksheet.Range[Column[iCol] + (_startRow - 1)].Font.Bold = true;
            }
            //Picture Header
            if (_ExportPictures)
            {
                excelWorksheet.Range[Column[_dt.Columns.Count] + (_startRow - 1)].Value = "Picture";
                excelWorksheet.Range[Column[_dt.Columns.Count] + (_startRow - 1)].Font.Bold = true;
            }
            
            //Adjust column width
            //excelWorksheet.Range["A1"].ColumnWidth = 10; //ItemCode
            //excelWorksheet.Range["B1"].ColumnWidth = 15; //UPC
            //excelWorksheet.Range["C1"].ColumnWidth = 30; //Description
            //excelWorksheet.Range["G1"].ColumnWidth = 12; //Picture

            for (int iRow = 0; iRow <= _dt.Rows.Count - 1; iRow++)
            {
                if(_ExportPictures)
                    excelWorksheet.Range["A" + (iRow + _startRow)].RowHeight = 60;

                string rowRange = "A" + (iRow + _startRow) + ":G" + (iRow + _startRow);

                excelWorksheet.Range[rowRange].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelWorksheet.Range[rowRange].VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelWorksheet.Range[rowRange].Borders.LineStyle = XlLineStyle.xlContinuous;
                excelWorksheet.Range[rowRange].Borders.Color = Color.LightGray;
                excelWorksheet.Range[rowRange].Borders.Weight = 2;

                for (int iCol = 0; iCol <= _dt.Columns.Count - 1; iCol++)
                {
                    string cellValue;

                    cellValue = _dt.Rows[iRow][iCol].ToString();

                    string range = Column[iCol] + (iRow + _startRow);

                    excelWorksheet.Range[range].Value = cellValue;

                    //Format Cells
                    //excelWorksheet.Range[range].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    //excelWorksheet.Range[range].VerticalAlignment = XlHAlign.xlHAlignCenter;

                    switch (_dt.Columns[iCol].ColumnName)
                    {
                        case "UPC":
                            excelWorksheet.Range[range].NumberFormat = "0";
                            break;

                        case "Description":
                            excelWorksheet.Range[range].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                            excelWorksheet.Range[range].WrapText = true;
                            break;

                        case "Price":
                            excelWorksheet.Range[range].NumberFormat = "$#,###,###.00";
                            break;

                        case "Amount":
                            excelWorksheet.Range[range].NumberFormat = "$#,###,###.00";
                            break;
                    }
                }

                string itemCode = _dt.Rows[iRow][0].ToString();

                string listID = _salesOrder.InventoryItems.First(x => x.ItemCode == itemCode).ListID;
                int intListID = 0;
                if (listID != null)
                {
                    intListID = ListIDHelper.ConvertToDecimal(listID);
                }
                
                float imageX = (float)excelWorksheet.Range["G" + (iRow + _startRow)].Left + 2;
                float imageY = (float)excelWorksheet.Range["G" + (iRow + _startRow)].Top + 2;
                float imageWidth;
                float imageHeight;

                string FileLocation = Settings.Default.ImagesLocation + "Image_For_Items_Record_" + intListID + ".jpg";

                if (_ExportPictures)
                {
                    if (System.IO.File.Exists(FileLocation))
                    {
                        Image image = Image.FromFile(FileLocation);

                        if (image.Width > image.Height)
                        {
                            imageWidth = 58;
                            imageHeight = (float)image.Height / image.Width * 58;
                            imageY += (58 - imageHeight) / 2;
                        }
                        else
                        {
                            imageHeight = 58;
                            imageWidth = (float)image.Width / image.Height * 58;
                            imageX += (58 - imageWidth) / 2;
                        }

                        excelWorksheet.Shapes.AddPicture(FileLocation, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, imageX, imageY, imageWidth, imageHeight);
                    }
                }
            }

            excelApp.Visible = true;

            //excelBook.SaveAs("D:\\Ahmad Faiq\\Desktop\\New folder (2)\\" + _salesOrder.Number.ToString() + ".xlsx");
            //excelBook.Close();
            //excelApp.Quit();
            //excelApp = null;
        }
    }
}
