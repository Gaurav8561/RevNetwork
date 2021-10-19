using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;


namespace Database
{
    class MySQLQueryStringBuilder : IQueryStringBuilderInterface
    {
        private const string DATABASE_NAME = "RevNetworkTenant1";
        private const string SCHEMA_NAME = "dbo";

        private const string UUID_COLUMN_NAME = "UUID";

        public string GetSelectStatementByPrimaryKey(string strTableName, string strPrimaryKeyColumnName, string strStatusColumnName)
        {
            return string.Format("SELECT * FROM [{0}].[{1}].[{2}] WHERE [{3}] = @{3} {4} ; ",
                DATABASE_NAME, SCHEMA_NAME, strTableName, strPrimaryKeyColumnName, 
                string.IsNullOrEmpty(strStatusColumnName) ? string.Empty : string.Format(" AND [{0}] <> '{1}'", strStatusColumnName, StatusEnumerator.StatusDeleted.StrKey) );
        }

        public string GetSelectAllRowsStatement(string strTableName)
        {
            return "SELECT * FROM [" + DATABASE_NAME + "].[" + SCHEMA_NAME + "].[" + strTableName + "] ; ";
        }

        public string GetSelectStatementByConstraints(string strTableName, string[] strColumnNames, string strStatusColumnName)
        {
            return GetMultipleConstraintSelectStatement(strTableName, strColumnNames, false, strStatusColumnName);
        }

        public string GetSelectStatementByMatches(string strTableName, string[] strColumnNames, string strStatusColumnName)
        {
            return GetMultipleConstraintSelectStatement(strTableName, strColumnNames, true, strStatusColumnName);
        }

        private string GetMultipleConstraintSelectStatement(string strTableName, string[] strColumnNames, bool isOr, string strStatusColumnName)
        {
            //StringBuilder sbColumn = new StringBuilder();

            //string strConst = isOr ? "OR" : "AND";


            //for (int i = 0; i < strColumnNames.Length; i++)
            //{
            //    sbColumn.Append("[" + strColumnNames[i] + "] = @" + strColumnNames[i]);

            //    if (i + 1 < strColumnNames.Length)
            //    {
            //        sbColumn.Append(" " + strConst + " ");
            //    }
            //}
            //return string.Format("SELECT * FROM [{0}].[{1}].[{2}] {3} {4} ; ", 
            //    DATABASE_NAME, SCHEMA_NAME, strTableName, 
            //    (string.IsNullOrEmpty(sbColumn.ToString()) ? string.Empty : " WHERE " + sbColumn.ToString()),
            //    (string.IsNullOrEmpty(strStatusColumnName) ? string.Empty : string.Format(" {0} [{1}] <> '{2}'", string.IsNullOrEmpty(sbColumn.ToString()) ? "WHERE" : "AND", strStatusColumnName, StatusEnumerator.StatusDeleted.StrKey)));

            return string.Format("SELECT * FROM [{0}].[{1}].[{2}] {3} {4} ; ",
                DATABASE_NAME, SCHEMA_NAME, strTableName,
                (strColumnNames.Length <= 0 ? string.Empty : " WHERE " + string.Join((isOr ? " OR " : " AND "), strColumnNames.Select(x => string.Format("[{0}] = @{0}", x)))),
                (string.IsNullOrEmpty(strStatusColumnName) ? string.Empty : string.Format(" {0} [{1}] <> '{2}'", strColumnNames.Length <= 0 ? "WHERE" : "AND", strStatusColumnName, StatusEnumerator.StatusDeleted.StrKey)));
        }



        private string GetSelectStatementByLike(string strTableName, string[] strColumnNames, bool isOr)
        {
            StringBuilder sbColumn = new StringBuilder();

            string strConst = isOr ? "OR" : "AND";

            for (int i = 0; i < strColumnNames.Length; i++)
            {
                sbColumn.Append(strColumnNames[i] + " COLLATE UTF8_GENERAL_CI LIKE %@" + strColumnNames[i] + "%");

                if (i + 1 < strColumnNames.Length)
                {
                    sbColumn.Append(" " + strConst + " ");
                }
            }
            return "SELECT * FROM [" + DATABASE_NAME + "].[" + SCHEMA_NAME + "].[" + strTableName + "] WHERE " + sbColumn.ToString() + " ; ";
        }



