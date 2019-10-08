using System;

namespace IndiaHouse.Core.Models
{
    [Serializable]
    public class InventoryItem
    { 
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public double Price { get; set; }
        public string Amount { get; set; }
        public string ListID { get; set; }
        public string MPN { get; set; }

        public string Inner { get; set; }
        public string Case { get; set; }
        public double Price2 { get; set; }
        public string Volume { get; set; }
        public double Price3 { get; set; }

        public string Price3Code {
            get
            {
                return EncodePrice3();
            }
        }

        private string EncodePrice3()
        {
            //if (Price3 == null)
            //    return "";

            string _price3 = Price3.ToString("F2");
            _price3 = _price3.Replace(".","");

            //remove all the zeroes on the left
            while (_price3.StartsWith("0"))
            {
               _price3 = _price3.Remove(0, 1);
            }

            char[] _price3Array = _price3.ToCharArray();

            for(int i=0;i <= _price3Array.Length-1;i++)
            {
                switch (_price3Array[i]){
                    case '0':
                        _price3Array[i] = 'O';
                        break;
                    case '1':
                        _price3Array[i] = '-';
                        break;
                    case '2':
                        _price3Array[i] = ')';
                        break;
                    case '3':
                        _price3Array[i] = 'L';
                        break;
                    case '4':
                        _price3Array[i] = 'H';
                        break;
                    case '5':
                        _price3Array[i] = 'V';
                        break;
                    case '6':
                        _price3Array[i] = 'Z';
                        break;
                    case '8':
                        _price3Array[i] = 'C';
                        break;
                    case '9':
                        _price3Array[i] = 'A';
                        break;
                }
            }

            _price3 = new string(_price3Array);

            return _price3;
        }
    }
}
