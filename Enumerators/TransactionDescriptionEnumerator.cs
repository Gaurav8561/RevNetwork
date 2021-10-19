using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeEnumerator
{
    public class TransactionDescriptionEnumerator : BaseEnumerator
    {
        public static readonly TransactionDescriptionEnumerator TransactionDescriptionTopup = new TransactionDescriptionEnumerator("T", "eWallet Topup", "typeEnum.transactiondescription.topup");
        public static readonly TransactionDescriptionEnumerator TransactionDescriptionPurchase = new TransactionDescriptionEnumerator("P", "eWallet Payment", "typeEnum.transactiondescription.purchase");
        public static readonly TransactionDescriptionEnumerator TransactionDescriptionMembership = new TransactionDescriptionEnumerator("M", "Membership", "typeEnum.transactiondescription.membership");
        public static readonly TransactionDescriptionEnumerator TransactionDescriptionExpire = new TransactionDescriptionEnumerator("E", "Expire", "typeEnum.transactiondescription.expire");
        public static readonly TransactionDescriptionEnumerator TransactionDescriptionInterest = new TransactionDescriptionEnumerator("I", "Bonus+", "typeEnum.transactiondescription.interest");
        public static readonly TransactionDescriptionEnumerator TransactionDescriptionCashPayment = new TransactionDescriptionEnumerator("CP", "Cash Payment", "typeEnum.transactiondescription.cashpayment");

        private static readonly Dictionary<string, TransactionDescriptionEnumerator> dict
            = new Dictionary<string, TransactionDescriptionEnumerator> {
                { TransactionDescriptionTopup.StrKey, TransactionDescriptionTopup },
                { TransactionDescriptionPurchase.StrKey, TransactionDescriptionPurchase },
                { TransactionDescriptionMembership.StrKey, TransactionDescriptionMembership },
                { TransactionDescriptionExpire.StrKey, TransactionDescriptionExpire },
                { TransactionDescriptionInterest.StrKey, TransactionDescriptionInterest },
                { TransactionDescriptionCashPayment.StrKey, TransactionDescriptionCashPayment }
            };

        public TransactionDescriptionEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }

        public static TransactionDescriptionEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out TransactionDescriptionEnumerator value))
                return value;
            else
                return null;
        }

        public static List<TransactionDescriptionEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
