using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class MembershipUpgradeModeEnumerator : BaseEnumerator
    {
        public static readonly MembershipUpgradeModeEnumerator UpgradeModePurchase = new MembershipUpgradeModeEnumerator("P", "Purchase", "typeEnum.upgrademode.purchase");        
        public static readonly MembershipUpgradeModeEnumerator UpgradeModeTopup = new MembershipUpgradeModeEnumerator("T", "Topup", "typeEnum.upgrademode.topup");

        private static readonly Dictionary<string, MembershipUpgradeModeEnumerator> dict
            = new Dictionary<string, MembershipUpgradeModeEnumerator>{{ UpgradeModePurchase.StrKey, UpgradeModePurchase },
                                                        { UpgradeModeTopup.StrKey, UpgradeModeTopup }};

        public MembershipUpgradeModeEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static MembershipUpgradeModeEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out MembershipUpgradeModeEnumerator value))
                return value;
            else
                return null;
        }



        public static List<MembershipUpgradeModeEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
