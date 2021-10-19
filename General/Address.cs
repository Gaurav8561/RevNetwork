using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace General
{
    public class Address
    {
        public string StrAddLine1 { get; set; }
        public string StrAddLine2 { get; set; }
        public string StrAddLine3 { get; set; }
        public string StrAddPostcode { get; set; }
        public string StrAddCity { get; set; }
        public string StrAddState { get; set; }
        public string StrAddCountry { get; set; }

        public Address()
        {
            this.StrAddLine1 = string.Empty;
            this.StrAddLine2 = string.Empty;
            this.StrAddLine3 = string.Empty;
            this.StrAddPostcode = string.Empty;
            this.StrAddCity = string.Empty;
            this.StrAddState = string.Empty;
            this.StrAddCountry = string.Empty;
        }



        public Address(string strAddLine1,
                        string strAddLine2,
                        string strAddLine3,
                        string strAddPostcode,
                        string strAddCity,
                        string strAddState,
                        string strAddCountry)
        {
            this.StrAddLine1 = strAddLine1;
            this.StrAddLine2 = strAddLine2;
            this.StrAddLine3 = strAddLine3;
            this.StrAddPostcode = strAddPostcode;
            this.StrAddCity = strAddCity;
            this.StrAddState = strAddState;
            this.StrAddCountry = strAddCountry;
        }
    }
}
