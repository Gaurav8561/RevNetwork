using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data;
using System.Data.SqlClient;



namespace Utility
{
    public class PrimaryKeyController
    {
        public static string GetLatestPrimaryKey(string strTableName, string strPrefix)
        {
            long intCurrentYear = DateTime.Now.Year;
            PrimaryKeyControlEntity primaryKeyControl = PrimaryKeyControlInterface.GetPrimaryKeyControlByTableNameAndYear(strTableName, intCurrentYear);

            if (primaryKeyControl == null)
                primaryKeyControl = PrimaryKeyControlInterface.NewPrimaryKeyControl(
                    new PrimaryKeyControlEntity
                    {
                        StrPrimaryKeyControlTableName = strTableName,
                        LongPrimaryKeyControlYear = intCurrentYear,
                        LongPrimaryKeyControlLatestNumber = 1
                    });

            string strPrimaryKey = string.Format("{0}{1}{2:X10}", strPrefix, primaryKeyControl.LongPrimaryKeyControlYear, primaryKeyControl.LongPrimaryKeyControlLatestNumber);

            primaryKeyControl.LongPrimaryKeyControlLatestNumber++;

            PrimaryKeyControlInterface.UpdatePrimaryKeyControl(primaryKeyControl);

            return strPrimaryKey;
        }



        public static string GetLatestUUIDPrimaryKey(string strPrefix)
        {
            return string.Format("{0}-{1}-{2}", strPrefix, DateTime.Now.ToString("yyyy-MM-dd-HHmmssfff"), Guid.NewGuid());
        }


        private class PrimaryKeyControlEntity
        {
            public string StrPrimaryKeyControlID { get; set; }
            public string StrPrimaryKeyControlTableName { get; set; }
            public long LongPrimaryKeyControlYear { get; set; }
            public long LongPrimaryKeyControlLatestNumber { get; set; }
            public string StrPrimaryKeyControlCreatedBy { get; set; }
            public DateTime? DtePrimaryKeyControlCreatedDate { get; set; }
            public string StrPrimaryKeyControlModifiedBy { get; set; }
            public DateTime? DtePrimaryKeyControlModifieDate { get; set; }
        }



        private class PrimaryKeyControlInterface
        {
            private const string PRIMARY_KEY_CONTROL_TABLE_NAME = "tbl_PrimaryKeyControl";
            
            private const string PRIMARY_KEY_CONTROL_ID_COLUMN_NAME_PK = "PrimaryKeyControlID";
            private const string PRIMARY_KEY_CONTROL_TABLE_NAME_COLUMN_NAME = "PrimaryKeyControlTableName";
            private const string PRIMARY_KEY_CONTROL_YEAR_COLUMN_NAME = "PrimaryKeyControlYear";
            private const string PRIMARY_KEY_CONTROL_LATEST_NUMBER_COLUMN_NAME = "PrimaryKeyControlLatestNumber";
            private const string PRIMARY_KEY_CONTROL_CREATED_BY_COLUMN_NAME = "PrimaryKeyControlCreatedBy";
            private const string PRIMARY_KEY_CONTROL_CREATED_DATE_COLUMN_NAME = "PrimaryKeyControlCreatedDate";
            private const string PRIMARY_KEY_CONTROL_MODIFIED_BY_COLUMN_NAME = "PrimaryKeyControlModifiedBy";
            private const string PRIMARY_KEY_CONTROL_MODIFIED_DATE_COLUMN_NAME = "PrimaryKeyControlModifiedDate";

            internal static PrimaryKeyControlEntity GetPrimaryKeyControlByTableNameAndYear(string strTableName, long intYear)
            {
                DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByConstraints(PRIMARY_KEY_CONTROL_TABLE_NAME,
                                                                                                                new string[] 
                                                                                                                { 
                                                                                                                    PRIMARY_KEY_CONTROL_TABLE_NAME_COLUMN_NAME,
                                                                                                                    PRIMARY_KEY_CONTROL_YEAR_COLUMN_NAME 
                                                                                                                },
                                                                                                                null),
                                                         new SqlParameter[] 
                                                         { 
                                                             CommonDB.SetParameter(PRIMARY_KEY_CONTROL_TABLE_NAME_COLUMN_NAME, strTableName),
                                                             CommonDB.SetParameter(PRIMARY_KEY_CONTROL_YEAR_COLUMN_NAME, intYear)
                                                         },
                                                         out string strErrMsg, out int intTotalRows);

                if (!String.IsNullOrEmpty(strErrMsg))
                    throw new Exception(strErrMsg);

