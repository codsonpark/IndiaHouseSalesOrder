using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.QBFC13;

namespace IndiaHouse.Core.Helpers
{
   public class Address
    { 
        public string getAddress(IAddress Address)
        {
            if (Address == null)
                return "";

            StringBuilder address = new StringBuilder();

            if (Address.Addr1 != null)
                address.AppendLine(Address.Addr1.GetValue());

            if (Address.Addr2 != null)
                address.AppendLine(Address.Addr2.GetValue());

            if (Address.City != null)
                address.Append(Address.City.GetValue());

            if (Address.State != null)
                address.Append(", " + Address.State.GetValue());

            if (Address.PostalCode != null)
                address.Append(" " + Address.PostalCode.GetValue());

            if (Address.Country != null)
                address.Append(" " + Address.Country.GetValue());

            return address.ToString();
        }
        
    }
}
