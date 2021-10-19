using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;
using TypeEnumerator;



namespace Entity
{
    public class PotentialStudentEntity
    {
        public string StrPotenStudID { get; set; }
        public string StrPotenStudName { get; set; }
        public IDTypeEnumerator IDTypePotenStudIDType { get; set; }
        public string StrPotenStudIDNumber { get; set; }
        public DateTime? DtePotenStudDOB { get; set; }
        public string StrPotenStudEmail { get; set; }
        public GenderEnumerator GenderPotenStudGender { get; set; }
        public MaritalStatusEnumerator MarStatPotenStudMaritalStat { get; set; }
        public string StrPotenStudContactNo { get; set; }
        public Address AddPotenStudAddress { get; set; }
        public DateTime? DtePotenStudRegByDate { get; set; }
        public DateTime? DtePotenStudSignUpDate { get; set; }
        public DateTime? DtePotenStudRegFormalisationDate { get; set; }
        public decimal? DecPotenStudCommissionRate { get; set; }
        public decimal? DecPotenStudCommissionTotalPaidOut { get; set; }
        public DateTime? DtePotenStudCommissionPaidOutDate { get; set; }
        public string StrPotenStudReferrer_AgentID { get; set; }
        public string StrPotenStudBranch_BranchID { get; set; }
        public string StrPotenStudProgramme_ProgrammeID { get; set; }
        public StatusEnumerator StatusPotenStudStatus { get; set; }
        public string StrPotenStudCreatedBy { get; set; }
        public DateTime? DtePotenStudCreatedDate { get; set; }
        public string StrPotenStudModifiedBy { get; set; }
        public DateTime? DtePotenStudModifiedDate { get; set; }

        private AgentEntity field_agentPotenStudReferrer;
        public AgentEntity AgentPotenStudReferrer
        {
            get
            {
                if (field_agentPotenStudReferrer == null)
                {
                    field_agentPotenStudReferrer = AgentInterface.GetAgentByPrimaryKey(this.StrPotenStudReferrer_AgentID);
                }
                return field_agentPotenStudReferrer;
            }
        }



        private BranchEntity field_branchPotenStudBranch;
        public BranchEntity BranchPotenStudBranch
        {
            get
            {
                if (field_branchPotenStudBranch == null)
                {
                    field_branchPotenStudBranch = BranchInterface.GetBranchByPrimaryKey(this.StrPotenStudBranch_BranchID);
                }
                return field_branchPotenStudBranch;
            }
        }

        private ProgrammeEntity field_programmePotenStudProgramme;
        public ProgrammeEntity ProgrammePotenStudProgramme
        {
            get
            {
                if (field_programmePotenStudProgramme == null)
                {
                    field_programmePotenStudProgramme = ProgrammeInterface.GetByPrimaryKey(this.StrPotenStudProgramme_ProgrammeID);
                }
                return field_programmePotenStudProgramme;
            }
        }

        private List<PotentialStudentCommentLogEntity> field_LstCommentLogs;
        public List<PotentialStudentCommentLogEntity> LstCommentLogs
        {
            get
            {
                if (field_LstCommentLogs == null)
                {
                    field_LstCommentLogs = PotentialStudentCommentLogInterface.List(new PotentialStudentCommentLogEntity { StrPotentialStudentCommentLog_PotenStudID = this.StrPotenStudID });
                }
                return field_LstCommentLogs;
            }
        }

        public StudentRegistrationStatusEnumerator RegistrationStatus
        {
            get
            {
                if (DtePotenStudRegFormalisationDate != null)
                    return StudentRegistrationStatusEnumerator.StudentRegistrationRegistered;
                else
                {
                    if (((DateTime)DtePotenStudRegByDate) >= DateTime.Now)
                        return StudentRegistrationStatusEnumerator.StudentRegistrationPending;
                    else
                        return StudentRegistrationStatusEnumerator.StudentRegistrationExpired;

                }
            }
        }

