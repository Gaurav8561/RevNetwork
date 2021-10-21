using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TypeEnumerator;
using Utility;
using MySql.Data.MySqlClient;
using General;

namespace Database
{
    public class CommonDB
    {
        private static readonly string sConnString = GetConnectionString();
        
        public static DataSet ExecuteReader(string sCmdText, SqlParameter[] spmCmdParams, out string sErrMsg, out int iTotalRows)
        {
            sErrMsg = null;
            iTotalRows = 0;
            SqlCommand scmCmd = new SqlCommand();
            SqlConnection scnConn = new SqlConnection(sConnString);
            scnConn.Open();
            DataSet dsReader = new DataSet();

            try
            {
                PrepareCommand(scmCmd, scnConn, null, sCmdText, spmCmdParams);

                //if (iTimeout > 0)
                //    scmCmd.CommandTimeout = iTimeout;

                SqlDataAdapter sdaReader = new SqlDataAdapter(scmCmd);
                sdaReader.Fill(dsReader);
                foreach (DataTable dtReaderTbl in dsReader.Tables)
                {
                    iTotalRows += dtReaderTbl.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                dsReader = null;
                iTotalRows = 0;
            }
            finally
            {
                scmCmd.Parameters.Clear();
                scmCmd.Dispose();
                if (scnConn.State != ConnectionState.Closed)
                {
                    scnConn.Close();
                }
            }

            return dsReader;
        }



        public static void ExecuteNonQuery(string sCmdText, IsolationLevel ilTransIsolationLvl, SqlParameter[] spmCmdParams, out string sErrMsg)
        {
            sErrMsg = null;
            //iTotalRows = 0;
            SqlCommand scmCmd = new SqlCommand();
            SqlConnection scnConn = new SqlConnection(sConnString);
            //DataSet dsReader = new DataSet();
            scnConn.Open();
            SqlTransaction stTrans = scnConn.BeginTransaction(ilTransIsolationLvl);

            try
            {
                PrepareCommand(scmCmd, scnConn, stTrans, sCmdText, spmCmdParams);

                //if (iTimeout > 0)
                //    scmCmd.CommandTimeout = iTimeout;

                scmCmd.ExecuteNonQuery();

                stTrans.Commit();


                //SqlDataAdapter sdaReader = new SqlDataAdapter(scmCmd);
                //sdaReader.Fill(dsReader);
                //foreach (DataTable dtReaderTbl in dsReader.Tables)
                //{
                //    iTotalRows += dtReaderTbl.Rows.Count;
                //}
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                //dsReader = null;
                //iTotalRows = 0;

                stTrans.Rollback();
            }
            finally
            {
                scmCmd.Parameters.Clear();
                scmCmd.Dispose();
                if (scnConn.State != ConnectionState.Closed)
                {
                    scnConn.Close();
                }
            }
        }



        private static void PrepareCommand(SqlCommand scmCmd, SqlConnection scnConn, SqlTransaction stnTrans, string sCmdText, SqlParameter[] spmCmdParams)
        {
            if (scnConn.State != ConnectionState.Open)
            {
                scnConn.Open();
            }
            scmCmd.Connection = scnConn;
            scmCmd.CommandText = sCmdText;
            if (stnTrans != null)
            {
                scmCmd.Transaction = stnTrans;
            }
            //scmCmd.CommandType = ctCmdType;
            if (spmCmdParams != null)
            {
                for (int i = 0; i < spmCmdParams.Length; i++)
                {
                    SqlParameter spParam = spmCmdParams[i];
                    scmCmd.Parameters.Add(spParam);
                }
            }
        }



        //public static SqlParameter SetParameter(string sParameterName, object objValue, SqlDbType sdtSqlDbType, object iSize)
        public static SqlParameter SetParameter(string sParameterName, object objValue)
        {
            SqlParameter spSqlParam = new SqlParameter();
            spSqlParam.ParameterName = sParameterName;
            if ((new Type[] { typeof(BaseEnumerator) }).Any(x => objValue != null && x.IsAssignableFrom(objValue.GetType())))
                spSqlParam.Value = ((objValue == null) ? DBNull.Value : (string.IsNullOrEmpty(objValue.ToString().Trim()) ? DBNull.Value : (object)objValue.ToString()));
            else
                spSqlParam.Value = ((objValue == null) ? DBNull.Value : (string.IsNullOrEmpty(objValue.ToString().Trim()) ? DBNull.Value : objValue));
            //spSqlParam.SqlDbType = sdtSqlDbType;
            //int iPrmSize = 0;
            //if (iSize != null)
            //{
            //    int.TryParse(iSize.ToString(), out iPrmSize);
            //}
            //if (iSize != null)
            //{
            //    spSqlParam.Size = iPrmSize;
            //}
            return spSqlParam;
        }

        

        internal static string GetConnectionString()
        {
            return Encryption.Decrypt(ConfigurationManager.ConnectionStrings[EnviromentSwitch.GetVariables().StrConnStringName].ConnectionString);
        }

        public static DataSet ExecuteReader(string sCmdText, object[] spmCmdParams)
        {
            return DBSwitch.GetVariables().ExecutionInterface.ExecuteReader(sCmdText, spmCmdParams);
        }
        public static void ExecuteNonQuery(string sCmdText, IsolationLevel ilTransIsolationLvl, object[] spmCmdParams)
        {
            DBSwitch.GetVariables().ExecutionInterface.ExecuteNonQuery(sCmdText, ilTransIsolationLvl, spmCmdParams);
        }
        public static void ExecuteScalar(string sCmdText, object[] spmCmdParams)
        {
            DBSwitch.GetVariables().ExecutionInterface.ExecuteScalar(sCmdText, spmCmdParams);
        }

        public static object ProcessParameter(string strParamName, object objParamValue)
        {
            if (objParamValue == null || (objParamValue != null && string.IsNullOrWhiteSpace(objParamValue.ToString())))
                objParamValue = DBNull.Value;
            else if ((new Type[] { typeof(BaseEnumerator), typeof(IDBVarcharDerivedType) }).Any(x => x.IsAssignableFrom(objParamValue.GetType())))
                objParamValue = objParamValue.ToString();

            return DBSwitch.GetVariables().ExecutionInterface.ProcessParameter(strParamName, objParamValue);
        }

        public static object ParseFromDB(Type fieldType, object objReturnValue)
        {
            if (typeof(string).IsAssignableFrom(fieldType))
            {
                return  objReturnValue.ToString();
            }
            else if (typeof(BaseEnumerator).IsAssignableFrom(fieldType))
            {
                return fieldType.GetMethod("GetEnumByKey").Invoke(null, new object[] { objReturnValue.ToString() });
            }
            else if (fieldType.IsEnum)
            {
                object[] param = new object[] { fieldType, objReturnValue.ToString(), null };
                return (bool)(Nullable.GetUnderlyingType(fieldType) ?? fieldType).GetMethod("TryParse", new Type[] { typeof(Type), typeof(string), (Nullable.GetUnderlyingType(fieldType) ?? fieldType).MakeByRefType() }).Invoke(null, param) ? param[1] : null;
            }
            else if(fieldType.IsValueType)
            {
                object[] param = new object[] { objReturnValue.ToString(), null };
                return (bool)(Nullable.GetUnderlyingType(fieldType) ?? fieldType).GetMethod("TryParse", new Type[] { typeof(string), (Nullable.GetUnderlyingType(fieldType) ?? fieldType).MakeByRefType() }).Invoke(null, param) ? param[1] : null;
            }
            else
            {
                return objReturnValue;
            }
        }

        public static bool TableExists(string tableName)
        {
            using (SqlConnection scnConn = new SqlConnection(sConnString))
            {
                scnConn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @table) SELECT 1 ELSE SELECT 0";
                using (SqlCommand scmCmd = new SqlCommand(query, scnConn))
                {
                    scmCmd.Parameters.Add("@table", SqlDbType.NVarChar).Value = tableName;
                    int result = (int)scmCmd.ExecuteScalar();
                    return result == 1;
                }
            }
        }

