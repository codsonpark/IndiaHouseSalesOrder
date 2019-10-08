using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.QBFC13;
using System.Windows.Forms;
using IndiaHouse.Core.Models;
using IndiaHouse.Core.Helpers;

namespace IndiaHouse.Core.Repositories
{
    public class SalesOrderHelper
    {
        private QBSessionManager _MySessionManager;
        private SalesOrder _salesOrder;

        public SalesOrderHelper(QBSessionManager MySessionManager)
        {
            _MySessionManager = MySessionManager;
        }

        public SalesOrder Populate(string salesOrderNumber)
        { 

            IMsgSetRequest requestMsgSet = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

            ISalesOrderQuery soQuery = requestMsgSet.AppendSalesOrderQueryRq();
            soQuery.ORTxnNoAccountQuery.RefNumberList.Add(salesOrderNumber);

            soQuery.IncludeLineItems.SetValue(true);

            IMsgSetResponse responseMsgSet = _MySessionManager.DoRequests(requestMsgSet);

            IResponseList rsList = responseMsgSet.ResponseList;

            IResponse response = rsList.GetAt(0);

            ISalesOrderRetList SalesOrderList = (ISalesOrderRetList)response.Detail;

            if (SalesOrderList == null)
            {
                throw new Exception("Sales order not found.");
            }

            try
            {
                ISalesOrderRet QBSalesOrder = SalesOrderList.GetAt(0);

                _salesOrder = new SalesOrder();
                _salesOrder.Number = QBSalesOrder.RefNumber.GetValue();
                _salesOrder.Date = QBSalesOrder.TxnDate.GetValue();
                _salesOrder.ShipDate = QBSalesOrder.ShipDate.GetValue();
                _salesOrder.Total = QBSalesOrder.TotalAmount.GetAsString();

                _salesOrder.CustomerFullName = QBSalesOrder.CustomerRef.FullName.GetValue();

                Address address = new Address();
                _salesOrder.BillingAddress = address.getAddress(QBSalesOrder.BillAddress);
                _salesOrder.ShippingAddress = address.getAddress(QBSalesOrder.ShipAddress);

                IORSalesOrderLineRetList SalesOrderItems = QBSalesOrder.ORSalesOrderLineRetList;

                if (SalesOrderItems != null)
                {
                    for (int i = 0; i <= SalesOrderItems.Count - 1; i++)
                    {
                        IORSalesOrderLineRet SalesOrderItem = SalesOrderItems.GetAt(i);

                        if (SalesOrderItem.ortype == ENORSalesOrderLineRet.orsolrSalesOrderLineRet)
                        {
                            InventoryItem inventoryItem = new InventoryItem();

                            inventoryItem.ItemCode = SalesOrderItem.SalesOrderLineRet.ItemRef.FullName.GetValue();

                            inventoryItem.Description = SalesOrderItem.SalesOrderLineRet.Desc.GetValue();

                            if (SalesOrderItem.SalesOrderLineRet.Quantity != null)
                            {
                                _salesOrder.TotalQty += SalesOrderItem.SalesOrderLineRet.Quantity.GetValue();
                                inventoryItem.Quantity = SalesOrderItem.SalesOrderLineRet.Quantity.GetAsString();
                            }
                            else
                                inventoryItem.Quantity = "";

                            inventoryItem.Price = SalesOrderItem.SalesOrderLineRet.ORRate.Rate.GetValue();
                            inventoryItem.Amount = SalesOrderItem.SalesOrderLineRet.Amount.GetAsString();
                            _salesOrder.InventoryItems.Add(inventoryItem);
                        }
                    }

                    //Update the items UPC and List in the sales order from itemsWithUPC list
                    //The reason is that the salesOrder items don't have these properties
                    //So we make another request to QB to get items with all properties
                    InventoryHelper inventoryHelper = new InventoryHelper(_MySessionManager);
                    _salesOrder.InventoryItems = inventoryHelper.UpdateItemUPCAndListID(_salesOrder.InventoryItems);
                }

                return _salesOrder;
            }
            catch (Exception)
            {
                throw new Exception("Failed to read Sales Order from QuickBooks.");
            }
        }
    }
}