        public PotentialStudentEntity()
        {
            this.StrPotenStudID = string.Empty;
            this.StrPotenStudName = string.Empty;
            this.IDTypePotenStudIDType = null;
            this.StrPotenStudIDNumber = string.Empty;
            this.DtePotenStudDOB = null;
            this.StrPotenStudEmail = string.Empty;
            this.GenderPotenStudGender = null;
            this.MarStatPotenStudMaritalStat = null;
            this.StrPotenStudContactNo = string.Empty;
            this.AddPotenStudAddress = null;
            this.DtePotenStudRegByDate = null;
            this.DtePotenStudSignUpDate = null;
            this.DtePotenStudRegFormalisationDate = null;
            this.DecPotenStudCommissionRate = 0;
            this.DecPotenStudCommissionTotalPaidOut = 0;
            this.DtePotenStudCommissionPaidOutDate = null;
            this.StrPotenStudReferrer_AgentID = string.Empty;
            this.StrPotenStudBranch_BranchID = string.Empty;
            this.StrPotenStudProgramme_ProgrammeID = string.Empty;
            this.StatusPotenStudStatus = null;
            this.StrPotenStudCreatedBy = string.Empty;
            this.DtePotenStudCreatedDate = null;
            this.StrPotenStudModifiedBy = string.Empty;
            this.DtePotenStudModifiedDate = null;

            this.field_agentPotenStudReferrer = null;
            this.field_branchPotenStudBranch = null;
        }



        public PotentialStudentEntity(string strPotenStudID,
                                        string strPotenStudName,
                                        IDTypeEnumerator idTypePotenStudIDType,
                                        string strPotenStudIDNumber,
                                        DateTime? dtePotenStudDOB,
                                        string strPotenStudEmail,
                                        GenderEnumerator genderPotenStudGender,
                                        MaritalStatusEnumerator marStatPotenStudMaritalStat,
                                        string strPotenStudContactNo,
                                        Address addPotenStudAddress,
                                        DateTime? dtePotenStudRegByDate,
                                        DateTime? dtePotenStudSignUpDate,
                                        DateTime? dtePotenStudRegFormalisationDate,
                                        decimal decPotenStudCommissionRate,
                                        decimal decPotenStudCommissionTotalPaidOut,
                                        DateTime? dtePotenStudCommissionPaidOutDate,
                                        string strPotenStudReferrer_AgentID,
                                        string strPotenStudBranch_BranchID,
                                        string strPotenStudProgramme_ProgrammeID,
                                        StatusEnumerator statusPotenStudStatus,
                                        string strPotenStudCreatedBy,
                                        DateTime? dtePotenStudCreatedDate,
                                        string strPotenStudModifiedBy,
                                        DateTime? dtePotenStudModifiedDate)
        {
            this.StrPotenStudID = strPotenStudID;
            this.StrPotenStudName = strPotenStudName;
            this.IDTypePotenStudIDType = idTypePotenStudIDType;
            this.StrPotenStudIDNumber = strPotenStudIDNumber;
            this.DtePotenStudDOB = dtePotenStudDOB;
            this.StrPotenStudEmail = strPotenStudEmail;
            this.GenderPotenStudGender = genderPotenStudGender;
            this.MarStatPotenStudMaritalStat = marStatPotenStudMaritalStat;
            this.StrPotenStudContactNo = strPotenStudContactNo;
            this.AddPotenStudAddress = addPotenStudAddress;
            this.DtePotenStudRegByDate = dtePotenStudRegByDate;
            this.DtePotenStudSignUpDate = dtePotenStudSignUpDate;
            this.DtePotenStudRegFormalisationDate = dtePotenStudRegFormalisationDate;
            this.DecPotenStudCommissionRate = decPotenStudCommissionRate;
            this.DecPotenStudCommissionTotalPaidOut = decPotenStudCommissionTotalPaidOut;
            this.DtePotenStudCommissionPaidOutDate = dtePotenStudCommissionPaidOutDate;
            this.StrPotenStudReferrer_AgentID = strPotenStudReferrer_AgentID;
            this.StrPotenStudBranch_BranchID = strPotenStudBranch_BranchID;
            this.StrPotenStudProgramme_ProgrammeID = strPotenStudProgramme_ProgrammeID;
            this.StatusPotenStudStatus = statusPotenStudStatus;
            this.StrPotenStudCreatedBy = strPotenStudCreatedBy;
            this.DtePotenStudCreatedDate = dtePotenStudCreatedDate;
            this.StrPotenStudModifiedBy = strPotenStudModifiedBy;
            this.DtePotenStudModifiedDate = dtePotenStudModifiedDate;

            this.field_agentPotenStudReferrer = null;
            this.field_branchPotenStudBranch = null;
        }
    }
}
