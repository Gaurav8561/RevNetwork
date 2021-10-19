using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class MaritalStatusEnumerator  : BaseEnumerator
    {
        public static readonly MaritalStatusEnumerator MaritalStatSingle = new MaritalStatusEnumerator("SIN", "Single", "typeEnum.maritalStatus.single");
        public static readonly MaritalStatusEnumerator MaritalStatMarried = new MaritalStatusEnumerator("MAR", "Married", "typeEnum.maritalStatus.married");
        public static readonly MaritalStatusEnumerator MaritalStatDivorced = new MaritalStatusEnumerator("DIV", "Divorced", "typeEnum.maritalStatus.divorced");
        public static readonly MaritalStatusEnumerator MaritalStatWidowed = new MaritalStatusEnumerator("WID", "Widowed", "typeEnum.maritalStatus.widowed");

        private static readonly Dictionary<string, MaritalStatusEnumerator> dict
            = new Dictionary<string, MaritalStatusEnumerator>{{ MaritalStatSingle.StrKey, MaritalStatSingle },
                                                                { MaritalStatMarried.StrKey, MaritalStatMarried },
                                                                { MaritalStatDivorced.StrKey, MaritalStatDivorced },
                                                                { MaritalStatWidowed.StrKey, MaritalStatWidowed }};

        public MaritalStatusEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static MaritalStatusEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out MaritalStatusEnumerator value))
                return value;
            else
                return null;
        }



        public static List<MaritalStatusEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
