using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IQueryStringBuilderInterface
    {
        string GetSelectStatementByPrimaryKey(string strTableName, string strPrimaryKeyColumnName, string strStatusColumnName);
        string GetSelectAllRowsStatement(string strTableName);
        string GetSelectStatementByConstraints(string strTableName, string[] strColumnNames, string strStatusColumnName);
        string GetSelectStatementByMatches(string strTableName, string[] strColumnNames, string strStatusColumnName);
        string GetInsertStatement(string strTableName, string[] strColumnNames);
        string GetUpdateStatement(string strTableName, string strPrimaryKeyColumnName, string[] strColumnNames);
        string GetBetweenValueSelectStatement(string strTableName, string strColumnName, out string[] strParamNames);
        string GetValueGreaterOrLessThanSelectStatement(string strTableName, string strColumnName, bool isGreater, bool isInclusive);
        string GetMultipleDateRangeSelectStatement(string strTableName, string[] strColumnNames, out string[][] strParamNames);
        string GetDeleteStatementByPrimaryKey(string strTableName, string strPrimaryKeyColumnName);
        string GetSelectUUIDStatement(string strTableName, out string strUUIDColumnName);
    }
}
