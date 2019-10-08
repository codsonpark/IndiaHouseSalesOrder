using IndiaHouse.Core.Helpers;
using IndiaHouse.Core.Models;
using Interop.QBFC13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaHouse.Core.Repositories
{
    public class InvoiceHelper
    {
        private QBSessionManager _MySessionManager;
        private Invoice _invoice;
        public InvoiceHelper(QBSessionManager MySessionManager)
        {
            _MySessionManager = MySessionManager; 
        }
        public Invoice Populate(string invoiceNumber)
        {
            IMsgSetRequest requestMsgSet = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

            IInvoiceQuery invoiceQuery = requestMsgSet.AppendInvoiceQueryRq();
            invoiceQuery.ORInvoiceQuery.RefNumberList.Add(invoiceNumber);

            invoiceQuery.IncludeLineItems.SetValue(true);

            IMsgSetResponse responseMsgSet = _MySessionManager.DoRequests(requestMsgSet);

            IResponseList rsList = responseMsgSet.ResponseList;

            IResponse response = rsList.GetAt(0);

            IInvoiceRetList InvoiceList = (IInvoiceRetList)response.Detail;

            if (InvoiceList == null)
            {
                throw new Exception("Invoice not found.");
            }

            try
            {
                IInvoiceRet QBInvoices = InvoiceList.GetAt(0);

                _invoice = new Invoice();
                _invoice.Number = QBInvoices.RefNumber.GetValue();
                _invoice.Total = QBInvoices.Subtotal.GetAsString();
                _invoice.Date = QBInvoices.TxnDate.GetValue();
                _invoice.Terms = QBInvoices.TermsRef.FullName.GetValue();
                if (QBInvoices.PONumber != null) _invoice.PONumber = QBInvoices.PONumber.GetValue();
                if (QBInvoices.ShipDate != null) _invoice.ShipDate = QBInvoices.ShipDate.GetValue();

                _invoice.CustomerFullName = QBInvoices.CustomerRef.FullName.GetValue();

                Address address = new Address();
                _invoice.BillingAddress = address.getAddress(QBInvoices.BillAddress);
                _invoice.ShippingAddress = address.getAddress(QBInvoices.ShipAddress);

                IORInvoiceLineRetList InvoiceItems = QBInvoices.ORInvoiceLineRetList;

                if (InvoiceItems != null)
                {
                    for (int i = 0; i <= InvoiceItems.Count - 1; i++)
                    {
                        IORInvoiceLineRet InvoiceItem = InvoiceItems.GetAt(i);

                        if (InvoiceItem.ortype == ENORInvoiceLineRet.orilrInvoiceLineRet)
                        {
                            InventoryItem inventoryItem = new InventoryItem();

                            inventoryItem.ItemCode = InvoiceItem.InvoiceLineRet.ItemRef.FullName.GetValue();

                            inventoryItem.Description = InvoiceItem.InvoiceLineRet.Desc.GetValue();

                            if (InvoiceItem.InvoiceLineRet.Quantity != null)
                            {
                                _invoice.TotalQty += InvoiceItem.InvoiceLineRet.Quantity.GetValue();
                                inventoryItem.Quantity = InvoiceItem.InvoiceLineRet.Quantity.GetAsString();
                            }
                            else
                                inventoryItem.Quantity = "";

                            inventoryItem.Price = InvoiceItem.InvoiceLineRet.ORRate.Rate.GetValue();
                            inventoryItem.Amount = InvoiceItem.InvoiceLineRet.Amount.GetAsString();
                            _invoice.InventoryItems.Add(inventoryItem);
                        }
                    }

                    //Update the items UPC and List in the sales order from itemsWithUPC list
                    //The reason is that the salesOrder items don't have these properties
                    //So we make another request to QB to get items with all properties
                    InventoryHelper inventoryHelper = new InventoryHelper(_MySessionManager);
                    _invoice.InventoryItems = inventoryHelper.UpdateItemUPCAndListID(_invoice.InventoryItems);
                }

                return _invoice;
            }
            catch (Exception)
            {
                throw new Exception("Failed to read Invoice from QuickBooks.");
            }


        }
    }
}
