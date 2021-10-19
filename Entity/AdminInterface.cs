using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data;
using System.Data.SqlClient;
using TypeEnumerator;
using Utility;



namespace Entity
{
    public class AdminInterface
    {
        private const string USER_TABLE_NAME = "tbl_User"; 

        private const string USER_PRIMARY_KEY_PREFIX = "USR";

        private const string USER_ID_COLUMN_NAME_PK = "UserID";
        private const string USER_LOGIN_NAME_COLUMN_NAME = "UserLoginName";
        private const string USER_LOGIN_PASSWORD_COLUMN_NAME = "UserLoginPassword";
        private const string USER_NAME_COLUMN_NAME = "UserName";
        private const string USER_ROLE_COLUMN_NAME = "UserRole";
        private const string USER_LAST_LOGIN_COLUMN_NAME = "UserLastLogin";
        private const string USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK = "UserBranch_BranchID";
        private const string USER_STATUS_COLUMN_NAME = "UserStatus";
        private const string USER_CREATED_BY_COLUMN_NAME = "UserCreatedBy";
        private const string USER_CREATED_DATE_COLUMN_NAME = "UserCreatedDate";
        private const string USER_MODIFIED_BY_COLUMN_NAME = "UserModifiedBy";
        private const string USER_MODIFIED_DATE_COLUMN_NAME = "UserModifiedDate";