        public static void ExecuteStoredProcedure(string storedProcedureName, SqlParameter[] spmCmdParams)
        {
            using (SqlConnection scnConn = new SqlConnection(sConnString))
            {
                scnConn.Open();
                using (SqlCommand scmCmd = new SqlCommand(storedProcedureName, scnConn))
                {
                    scmCmd.CommandType = CommandType.StoredProcedure;
                    if (spmCmdParams != null)
                    {
                        spmCmdParams.ToList().ForEach(p => scmCmd.Parameters.Add(p));
                    }
                    scmCmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet ExecuteScalarDataSet(string storedProcedureName, SqlParameter[] spmCmdParams)
        {
            DataSet dsReader = new DataSet();

            using (SqlConnection scnConn = new SqlConnection(sConnString))
            {
                scnConn.Open();
                using (SqlCommand scmCmd = new SqlCommand(storedProcedureName, scnConn))
                {
                    scmCmd.CommandType = CommandType.StoredProcedure;
                    if (spmCmdParams != null)
                    {
                        spmCmdParams.ToList().ForEach(p => scmCmd.Parameters.Add(p));
                    }

                    SqlDataAdapter sdaReader = new SqlDataAdapter(scmCmd);
                    sdaReader.Fill(dsReader);
                    scmCmd.ExecuteNonQuery();
                    return dsReader;
                }
            }
        }

        public static DataTable ExecuteScalarDataTable(string storedProcedureName, SqlParameter[] spmCmdParams)
        {
            DataTable dtReader = new DataTable();

            using (SqlConnection scnConn = new SqlConnection(sConnString))
            {
                scnConn.Open();
                using (SqlCommand scmCmd = new SqlCommand(storedProcedureName, scnConn))
                {
                    scmCmd.CommandType = CommandType.StoredProcedure;
                    if (spmCmdParams != null)
                    {
                        spmCmdParams.ToList().ForEach(p => scmCmd.Parameters.Add(p));
                    }

                    SqlDataAdapter sdaReader = new SqlDataAdapter(scmCmd);
                    sdaReader.Fill(dtReader);
                    scmCmd.ExecuteNonQuery();
                    return dtReader;
                }
            }
        }
    }
}
