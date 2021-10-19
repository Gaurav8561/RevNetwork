using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeEnumerator
{
    public class DurationFormatEnumerator : BaseEnumerator
    {
        public static readonly DurationFormatEnumerator DurationFormatDay = new DurationFormatEnumerator("D", "Day", "typeEnum.durationformat.day");
        public static readonly DurationFormatEnumerator DurationFormatMonth = new DurationFormatEnumerator("M", "Month", "typeEnum.durationformat.month");
        public static readonly DurationFormatEnumerator DurationFormatYear = new DurationFormatEnumerator("Y", "Year", "typeEnum.durationformat.year");

        private static readonly Dictionary<string, DurationFormatEnumerator> dict
            = new Dictionary<string, DurationFormatEnumerator> {
                { DurationFormatDay.StrKey, DurationFormatDay },
                { DurationFormatMonth.StrKey, DurationFormatMonth },
                { DurationFormatYear.StrKey, DurationFormatYear } };

        public DurationFormatEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }

        public static DurationFormatEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out DurationFormatEnumerator value))
                return value;
            else
                return null;
        }

        public static List<DurationFormatEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
