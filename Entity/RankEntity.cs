using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;
using TypeEnumerator;



namespace Entity
{
    public class RankEntity
    {
        public string StrRankID { get; set; }
        public string StrRankName { get; set; }
        public string StrRankDescription { get; set; }
        public StatusEnumerator StatusRewardStatus { get; set; }
        public decimal DecRewardConditionValue { get; set; }
        public decimal DecRewardMinOrderValue { get; set; }
        public string StrRewardName { get; set; }
        public decimal DecRewardValue { get; set; }
        public string StrRewardCode { get; set; }
        public string StrRewardCreatedBy { get; set; }
        public DateTime? DteRewardCreatedDate { get; set; }
        public string StrRewardModifiedBy { get; set; }
        public DateTime? DteRewardModifiedDate { get; set; }



        public RankEntity()
        {
            this.StrRankID = string.Empty;
            this.StrRankName = string.Empty;
            this.StrRankDescription = string.Empty;
            this.StatusRewardStatus = null;
            this.DecRewardConditionValue = 0;
            this.DecRewardMinOrderValue = 0;
            this.StrRewardName = string.Empty;
            this.DecRewardValue = 0;
            this.StrRewardCode = string.Empty;
            this.StrRewardCreatedBy = string.Empty;
            this.DteRewardCreatedDate = null;
            this.StrRewardModifiedBy = string.Empty;
            this.DteRewardModifiedDate = null;
        }



        public RankEntity(
            string strRankID,
            string strRankName,
            string strRankDescription,
            StatusEnumerator statusRewardStatus,
            decimal decRewardConditionValue,
            decimal decRewardMinOrderValue,
            string strRewardName,
            decimal decRewardValue,
            string strRewardCode,
            string strRewardCreatedBy,
            DateTime? dteRewardCreatedDate,
            string strRewardModifiedBy,
            DateTime? dteRewardModifiedDate)
        {
            this.StrRankID = strRankID;
            this.StrRankName = strRankName;
            this.StrRankDescription = strRankDescription;
            this.StatusRewardStatus = statusRewardStatus;
            this.DecRewardConditionValue = decRewardConditionValue;
            this.DecRewardMinOrderValue = decRewardMinOrderValue;
            this.StrRewardName = strRewardName;
            this.DecRewardValue = decRewardValue;
            this.StrRewardCode = strRewardCode;
            this.StrRewardCreatedBy = strRewardCreatedBy;
            this.DteRewardCreatedDate = dteRewardCreatedDate;
            this.StrRewardModifiedBy = strRewardModifiedBy;
            this.DteRewardModifiedDate = dteRewardModifiedDate;
        }
    }
}
