using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class ReferralCodeTypeEnumerator : BaseEnumerator
    {
        public static readonly ReferralCodeTypeEnumerator RefCodeTypeOnetime = new ReferralCodeTypeEnumerator("O", "One-Time", "typeEnum.refferalCodeType.oneTime");
        public static readonly ReferralCodeTypeEnumerator RefCodeTypeReuse = new ReferralCodeTypeEnumerator("R", "Reusable", "typeEnum.refferalCodeType.reusable");

        private static readonly Dictionary<string, ReferralCodeTypeEnumerator> dict
            = new Dictionary<string, ReferralCodeTypeEnumerator>{{ RefCodeTypeOnetime.StrKey, RefCodeTypeOnetime },
                                                                 { RefCodeTypeReuse.StrKey, RefCodeTypeReuse }};

        public ReferralCodeTypeEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static ReferralCodeTypeEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out ReferralCodeTypeEnumerator value))
                return value;
            else
                return null;
        }



        public static List<ReferralCodeTypeEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
