using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;

namespace Entity
{
    public class TransactionEntity : BaseEntity
    {
        public string StrWalletPocketTransactionID { get; set; }
        public TransactionDescriptionEnumerator TransactionDescriptionEnumeratorTransactionDescription { get; set; }
        
        public decimal DecEarningPoint { get; set; }
        public decimal DecPointPerCredit { get; set; }
        public decimal DecExistingMasterPointBalance { get; set; }
        public decimal DecNewEarningPointBalance { get; set; }

        public decimal DecCredit { get; set; }
        public decimal DecInterestRate { get; set; }
        public decimal DecExistingBalance { get; set; }
        public decimal DecNewBalance { get; set; }
        
        public DateTime? DteValidity { get; set; }

        public string StrContactID { get; set; }

        public string StrWalletPocketID { get; set; }
        public string StrWalletPocketTransactionReferenceID { get; set; }
        public string StrWalletPocketTransactionToken { get; set; }
        public decimal DecWalletPocketTransactionAmount { get; set; }
        public string StrPOSTransactionNo { get; set; }
        public StatusEnumerator StatusWalletPocketTransactionStatus { get; set; }
        public string StrWalletPocketTransactionCreatedBy { get; set; }
        public DateTime? DteWalletPocketTransactionCreatedDate { get; set; }
        public string StrWalletPocketTransactionModifiedBy { get; set; }
        public DateTime? DteWalletPocketTransactionModifiedDate { get; set; }
    }
}
