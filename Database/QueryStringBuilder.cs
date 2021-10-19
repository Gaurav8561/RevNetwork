namespace Database
{
    public class QueryStringBuilder
    {
        public static string GetSelectStatementByPrimaryKey(string strTableName, string strPrimaryKeyColumnName, string strStatusColumnName)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetSelectStatementByPrimaryKey(strTableName, strPrimaryKeyColumnName, strStatusColumnName);
        }

        public static string GetSelectAllRowsStatement(string strTableName)
        {
            return  DBSwitch.GetVariables().QueryStringBuilder.GetSelectAllRowsStatement(strTableName);
        }

        public static string GetSelectStatementByConstraints(string strTableName, string[] strColumnNames, string strStatusColumnName)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetSelectStatementByConstraints(strTableName, strColumnNames, strStatusColumnName);
        }

        public static string GetSelectStatementByMatches(string strTableName, string[] strColumnNames, string strStatusColumnName)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetSelectStatementByMatches(strTableName, strColumnNames, strStatusColumnName);
        }

        public static string GetInsertStatement(string strTableName, string[] strColumnNames)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetInsertStatement(strTableName, strColumnNames);
        }

        public static string GetUpdateStatement(string strTableName, string strPrimaryKeyColumnName, string[] strColumnNames)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetUpdateStatement(strTableName, strPrimaryKeyColumnName, strColumnNames);
        }

        public static string GetBetweenValueSelectStatement(string strTableName, string strColumnName, out string[] strParamNames)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetBetweenValueSelectStatement(strTableName, strColumnName, out strParamNames);
        }

        public static string GetValueGreaterOrLessThanSelectStatement(string strTableName, string strColumnName, bool isGreater, bool isInclusive)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetValueGreaterOrLessThanSelectStatement(strTableName, strColumnName, isGreater, isInclusive);
        }

        public static string GetMultipleDateRangeSelectStatement(string strTableName, string[] strColumnNames, out string[][] strParamNames)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetMultipleDateRangeSelectStatement(strTableName, strColumnNames, out strParamNames);
        }

        public static string GetDeleteStatementByPrimaryKey(string strTableName, string strPrimaryKeyColumnName)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetDeleteStatementByPrimaryKey(strTableName, strPrimaryKeyColumnName);
        }

        public static string GetSelectUUIDStatement(string strTableName, out string strUUIDColumnName)
        {
            return DBSwitch.GetVariables().QueryStringBuilder.GetSelectUUIDStatement(strTableName, out strUUIDColumnName);
        }
    }
}
