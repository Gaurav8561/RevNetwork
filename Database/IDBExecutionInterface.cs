using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IDBExecutionInterface
    {
        DataSet ExecuteReader(string sCmdText, object[] spmCmdParams);
        void ExecuteNonQuery(string sCmdText, IsolationLevel ilTransIsolationLvl, object[] spmCmdParams);
        object ExecuteScalar(string sCmdText, object[] spmCmdParams);
        object ProcessParameter(string strParamName, object objParamValue);
    }
}