        public static AdminEntity GetUserByPrimaryKey(string strUserID)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByPrimaryKey(USER_TABLE_NAME, USER_ID_COLUMN_NAME_PK, USER_STATUS_COLUMN_NAME),
                                                        new SqlParameter[] { CommonDB.SetParameter(USER_ID_COLUMN_NAME_PK, strUserID) },
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            if (intTotalRows <= 0)
                return null;
            else
                return new AdminEntity(dataSet.Tables[0].Rows[0][USER_ID_COLUMN_NAME_PK].ToString(),
                                        dataSet.Tables[0].Rows[0][USER_LOGIN_NAME_COLUMN_NAME].ToString(),
                                        dataSet.Tables[0].Rows[0][USER_LOGIN_PASSWORD_COLUMN_NAME].ToString(),
                                        dataSet.Tables[0].Rows[0][USER_NAME_COLUMN_NAME].ToString(),
                                        AdminRoleEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][USER_ROLE_COLUMN_NAME].ToString()),
                                        Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][USER_LAST_LOGIN_COLUMN_NAME].ToString()),
                                        dataSet.Tables[0].Rows[0][USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                        StatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][USER_STATUS_COLUMN_NAME].ToString()),
                                        dataSet.Tables[0].Rows[0][USER_CREATED_BY_COLUMN_NAME].ToString(),
                                        Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][USER_CREATED_DATE_COLUMN_NAME].ToString()),
                                        dataSet.Tables[0].Rows[0][USER_MODIFIED_BY_COLUMN_NAME].ToString(),
                                        Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][USER_MODIFIED_DATE_COLUMN_NAME].ToString()));
        }



        public static AdminEntity GetUserByLoginName(string strLoginName)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByPrimaryKey(USER_TABLE_NAME, USER_LOGIN_NAME_COLUMN_NAME, USER_STATUS_COLUMN_NAME),
                                                        new SqlParameter[] { CommonDB.SetParameter(USER_LOGIN_NAME_COLUMN_NAME, strLoginName) },
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            if (intTotalRows <= 0)
                return null;
            else
                return new AdminEntity(dataSet.Tables[0].Rows[0][USER_ID_COLUMN_NAME_PK].ToString(),
                                        dataSet.Tables[0].Rows[0][USER_LOGIN_NAME_COLUMN_NAME].ToString(),
                                        dataSet.Tables[0].Rows[0][USER_LOGIN_PASSWORD_COLUMN_NAME].ToString(),
                                        dataSet.Tables[0].Rows[0][USER_NAME_COLUMN_NAME].ToString(),
                                        AdminRoleEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][USER_ROLE_COLUMN_NAME].ToString()),
                                        Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][USER_LAST_LOGIN_COLUMN_NAME].ToString()),
                                        dataSet.Tables[0].Rows[0][USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                        StatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][USER_STATUS_COLUMN_NAME].ToString()),
                                        dataSet.Tables[0].Rows[0][USER_CREATED_BY_COLUMN_NAME].ToString(),
                                        Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][USER_CREATED_DATE_COLUMN_NAME].ToString()),
                                        dataSet.Tables[0].Rows[0][USER_MODIFIED_BY_COLUMN_NAME].ToString(),
                                        Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][USER_MODIFIED_DATE_COLUMN_NAME].ToString()));
        }



        public static AdminEntity NewUser(AdminEntity user)
        {
            user.StrUserID = PrimaryKeyController.GetLatestPrimaryKey(USER_TABLE_NAME, USER_PRIMARY_KEY_PREFIX);

            CommonDB.ExecuteNonQuery(QueryStringBuilder.GetInsertStatement(USER_TABLE_NAME, new string[] { USER_ID_COLUMN_NAME_PK,
                                                                                                                USER_LOGIN_NAME_COLUMN_NAME,
                                                                                                                USER_LOGIN_PASSWORD_COLUMN_NAME,
                                                                                                                USER_NAME_COLUMN_NAME,
                                                                                                                USER_ROLE_COLUMN_NAME,
                                                                                                                //USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK,
                                                                                                                USER_STATUS_COLUMN_NAME,
                                                                                                                USER_CREATED_BY_COLUMN_NAME,
                                                                                                                USER_CREATED_DATE_COLUMN_NAME,
                                                                                                                USER_MODIFIED_BY_COLUMN_NAME,
                                                                                                                USER_MODIFIED_DATE_COLUMN_NAME}),
                                        IsolationLevel.Serializable,
                                        new SqlParameter[] { CommonDB.SetParameter(USER_ID_COLUMN_NAME_PK, user.StrUserID),
                                                                CommonDB.SetParameter(USER_LOGIN_NAME_COLUMN_NAME, user.StrUserLoginName),
                                                                CommonDB.SetParameter(USER_LOGIN_PASSWORD_COLUMN_NAME, Encryption.HashPassword(user.StrUserLoginPassword)),
                                                                CommonDB.SetParameter(USER_NAME_COLUMN_NAME, user.StrUserName),
                                                                CommonDB.SetParameter(USER_ROLE_COLUMN_NAME, user.UserRoleUserRole.StrKey),
                                                                //CommonDB.SetParameter(USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK, user.StrUserBranch_BranchID),
                                                                CommonDB.SetParameter(USER_STATUS_COLUMN_NAME, StatusEnumerator.StatusActive.StrKey),
                                                                CommonDB.SetParameter(USER_CREATED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username),
                                                                CommonDB.SetParameter(USER_CREATED_DATE_COLUMN_NAME, DateTime.Now),
                                                                CommonDB.SetParameter(USER_MODIFIED_BY_COLUMN_NAME, null),
                                                                CommonDB.SetParameter(USER_MODIFIED_DATE_COLUMN_NAME, null)},
                                        out string strErrMsg);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            return GetUserByPrimaryKey(user.StrUserID);
        }



        public static AdminEntity UpdateUser(AdminEntity user)
        {
            AdminEntity existingUser = GetUserByPrimaryKey(user.StrUserID);
            List<string> columnList = new List<string>();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (!user.StrUserLoginName.Equals(existingUser.StrUserLoginName))
            {
                columnList.Add(USER_LOGIN_NAME_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_LOGIN_NAME_COLUMN_NAME, user.StrUserLoginName));
            }

            if (!user.StrUserLoginPassword.Equals(existingUser.StrUserLoginPassword))
            {
                columnList.Add(USER_LOGIN_PASSWORD_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_LOGIN_PASSWORD_COLUMN_NAME, Encryption.HashPassword(user.StrUserLoginPassword)));
            }

            if (!user.StrUserName.Equals(existingUser.StrUserName))
            {
                columnList.Add(USER_NAME_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_NAME_COLUMN_NAME, user.StrUserName));
            }

            if (!user.StrUserBranch_BranchID.Equals(existingUser.StrUserBranch_BranchID))
            {
                columnList.Add(USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK, user.StrUserBranch_BranchID));
            }

            if (!user.UserRoleUserRole.Equals(existingUser.UserRoleUserRole))
            {
                columnList.Add(USER_ROLE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_ROLE_COLUMN_NAME, user.UserRoleUserRole.StrKey));
            }

            if (!user.DteUserLastLogin.Equals(existingUser.DteUserLastLogin))
            {
                columnList.Add(USER_LAST_LOGIN_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_LAST_LOGIN_COLUMN_NAME, user.DteUserLastLogin));
            }

            if (!user.StatusUserStatus.Equals(existingUser.StatusUserStatus))
            {
                columnList.Add(USER_STATUS_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_STATUS_COLUMN_NAME, user.StatusUserStatus.StrKey));
            }

            if (columnList.Count > 0 && paramList.Count > 0)
            {
                columnList.Add(USER_MODIFIED_BY_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_MODIFIED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username));

                columnList.Add(USER_MODIFIED_DATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_MODIFIED_DATE_COLUMN_NAME, DateTime.Now));

                paramList.Add(CommonDB.SetParameter(USER_ID_COLUMN_NAME_PK, user.StrUserID));

                CommonDB.ExecuteNonQuery(QueryStringBuilder.GetUpdateStatement(USER_TABLE_NAME, USER_ID_COLUMN_NAME_PK, columnList.ToArray()),
                                            IsolationLevel.Serializable,
                                            paramList.ToArray(),
                                            out string strErrMsg);

                if (!String.IsNullOrEmpty(strErrMsg))
                    throw new Exception(strErrMsg);
            }

            return GetUserByPrimaryKey(user.StrUserID);
        }



        public static List<AdminEntity> ListUser(AdminEntity user)
        {
            List<string> columnList = new List<string>();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(user.StrUserID))
            {
                columnList.Add(USER_ID_COLUMN_NAME_PK);
                paramList.Add(CommonDB.SetParameter(USER_ID_COLUMN_NAME_PK, user.StrUserID));
            }

            if (!String.IsNullOrEmpty(user.StrUserName))
            {
                columnList.Add(USER_NAME_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_NAME_COLUMN_NAME, user.StrUserName));
            }

            if (!String.IsNullOrEmpty(user.StrUserBranch_BranchID))
            {
                columnList.Add(USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK, user.StrUserBranch_BranchID));
            }

            if (user.StatusUserStatus != null)
            {
                columnList.Add(USER_STATUS_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(USER_STATUS_COLUMN_NAME, user.StatusUserStatus.StrKey));
            }

            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByConstraints(USER_TABLE_NAME, columnList.ToArray(), USER_STATUS_COLUMN_NAME),
                                                        paramList.ToArray(),
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            List<AdminEntity> userList = new List<AdminEntity>();

            if (intTotalRows > 0)
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    userList.Add(new AdminEntity(row[USER_ID_COLUMN_NAME_PK].ToString(),
                                                    row[USER_LOGIN_NAME_COLUMN_NAME].ToString(),
                                                    row[USER_LOGIN_PASSWORD_COLUMN_NAME].ToString(),
                                                    row[USER_NAME_COLUMN_NAME].ToString(),
                                                    AdminRoleEnumerator.GetEnumByKey(row[USER_ROLE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[USER_LAST_LOGIN_COLUMN_NAME].ToString()),
                                        row[USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                        StatusEnumerator.GetEnumByKey(row[USER_STATUS_COLUMN_NAME].ToString()),
                                        row[USER_CREATED_BY_COLUMN_NAME].ToString(),
                                        Common.ParseDateFromDatabase(row[USER_CREATED_DATE_COLUMN_NAME].ToString()),
                                        row[USER_MODIFIED_BY_COLUMN_NAME].ToString(),
                                        Common.ParseDateFromDatabase(row[USER_MODIFIED_DATE_COLUMN_NAME].ToString())));

            return userList;
        }



        public static List<AdminEntity> ListUser()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectAllRowsStatement(USER_TABLE_NAME),
                                                        paramList.ToArray(),
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            List<AdminEntity> userList = new List<AdminEntity>();

            if (intTotalRows > 0)
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    userList.Add(new AdminEntity(row[USER_ID_COLUMN_NAME_PK].ToString(),
                                                    row[USER_LOGIN_NAME_COLUMN_NAME].ToString(),
                                                    row[USER_LOGIN_PASSWORD_COLUMN_NAME].ToString(),
                                                    row[USER_NAME_COLUMN_NAME].ToString(),
                                                    AdminRoleEnumerator.GetEnumByKey(row[USER_ROLE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[USER_LAST_LOGIN_COLUMN_NAME].ToString()),
                                        row[USER_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                        StatusEnumerator.GetEnumByKey(row[USER_STATUS_COLUMN_NAME].ToString()),
                                        row[USER_CREATED_BY_COLUMN_NAME].ToString(),
                                        Common.ParseDateFromDatabase(row[USER_CREATED_DATE_COLUMN_NAME].ToString()),
                                        row[USER_MODIFIED_BY_COLUMN_NAME].ToString(),
                                        Common.ParseDateFromDatabase(row[USER_MODIFIED_DATE_COLUMN_NAME].ToString())));

            return userList;
        }
    }
}
