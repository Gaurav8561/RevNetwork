using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TypeEnumerator;
using Utility;



namespace Entity
{
    public abstract class BaseInterface
    {
        public static BaseEntity GetByPrimaryKey(EntityToTableMapping tableMapping, string strPrimaryKey)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByPrimaryKey(tableMapping.StrTableName, tableMapping.StrPrimaryKeyColumnName, tableMapping.StrStatusColumnName),
                                                        new object[]
                                                        {
                                                            CommonDB.ProcessParameter(tableMapping.StrPrimaryKeyColumnName, strPrimaryKey)
                                                        });

            if (dataSet == null || dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
                return null;
            else
            {
                BaseEntity entity = (BaseEntity)tableMapping.TypeEntityType.GetConstructor(new Type[] { }).Invoke(new object[] { });

                tableMapping.LstPropertyToColumnPairs.ForEach(propertyColumnPair => Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, propertyColumnPair.StrPropertyName), CommonDB.ParseFromDB(Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).PropertyType, dataSet.Tables[0].Rows[0][propertyColumnPair.StrColumnName])));

                return entity;
            }
        }



        public static BaseEntity GetByCustomColumn(EntityToTableMapping tableMapping, string strCustomColumn, string strColumnValue)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByPrimaryKey(tableMapping.StrTableName, strCustomColumn, tableMapping.StrStatusColumnName),
                                                        new object[]
                                                        {
                                                            CommonDB.ProcessParameter(strCustomColumn, strColumnValue)
                                                        });

            if (dataSet == null || dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
                return null;
            else
            {
                BaseEntity entity = (BaseEntity)tableMapping.TypeEntityType.GetConstructor(new Type[] { }).Invoke(new object[] { });

                tableMapping.LstPropertyToColumnPairs.ForEach(propertyColumnPair => Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, propertyColumnPair.StrPropertyName), CommonDB.ParseFromDB(Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).PropertyType, dataSet.Tables[0].Rows[0][propertyColumnPair.StrColumnName])));

                return entity;
            }
        }



        public static BaseEntity New(EntityToTableMapping tableMapping, BaseEntity entity)
        {
            do
            {
                Common.GetPropertyByPath(entity, tableMapping.StrPrimaryKeyPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, tableMapping.StrPrimaryKeyPropertyName), PrimaryKeyController.GetLatestUUIDPrimaryKey(tableMapping.StrPrimaryKeyPrefix));
            } while (GetByPrimaryKey(tableMapping, Common.GetPropertyByPath(entity, tableMapping.StrPrimaryKeyPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, tableMapping.StrPrimaryKeyPropertyName)) as string) != null);

            if (!string.IsNullOrEmpty(tableMapping.StrStatusColumnName))
                Common.GetPropertyByPath(entity, tableMapping.StrStatusPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, tableMapping.StrStatusPropertyName), StatusEnumerator.StatusActive);
            if (!string.IsNullOrEmpty(tableMapping.StrCreatedByColumnName))
                Common.GetPropertyByPath(entity, tableMapping.StrCreatedByPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, tableMapping.StrCreatedByPropertyName), UserInfo.GetUserInfo().Username);
            if (!string.IsNullOrEmpty(tableMapping.StrCreatedDateColumnName))
                Common.GetPropertyByPath(entity, tableMapping.StrCreatedDatePropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, tableMapping.StrCreatedDatePropertyName), DateTime.Now);
            if (!string.IsNullOrEmpty(tableMapping.StrModifiedByPropertyName))
                Common.GetPropertyByPath(entity, tableMapping.StrModifiedByPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, tableMapping.StrModifiedByPropertyName), null);
            if (!string.IsNullOrEmpty(tableMapping.StrModifiedDateColumnName))
                Common.GetPropertyByPath(entity, tableMapping.StrModifiedDatePropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, tableMapping.StrModifiedDatePropertyName), null);

            CommonDB.ExecuteNonQuery(QueryStringBuilder.GetInsertStatement(tableMapping.StrTableName, tableMapping.LstPropertyToColumnPairs.Select(x=>x.StrColumnName).ToArray()),
                                        IsolationLevel.Serializable,
                                        tableMapping.LstPropertyToColumnPairs.Select(x => CommonDB.ProcessParameter(x.StrColumnName, Common.GetPropertyByPath(entity, x.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, x.StrPropertyName)))).ToArray());

            return GetByPrimaryKey(tableMapping, Common.GetPropertyByPath(entity,tableMapping.StrPrimaryKeyPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, tableMapping.StrPrimaryKeyPropertyName)) as string);
        }



        //public static BaseEntity Update(EntityToTableMapping tableMapping, BaseEntity updatedEntity)
        //{
        //    BaseEntity existingEntity = GetByPrimaryKey(tableMapping, Common.GetPropertyByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName)) as string);

        //    List<string> columnList = tableMapping.LstPropertyToColumnPairs.Where(propertyColumnPair => !Common.IsEqual(Common.GetPropertyByPath(updatedEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, propertyColumnPair.StrPropertyName)), Common.GetPropertyByPath(existingEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(existingEntity, propertyColumnPair.StrPropertyName)))).Select(propertyColumnPair => propertyColumnPair.StrColumnName).ToList();
        //    List<object> paramList = tableMapping.LstPropertyToColumnPairs.Where(propertyColumnPair => !Common.IsEqual(Common.GetPropertyByPath(updatedEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, propertyColumnPair.StrPropertyName)), Common.GetPropertyByPath(existingEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(existingEntity, propertyColumnPair.StrPropertyName)))).Select(propertyColumnPair => CommonDB.ProcessParameter(propertyColumnPair.StrColumnName, Common.GetPropertyByPath(updatedEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, propertyColumnPair.StrPropertyName)))).ToList();

        //    if (columnList.Count > 0 && paramList.Count > 0)
        //    {
        //        if (!string.IsNullOrEmpty(tableMapping.StrModifiedByPropertyName))
        //        {
        //            columnList.Add(tableMapping.StrModifiedByColumnName);
        //            paramList.Add(CommonDB.ProcessParameter(tableMapping.StrModifiedByColumnName, UserInfo.GetUserInfo().Username));
        //        }
        //        if (!string.IsNullOrEmpty(tableMapping.StrModifiedDateColumnName))
        //        {
        //            columnList.Add(tableMapping.StrModifiedDateColumnName);
        //            paramList.Add(CommonDB.ProcessParameter(tableMapping.StrModifiedDateColumnName, DateTime.Now));
        //        }

        //        paramList.Add(CommonDB.ProcessParameter(tableMapping.StrPrimaryKeyColumnName, Common.GetPropertyByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName))));

        //        CommonDB.ExecuteNonQuery(QueryStringBuilder.GetUpdateStatement(tableMapping.StrTableName, tableMapping.StrPrimaryKeyColumnName, columnList.ToArray()),
        //                                    IsolationLevel.Serializable,
        //                                    paramList.ToArray());
        //    }

        //    return GetByPrimaryKey(tableMapping, Common.GetPropertyByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName)) as string);
        //}



        public static BaseEntity Update(EntityToTableMapping tableMapping, BaseEntity updatedEntity)
        {
            BaseEntity existingEntity = GetByPrimaryKey(tableMapping, Common.GetPropertyByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName)) as string);

            List<string> columnList = tableMapping.LstPropertyToColumnPairs.Where(propertyColumnPair => !Common.IsEqual(Common.GetPropertyByPath(updatedEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, propertyColumnPair.StrPropertyName)), Common.GetPropertyByPath(existingEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(existingEntity, propertyColumnPair.StrPropertyName))) && !propertyColumnPair.StrPropertyName.Equals(tableMapping.StrModifiedByPropertyName) && !propertyColumnPair.StrColumnName.Equals(tableMapping.StrModifiedDateColumnName)).Select(propertyColumnPair => propertyColumnPair.StrColumnName).ToList();
            List<object> paramList = tableMapping.LstPropertyToColumnPairs.Where(propertyColumnPair => !Common.IsEqual(Common.GetPropertyByPath(updatedEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, propertyColumnPair.StrPropertyName)), Common.GetPropertyByPath(existingEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(existingEntity, propertyColumnPair.StrPropertyName))) && !propertyColumnPair.StrPropertyName.Equals(tableMapping.StrModifiedByPropertyName) && !propertyColumnPair.StrColumnName.Equals(tableMapping.StrModifiedDateColumnName)).Select(propertyColumnPair => CommonDB.ProcessParameter(propertyColumnPair.StrColumnName, Common.GetPropertyByPath(updatedEntity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, propertyColumnPair.StrPropertyName)))).ToList();

            if (columnList.Count > 0 && paramList.Count > 0)
            {
                if (!string.IsNullOrEmpty(tableMapping.StrModifiedByPropertyName))
                {
                    columnList.Add(tableMapping.StrModifiedByColumnName);
                    paramList.Add(CommonDB.ProcessParameter(tableMapping.StrModifiedByColumnName, UserInfo.GetUserInfo().Username));
                }
                if (!string.IsNullOrEmpty(tableMapping.StrModifiedDateColumnName))
                {
                    columnList.Add(tableMapping.StrModifiedDateColumnName);
                    paramList.Add(CommonDB.ProcessParameter(tableMapping.StrModifiedDateColumnName, DateTime.Now));
                }

                paramList.Add(CommonDB.ProcessParameter(tableMapping.StrPrimaryKeyColumnName, Common.GetPropertyByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName))));

                CommonDB.ExecuteNonQuery(QueryStringBuilder.GetUpdateStatement(tableMapping.StrTableName, tableMapping.StrPrimaryKeyColumnName, columnList.ToArray()),
                                            IsolationLevel.Serializable,
                                            paramList.ToArray());
            }

            return GetByPrimaryKey(tableMapping, Common.GetPropertyByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName).GetValue(Common.GetPropertyInstanceByPath(updatedEntity, tableMapping.StrPrimaryKeyPropertyName)) as string);
        }



        public static List<BaseEntity> List(EntityToTableMapping tableMapping, BaseEntity entity)
        {
            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByConstraints(tableMapping.StrTableName, 
                                                                                                            tableMapping.LstPropertyToColumnPairs.Where(propertyColumnPair => !Common.IsEmpty(Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, propertyColumnPair.StrPropertyName)))).Select(propertyColumnPair => propertyColumnPair.StrColumnName).ToArray(), tableMapping.StrStatusColumnName),
                                                        tableMapping.LstPropertyToColumnPairs.Where(propertyColumnPair => !Common.IsEmpty(Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, propertyColumnPair.StrPropertyName)))).Select(propertyColumnPair => CommonDB.ProcessParameter(propertyColumnPair.StrColumnName, Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, propertyColumnPair.StrPropertyName)))).ToArray());

            List<BaseEntity> entityList = new List<BaseEntity>();

           if (!(dataSet == null || dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0))
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    BaseEntity entityResult = (BaseEntity)tableMapping.TypeEntityType.GetConstructor(new Type[] { }).Invoke(new object[] { });

                    tableMapping.LstPropertyToColumnPairs.ForEach(propertyColumnPair => Common.GetPropertyByPath(entityResult, propertyColumnPair.StrPropertyName).SetValue(Common.GetPropertyInstanceByPath(entityResult, propertyColumnPair.StrPropertyName), CommonDB.ParseFromDB(Common.GetPropertyByPath(entityResult, propertyColumnPair.StrPropertyName).PropertyType, row[propertyColumnPair.StrColumnName])));

                    entityList.Add(entityResult);
                }
            }

            return entityList;
        }



        public static List<BaseEntity> ListAll(EntityToTableMapping tableMapping, BaseEntity entity)
        {
            //string test = string.Empty;

            //test = QueryStringBuilder.GetSelectAllRowsStatement(tableMapping.StrTableName, tableMapping.LstPropertyToColumnPairs.Where(propertyColumnPair => !Common.IsEmpty(Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, propertyColumnPair.StrPropertyName)))).Select(propertyColumnPair => propertyColumnPair.StrColumnName).ToArray(), tableMapping.StrStatusColumnName);


            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectAllRowsStatement(tableMapping.StrTableName),
                                                        tableMapping.LstPropertyToColumnPairs.Where(propertyColumnPair => !Common.IsEmpty(Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, propertyColumnPair.StrPropertyName)))).Select(propertyColumnPair => CommonDB.ProcessParameter(propertyColumnPair.StrColumnName, Common.GetPropertyByPath(entity, propertyColumnPair.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, propertyColumnPair.StrPropertyName)))).ToArray());

            List<BaseEntity> entityList = new List<BaseEntity>();

            if (!(dataSet == null || dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0))
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    BaseEntity entityResult = (BaseEntity)tableMapping.TypeEntityType.GetConstructor(new Type[] { }).Invoke(new object[] { });

                    tableMapping.LstPropertyToColumnPairs.ForEach(propertyColumnPair => Common.GetPropertyByPath(entityResult, propertyColumnPair.StrPropertyName).SetValue(Common.GetPropertyInstanceByPath(entityResult, propertyColumnPair.StrPropertyName), CommonDB.ParseFromDB(Common.GetPropertyByPath(entityResult, propertyColumnPair.StrPropertyName).PropertyType, row[propertyColumnPair.StrColumnName])));

                    entityList.Add(entityResult);
                }
            }

            return entityList;
        }
    }
}
