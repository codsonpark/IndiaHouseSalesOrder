using System.Collections.Generic;
using Interop.QBFC13;
using System.Linq;
using System;
using IndiaHouse.Core.Models;

namespace IndiaHouse.Core.Repositories
{
    public class InventoryHelper2
    {
        private readonly List<InventoryItem> _inventoryItems;
        private QBSessionManager _MySessionManager;

        public InventoryHelper2(QBSessionManager MySessionManager)
        {
            _MySessionManager = MySessionManager;
            _inventoryItems = new List<InventoryItem>();
        }

        public List<InventoryItem> getAllItems()
        {
            try
            {
                //Item Request
                IMsgSetRequest itemRequestset = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

                IItemQuery itemQuery = itemRequestset.AppendItemQueryRq();

                itemQuery.OwnerIDList.Add("0");

                ////Get item codes from sales order and add to item request
                //for (int i = 0; i < SalesOrderItems.Count; ++i)
                //{
                //    IORSalesOrderLineRet SalesOrderItem = SalesOrderItems.GetAt(i);
                //    itemQuery.ORListQuery.FullNameList.Add(SalesOrderItem.SalesOrderLineRet.ItemRef.FullName.GetValue());
                //}

                //itemQuery.ORListQuery.FullNameList.Add("17531");
                //itemQuery.ORListQuery.FullNameList.Add("17534");
                //itemQuery.ORListQuery.FullNameList.Add("17535");
                //itemQuery.ORListQuery.FullNameList.Add("17536");
                //itemQuery.ORListQuery.FullNameList.Add("17537");
                //itemQuery.ORListQuery.FullNameList.Add("17538");
                //itemQuery.ORListQuery.FullNameList.Add("62231");
                //itemQuery.ORListQuery.FullNameList.Add("12061");

                IMsgSetResponse responseItemRq = _MySessionManager.DoRequests(itemRequestset);

                IResponseList itemResponseList = responseItemRq.ResponseList;

                IResponse itemResponse = itemResponseList.GetAt(0);

                ENResponseType responseType = (ENResponseType)itemResponse.Type.GetValue();
                IORItemRetList QBItemList = (IORItemRetList)itemResponse.Detail;

                for (int i = 0; i <= QBItemList.Count - 1; i++)
                {
                    InventoryItem item = new InventoryItem();
                    IDataExtRetList customFieldsList;

                    if (QBItemList.GetAt(i).ItemNonInventoryRet != null)
                    {
                        IItemNonInventoryRet inventoryItem = QBItemList.GetAt(i).ItemNonInventoryRet;
                        customFieldsList = QBItemList.GetAt(i).ItemNonInventoryRet.DataExtRetList;

                        item.ListID = inventoryItem.ListID != null ? inventoryItem.ListID.GetValue() : "";
                        item.ItemCode = inventoryItem.Name != null ? inventoryItem.Name.GetValue() : "";
                        item.Description = inventoryItem.FullName.GetValue() != null ? inventoryItem.FullName.GetValue() : "";
                        item.MPN = inventoryItem.ManufacturerPartNumber != null ? inventoryItem.ManufacturerPartNumber.GetValue() : "";
                    }
                    else if (QBItemList.GetAt(i).ItemInventoryRet != null)
                    {
                        IItemInventoryRet inventoryItem = QBItemList.GetAt(i).ItemInventoryRet;
                        customFieldsList = QBItemList.GetAt(i).ItemInventoryRet.DataExtRetList;

                        item.ListID = inventoryItem.ListID != null ? inventoryItem.ListID.GetValue() : "";
                        item.ItemCode = inventoryItem.Name != null ? inventoryItem.Name.GetValue() : "";
                        item.Description = inventoryItem.SalesDesc != null ? inventoryItem.SalesDesc.GetValue() : "";
                        item.MPN = inventoryItem.ManufacturerPartNumber != null ? inventoryItem.ManufacturerPartNumber.GetValue() : "";
                        item.Price = inventoryItem.SalesPrice.GetValue();
                    }
                    else if (QBItemList.GetAt(i).ItemInventoryAssemblyRet != null)
                    {
                        IItemInventoryAssemblyRet inventoryItem = QBItemList.GetAt(i).ItemInventoryAssemblyRet;
                        customFieldsList = QBItemList.GetAt(i).ItemInventoryAssemblyRet.DataExtRetList;

                        item.ListID = inventoryItem.ListID != null ? inventoryItem.ListID.GetValue() : "";
                        item.ItemCode = inventoryItem.Name != null ? inventoryItem.Name.GetValue() : "";
                        item.Description = inventoryItem.SalesDesc.GetValue() != null ? inventoryItem.SalesDesc.GetValue() : "";
                        item.MPN = inventoryItem.ManufacturerPartNumber != null ? inventoryItem.ManufacturerPartNumber.GetValue() : "";
                    }
                    else
                    {
                        customFieldsList = null;
                    }

                    //get item external data (custom fields)
                    if (customFieldsList != null)
                    {
                        for (int iCustomField = 0; iCustomField <= customFieldsList.Count - 1; iCustomField++)
                        {
                            string fieldName = customFieldsList.GetAt(iCustomField).DataExtName.GetValue();
                            string fieldValue = customFieldsList.GetAt(iCustomField).DataExtValue.GetValue();

                            if (fieldName == "Inner")
                                item.Inner = fieldValue;

                            if (fieldName == "Case")
                                item.Case = fieldValue;

                            if (fieldName == "Price2")
                                item.Price2 = Convert.ToDouble(fieldValue);

                            if (fieldName == "Volume")
                                item.Volume = fieldValue;

                            if (fieldName == "Price3")
                                item.Price3 = Convert.ToDouble(fieldValue);
                        }
                    }

                    if (item.ItemCode != null)
                        _inventoryItems.Add(item);
                }

                return _inventoryItems;
            }
            catch (Exception)
            {
                throw new Exception("Failed to read Items from QuickBooks.");
            }
        }

        //public InventoryItem this[string itemNumber]
        //{
        //    get
        //    {
        //        if (_items.ContainsKey(itemNumber))
        //            return _items[itemNumber];

        //        return new InventoryItem();
        //    }
        //}


    }
}
