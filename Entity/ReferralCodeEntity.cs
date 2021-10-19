using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;



namespace Entity
{
    public class ReferralCodeEntity
    {
        public string StrRefCodeId { get; set; }
        public string StrRefCodeCode { get; set; }
        public ReferralCodeTypeEnumerator RCTRefCodeType { get; set; }
        public DateTime? DteRefCodeExpiryDate { get; set; }
        public string StrRefCodeOwner_ContactID { get; set; }
        public StatusEnumerator StatusRefCodeStatus { get; set; }
        public string StrRefCodeCreatedBy { get; set; }
        public DateTime? DteRefCodeCreatedDate { get; set; }
        public string StrRefCodeModifiedBy { get; set; }
        public DateTime? DteRefCodeModifiedDate { get; set; }

        private ContactEntity contactRefCodeOwner;
        public ContactEntity ContactRefCodeOwner
        {
            get
            {
                if (contactRefCodeOwner == null)
                    contactRefCodeOwner = ContactInterface.GetContactByPrimaryKey(this.StrRefCodeOwner_ContactID);

                return contactRefCodeOwner;
            }

            set { contactRefCodeOwner = value; }
        }




        //private AgentEntity agentRefCodeOwner;
        //public AgentEntity AgentRefCodeOwner
        //{
        //    get
        //    {
        //        if (agentRefCodeOwner == null)
        //            agentRefCodeOwner = AgentInterface.GetAgentByPrimaryKey(this.StrRefCodeOwner_AgentID);

        //        return agentRefCodeOwner;
        //    }

        //    set { agentRefCodeOwner = value; }
        //}



        public ReferralCodeEntity()
        {
            this.StrRefCodeId = string.Empty;
            this.StrRefCodeCode = string.Empty;
            this.RCTRefCodeType = null;
            this.DteRefCodeExpiryDate = null;
            this.StrRefCodeOwner_ContactID = string.Empty;
            this.StatusRefCodeStatus = null;
            this.StrRefCodeCreatedBy = string.Empty;
            this.DteRefCodeCreatedDate = null;
            this.StrRefCodeModifiedBy = string.Empty;
            this.DteRefCodeModifiedDate = null;

            this.contactRefCodeOwner = null;
        }



        public ReferralCodeEntity(string strReCodefId,
                                    string strRefCodeCode,
                                    ReferralCodeTypeEnumerator rctRefCodeType,
                                    DateTime? dteRefCodeExpiryDate,
                                    string strRefCodeOwner_ContactID,
                                    StatusEnumerator statusRefCodeState,
                                    string strRefCodeCreatedBy,
                                    DateTime? dteRefCodeCreatedDate,
                                    string strRefCodeModifiedBy,
                                    DateTime? dteRefCodeModifiedDate)
        {
            this.StrRefCodeId = strReCodefId;
            this.StrRefCodeCode = strRefCodeCode;
            this.RCTRefCodeType = rctRefCodeType;
            this.DteRefCodeExpiryDate = dteRefCodeExpiryDate;
            this.StrRefCodeOwner_ContactID = strRefCodeOwner_ContactID;
            this.StatusRefCodeStatus = statusRefCodeState;
            this.StrRefCodeCreatedBy = strRefCodeCreatedBy;
            this.DteRefCodeCreatedDate = dteRefCodeCreatedDate;
            this.StrRefCodeModifiedBy = strRefCodeModifiedBy;
            this.DteRefCodeModifiedDate = dteRefCodeModifiedDate;

            this.contactRefCodeOwner = null;
        }
    }
}
