using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data;
using System.Data.SqlClient;
using General;
using Utility;
using TypeEnumerator;



namespace Entity
{
    public class PotentialStudentInterface
    {
        private const string POTENTIAL_STUDENT_TABLE_NAME = "tbl_HELPUNI_PotentialStudent";

        private const string POTENTIAL_STUDENT_PRIMARY_KEY_PREFIX = "PT";

        private const string POTENTIAL_STUDENT_ID_COLUMN_NAME_PK = "PotenStudID";
        private const string POTENTIAL_STUDENT_NAME_COLUMN_NAME = "PotenStudName";
        private const string POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME = "PotenStudIDType";
        private const string POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME = "PotenStudIDNumber";
        private const string POTENTIAL_STUDENT_DOB_COLUMN_NAME = "PotenStudDOB";
        private const string POTENTIAL_STUDENT_EMAIL_COLUMN_NAME = "PotenStudEmail";
        private const string POTENTIAL_STUDENT_GENDER_COLUMN_NAME = "PotenStudGender";
        private const string POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME = "PotenStudMaritalStat";
        private const string POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME = "PotenStudContactNo";
        private const string POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME = "PotenStudAddLine1";
        private const string POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME = "PotenStudAddLine2";
        private const string POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME = "PotenStudAddLine3";
        private const string POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME = "PotenStudAddPostcode";
        private const string POTENTIAL_STUDENT_ADD_CITY_NAME = "PotenStudAddCity";
        private const string POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME = "PotenStudAddState";
        private const string POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME = "PotenStudAddCountry";
        private const string POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME = "PotenStudRegByDate";
        private const string POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME = "PotenStudSignUpDate";
        private const string POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME = "PotenStudRegFormalisationDate";
        private const string POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME = "PotenStudCommissionRate";
        private const string POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME = "PotenStudCommisionTotalPaid";
        private const string POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME = "PotenStudCommissionPaidOutDate";
        private const string POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK = "PotenStudReferrer_AgentID";
        private const string POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK = "PotenStudBranch_BranchID";
        private const string POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK = "PotenStudProgramme_ProgrammeID";
        private const string POTENTIAL_STUDENT_STATUS_COLUMN_NAME = "PotenStudStatus";
        private const string POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME = "PotenStudCreatedBy";
        private const string POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME = "PotenStudCreatedDate";
        private const string POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME = "PotenStudModifiedBy";
        private const string POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME = "PotenStudModifiedDate";

