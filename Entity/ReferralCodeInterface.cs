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
    public class ReferralCodeInterface
    {
        private const string REFERRAL_CODE_TABLE_NAME = "tbl_ReferralCode";

        private const string REFERRAL_CODE_PRIMARY_KEY_PREFIX = "RC";

        private const string REFERRAL_CODE_ID_COLUMN_NAME_PK = "RefCodeId";
        private const string REFERRAL_CODE_CODE_COLUMN_NAME = "RefCodeCode";
        private const string REFERRAL_CODE_TYPE_COLUMN_NAME = "RefCodeType";
        private const string REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME = "RefCodeExpiryDate";
        private const string REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK = "RefCodeOwner_ContactID";
        private const string REFERRAL_CODE_STATUS_COLUMN_NAME = "RefCodeStatus";
        private const string REFERRAL_CODE_CREATED_BY_COLUMN_NAME = "CreatedBy";
        private const string REFERRAL_CODE_CREATED_DATE_COLUMN_NAME = "CreatedDate";
        private const string REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME = "ModifiedBy";
        private const string REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME = "ModifiedDate";

        public static ReferralCodeEntity GetReferralCodeByPrimaryKey(string strReferralCodeID)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByPrimaryKey(REFERRAL_CODE_TABLE_NAME, REFERRAL_CODE_ID_COLUMN_NAME_PK, REFERRAL_CODE_STATUS_COLUMN_NAME),
                                                        new SqlParameter[] { CommonDB.SetParameter(REFERRAL_CODE_ID_COLUMN_NAME_PK, strReferralCodeID) },
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            if (intTotalRows <= 0)
                return null;
            else
                return new ReferralCodeEntity(dataSet.Tables[0].Rows[0][REFERRAL_CODE_ID_COLUMN_NAME_PK].ToString(),
                                                dataSet.Tables[0].Rows[0][REFERRAL_CODE_CODE_COLUMN_NAME].ToString(),
                                                ReferralCodeTypeEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][REFERRAL_CODE_TYPE_COLUMN_NAME].ToString()),
                                                Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME].ToString()),
                                                dataSet.Tables[0].Rows[0][REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK].ToString(),
                                                StatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][REFERRAL_CODE_STATUS_COLUMN_NAME].ToString()),
                                                dataSet.Tables[0].Rows[0][REFERRAL_CODE_CREATED_BY_COLUMN_NAME].ToString(),
                                                Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][REFERRAL_CODE_CREATED_DATE_COLUMN_NAME].ToString()),
                                                dataSet.Tables[0].Rows[0][REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME].ToString())); 
        }



        public static ReferralCodeEntity GetReferralCodeByReferalCode(string strReferralCode)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByPrimaryKey(REFERRAL_CODE_TABLE_NAME, REFERRAL_CODE_CODE_COLUMN_NAME, REFERRAL_CODE_STATUS_COLUMN_NAME),
                                                        new SqlParameter[] { CommonDB.SetParameter(REFERRAL_CODE_CODE_COLUMN_NAME, strReferralCode) },
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            if (intTotalRows <= 0)
                return null;
            else
                return new ReferralCodeEntity(dataSet.Tables[0].Rows[0][REFERRAL_CODE_ID_COLUMN_NAME_PK].ToString(),
                                                dataSet.Tables[0].Rows[0][REFERRAL_CODE_CODE_COLUMN_NAME].ToString(),
                                                ReferralCodeTypeEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][REFERRAL_CODE_TYPE_COLUMN_NAME].ToString()),
                                                Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME].ToString()),
                                                dataSet.Tables[0].Rows[0][REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK].ToString(),
                                                StatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][REFERRAL_CODE_STATUS_COLUMN_NAME].ToString()),
                                                dataSet.Tables[0].Rows[0][REFERRAL_CODE_CREATED_BY_COLUMN_NAME].ToString(),
                                                Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][REFERRAL_CODE_CREATED_DATE_COLUMN_NAME].ToString()),
                                                dataSet.Tables[0].Rows[0][REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME].ToString()));
        }



        public static ReferralCodeEntity NewReferralCode(ReferralCodeEntity referralCode)
        {
            referralCode.StrRefCodeId = PrimaryKeyController.GetLatestPrimaryKey(REFERRAL_CODE_TABLE_NAME, REFERRAL_CODE_PRIMARY_KEY_PREFIX);

            CommonDB.ExecuteNonQuery(QueryStringBuilder.GetInsertStatement(REFERRAL_CODE_TABLE_NAME, new string[] { REFERRAL_CODE_ID_COLUMN_NAME_PK,
                                                                                                                        REFERRAL_CODE_CODE_COLUMN_NAME,
                                                                                                                        REFERRAL_CODE_TYPE_COLUMN_NAME,
                                                                                                                        REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME,
                                                                                                                        REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK,
                                                                                                                        REFERRAL_CODE_STATUS_COLUMN_NAME,
                                                                                                                        REFERRAL_CODE_CREATED_BY_COLUMN_NAME,
                                                                                                                        REFERRAL_CODE_CREATED_DATE_COLUMN_NAME,
                                                                                                                        REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME,
                                                                                                                        REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME }),
                                        IsolationLevel.Serializable,
                                        new SqlParameter[] { CommonDB.SetParameter(REFERRAL_CODE_ID_COLUMN_NAME_PK, referralCode.StrRefCodeId),
                                                                CommonDB.SetParameter(REFERRAL_CODE_CODE_COLUMN_NAME, referralCode.StrRefCodeCode),
                                                                CommonDB.SetParameter(REFERRAL_CODE_TYPE_COLUMN_NAME, referralCode.RCTRefCodeType.StrKey),
                                                                CommonDB.SetParameter(REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME, referralCode.DteRefCodeExpiryDate),
                                                                CommonDB.SetParameter(REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK, referralCode.StrRefCodeOwner_ContactID),
                                                                CommonDB.SetParameter(REFERRAL_CODE_STATUS_COLUMN_NAME, StatusEnumerator.StatusActive.StrKey),
                                                                CommonDB.SetParameter(REFERRAL_CODE_CREATED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username),
                                                                CommonDB.SetParameter(REFERRAL_CODE_CREATED_DATE_COLUMN_NAME, DateTime.Now),
                                                                CommonDB.SetParameter(REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME, null),
                                                                CommonDB.SetParameter(REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME, null)},
                                        out string strErrMsg);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            return GetReferralCodeByPrimaryKey(referralCode.StrRefCodeId);
        }



        public static ReferralCodeEntity UpdateReferralCode(ReferralCodeEntity referralCode)
        {
            ReferralCodeEntity existingReferralCode = GetReferralCodeByPrimaryKey(referralCode.StrRefCodeId);
            List<string> columnList = new List<string>();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (!referralCode.StrRefCodeCode.Equals(existingReferralCode.StrRefCodeCode))
            {
                columnList.Add(REFERRAL_CODE_CODE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_CODE_COLUMN_NAME, referralCode.StrRefCodeCode));
            }

            if (!referralCode.RCTRefCodeType.Equals(existingReferralCode.RCTRefCodeType))
            {
                columnList.Add(REFERRAL_CODE_TYPE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_TYPE_COLUMN_NAME, referralCode.RCTRefCodeType.StrKey));
            }

            if (!referralCode.DteRefCodeExpiryDate.Equals(existingReferralCode.DteRefCodeExpiryDate))
            {
                columnList.Add(REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME, referralCode.DteRefCodeExpiryDate));
            }

            if (!referralCode.StrRefCodeOwner_ContactID.Equals(existingReferralCode.StrRefCodeOwner_ContactID))
            {
                columnList.Add(REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK, referralCode.StrRefCodeOwner_ContactID));
            }

            if (!referralCode.StatusRefCodeStatus.Equals(existingReferralCode.StatusRefCodeStatus))
            {
                columnList.Add(REFERRAL_CODE_STATUS_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_STATUS_COLUMN_NAME, referralCode.StatusRefCodeStatus.StrKey));
            }

            if (columnList.Count > 0 && paramList.Count > 0)
            {
                columnList.Add(REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username));

                columnList.Add(REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME, DateTime.Now));

                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_ID_COLUMN_NAME_PK, referralCode.StrRefCodeId));

                CommonDB.ExecuteNonQuery(QueryStringBuilder.GetUpdateStatement(REFERRAL_CODE_TABLE_NAME, REFERRAL_CODE_ID_COLUMN_NAME_PK, columnList.ToArray()),
                                            IsolationLevel.Serializable,
                                            paramList.ToArray(),
                                            out string strErrMsg);

                if (!String.IsNullOrEmpty(strErrMsg))
                    throw new Exception(strErrMsg);
            }

            return GetReferralCodeByPrimaryKey(referralCode.StrRefCodeId);
        }



        public static List<ReferralCodeEntity> listReferralCode(ReferralCodeEntity referralCode)
        {
            List<string> columnList = new List<string>();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(referralCode.StrRefCodeId))
            {
                columnList.Add(REFERRAL_CODE_ID_COLUMN_NAME_PK);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_ID_COLUMN_NAME_PK, referralCode.StrRefCodeId));
            }

            if (!String.IsNullOrEmpty(referralCode.StrRefCodeCode))
            {
                columnList.Add(REFERRAL_CODE_CODE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_CODE_COLUMN_NAME, referralCode.StrRefCodeCode));
            }

            if (!String.IsNullOrEmpty(referralCode.StrRefCodeOwner_ContactID))
            {
                columnList.Add(REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK, referralCode.StrRefCodeOwner_ContactID));
            }

            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByConstraints(REFERRAL_CODE_TABLE_NAME, columnList.ToArray(), REFERRAL_CODE_STATUS_COLUMN_NAME),
                                                        paramList.ToArray(),
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            List<ReferralCodeEntity> referralCodeList = new List<ReferralCodeEntity>();

            if (intTotalRows > 0)
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    referralCodeList.Add(new ReferralCodeEntity(row[REFERRAL_CODE_ID_COLUMN_NAME_PK].ToString(),
                                                row[REFERRAL_CODE_CODE_COLUMN_NAME].ToString(),
                                                ReferralCodeTypeEnumerator.GetEnumByKey(row[REFERRAL_CODE_TYPE_COLUMN_NAME].ToString()),
                                                Common.ParseDateFromDatabase(row[REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME].ToString()),
                                                row[REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK].ToString(),
                                                StatusEnumerator.GetEnumByKey(row[REFERRAL_CODE_STATUS_COLUMN_NAME].ToString()),
                                                row[REFERRAL_CODE_CREATED_BY_COLUMN_NAME].ToString(),
                                                Common.ParseDateFromDatabase(row[REFERRAL_CODE_CREATED_DATE_COLUMN_NAME].ToString()),
                                                row[REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                Common.ParseDateFromDatabase(row[REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME].ToString())));

            return referralCodeList;
        }



        public static List<ReferralCodeEntity> ListReferralCodeByExpiryDate(DateTime? dteBeginDate, DateTime? dteEndDate)
        {
            DataSet dataSet;
            string strErrMsg;
            int intTotalRows;

            if(dteBeginDate == null && dteEndDate == null)
            {
                throw new Exception("At least one parameter must not be <Null>")
;            }
            else if (dteBeginDate != null && dteEndDate != null)
            {
                string strSQLStatement = QueryStringBuilder.GetBetweenValueSelectStatement(REFERRAL_CODE_TABLE_NAME, REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME, out string[] paramNames);
                dataSet = CommonDB.ExecuteReader(strSQLStatement,
                                                            new SqlParameter[] { CommonDB.SetParameter(paramNames[0], dteBeginDate),
                                                                             CommonDB.SetParameter(paramNames[1], dteEndDate)},
                                                            out strErrMsg, out intTotalRows);
            }
            else
            {
                DateTime dteSampleDate;
                bool isGreater;
                if(dteBeginDate != null)
                {
                    dteSampleDate = (DateTime)dteBeginDate;
                    isGreater = true;
                }
                else
                {
                    dteSampleDate = (DateTime)dteEndDate;
                    isGreater = false;
                }

                dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetValueGreaterOrLessThanSelectStatement(REFERRAL_CODE_TABLE_NAME, REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME, isGreater, true),
                                                            new SqlParameter[] { CommonDB.SetParameter(REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME, dteSampleDate) },
                                                            out strErrMsg, out intTotalRows);
            }

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            List < ReferralCodeEntity > lstReferralCodeList = new List<ReferralCodeEntity>();

            if (intTotalRows > 0)
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    lstReferralCodeList.Add(new ReferralCodeEntity(row[REFERRAL_CODE_ID_COLUMN_NAME_PK].ToString(),
                                                                   row[REFERRAL_CODE_CODE_COLUMN_NAME].ToString(),
                                                                   ReferralCodeTypeEnumerator.GetEnumByKey(row[REFERRAL_CODE_TYPE_COLUMN_NAME].ToString()),
                                                                   DateTime.Parse(row[REFERRAL_CODE_EXPIRY_DATE_COLUMN_NAME].ToString()),
                                                                   row[REFERRAL_CODE_OWNER_CONTACT_ID_COLUMN_NAME_FK].ToString(),
                                                                   StatusEnumerator.GetEnumByKey(row[REFERRAL_CODE_STATUS_COLUMN_NAME].ToString()),
                                                                   row[REFERRAL_CODE_CREATED_BY_COLUMN_NAME].ToString(),
                                                                   DateTime.Parse(row[REFERRAL_CODE_CREATED_DATE_COLUMN_NAME].ToString()),
                                                                   row[REFERRAL_CODE_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                                   DateTime.Parse(row[REFERRAL_CODE_MODIFIED_DATE_COLUMN_NAME].ToString())));
            return lstReferralCodeList;
        }
    }
}
