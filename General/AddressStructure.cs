using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace General
{
    public struct AddressStructure : IDBVarcharDerivedType
    {
        public string StrAddLine1 { get; set; }
        public string StrAddLine2 { get; set; }
        public string StrAddLine3 { get; set; }
        public string StrAddPostcode { get; set; }
        public string StrAddCity { get; set; }
        public string StrAddState { get; set; }
        public string StrAddCountry { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public AddressStructure Parse(string s)
        {
            try 
            {
                return JsonConvert.DeserializeObject<AddressStructure>(s);
            }
            catch (JsonReaderException)
            {
                throw new FormatException("Invalid Address Structure String");
            }
        }

        public bool TryParse(string s, out AddressStructure result)
        {
            try
            {
                result = Parse(s);

                return true;
            }
            catch (Exception)
            {
                result = default;

                return false;
            }
        }
    }
}
