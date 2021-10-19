using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;



namespace Entity
{
    public class AdminEntity : UserEntity
    {
        public string StrUserID { get; set; }
        public string StrUserLoginName { get; set; }
        public string StrUserLoginPassword { get; set; }
        public string StrUserName { get; set; }
        public AdminRoleEnumerator UserRoleUserRole { get; set; }
        public DateTime? DteUserLastLogin { get; set; }
        public string StrUserBranch_BranchID { get; set; }
        public StatusEnumerator StatusUserStatus { get; set; }
        public string StrUserCreatedBy { get; set; }
        public DateTime? DteUserCreatedDate { get; set; }
        public string StrUserModifiedBy { get; set; }
        public DateTime? DteUserModifiedDate { get; set; }

        //private BranchEntity field_branchUserBranch;
        //public BranchEntity BranchUserBranch
        //{
        //    get
        //    {
        //        if (field_branchUserBranch == null)
        //            field_branchUserBranch = BranchInterface.GetBranchByPrimaryKey(this.StrUserBranch_BranchID);

        //        return field_branchUserBranch;
        //    }
        //}



        public AdminEntity()
        {
            this.StrUserID = String.Empty;
            this.StrUserLoginName = String.Empty;
            this.StrUserLoginPassword = String.Empty;
            this.StrUserName = String.Empty;
            this.UserRoleUserRole = null;
            this.DteUserLastLogin = new DateTime();
            this.StrUserBranch_BranchID = string.Empty;
            this.StatusUserStatus = null;
            this.StrUserCreatedBy = String.Empty;
            this.DteUserCreatedDate = new DateTime();
            this.StrUserModifiedBy = String.Empty;
            this.DteUserModifiedDate = new DateTime();
        }



        public AdminEntity(string strUserID,
                             string strUserLoginName,
                             string strUserLoginPassword,
                             string strUserName,
                             AdminRoleEnumerator userRoleUserRole,
                             DateTime? dteUserLastLogin,
                             string strUserBranch_BranchID,
                             StatusEnumerator statusUserStatus,
                             string strUserCreatedBy,
                             DateTime? dteUserCreatedDate,
                             string strUserModifiedBy,
                             DateTime? dteUserModifiedDate)
        {
            this.StrUserID = strUserID;
            this.StrUserLoginName = strUserLoginName;
            this.StrUserLoginPassword = strUserLoginPassword;
            this.StrUserName = strUserName;
            this.UserRoleUserRole = userRoleUserRole;
            this.DteUserLastLogin = dteUserLastLogin;
            this.StrUserBranch_BranchID = strUserBranch_BranchID;
            this.StatusUserStatus = statusUserStatus;
            this.StrUserCreatedBy = strUserCreatedBy;
            this.DteUserCreatedDate = dteUserCreatedDate;
            this.StrUserModifiedBy = strUserModifiedBy;
            this.DteUserModifiedDate = dteUserModifiedDate;
        }
    }
}
