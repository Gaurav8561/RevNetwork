using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class MembershipPlanPaymentIntervalEnumerator  : BaseEnumerator
    {
        public static readonly MembershipPlanPaymentIntervalEnumerator PaymentIntervalOnce = new MembershipPlanPaymentIntervalEnumerator("O", "Once", "typeEnum.paymentinterval.once");
        public static readonly MembershipPlanPaymentIntervalEnumerator PaymentIntervalMonthly = new MembershipPlanPaymentIntervalEnumerator("M", "Monthly", "typeEnum.paymentinterval.monthly");
        public static readonly MembershipPlanPaymentIntervalEnumerator PaymentIntervalYearly = new MembershipPlanPaymentIntervalEnumerator("Y", "Yearly", "typeEnum.paymentinterval.yearly");

        private static readonly Dictionary<string, MembershipPlanPaymentIntervalEnumerator> dict
            = new Dictionary<string, MembershipPlanPaymentIntervalEnumerator>{{ PaymentIntervalOnce.StrKey, PaymentIntervalOnce },
                                                        { PaymentIntervalMonthly.StrKey, PaymentIntervalMonthly },
                                                        { PaymentIntervalYearly.StrKey, PaymentIntervalYearly }};

        public MembershipPlanPaymentIntervalEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static MembershipPlanPaymentIntervalEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out MembershipPlanPaymentIntervalEnumerator value))
                return value;
            else
                return null;
        }



        public static List<MembershipPlanPaymentIntervalEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
