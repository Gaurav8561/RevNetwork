using General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    public class EntityToTableMapping
    {
        public class PropertyToColumnPair
        {
            public string StrPropertyName { get; set; }
            public string StrColumnName { get; set; }

            public PropertyToColumnPair(string strPropertyName, string strColumnName)
            {
                this.StrPropertyName = strPropertyName;
                this.StrColumnName = strColumnName;
            }
        }

        public Type TypeEntityType { get; set; }
        public string StrTableName { get; set; }
        public string StrPrimaryKeyPrefix { get; set; }
        public string StrPrimaryKeyColumnName { get; set; }
        public string StrPrimaryKeyPropertyName { get { return this.StrPrimaryKeyColumnName != null ? GetPropertyNameByColumnName(this.StrPrimaryKeyColumnName) : null; } }
        public string StrStatusColumnName { get; set; }
        public string StrStatusPropertyName { get { return this.StrStatusColumnName != null ? GetPropertyNameByColumnName(this.StrStatusColumnName) : null; } }
        public string StrCreatedByColumnName { get; set; }
        public string StrCreatedByPropertyName { get { return this.StrCreatedByColumnName != null ? GetPropertyNameByColumnName(this.StrCreatedByColumnName) : null; } }
        public string StrCreatedDateColumnName { get; set; }
        public string StrCreatedDatePropertyName { get { return this.StrCreatedDateColumnName != null ? GetPropertyNameByColumnName(this.StrCreatedDateColumnName) : null; } }
        public string StrModifiedByColumnName { get; set; }
        public string StrModifiedByPropertyName { get { return this.StrModifiedByColumnName != null ? GetPropertyNameByColumnName(this.StrModifiedByColumnName) : null; } }
        public string StrModifiedDateColumnName { get; set; }
        public string StrModifiedDatePropertyName { get { return this.StrModifiedDateColumnName != null ? GetPropertyNameByColumnName(this.StrModifiedDateColumnName) : null; } }
        public List<PropertyToColumnPair> LstPropertyToColumnPairs { get; set; }


        private readonly Map<string, string> field_MapPropertyToColumnMap;

        public EntityToTableMapping(Type typeEntityType, string strTableName, string strPrimaryKeyPrefix, string strPrimaryKeyColumnName, string strStatusColumnName, string strCreatedByColumnName, string strCreatedDateColumnName, string strModifiedByColumnName, string strModifiedDateColumnName, List<PropertyToColumnPair> lstPropertyToColumnPairs)
        {
            this.TypeEntityType = typeEntityType;
            this.StrTableName = strTableName;
            this.StrPrimaryKeyPrefix = strPrimaryKeyPrefix;
            this.StrPrimaryKeyColumnName = strPrimaryKeyColumnName;
            this.StrStatusColumnName = strStatusColumnName;
            this.StrCreatedByColumnName = strCreatedByColumnName;
            this.StrCreatedDateColumnName = strCreatedDateColumnName;
            this.StrModifiedByColumnName = strModifiedByColumnName;
            this.StrModifiedDateColumnName = strModifiedDateColumnName;
            this.LstPropertyToColumnPairs = lstPropertyToColumnPairs;

            field_MapPropertyToColumnMap = new Map<string, string>(this.LstPropertyToColumnPairs.ToDictionary(x => x.StrPropertyName, x => x.StrColumnName));
        }

        public string GetPropertyNameByColumnName(string strColumnName)
        {
            return field_MapPropertyToColumnMap.Reverse[strColumnName];
        }

        public string GetColumnNameByPropertyName(string strPropertyName)
        {
            return field_MapPropertyToColumnMap.Forward[strPropertyName];
        }
    }
}
