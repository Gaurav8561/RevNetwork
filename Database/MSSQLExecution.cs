using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Database
{
    class MSSQLExecution : IDBExecutionInterface
    {

        private static readonly BaseDBExecution.DBClassMapping msSQLDBClassMapping = new BaseDBExecution.DBClassMapping()
        {
            TypeCommandClass = typeof(SqlCommand),
            TypeConnectionClass = typeof(SqlConnection),
            TypeTransactionClass = typeof(SqlTransaction),
            TypeDataAdapterClass = typeof(SqlDataAdapter),
            TypeParameterClass = typeof(SqlParameter),
            TypeParameterCollectionClass = typeof(SqlParameterCollection)
        };


        private static readonly string sConnString = CommonDB.GetConnectionString();

        private object Execute(string sCmdText, IsolationLevel ilTransIsolationLvl, object[] spmCmdParams, string strCallingMethodName)
        {
            return BaseDBExecution.Execute(msSQLDBClassMapping, sConnString, sCmdText, ilTransIsolationLvl, spmCmdParams, strCallingMethodName);
        }

        //Back-Up: Do not delete
        //private object Execute_bk(string sCmdText, IsolationLevel ilTransIsolationLvl, object[] spmCmdParams, string strCallingMethodName)
        //{
        //    SqlCommand scmCmd = new SqlCommand(sCmdText);
        //    SqlConnection scnConn = new SqlConnection(sConnString);

        //    object objResult = null;
        //    Exception e = null;

        //    if (scnConn.State != ConnectionState.Open)
        //        scnConn.Open();

        //    SqlTransaction stTrans = scnConn.BeginTransaction(ilTransIsolationLvl);

        //    try
        //    {
        //        if (scnConn.State != ConnectionState.Open)
        //            scnConn.Open();

        //        scmCmd.Connection = scnConn;

        //        if (stTrans != null)
        //            scmCmd.Transaction = stTrans;

        //        if (spmCmdParams != null)
        //            spmCmdParams.Cast<SqlParameter>().ToList().ForEach(x => scmCmd.Parameters.Add(x));

        //        switch (strCallingMethodName)
        //        {
        //            case "ExecuteReader":
        //                objResult = new DataSet();
        //                new SqlDataAdapter(scmCmd).Fill(objResult as DataSet);
        //                break;
        //            case "ExecuteScalar":
        //                objResult = scmCmd.ExecuteScalar();
        //                break;
        //            case "ExecuteNonQuery":
        //                scmCmd.ExecuteNonQuery();
        //                stTrans.Commit();
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        e = ex;
        //        stTrans.Rollback();
        //    }
        //    finally
        //    {
        //        scmCmd.Parameters.Clear();
        //        scmCmd.Dispose();

        //        if (scnConn.State != ConnectionState.Closed)
        //        {
        //            scnConn.Close();
        //        }

        //        if (e != null)
        //            throw e;
        //    }

        //    return objResult;
        //}

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
            return new SqlParameter()
            {
                ParameterName = strParamName,
                Value = objParamValue
            };
        }
    }
}
