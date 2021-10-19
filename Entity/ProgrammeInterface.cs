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
    public class ProgrammeInterface : BaseInterface
    {
        private static readonly EntityToTableMapping tableMapping
            = new EntityToTableMapping
                (typeof(ProgrammeEntity),
                    "tbl_Programme", 
                    "PROG", 
                    "ProgrammeID",
                    "ProgrammeStatus",
                    "ProgrammeCreatedBy",
                    "ProgrammeCreatedDate",
                    "ProgrammeModifiedBy",
                    "ProgrammeModifiedDate",
                    new List<EntityToTableMapping.PropertyToColumnPair>
                    {
                        new EntityToTableMapping.PropertyToColumnPair("StrProgrammeID", "ProgrammeID"),
                        new EntityToTableMapping.PropertyToColumnPair("StrProgrammeCode", "ProgrammeCode"),
                        new EntityToTableMapping.PropertyToColumnPair("StrProgrammeTitle", "ProgrammeTitle"),
                        new EntityToTableMapping.PropertyToColumnPair("DecProgrammeCommission", "ProgrammeCommission"),
                        new EntityToTableMapping.PropertyToColumnPair("StatusProgrammeStatus", "ProgrammeStatus"),
                        new EntityToTableMapping.PropertyToColumnPair("StrProgrammeCreatedBy", "ProgrammeCreatedBy"),
                        new EntityToTableMapping.PropertyToColumnPair("DteProgrammeCreatedDate", "ProgrammeCreatedDate"),
                        new EntityToTableMapping.PropertyToColumnPair("StrProgrammeModifiedBy", "ProgrammeModifiedBy"),
                        new EntityToTableMapping.PropertyToColumnPair("DteProgrammeModifiedDate", "ProgrammeModifiedDate")
                    });

        //private const string PROGRAMME_TABLE_NAME = "tbl_Programme";

        //private const string PROGRAMME_PRIMARY_KEY_PREFIX = "PROG";

        //private const string PROGRAMME_ID_COLUMN_NAME_PK = "ProgrammeID";
        //private const string PROGRAMME_CODE_COLUMN_NAME = "ProgrammeCode";
        //private const string PROGRAMME_TITLE_COLUMN_NAME = "ProgrammeTitle";
        //private const string PROGRAMME_COMMISSION_COLUMN_NAME = "ProgrammeCommission";
        //private const string PROGRAMME_STATUS_COLUMN_NAME = "ProgrammeStatus";
        //private const string PROGRAMME_CREATED_BY_COLUMN_NAME = "ProgrammeCreatedBy";
        //private const string PROGRAMME_CREATED_DATE_COLUMN_NAME = "ProgrammeCreatedDate";
        //private const string PROGRAMME_MODIFIED_BY_COLUMN_NAME = "ProgrammeModifiedBy";
        //private const string PROGRAMME_MODIFIED_DATE_COLUMN_NAME = "ProgrammeModifiedDate";


        public static ProgrammeEntity GetByPrimaryKey(string strProgrammeID)
        {
            return (ProgrammeEntity)GetByPrimaryKey(tableMapping, strProgrammeID);
        }

        public static ProgrammeEntity New(ProgrammeEntity programme)
        {
            return (ProgrammeEntity)New(tableMapping, programme);
        }

        public static ProgrammeEntity Update(ProgrammeEntity programme)
        {
            return (ProgrammeEntity)Update(tableMapping, programme);
        }

        public static List<ProgrammeEntity> List(ProgrammeEntity programme)
        {
            return List(tableMapping, programme).Cast<ProgrammeEntity>().ToList();
        }

        public static List<ProgrammeEntity> List()
        {
            return List(new ProgrammeEntity());
        }

        //public static ProgrammeEntity GetProgrammeByPrimaryKey_bk(string strProgrammeID)
        //{
        //    DataSet dataSet = CommonDB.ExecuteReader(SQLQueryStringBuilder.getSelectStatementByPrimaryKey(PROGRAMME_TABLE_NAME, PROGRAMME_ID_COLUMN_NAME_PK, PROGRAMME_STATUS_COLUMN_NAME),
        //                                                new SqlParameter[]
        //                                                {
        //                                                    CommonDB.SetParameter(PROGRAMME_ID_COLUMN_NAME_PK, strProgrammeID)
        //                                                },
        //                                                out string strErrMsg, out int intTotalRows);

        //    if (!String.IsNullOrEmpty(strErrMsg))
        //        throw new Exception(strErrMsg);

        //    if (intTotalRows <= 0)
        //        return null;
        //    else
        //        return new ProgrammeEntity()
        //        {
        //            StrProgrammeID = dataSet.Tables[0].Rows[0][PROGRAMME_ID_COLUMN_NAME_PK].ToString(),
        //            StrProgrammeCode = dataSet.Tables[0].Rows[0][PROGRAMME_CODE_COLUMN_NAME].ToString(),
        //            StrProgrammeTitle = dataSet.Tables[0].Rows[0][PROGRAMME_TITLE_COLUMN_NAME].ToString(),
        //            DecProgrammeCommission = Common.ParseDecimalFromDatabase(dataSet.Tables[0].Rows[0][PROGRAMME_COMMISSION_COLUMN_NAME].ToString()),
        //            StatusProgrammeStatus = StatusEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][PROGRAMME_STATUS_COLUMN_NAME].ToString()),
        //            StrProgrammeCreatedBy = dataSet.Tables[0].Rows[0][PROGRAMME_CREATED_BY_COLUMN_NAME].ToString(),
        //            DteProgrammeCreatedDate = Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][PROGRAMME_CREATED_DATE_COLUMN_NAME].ToString()),
        //            StrProgrammeModifiedBy = dataSet.Tables[0].Rows[0][PROGRAMME_MODIFIED_BY_COLUMN_NAME].ToString(),
        //            DteProgrammeModifiedDate = Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][PROGRAMME_MODIFIED_DATE_COLUMN_NAME].ToString())
        //        };
        //}

        //public static ProgrammeEntity NewProgramme_bk(ProgrammeEntity programme)
        //{
        //    programme.StrProgrammeID = PrimaryKeyController.GetLatestPrimaryKey(PROGRAMME_TABLE_NAME, PROGRAMME_PRIMARY_KEY_PREFIX);

        //    CommonDB.ExecuteNonQuery(SQLQueryStringBuilder.getInsertStatement(PROGRAMME_TABLE_NAME, 
        //                                                                        new string[] 
        //                                                                        {
        //                                                                            PROGRAMME_ID_COLUMN_NAME_PK,
        //                                                                            PROGRAMME_CODE_COLUMN_NAME,
        //                                                                            PROGRAMME_TITLE_COLUMN_NAME,
        //                                                                            PROGRAMME_COMMISSION_COLUMN_NAME,
        //                                                                            PROGRAMME_STATUS_COLUMN_NAME,
        //                                                                            PROGRAMME_CREATED_BY_COLUMN_NAME,
        //                                                                            PROGRAMME_CREATED_DATE_COLUMN_NAME,
        //                                                                            PROGRAMME_MODIFIED_BY_COLUMN_NAME,
        //                                                                            PROGRAMME_MODIFIED_DATE_COLUMN_NAME
        //                                                                        }),
        //                                IsolationLevel.Serializable,
        //                                new SqlParameter[] 
        //                                {  
        //                                    CommonDB.SetParameter(PROGRAMME_ID_COLUMN_NAME_PK, programme.StrProgrammeID),
        //                                    CommonDB.SetParameter(PROGRAMME_CODE_COLUMN_NAME, programme.StrProgrammeCode),
        //                                    CommonDB.SetParameter(PROGRAMME_TITLE_COLUMN_NAME, programme.StrProgrammeTitle),
        //                                    CommonDB.SetParameter(PROGRAMME_COMMISSION_COLUMN_NAME, programme.DecProgrammeCommission),
        //                                    CommonDB.SetParameter(PROGRAMME_STATUS_COLUMN_NAME, StatusEnumerator.StatusActive.StrKey),
        //                                    CommonDB.SetParameter(PROGRAMME_CREATED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username),
        //                                    CommonDB.SetParameter(PROGRAMME_CREATED_DATE_COLUMN_NAME, DateTime.Now),
        //                                    CommonDB.SetParameter(PROGRAMME_MODIFIED_BY_COLUMN_NAME, null),
        //                                    CommonDB.SetParameter(PROGRAMME_MODIFIED_DATE_COLUMN_NAME, null),
        //                                },
        //                                out string strErrMsg);

        //    if (!String.IsNullOrEmpty(strErrMsg))
        //        throw new Exception(strErrMsg);

        //    return GetProgrammeByPrimaryKey(programme.StrProgrammeID);
        //}



        //public static ProgrammeEntity UpdateProgramme_bk(ProgrammeEntity programme)
        //{
        //    ProgrammeEntity existingProgramme = GetProgrammeByPrimaryKey(programme.StrProgrammeID);
        //    List<string> columnList = new List<string>();
        //    List<SqlParameter> paramList = new List<SqlParameter>();

        //    if (!programme.StrProgrammeCode.Equals(existingProgramme.StrProgrammeCode))
        //    {
        //        columnList.Add(PROGRAMME_CODE_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_CODE_COLUMN_NAME, programme.StrProgrammeCode));
        //    }

        //    if (!programme.StrProgrammeTitle.Equals(existingProgramme.StrProgrammeTitle))
        //    {
        //        columnList.Add(PROGRAMME_TITLE_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_TITLE_COLUMN_NAME, programme.StrProgrammeTitle));
        //    }

        //    if (!programme.DecProgrammeCommission.Equals(existingProgramme.DecProgrammeCommission))
        //    {
        //        columnList.Add(PROGRAMME_COMMISSION_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_COMMISSION_COLUMN_NAME, programme.DecProgrammeCommission));
        //    }

        //    if (!programme.StatusProgrammeStatus.Equals(existingProgramme.StatusProgrammeStatus))
        //    {
        //        columnList.Add(PROGRAMME_STATUS_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_STATUS_COLUMN_NAME, programme.StatusProgrammeStatus.StrKey));
        //    }

        //    if (columnList.Count > 0 && paramList.Count > 0)
        //    {
        //        columnList.Add(PROGRAMME_MODIFIED_BY_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_MODIFIED_BY_COLUMN_NAME, UserInfo.GetUserInfo().Username));

        //        columnList.Add(PROGRAMME_MODIFIED_DATE_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_MODIFIED_DATE_COLUMN_NAME, DateTime.Now));

        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_ID_COLUMN_NAME_PK, programme.StrProgrammeID));

        //        CommonDB.ExecuteNonQuery(SQLQueryStringBuilder.getUpdateStatement(PROGRAMME_TABLE_NAME, PROGRAMME_ID_COLUMN_NAME_PK, columnList.ToArray()),
        //                                    IsolationLevel.Serializable,
        //                                    paramList.ToArray(),
        //                                    out string strErrMsg);

        //        if (!String.IsNullOrEmpty(strErrMsg))
        //            throw new Exception(strErrMsg);
        //    }

        //    return GetProgrammeByPrimaryKey(programme.StrProgrammeID);
        //}



        //public static List<ProgrammeEntity> ListProgramme_bk(ProgrammeEntity programme)
        //{
        //    List<string> columnList = new List<string>();
        //    List<SqlParameter> paramList = new List<SqlParameter>();

        //    if (!string.IsNullOrEmpty(programme.StrProgrammeID))
        //    {
        //        columnList.Add(PROGRAMME_ID_COLUMN_NAME_PK);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_ID_COLUMN_NAME_PK, programme.StrProgrammeID));
        //    }

        //    if (!string.IsNullOrEmpty(programme.StrProgrammeCode))
        //    {
        //        columnList.Add(PROGRAMME_CODE_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_CODE_COLUMN_NAME, programme.StrProgrammeCode));
        //    }

        //    if (!string.IsNullOrEmpty(programme.StrProgrammeTitle))
        //    {
        //        columnList.Add(PROGRAMME_TITLE_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_TITLE_COLUMN_NAME, programme.StrProgrammeTitle));
        //    }

        //    if (programme.StatusProgrammeStatus!=null)
        //    {
        //        columnList.Add(PROGRAMME_STATUS_COLUMN_NAME);
        //        paramList.Add(CommonDB.SetParameter(PROGRAMME_STATUS_COLUMN_NAME, programme.StatusProgrammeStatus.StrKey));
        //    }

        //    DataSet dataSet = CommonDB.ExecuteReader(SQLQueryStringBuilder.getSelectStatementByConstraints(PROGRAMME_TABLE_NAME, columnList.ToArray(), PROGRAMME_STATUS_COLUMN_NAME),
        //                                                paramList.ToArray(),
        //                                                out string strErrMsg, out int intTotalRows);

        //    if (!String.IsNullOrEmpty(strErrMsg))
        //        throw new Exception(strErrMsg);

        //    List<ProgrammeEntity> programmeList = new List<ProgrammeEntity>();

        //    if (intTotalRows > 0)
        //        foreach (DataRow row in dataSet.Tables[0].Rows)
        //            programmeList.Add(new ProgrammeEntity()
        //                                {
        //                                    StrProgrammeID = row[PROGRAMME_ID_COLUMN_NAME_PK].ToString(),
        //                                    StrProgrammeCode = row[PROGRAMME_CODE_COLUMN_NAME].ToString(),
        //                                    StrProgrammeTitle = row[PROGRAMME_TITLE_COLUMN_NAME].ToString(),
        //                                    DecProgrammeCommission = Common.ParseDecimalFromDatabase(row[PROGRAMME_COMMISSION_COLUMN_NAME].ToString()),
        //                                    StatusProgrammeStatus = StatusEnumerator.GetEnumByKey(row[PROGRAMME_STATUS_COLUMN_NAME].ToString()),
        //                                    StrProgrammeCreatedBy = row[PROGRAMME_CREATED_BY_COLUMN_NAME].ToString(),
        //                                    DteProgrammeCreatedDate = Common.ParseDateFromDatabase(row[PROGRAMME_CREATED_DATE_COLUMN_NAME].ToString()),
        //                                    StrProgrammeModifiedBy = row[PROGRAMME_MODIFIED_BY_COLUMN_NAME].ToString(),
        //                                    DteProgrammeModifiedDate = Common.ParseDateFromDatabase(row[PROGRAMME_MODIFIED_DATE_COLUMN_NAME].ToString())
        //                                });

        //    return programmeList;
        //}


    }
}