                if (intTotalRows == 1)
                    return new PrimaryKeyControlEntity
                    {
                        StrPrimaryKeyControlID = dataSet.Tables[0].Rows[0][PRIMARY_KEY_CONTROL_ID_COLUMN_NAME_PK].ToString().Trim(),
                        StrPrimaryKeyControlTableName = dataSet.Tables[0].Rows[0][PRIMARY_KEY_CONTROL_TABLE_NAME_COLUMN_NAME].ToString(),
                        LongPrimaryKeyControlYear = long.Parse(dataSet.Tables[0].Rows[0][PRIMARY_KEY_CONTROL_YEAR_COLUMN_NAME].ToString().Trim()),
                        LongPrimaryKeyControlLatestNumber = long.Parse(dataSet.Tables[0].Rows[0][PRIMARY_KEY_CONTROL_LATEST_NUMBER_COLUMN_NAME].ToString().Trim()),
                        StrPrimaryKeyControlCreatedBy = dataSet.Tables[0].Rows[0][PRIMARY_KEY_CONTROL_CREATED_BY_COLUMN_NAME].ToString(),
                        DtePrimaryKeyControlCreatedDate = Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][PRIMARY_KEY_CONTROL_CREATED_DATE_COLUMN_NAME].ToString()),
                        StrPrimaryKeyControlModifiedBy = dataSet.Tables[0].Rows[0][PRIMARY_KEY_CONTROL_MODIFIED_BY_COLUMN_NAME].ToString(),
                        DtePrimaryKeyControlModifieDate = Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][PRIMARY_KEY_CONTROL_MODIFIED_DATE_COLUMN_NAME].ToString())
                    };
                else if (intTotalRows < 1)
                    return null;
                else
                    throw new Exception("Duplication of primary key(s) control occured. Please contact system administrator rectify this anomally before proceeding.");
            }

            internal static PrimaryKeyControlEntity NewPrimaryKeyControl(PrimaryKeyControlEntity primaryKeyControl)
            {
                CommonDB.ExecuteNonQuery(QueryStringBuilder.GetInsertStatement(PRIMARY_KEY_CONTROL_TABLE_NAME, 
                                                                                    new string[] 
                                                                                    {
                                                                                        PRIMARY_KEY_CONTROL_TABLE_NAME_COLUMN_NAME,
                                                                                        PRIMARY_KEY_CONTROL_YEAR_COLUMN_NAME,
                                                                                        PRIMARY_KEY_CONTROL_LATEST_NUMBER_COLUMN_NAME,
                                                                                        PRIMARY_KEY_CONTROL_CREATED_BY_COLUMN_NAME,
                                                                                        PRIMARY_KEY_CONTROL_CREATED_DATE_COLUMN_NAME,
                                                                                        PRIMARY_KEY_CONTROL_MODIFIED_BY_COLUMN_NAME,
                                                                                        PRIMARY_KEY_CONTROL_MODIFIED_DATE_COLUMN_NAME 
                                                                                    }),
                                        IsolationLevel.Serializable,
                                        new SqlParameter[] 
                                        { 
                                            CommonDB.SetParameter(PRIMARY_KEY_CONTROL_TABLE_NAME_COLUMN_NAME, primaryKeyControl.StrPrimaryKeyControlTableName),
                                            CommonDB.SetParameter(PRIMARY_KEY_CONTROL_YEAR_COLUMN_NAME, primaryKeyControl.LongPrimaryKeyControlYear),
                                            CommonDB.SetParameter(PRIMARY_KEY_CONTROL_LATEST_NUMBER_COLUMN_NAME, primaryKeyControl.LongPrimaryKeyControlLatestNumber),
                                            CommonDB.SetParameter(PRIMARY_KEY_CONTROL_CREATED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username),
                                            CommonDB.SetParameter(PRIMARY_KEY_CONTROL_CREATED_DATE_COLUMN_NAME, DateTime.Now),
                                            CommonDB.SetParameter(PRIMARY_KEY_CONTROL_MODIFIED_BY_COLUMN_NAME, null),
                                            CommonDB.SetParameter(PRIMARY_KEY_CONTROL_MODIFIED_DATE_COLUMN_NAME, null) 
                                        },
                                        out string strErrMsg);

                if (!String.IsNullOrEmpty(strErrMsg))
                    throw new Exception(strErrMsg);

                return GetPrimaryKeyControlByTableNameAndYear(primaryKeyControl.StrPrimaryKeyControlTableName, primaryKeyControl.LongPrimaryKeyControlYear);
            }

            internal static void UpdatePrimaryKeyControl(PrimaryKeyControlEntity primaryKeyControl)
            {
                CommonDB.ExecuteNonQuery(QueryStringBuilder.GetUpdateStatement(PRIMARY_KEY_CONTROL_TABLE_NAME, PRIMARY_KEY_CONTROL_ID_COLUMN_NAME_PK,
                                                                                    new string[] 
                                                                                    { 
                                                                                        PRIMARY_KEY_CONTROL_LATEST_NUMBER_COLUMN_NAME,
                                                                                        PRIMARY_KEY_CONTROL_MODIFIED_BY_COLUMN_NAME,
                                                                                        PRIMARY_KEY_CONTROL_MODIFIED_DATE_COLUMN_NAME 
                                                                                    }),
                                            IsolationLevel.Serializable,
                                            new SqlParameter[] 
                                            { 
                                                CommonDB.SetParameter(PRIMARY_KEY_CONTROL_ID_COLUMN_NAME_PK, primaryKeyControl.StrPrimaryKeyControlID),
                                                CommonDB.SetParameter(PRIMARY_KEY_CONTROL_LATEST_NUMBER_COLUMN_NAME, primaryKeyControl.LongPrimaryKeyControlLatestNumber),
                                                CommonDB.SetParameter(PRIMARY_KEY_CONTROL_MODIFIED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username),
                                                CommonDB.SetParameter(PRIMARY_KEY_CONTROL_MODIFIED_DATE_COLUMN_NAME, DateTime.Now)
                                            },
                                            out string strErrMsg);

                if (!String.IsNullOrEmpty(strErrMsg))
                    throw new Exception(strErrMsg);
            }
        }
    }
}
