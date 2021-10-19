using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace General
{
    public struct PhoneNumberStructure : IDBVarcharDerivedType
    {
        private const string DISCARD_CHAR = "_";

        public string StrPhoneCountryCode { get; set; }
        public string StrPhoneAreaCode { get; set; }
        public string StrPhoneNumber { get; set; }


        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", (new string[] { StrPhoneCountryCode, StrPhoneAreaCode, StrPhoneNumber }).Select(x => string.IsNullOrWhiteSpace(x) ? DISCARD_CHAR : x).ToArray());
        }

        public PhoneNumberStructure Parse(string s)
        {
            try 
            {
                string[] strResultArray = s.Split(new char[] { '-' }).Select(x => x == DISCARD_CHAR ? string.Empty : x).ToArray();
                return new PhoneNumberStructure { StrPhoneCountryCode = strResultArray[0], StrPhoneAreaCode = strResultArray[1], StrPhoneNumber = strResultArray[2] };
            }
            catch (IndexOutOfRangeException)
            {
                throw new FormatException("Invalid Address Structure String");
            }
        }

        public bool TryParse(string s, out PhoneNumberStructure result)
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
