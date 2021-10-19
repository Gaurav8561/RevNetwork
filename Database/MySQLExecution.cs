using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Database
{
    class MySQLExecution : IDBExecutionInterface
    {

        private static readonly BaseDBExecution.DBClassMapping msSQLDBClassMapping = new BaseDBExecution.DBClassMapping()
        {
            TypeCommandClass = typeof(MySqlCommand),
            TypeConnectionClass = typeof(MySqlConnection),
            TypeTransactionClass = typeof(MySqlTransaction),
            TypeDataAdapterClass = typeof(MySqlDataAdapter),
            TypeParameterClass = typeof(MySqlParameter),
            TypeParameterCollectionClass = typeof(MySqlParameterCollection)
        };

        private static readonly string sConnString = CommonDB.GetConnectionString();

        private object Execute(string sCmdText, IsolationLevel ilTransIsolationLvl, object[] spmCmdParams, string strCallingMethodName)
        {
            return BaseDBExecution.Execute(msSQLDBClassMapping, sConnString, sCmdText, ilTransIsolationLvl, spmCmdParams, strCallingMethodName);
        }

        public DataSet ExecuteReader(string sCmdText, object[] spmCmdParams)
        {
            return Execute(sCmdText, IsolationLevel.Unspecified, spmCmdParams, MethodBase.GetCurrentMethod().Name) as DataSet;
        }

        public void ExecuteNonQuery(string sCmdText, IsolationLevel ilTransIsolationLvl, object[] spmCmdParams)
        {
            Execute(sCmdText, ilTransIsolationLvl, spmCmdParams, MethodBase.GetCurrentMethod().Name);
        }

        public object ExecuteScalar(string sCmdText, object[] spmCmdParams)
        {
            return Execute(sCmdText, IsolationLevel.Unspecified, spmCmdParams, MethodBase.GetCurrentMethod().Name);
        }

        public object ProcessParameter(string strParamName, object objParamValue)
        {
            return new MySqlParameter()
            {
                ParameterName = strParamName,
                Value = objParamValue
            };
        }
    }
}
