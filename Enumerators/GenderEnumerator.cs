using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class GenderEnumerator  : BaseEnumerator
    {
        public static readonly GenderEnumerator GenderMale = new GenderEnumerator("M", "Male", "typeEnum.gender.male");
        public static readonly GenderEnumerator GenderFemale = new GenderEnumerator("F", "Female", "typeEnum.gender.female");

        private static readonly Dictionary<string, GenderEnumerator> dict
            = new Dictionary<string, GenderEnumerator>{{ GenderMale.StrKey, GenderMale },
                                                       { GenderFemale.StrKey, GenderFemale }};

        public GenderEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static GenderEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out GenderEnumerator value))
                return value;
            else
                return null;
        }



        public static List<GenderEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
