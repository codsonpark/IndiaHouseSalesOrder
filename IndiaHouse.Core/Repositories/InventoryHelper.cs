using System.Collections.Generic;
using Interop.QBFC13;
using System.Linq;
using IndiaHouse.Core.Models;

namespace IndiaHouse.Core.Repositories
{
    public class InventoryHelper
    {
        //private readonly List<InventoryItem> _inventoryItems;
        private QBSessionManager _MySessionManager;
         
        public InventoryHelper(QBSessionManager MySessionManager)
        {
            _MySessionManager = MySessionManager;
        }

        public List<InventoryItem> UpdateItemUPCAndListID(List<InventoryItem> inventoryItems)
        { 
            //Item Request
            IMsgSetRequest itemRequestset = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

            IItemQuery itemQuery = itemRequestset.AppendItemQueryRq();

            itemQuery.OwnerIDList.Add("0");

            //Get item codes from sales order and add to item request
            foreach (InventoryItem item in inventoryItems)
            {
                itemQuery.ORListQuery.FullNameList.Add(item.ItemCode);
            }

            IMsgSetResponse responseItemRq = _MySessionManager.DoRequests(itemRequestset);

            IResponseList itemResponseList = responseItemRq.ResponseList;

            IResponse itemResponse = itemResponseList.GetAt(0);

            ENResponseType responseType = (ENResponseType)itemResponse.Type.GetValue();
            IORItemRetList QBItemList = (IORItemRetList)itemResponse.Detail;

            for (int i = 0; i <= QBItemList.Count - 1; i++)
            {
                if (QBItemList.GetAt(i).ItemNonInventoryRet != null)
                {
                    if (QBItemList.GetAt(i).ItemNonInventoryRet.Name != null)
                    {                    
                        string itemCode = QBItemList.GetAt(i).ItemNonInventoryRet.Name.GetValue();

                        if (QBItemList.GetAt(i).ItemNonInventoryRet.ManufacturerPartNumber != null)
                            inventoryItems.First(a => a.ItemCode == itemCode).MPN = QBItemList.GetAt(i).ItemNonInventoryRet.ManufacturerPartNumber.GetValue();
                        if (QBItemList.GetAt(i).ItemNonInventoryRet.ListID != null)
                            inventoryItems.First(a => a.ItemCode == itemCode).ListID = QBItemList.GetAt(i).ItemNonInventoryRet.ListID.GetValue();
                    }
                }

                if (QBItemList.GetAt(i).ItemInventoryRet != null)
                {
                    IItemInventoryRet iInventory = QBItemList.GetAt(i).ItemInventoryRet;

                    //get item external data (custom fields)
                    //IDataExtRetList dataExtRetList = OR.GetAt(i).ItemInventoryRet.DataExtRetList;
                    //if (dataExtRetList != null)
                    //{
                    //    Console.WriteLine(dataExtRetList.Count);
                    //    IDataExtRet dataExtRet = dataExtRetList.GetAt(0);
                    //    Console.WriteLine(dataExtRet.DataExtName.GetValue() + " === " + dataExtRet.DataExtValue.GetValue());
                    //}

                    if (QBItemList.GetAt(i).ItemInventoryRet.Name != null)
                    {
                        string itemCode = QBItemList.GetAt(i).ItemInventoryRet.Name.GetValue();

                    if (QBItemList.GetAt(i).ItemInventoryRet.ManufacturerPartNumber != null)
                        inventoryItems.First(a => a.ItemCode == itemCode).MPN = QBItemList.GetAt(i).ItemInventoryRet.ManufacturerPartNumber.GetValue();

                    if (QBItemList.GetAt(i).ItemInventoryRet.ListID != null)
                        inventoryItems.First(a => a.ItemCode == itemCode).ListID = QBItemList.GetAt(i).ItemInventoryRet.ListID.GetValue();
                    }

                }

                if (QBItemList.GetAt(i).ItemInventoryAssemblyRet != null)
                {
                    if (QBItemList.GetAt(i).ItemInventoryAssemblyRet.Name != null)
                    {
                        string itemCode = QBItemList.GetAt(i).ItemInventoryAssemblyRet.Name.GetValue();

                        if (QBItemList.GetAt(i).ItemInventoryAssemblyRet.ManufacturerPartNumber != null)
                            inventoryItems.First(a => a.ItemCode == itemCode).MPN = QBItemList.GetAt(i).ItemInventoryAssemblyRet.ManufacturerPartNumber.GetValue();

                        if (QBItemList.GetAt(i).ItemInventoryAssemblyRet.ListID != null)
                            inventoryItems.First(a => a.ItemCode == itemCode).ListID = QBItemList.GetAt(i).ItemInventoryAssemblyRet.ListID.GetValue();
                    }
                }

                //if (item.ItemCode != null)
                //    _inventoryItems.Add(item);
            }

            return inventoryItems;
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
