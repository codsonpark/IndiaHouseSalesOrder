using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaHouse.Core.Models
{
    public class Invoice : SalesOrder
    {
        public string Terms { get; set; }
        public string PONumber { get; set; }

    }
}