        public string GetInsertStatement(string strTableName, string[] strColumnNames)
        {
            //StringBuilder sbColumn = new StringBuilder();
            //StringBuilder sbParam = new StringBuilder();

            //for (int i = 0; i < strColumnNames.Length; i++)
            //{
            //    sbColumn.Append(strColumnNames[i]);
            //    sbParam.Append("@" + strColumnNames[i]);

            //    if (i + 1 < strColumnNames.Length)
            //    {
            //        sbColumn.Append(", ");
            //        sbParam.Append(", ");
            //    }
            //}
            //return "INSERT INTO [" + DATABASE_NAME + "].[" + SCHEMA_NAME + "].[" + strTableName + "] (" + sbColumn.ToString() + ") VALUES (" + sbParam.ToString() + ") ; ";
            return string.Format("INSERT INTO [{0}].[{1}].[{2}] ({3}) VALUES ({4}) ; ",
                DATABASE_NAME, SCHEMA_NAME, strTableName, string.Join(", ", strColumnNames), string.Join(", ", strColumnNames.Select(x => string.Format("@{0}", x))));
        }



        public string GetUpdateStatement(string strTableName, string strPrimaryKeyColumnName, string[] strColumnNames)
        {
            StringBuilder sbColumn = new StringBuilder();

            for (int i = 0; i < strColumnNames.Length; i++)
            {
                sbColumn.Append(strColumnNames[i] + " = @" + strColumnNames[i]);

                if (i + 1 < strColumnNames.Length)
                {
                    sbColumn.Append(", ");
                }
            }
            return "UPDATE [" + DATABASE_NAME + "].[" + SCHEMA_NAME + "].[" + strTableName + "] SET " + sbColumn.ToString() + " WHERE " + strPrimaryKeyColumnName + " = @" + strPrimaryKeyColumnName + " ; ";
        }



        public string GetBetweenValueSelectStatement(string strTableName, string strColumnName, out string[] strParamNames)
        {
            strParamNames = new string[] { strColumnName + "_Begin", strColumnName + "_End" };
            return "SELECT * FROM [" + DATABASE_NAME + "].[" + SCHEMA_NAME + "].[" + strTableName + "] WHERE " + strColumnName + " BETWEEN @" + strParamNames[0] + " AND @" + strParamNames[1] + " ; ";
        }



        public string GetValueGreaterOrLessThanSelectStatement(string strTableName, string strColumnName, bool isGreater, bool isInclusive)
        {
            return "SELECT * FROM [" + DATABASE_NAME + "].[" + SCHEMA_NAME + "].[" + strTableName + "] WHERE " + strColumnName + " " + (isGreater ? ">" : "<" + " ") + (isInclusive ? "=" : "" + " ") + strColumnName + " ; ";
        }



        public string GetMultipleDateRangeSelectStatement(string strTableName, string[] strColumnNames, out string[][] strParamNames)
        {
            StringBuilder sbColumn = new StringBuilder();
            List<string[]> paramsList = new List<string[]>();
            for (int i = 0; i < strColumnNames.Length; i++)
            {
                string strBeginParam = strColumnNames[i] + "_Begin";
                string strEndParam = strColumnNames[i] + "_End";
                paramsList.Add(new string[] { strBeginParam, strEndParam });
                sbColumn.Append(strColumnNames[i] + " BETWEEN @" + strBeginParam + " AND @" + strEndParam);

                if (i + 1 < strColumnNames.Length)
                {
                    sbColumn.Append(" OR ");
                }
            }
                
            strParamNames = paramsList.ToArray();

            return "SELECT * FROM [" + DATABASE_NAME + "].[" + SCHEMA_NAME + "].[" + strTableName + "] WHERE " + sbColumn.ToString() + " ; ";
        }



        public string GetDeleteStatementByPrimaryKey(string strTableName, string strPrimaryKeyColumnName)
        {
            return "DELETE FROM [" + DATABASE_NAME + "].[" + SCHEMA_NAME + "].[" + strTableName + "] WHERE [" + strPrimaryKeyColumnName + "] = @" + strPrimaryKeyColumnName + " ; ";
        }



        public string GetSelectUUIDStatement(string strTableName, out string strUUIDColumnName)
        {
            strUUIDColumnName = UUID_COLUMN_NAME;
            return string.Format("SELECT TOP 1 NEWID() AS [{0}] FROM [{1}].[{2}].[{3}] ; ", strUUIDColumnName, DATABASE_NAME, SCHEMA_NAME, strTableName);
        }
    }
}
