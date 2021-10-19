using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class MembershipPlanUnpaidActionEnumerator  : BaseEnumerator
    {
        public static readonly MembershipPlanUnpaidActionEnumerator UnpaidActionIgnore = new MembershipPlanUnpaidActionEnumerator("I", "Ignore", "typeEnum.unpaidaction.ignore");
        public static readonly MembershipPlanUnpaidActionEnumerator UnpaidActionWarnAndAction = new MembershipPlanUnpaidActionEnumerator("W", "Warn and Action", "typeEnum.unpaidaction.warnandaction");
        public static readonly MembershipPlanUnpaidActionEnumerator UnpaidActionCancel = new MembershipPlanUnpaidActionEnumerator("C", "Cancel", "typeEnum.unpaidaction.cancel");

        private static readonly Dictionary<string, MembershipPlanUnpaidActionEnumerator> dict
            = new Dictionary<string, MembershipPlanUnpaidActionEnumerator>{{ UnpaidActionIgnore.StrKey, UnpaidActionIgnore },
                                                        { UnpaidActionWarnAndAction.StrKey, UnpaidActionWarnAndAction },
                                                        { UnpaidActionCancel.StrKey, UnpaidActionCancel }};

        public MembershipPlanUnpaidActionEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static MembershipPlanUnpaidActionEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out MembershipPlanUnpaidActionEnumerator value))
                return value;
            else
                return null;
        }



        public static List<MembershipPlanUnpaidActionEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
