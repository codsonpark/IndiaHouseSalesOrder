using System;

namespace IndiaHouse.Core.Helpers
{
    public static class ListIDHelper
    {
        public static int ConvertToDecimal(string listID)
        {
            int intListID = 0;
            listID = listID.Substring(1, 7);
            intListID = Convert.ToInt32(listID, 16);
            return intListID;
        }
    }
}
