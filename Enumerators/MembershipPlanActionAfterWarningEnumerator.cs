using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class MembershipPlanActionAfterWarningEnumerator : BaseEnumerator
    {
        public static readonly MembershipPlanActionAfterWarningEnumerator ActionAfterWarningIgnore = new MembershipPlanActionAfterWarningEnumerator("I", "Ignore", "typeEnum.actionafterwarning.ignore");        
        public static readonly MembershipPlanActionAfterWarningEnumerator ActionAfterWarningCancel = new MembershipPlanActionAfterWarningEnumerator("C", "Cancel", "typeEnum.actionafterwarning.cancel");

        private static readonly Dictionary<string, MembershipPlanActionAfterWarningEnumerator> dict
            = new Dictionary<string, MembershipPlanActionAfterWarningEnumerator>{{ ActionAfterWarningIgnore.StrKey, ActionAfterWarningIgnore },
                                                        { ActionAfterWarningCancel.StrKey, ActionAfterWarningCancel }};

        public MembershipPlanActionAfterWarningEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static MembershipPlanActionAfterWarningEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out MembershipPlanActionAfterWarningEnumerator value))
                return value;
            else
                return null;
        }



        public static List<MembershipPlanActionAfterWarningEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