        public static PotentialStudentEntity GetPotentialStudentByPrimaryKey(string strPotentialStudentID)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByPrimaryKey(POTENTIAL_STUDENT_TABLE_NAME, POTENTIAL_STUDENT_ID_COLUMN_NAME_PK, POTENTIAL_STUDENT_STATUS_COLUMN_NAME),
                                                        new SqlParameter[] { CommonDB.SetParameter(POTENTIAL_STUDENT_ID_COLUMN_NAME_PK, strPotentialStudentID) },
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            if (intTotalRows <= 0)
                return null;
            else
                return new PotentialStudentEntity(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_COLUMN_NAME_PK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_NAME_COLUMN_NAME].ToString(),
                                                    IDTypeEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_DOB_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_EMAIL_COLUMN_NAME].ToString(),
                                                    GenderEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_GENDER_COLUMN_NAME].ToString()),
                                                    MaritalStatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME].ToString(),
                                                    new Address(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_CITY_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK].ToString(),
                                                    StatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_STATUS_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME].ToString()));
        }



        public static PotentialStudentEntity GetPotentialStudentByEmail(string strPotentialStudentEmail)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByPrimaryKey(POTENTIAL_STUDENT_TABLE_NAME, POTENTIAL_STUDENT_EMAIL_COLUMN_NAME, POTENTIAL_STUDENT_STATUS_COLUMN_NAME),
                                                        new SqlParameter[] { CommonDB.SetParameter(POTENTIAL_STUDENT_EMAIL_COLUMN_NAME, strPotentialStudentEmail) },
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            if (intTotalRows <= 0)
                return null;
            else
                return new PotentialStudentEntity(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_COLUMN_NAME_PK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_NAME_COLUMN_NAME].ToString(),
                                                    IDTypeEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_DOB_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_EMAIL_COLUMN_NAME].ToString(),
                                                    GenderEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_GENDER_COLUMN_NAME].ToString()),
                                                    MaritalStatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME].ToString(),
                                                    new Address(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_CITY_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK].ToString(),
                                                    StatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_STATUS_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME].ToString()));
        }



        public static PotentialStudentEntity GetPotentialStudentByIDTypeNumber(string strPotentialStudentIdType, string strPotentialStudentIdNumber)
        {
            string[] strPotentialStudentColumn = new string[2];

            strPotentialStudentColumn[0] = POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME;
            strPotentialStudentColumn[1] = POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME;

            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByConstraints(POTENTIAL_STUDENT_TABLE_NAME, strPotentialStudentColumn, POTENTIAL_STUDENT_STATUS_COLUMN_NAME),
                                                        new SqlParameter[] { CommonDB.SetParameter(POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME, strPotentialStudentIdType), CommonDB.SetParameter(POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME, strPotentialStudentIdNumber) },
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            if (intTotalRows <= 0)
                return null;
            else
                return new PotentialStudentEntity(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_COLUMN_NAME_PK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_NAME_COLUMN_NAME].ToString(),
                                                    IDTypeEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_DOB_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_EMAIL_COLUMN_NAME].ToString(),
                                                    GenderEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_GENDER_COLUMN_NAME].ToString()),
                                                    MaritalStatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME].ToString(),
                                                    new Address(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_CITY_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME].ToString(),
                                                                dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK].ToString(),
                                                    StatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_STATUS_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME].ToString()),
                                                    dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME].ToString()));
        }



        public static PotentialStudentEntity NewPotentialStudent(PotentialStudentEntity potentialStudent)
        {
            potentialStudent.StrPotenStudID = PrimaryKeyController.GetLatestPrimaryKey(POTENTIAL_STUDENT_TABLE_NAME, POTENTIAL_STUDENT_PRIMARY_KEY_PREFIX);

            CommonDB.ExecuteNonQuery(QueryStringBuilder.GetInsertStatement(POTENTIAL_STUDENT_TABLE_NAME, new string[] { POTENTIAL_STUDENT_ID_COLUMN_NAME_PK,
                                                                                                                            POTENTIAL_STUDENT_NAME_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_DOB_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_EMAIL_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_GENDER_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_ADD_CITY_NAME,
                                                                                                                            POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK,
                                                                                                                            POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK,
                                                                                                                            POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK,
                                                                                                                            POTENTIAL_STUDENT_STATUS_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME,
                                                                                                                            POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME}),
                                        IsolationLevel.Serializable,
                                        new SqlParameter[] { CommonDB.SetParameter(POTENTIAL_STUDENT_ID_COLUMN_NAME_PK, potentialStudent.StrPotenStudID),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_NAME_COLUMN_NAME, potentialStudent.StrPotenStudName),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME, potentialStudent.IDTypePotenStudIDType.StrKey),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME, potentialStudent.StrPotenStudIDNumber),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_DOB_COLUMN_NAME, potentialStudent.DtePotenStudDOB),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_EMAIL_COLUMN_NAME, potentialStudent.StrPotenStudEmail),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_GENDER_COLUMN_NAME, potentialStudent.GenderPotenStudGender.StrKey),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME, potentialStudent.MarStatPotenStudMaritalStat.StrKey),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME, potentialStudent.StrPotenStudContactNo),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddLine1),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddLine2),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddLine3),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddPostcode),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_CITY_NAME, potentialStudent.AddPotenStudAddress.StrAddCity),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddState),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddCountry),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME, potentialStudent.DtePotenStudRegByDate),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME, potentialStudent.DtePotenStudSignUpDate),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME, potentialStudent.DtePotenStudRegFormalisationDate),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME, potentialStudent.DecPotenStudCommissionRate),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME, potentialStudent.DecPotenStudCommissionTotalPaidOut),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME, potentialStudent.DtePotenStudCommissionPaidOutDate),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudReferrer_AgentID),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudBranch_BranchID),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudProgramme_ProgrammeID),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_STATUS_COLUMN_NAME, StatusEnumerator.StatusActive.StrKey),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME, DateTime.Now),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME, null),
                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME, null)},
                                        out string strErrMsg);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            return GetPotentialStudentByPrimaryKey(potentialStudent.StrPotenStudID);
        }



        public static PotentialStudentEntity UpdatePotentialStudent(PotentialStudentEntity potentialStudent)
        {
            PotentialStudentEntity existingPotentialStudent = GetPotentialStudentByPrimaryKey(potentialStudent.StrPotenStudID);
            List<string> columnList = new List<string>();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (!potentialStudent.StrPotenStudName.Equals(existingPotentialStudent.StrPotenStudName))
            {
                columnList.Add(POTENTIAL_STUDENT_NAME_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_NAME_COLUMN_NAME, potentialStudent.StrPotenStudName));
            }

            if (!potentialStudent.IDTypePotenStudIDType.Equals(existingPotentialStudent.IDTypePotenStudIDType))
            {
                columnList.Add(POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME, potentialStudent.IDTypePotenStudIDType.StrKey));
            }

            if (!potentialStudent.StrPotenStudIDNumber.Equals(existingPotentialStudent.StrPotenStudIDNumber))
            {
                columnList.Add(POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME, potentialStudent.StrPotenStudIDNumber));
            }

            if (!potentialStudent.DtePotenStudDOB.Equals(existingPotentialStudent.DtePotenStudDOB))
            {
                columnList.Add(POTENTIAL_STUDENT_DOB_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_DOB_COLUMN_NAME, potentialStudent.DtePotenStudDOB));
            }

            if (!potentialStudent.StrPotenStudEmail.Equals(existingPotentialStudent.StrPotenStudEmail))
            {
                columnList.Add(POTENTIAL_STUDENT_EMAIL_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_EMAIL_COLUMN_NAME, potentialStudent.StrPotenStudEmail));
            }

            if (!potentialStudent.GenderPotenStudGender.Equals(existingPotentialStudent.GenderPotenStudGender))
            {
                columnList.Add(POTENTIAL_STUDENT_GENDER_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_GENDER_COLUMN_NAME, potentialStudent.GenderPotenStudGender.StrKey));
            }

            if (!potentialStudent.MarStatPotenStudMaritalStat.Equals(existingPotentialStudent.MarStatPotenStudMaritalStat))
            {
                columnList.Add(POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME, potentialStudent.MarStatPotenStudMaritalStat.StrKey));
            }

            if (!potentialStudent.StrPotenStudContactNo.Equals(existingPotentialStudent.StrPotenStudContactNo))
            {
                columnList.Add(POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME, potentialStudent.StrPotenStudContactNo));
            }

            if (!potentialStudent.AddPotenStudAddress.StrAddLine1.Equals(existingPotentialStudent.AddPotenStudAddress.StrAddLine1))
            {
                columnList.Add(POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddLine1));
            }

            if (!potentialStudent.AddPotenStudAddress.StrAddLine2.Equals(existingPotentialStudent.AddPotenStudAddress.StrAddLine2))
            {
                columnList.Add(POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddLine2));
            }

            if (!potentialStudent.AddPotenStudAddress.StrAddLine3.Equals(existingPotentialStudent.AddPotenStudAddress.StrAddLine3))
            {
                columnList.Add(POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddLine3));
            }

            if (!potentialStudent.AddPotenStudAddress.StrAddPostcode.Equals(existingPotentialStudent.AddPotenStudAddress.StrAddPostcode))
            {
                columnList.Add(POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddPostcode));
            }

            if (!potentialStudent.AddPotenStudAddress.StrAddCity.Equals(existingPotentialStudent.AddPotenStudAddress.StrAddCity))
            {
                columnList.Add(POTENTIAL_STUDENT_ADD_CITY_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_CITY_NAME, potentialStudent.AddPotenStudAddress.StrAddCity));
            }

            if (!potentialStudent.AddPotenStudAddress.StrAddState.Equals(existingPotentialStudent.AddPotenStudAddress.StrAddState))
            {
                columnList.Add(POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddState));
            }

            if (!potentialStudent.AddPotenStudAddress.StrAddCountry.Equals(existingPotentialStudent.AddPotenStudAddress.StrAddCountry))
            {
                columnList.Add(POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME, potentialStudent.AddPotenStudAddress.StrAddCountry));
            }

            if (!potentialStudent.DtePotenStudRegByDate.Equals(existingPotentialStudent.DtePotenStudRegByDate))
            {
                columnList.Add(POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME, potentialStudent.DtePotenStudRegByDate));
            }

            if (!potentialStudent.DtePotenStudSignUpDate.Equals(existingPotentialStudent.DtePotenStudSignUpDate))
            {
                columnList.Add(POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME, potentialStudent.DtePotenStudSignUpDate));
            }

            if (!potentialStudent.DtePotenStudRegFormalisationDate.Equals(existingPotentialStudent.DtePotenStudRegFormalisationDate))
            {
                columnList.Add(POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME, potentialStudent.DtePotenStudRegFormalisationDate));
            }

            if (!potentialStudent.DecPotenStudCommissionTotalPaidOut.Equals(existingPotentialStudent.DecPotenStudCommissionTotalPaidOut))
            {
                columnList.Add(POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME, potentialStudent.DecPotenStudCommissionTotalPaidOut));
            }

            if (!potentialStudent.StrPotenStudReferrer_AgentID.Equals(existingPotentialStudent.StrPotenStudReferrer_AgentID))
            {
                columnList.Add(POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudReferrer_AgentID));
            }

            if (!potentialStudent.StrPotenStudBranch_BranchID.Equals(existingPotentialStudent.StrPotenStudBranch_BranchID))
            {
                columnList.Add(POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudBranch_BranchID));
            }

            if (!potentialStudent.StrPotenStudProgramme_ProgrammeID.Equals(existingPotentialStudent.StrPotenStudProgramme_ProgrammeID))
            {
                columnList.Add(POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudProgramme_ProgrammeID));
            }

            if (!potentialStudent.StatusPotenStudStatus.Equals(existingPotentialStudent.StatusPotenStudStatus))
            {
                columnList.Add(POTENTIAL_STUDENT_STATUS_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_STATUS_COLUMN_NAME, potentialStudent.StatusPotenStudStatus.StrKey));
            }
            

            if(columnList.Count > 0 && paramList.Count > 0)
            {
                columnList.Add(POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username));

                columnList.Add(POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME, DateTime.Now));

                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ID_COLUMN_NAME_PK, potentialStudent.StrPotenStudID));

                CommonDB.ExecuteNonQuery(QueryStringBuilder.GetUpdateStatement(POTENTIAL_STUDENT_TABLE_NAME, POTENTIAL_STUDENT_ID_COLUMN_NAME_PK, columnList.ToArray()),
                                            IsolationLevel.Serializable,
                                            paramList.ToArray(),
                                            out string strErrMsg);

                if (!String.IsNullOrEmpty(strErrMsg))
                    throw new Exception(strErrMsg);
            }

            return GetPotentialStudentByPrimaryKey(potentialStudent.StrPotenStudID);
        }



        public static List<PotentialStudentEntity> ListPotentialStudents(PotentialStudentEntity potentialStudent)
        {
            List<string> columnList = new List<string>();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(potentialStudent.StrPotenStudID))
            {
                columnList.Add(POTENTIAL_STUDENT_ID_COLUMN_NAME_PK);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_ID_COLUMN_NAME_PK, potentialStudent.StrPotenStudID));
            }

            if (!String.IsNullOrEmpty(potentialStudent.StrPotenStudReferrer_AgentID))
            {
                columnList.Add(POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudReferrer_AgentID));
            }

            if (!String.IsNullOrEmpty(potentialStudent.StrPotenStudBranch_BranchID))
            {
                columnList.Add(POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudBranch_BranchID));
            }

            if (!String.IsNullOrEmpty(potentialStudent.StrPotenStudProgramme_ProgrammeID))
            {
                columnList.Add(POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK);
                paramList.Add(CommonDB.SetParameter(POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK, potentialStudent.StrPotenStudProgramme_ProgrammeID));
            }

            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByConstraints(POTENTIAL_STUDENT_TABLE_NAME, columnList.ToArray(), POTENTIAL_STUDENT_STATUS_COLUMN_NAME),
                                                        paramList.ToArray(),
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            List<PotentialStudentEntity> potenStudList = new List<PotentialStudentEntity>();

            if (intTotalRows > 0)
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    potenStudList.Add(new PotentialStudentEntity(row[POTENTIAL_STUDENT_ID_COLUMN_NAME_PK].ToString(),
                                                    row[POTENTIAL_STUDENT_NAME_COLUMN_NAME].ToString(),
                                                    IDTypeEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_DOB_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_EMAIL_COLUMN_NAME].ToString(),
                                                    GenderEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_GENDER_COLUMN_NAME].ToString()),
                                                    MaritalStatusEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME].ToString(),
                                                    new Address(row[POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_CITY_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK].ToString(),
                                                    row[POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                                    row[POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK].ToString(),
                                                    StatusEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_STATUS_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME].ToString())));
            return potenStudList;
        }



        public static List<PotentialStudentEntity> ListPotentialStudents()
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectAllRowsStatement(POTENTIAL_STUDENT_TABLE_NAME),
                                                        paramList.ToArray(),
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            List<PotentialStudentEntity> potenStudList = new List<PotentialStudentEntity>();

            if (intTotalRows > 0)
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    potenStudList.Add(new PotentialStudentEntity(row[POTENTIAL_STUDENT_ID_COLUMN_NAME_PK].ToString(),
                                                    row[POTENTIAL_STUDENT_NAME_COLUMN_NAME].ToString(),
                                                    IDTypeEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_DOB_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_EMAIL_COLUMN_NAME].ToString(),
                                                    GenderEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_GENDER_COLUMN_NAME].ToString()),
                                                    MaritalStatusEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME].ToString(),
                                                    new Address(row[POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_CITY_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK].ToString(),
                                                    row[POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                                    row[POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK].ToString(),
                                                    StatusEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_STATUS_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME].ToString())));
            return potenStudList;
        }



        public static List<PotentialStudentEntity> ListPotentialStudentCodeByRegByDate(DateTime dteBeginDate, DateTime dteEndDate)
        {
            DataSet dataSet;
            string strErrMsg;
            int intTotalRows;

            if (dteBeginDate == null && dteEndDate == null)
            {
                throw new Exception("At least one parameter must not be <Null>")
;
            }
            else if (dteBeginDate != null && dteEndDate != null)
            {
                string strSQLStatement = QueryStringBuilder.GetBetweenValueSelectStatement(POTENTIAL_STUDENT_TABLE_NAME, POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME, out string[] paramNames);
                dataSet = CommonDB.ExecuteReader(strSQLStatement,
                                                            new SqlParameter[] { CommonDB.SetParameter(paramNames[0], dteBeginDate),
                                                                             CommonDB.SetParameter(paramNames[1], dteEndDate)},
                                                            out strErrMsg, out intTotalRows);
            }
            else
            {
                DateTime dteSampleDate;
                bool isGreater;
                if (dteBeginDate != null)
                {
                    dteSampleDate = (DateTime)dteBeginDate;
                    isGreater = true;
                }
                else
                {
                    dteSampleDate = (DateTime)dteEndDate;
                    isGreater = false;
                }

                dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetValueGreaterOrLessThanSelectStatement(POTENTIAL_STUDENT_TABLE_NAME, POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME, isGreater, true),
                                                            new SqlParameter[] { CommonDB.SetParameter(POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME, dteSampleDate) },
                                                            out strErrMsg, out intTotalRows);
            }

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            List<PotentialStudentEntity> potenStudList = new List<PotentialStudentEntity>();

            if (intTotalRows > 0)
                foreach (DataRow row in dataSet.Tables[0].Rows)
                    potenStudList.Add(new PotentialStudentEntity(row[POTENTIAL_STUDENT_ID_COLUMN_NAME_PK].ToString(),
                                                    row[POTENTIAL_STUDENT_NAME_COLUMN_NAME].ToString(),
                                                    IDTypeEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_DOB_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_EMAIL_COLUMN_NAME].ToString(),
                                                    GenderEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_GENDER_COLUMN_NAME].ToString()),
                                                    MaritalStatusEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_MARITAL_STATUS_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_CONTACT_NO_COLUMN_NAME].ToString(),
                                                    new Address(row[POTENTIAL_STUDENT_ADD_LINE_1_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_LINE_2_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_LINE_3_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_POSTCODE_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_CITY_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_STATE_COLUMN_NAME].ToString(),
                                                                row[POTENTIAL_STUDENT_ADD_COUNTRY_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_REG_BY_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_SIGN_UP_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_REG_FORMALISATION_DATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_RATE_COLUMN_NAME].ToString()),
                                                    Common.ParseDecimalFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_TOTAL_PAID_COLUMN_NAME].ToString()),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_COMMISSION_PAID_OUT_DATE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_REFERRER_AGENT_ID_COLUMN_NAME_FK].ToString(),
                                                    row[POTENTIAL_STUDENT_BRANCH_BRANCH_ID_COLUMN_NAME_FK].ToString(),
                                                    row[POTENTIAL_STUDENT_PROGRAMME_PROGRAMME_ID_COLUMN_NAME_FK].ToString(),
                                                    StatusEnumerator.GetEnumByKey(row[POTENTIAL_STUDENT_STATUS_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_CREATED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME].ToString()),
                                                    row[POTENTIAL_STUDENT_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                    Common.ParseDateFromDatabase(row[POTENTIAL_STUDENT_MODIFIED_DATE_COLUMN_NAME].ToString())));
            return potenStudList;
        }



        private static void DeletePotentialStudentByPrimaryKey(string strPotentialStudentID)
        {
            CommonDB.ExecuteNonQuery(QueryStringBuilder.GetDeleteStatementByPrimaryKey(POTENTIAL_STUDENT_TABLE_NAME, POTENTIAL_STUDENT_ID_COLUMN_NAME_PK),
                                        IsolationLevel.Serializable,
                                        new SqlParameter[] { CommonDB.SetParameter(POTENTIAL_STUDENT_ID_COLUMN_NAME_PK, strPotentialStudentID) },
                                        out string strErrMsg);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);
        }



        public static void ArchivePotentialStudent(DateTime dteCutOffDate, DateTime dteTriggerDate)
        {
            DateTime dteStartTime = DateTime.Now;

            List<PotentialStudentEntity> studList = PotentialStudentInterface.ListPotentialStudents(new PotentialStudentEntity()).Where(x => ((DateTime)x.DtePotenStudCreatedDate) <= dteCutOffDate).ToList();

            foreach (PotentialStudentEntity stud in studList)
            {
                Archive_PotentialStudentInterface.NewPotentialStudentArchive(new Archive_PotentialStudentEntity
                {
                    StrArchive_PotenStudID = stud.StrPotenStudID,
                    StrArchive_PotenStudName = stud.StrPotenStudName,
                    IDTypeArchive_PotenStudIDType = stud.IDTypePotenStudIDType,
                    StrArchive_PotenStudIDNumber = stud.StrPotenStudIDNumber,
                    DteArchive_PotenStudDOB = stud.DtePotenStudDOB,
                    StrArchive_PotenStudEmail = stud.StrPotenStudEmail,
                    GenderArchive_PotenStudGender = stud.GenderPotenStudGender,
                    MarStatArchive_PotenStudMaritalStat = stud.MarStatPotenStudMaritalStat,
                    StrArchive_PotenStudContactNo = stud.StrPotenStudContactNo,
                    AddArchive_PotenStudAddress = stud.AddPotenStudAddress,
                    DteArchive_PotenStudRegByDate = stud.DtePotenStudRegByDate,
                    DteArchive_PotenStudSignUpDate = stud.DtePotenStudSignUpDate,
                    DteArchive_PotenStudRegFormalisationDate = stud.DtePotenStudRegFormalisationDate,
                    DecArchive_PotenStudCommissionRate = stud.DecPotenStudCommissionRate,
                    DecArchive_PotenStudCommissionTotalPaidOut = stud.DecPotenStudCommissionTotalPaidOut,
                    DteArchive_PotenStudCommissionPaidOutDate = stud.DtePotenStudCommissionPaidOutDate,
                    StrArchive_PotenStudReferrer_AgentID = stud.StrPotenStudReferrer_AgentID,
                    StrArchive_PotenStudBranch_BranchID = stud.StrPotenStudBranch_BranchID,
                    StrArchive_PotenStudProgramme_ProgrammeID = stud.StrPotenStudProgramme_ProgrammeID,
                    StatusArchive_PotenStudStatus = stud.StatusPotenStudStatus,
                    StrArchive_PotenStudCreatedBy = stud.StrPotenStudCreatedBy,
                    DteArchive_PotenStudCreatedDate = stud.DtePotenStudCreatedDate,
                    StrArchive_PotenStudModifiedBy = stud.StrPotenStudModifiedBy,
                    DteArchive_PotenStudModifiedDate = stud.DtePotenStudModifiedDate
                });

                DeletePotentialStudentByPrimaryKey(stud.StrPotenStudID);
            }

            DateTime dteEndTime = DateTime.Now;

            ArchiveLogInterface.New(new ArchiveLogEntity {
                StrArchiveLogTableName = POTENTIAL_STUDENT_TABLE_NAME,
                DteArchiveLogTriggerDate = dteTriggerDate,
                IntArchiveLogNoOfRecords = studList.Count,
                DteArchiveLogRunStartDate = dteStartTime,
                DteArchiveLogRunEndDate = dteEndTime,
                DecArchiveLogTimeElapsed = (decimal)(dteEndTime- dteStartTime).TotalSeconds
            });
        }



        public static bool IsStudentRegisteredLast30Days(PotentialStudentEntity stud)
        {
            CommonDB.ExecuteReader("SELECT * FROM [" + POTENTIAL_STUDENT_TABLE_NAME + "]"
                                    + " WHERE ( ( [" + POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME + "] = @" + POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME
                                                    + " AND [" + POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME + "] = @" + POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME + ")"
                                               + " OR [" + POTENTIAL_STUDENT_EMAIL_COLUMN_NAME + "] = @" + POTENTIAL_STUDENT_EMAIL_COLUMN_NAME + ")"
                                    + " AND DATEDIFF(day, [" + POTENTIAL_STUDENT_CREATED_DATE_COLUMN_NAME + "], GETDATE()) BETWEEN 0 AND 30"
                                    + " AND [" + POTENTIAL_STUDENT_STATUS_COLUMN_NAME + "] <> @" + POTENTIAL_STUDENT_STATUS_COLUMN_NAME + " ;",
                                                        new SqlParameter[] { CommonDB.SetParameter(POTENTIAL_STUDENT_ID_TYPE_COLUMN_NAME, stud.IDTypePotenStudIDType.StrKey),
                                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_ID_NUMBER_COLUMN_NAME, stud.StrPotenStudIDNumber),
                                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_EMAIL_COLUMN_NAME, stud.StrPotenStudEmail),
                                                                                CommonDB.SetParameter(POTENTIAL_STUDENT_STATUS_COLUMN_NAME, StatusEnumerator.StatusDeleted.StrKey)},
                                                        out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            return (intTotalRows > 0) ;
        }
    }
}
