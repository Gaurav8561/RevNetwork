using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Database
{
    public class BaseDBExecution
    {
        public class DBClassMapping
        {
            public Type TypeCommandClass { get; set; }
            public Type TypeConnectionClass { get; set; }
            public Type TypeTransactionClass { get; set; }
            public Type TypeDataAdapterClass { get; set; }
            public Type TypeParameterClass { get; set; }
            public Type TypeParameterCollectionClass { get; set; }
        }


        public static object Execute(DBClassMapping dbClassMapping, string sConnString, string sCmdText, IsolationLevel ilTransIsolationLvl, object[] spmCmdParams, string strCallingMethodName)
        {
            object scmCmd = dbClassMapping.TypeCommandClass.GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { sCmdText });
            object scnConn = dbClassMapping.TypeConnectionClass.GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { sConnString });

            object stTrans = null;
            object objResult = null;
            Exception e = null;

            if ((ConnectionState)scnConn.GetType().GetProperty("State", typeof(ConnectionState)).GetValue(scnConn) != ConnectionState.Open)
                scnConn.GetType().GetMethod("Open", new Type[] { }).Invoke(scnConn, null);

            if (!strCallingMethodName.Equals("ExecuteReader"))
                stTrans = scnConn.GetType().GetMethod("BeginTransaction", new Type[] { typeof(IsolationLevel) }).Invoke(scnConn, new object[] { ilTransIsolationLvl });

            try
            {
                scmCmd.GetType().GetProperty("Connection", dbClassMapping.TypeConnectionClass).SetValue(scmCmd, scnConn);

                scmCmd.GetType().GetProperty("CommandTimeout").SetValue(scmCmd, 120);

                if (stTrans != null)
                    scmCmd.GetType().GetProperty("Transaction", dbClassMapping.TypeTransactionClass).SetValue(scmCmd, stTrans);
                if (spmCmdParams != null)
                    spmCmdParams.Cast<SqlParameter>().ToList().ForEach(x => scmCmd.GetType().GetProperty("Parameters", dbClassMapping.TypeParameterCollectionClass).PropertyType.GetMethod("Add", new Type[] { dbClassMapping.TypeParameterClass }).Invoke(scmCmd.GetType().GetProperty("Parameters", dbClassMapping.TypeParameterCollectionClass).GetValue(scmCmd), new object[] { x }));

                switch (strCallingMethodName)
                {
                    case "ExecuteReader":
                        objResult = new DataSet();
                        object da = dbClassMapping.TypeDataAdapterClass.GetConstructor(new Type[] { dbClassMapping.TypeCommandClass }).Invoke(new object[] { scmCmd });
                        da.GetType().GetMethod("Fill", new Type[] { typeof(DataSet) }).Invoke(da, new object[] { objResult });

                        break;
                    case "ExecuteScalar":
                        objResult = scmCmd.GetType().GetMethod("ExecuteScalar").Invoke(scmCmd, null);
                        break;
                    case "ExecuteNonQuery":
                        scmCmd.GetType().GetMethod("ExecuteNonQuery").Invoke(scmCmd, null);
                        stTrans.GetType().GetMethod("Commit", new Type[] { }).Invoke(stTrans, null);
                        break;
                }

            }
            catch (Exception ex)
            {
                e = ex;
                if (stTrans != null)
                    stTrans.GetType().GetMethod("Rollback", new Type[] { }).Invoke(stTrans, null);
            }
            finally
            {
                scmCmd.GetType().GetProperty("Parameters", dbClassMapping.TypeParameterCollectionClass).PropertyType.GetMethod("Clear", new Type[] { }).Invoke(scmCmd.GetType().GetProperty("Parameters", dbClassMapping.TypeParameterCollectionClass).GetValue(scmCmd), null);
                scmCmd.GetType().GetMethod("Dispose", new Type[] { }).Invoke(scmCmd, null);


                if ((ConnectionState)scnConn.GetType().GetProperty("State", typeof(ConnectionState)).GetValue(scnConn) != ConnectionState.Closed)
                    scnConn.GetType().GetMethod("Close", new Type[] { }).Invoke(scnConn, null);

                if (e != null)
                    throw e;
            }

            return objResult;
        }
    }
}
