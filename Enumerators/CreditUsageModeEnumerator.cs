using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeEnumerator
{
    public class CreditUsageModeEnumerator : BaseEnumerator
    {
        public static readonly CreditUsageModeEnumerator CreditUsageModeDaily = new CreditUsageModeEnumerator("D", "Daily", "typeEnum.creditusagemode.daily");
        public static readonly CreditUsageModeEnumerator CreditUsageModeWeekly = new CreditUsageModeEnumerator("W", "Weekly", "typeEnum.creditusagemode.weekly");
        public static readonly CreditUsageModeEnumerator CreditUsageModeMonthly = new CreditUsageModeEnumerator("M", "Monthly", "typeEnum.creditusagemode.monthly");
        public static readonly CreditUsageModeEnumerator CreditUsageModeYearly = new CreditUsageModeEnumerator("Y", "Yearly", "typeEnum.creditusagemode.yearly");
        public static readonly CreditUsageModeEnumerator CreditUsageModeCustom = new CreditUsageModeEnumerator("C", "Custom", "typeEnum.creditusagemode.custom");

        private static readonly Dictionary<string, CreditUsageModeEnumerator> dict
            = new Dictionary<string, CreditUsageModeEnumerator> {
                { CreditUsageModeDaily.StrKey, CreditUsageModeDaily },
                { CreditUsageModeWeekly.StrKey, CreditUsageModeWeekly },
                { CreditUsageModeMonthly.StrKey, CreditUsageModeMonthly },
                { CreditUsageModeYearly.StrKey, CreditUsageModeYearly },
                { CreditUsageModeCustom.StrKey, CreditUsageModeCustom } };

        public CreditUsageModeEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }

        public static CreditUsageModeEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out CreditUsageModeEnumerator value))
                return value;
            else
                return null;
        }

        public static List<CreditUsageModeEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
