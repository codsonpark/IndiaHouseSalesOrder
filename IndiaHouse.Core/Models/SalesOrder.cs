using System;
using System.Collections.Generic;

namespace IndiaHouse.Core.Models
{
    public class SalesOrder
    {        
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ShipDate { get; set; }
        public string Total { get; set; }
        public string CustomerFullName { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public double TotalQty { get; set; }

        public List<InventoryItem> InventoryItems { get; set; }

        public SalesOrder()
        {
            InventoryItems = new List<InventoryItem>();

        }
    }
}
