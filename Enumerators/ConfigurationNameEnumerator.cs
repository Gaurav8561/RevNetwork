using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public abstract class ConfigurationNameEnumerator : BaseEnumerator
    {
        public enum ConfigurationDataType
        {
            [ConfigurationDataTypeVariables(null, null)]
            DATA_TYPE_STRING,
            [ConfigurationDataTypeVariables(null, null)]
            DATA_TYPE_INT,
            [ConfigurationDataTypeVariables(null, null)]
            DATA_TYPE_DECIMAL,
            [ConfigurationDataTypeVariables("FuncDateTimeFormatter", "FuncDateTimeParser")]
            DATA_TYPE_DATE,
            [ConfigurationDataTypeVariables(null, null)]
            DATA_TYPE_EMAIL,
            [ConfigurationDataTypeVariables(null, null)]
            DATA_TYPE_URL,
            [ConfigurationDataTypeVariables(null, null)]
            DATA_TYPE_PASSWORD,
            [ConfigurationDataTypeVariables(null, null)]
            DATA_TYPE_BOOLEAN
        }

        public class ConfigurationDataTypeVariablesAttribute : Attribute
        {
            

            public Func<object, string> FuncFormatter { get; private set; }
            public Func<string, object> FuncParser { get; private set; }

            public ConfigurationDataTypeVariablesAttribute(string strFuncFormatterName, string  strFuncParserName)
            {
                this.FuncFormatter = !string.IsNullOrEmpty(strFuncFormatterName) && typeof(ConfigurationDataFormatter).GetFields().Any(x => x.Name == strFuncFormatterName) ? (Func<object, string>)typeof(ConfigurationDataFormatter).GetField(strFuncFormatterName).GetValue(null) : null;
                this.FuncParser = !string.IsNullOrEmpty(strFuncParserName) && typeof(ConfigurationDataParser).GetFields().Any(x => x.Name == strFuncParserName) ? (Func<string, object>)typeof(ConfigurationDataParser).GetField(strFuncParserName).GetValue(null) : null;

                //this.ExecutionInterface = (IDBExecutionInterface)typeof(IDBExecutionInterface).Assembly.GetTypes().Single(x => x.Name == strExecutionInterfaceClassName).GetConstructor(new Type[] { }).Invoke(null);
                //this.QueryStringBuilder = (IQueryStringBuilderInterface)typeof(IQueryStringBuilderInterface).Assembly.GetTypes().Single(x => x.Name == strQueryStringBuilderClassName).GetConstructor(new Type[] { }).Invoke(null);
            }
        }

        private class ConfigurationDataFormatter
        {
            public static readonly Func<object, string> FuncDateTimeFormatter = new Func<object, string>(x => (x is DateTime || x is DateTime?) ? ((DateTime)x).ToString(CultureInfo.CurrentCulture.DateTimeFormat.UniversalSortableDateTimePattern) : string.Empty);
        }

        private class ConfigurationDataParser
        {
            public static readonly Func<string, object> FuncDateTimeParser = new Func<string, object>(x => DateTime.TryParse(x, out DateTime dteOutput) ? (DateTime?)dteOutput : null);
        }

        public ConfigurationDataType DtDataType { get; private set; }
        public object ObjDefaultValue { get; private set; }
        public Func<object, string> FuncFormatter { 
            get 
            {
                return GetVariables(DtDataType).FuncFormatter;
                //switch (DtDataType)
                //{
                //    case ConfigurationDataType.DATA_TYPE_DATE:
                //        return DateTimeFormatter;
                //    default:
                //        return null;
                //}
            } 
        }
        public Func<string, object> FuncParser
        {
            get
            {
                return GetVariables(DtDataType).FuncParser;
                //switch (DtDataType)
                //{
                //    case ConfigurationDataType.DATA_TYPE_DATE:
                //        return DateTimeParser;
                //    default:
                //        return null;
                //}
            }
        }

        protected ConfigurationNameEnumerator(string strKey, string strResxKey, ConfigurationDataType dtDataType, object objDefaultValue) : base(strKey, strResxKey)
        {
            this.DtDataType = dtDataType;
            this.ObjDefaultValue = objDefaultValue;

            RegisterChildEnumerator(typeof(ConfigurationNameEnumerator), this.GetType());
        }



        public static ConfigurationNameEnumerator GetEnumByKey(string strKey)
        {
            return (ConfigurationNameEnumerator)GetEnumByKey(typeof(ConfigurationNameEnumerator), strKey);
        }



        public static List<ConfigurationNameEnumerator> GetEnumList()
        {
            return GetEnumList(typeof(ConfigurationNameEnumerator)).Cast<ConfigurationNameEnumerator>().ToList();
        }


        //protected static string DateTimeFormatter(object objDateTimeObject)
        //{
        //    if (objDateTimeObject is DateTime || objDateTimeObject is DateTime?)
        //        return ((DateTime)objDateTimeObject).ToString(CultureInfo.CurrentCulture.DateTimeFormat.UniversalSortableDateTimePattern);
        //    else
        //        return string.Empty;
        //}

        //protected static object DateTimeParser(string strDateTimeString)
        //{
        //    if (DateTime.TryParseExact(strDateTimeString, CultureInfo.CurrentCulture.DateTimeFormat.UniversalSortableDateTimePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dteOutput))
        //        return dteOutput;
        //    else
        //        return null;
        //}

        private static ConfigurationDataTypeVariablesAttribute GetVariables(ConfigurationDataType cdtDataType)
        {
            return (ConfigurationDataTypeVariablesAttribute)typeof(ConfigurationDataType).GetMember(cdtDataType.ToString()).Single(m => m.DeclaringType == typeof(ConfigurationDataType)).GetCustomAttribute(typeof(ConfigurationDataTypeVariablesAttribute), false);
        }
    }
}
