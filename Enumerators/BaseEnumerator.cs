using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TypeEnumerator
{
    public abstract class BaseEnumerator
    {
        private static readonly Dictionary<Type, Dictionary<string, BaseEnumerator>> dict
            = new Dictionary<Type, Dictionary<string, BaseEnumerator>>();

        private static readonly Dictionary<Type, List<Type>> childListDict
            = new Dictionary<Type, List<Type>>();

        public string StrKey { get; set; }
        public string StrResxKey { get; set; }

        public string StrDispText 
        {
            get 
            { 
                return EnumeratorResourceManager.ResourceManager.GetString(StrResxKey); 
            }
        }

        protected BaseEnumerator(string strKey, string strResxKey)
        {
            this.StrKey = strKey;
            this.StrResxKey = strResxKey;

            if (dict.TryGetValue(this.GetType(), out Dictionary<string, BaseEnumerator> enumDict))
            {
                if(!enumDict.ContainsKey(this.StrKey))
                    enumDict.Add(this.StrKey, this);
            }
            else
            {
                dict.Add(this.GetType(), new Dictionary<string, BaseEnumerator>
                {
                    { this.StrKey, this }
                });
            }
        }

        protected static void RegisterChildEnumerator(Type typeParentType, Type typeChildType)
        {
            if (childListDict.ContainsKey(typeParentType))
            {
                if(!childListDict[typeParentType].Contains(typeChildType))
                    childListDict[typeParentType].Add(typeChildType);
            }
            else
            {
                childListDict.Add(typeParentType, new List<Type>() { typeChildType });
            }
        }

        protected static BaseEnumerator GetEnumByKey(Type enumType, string strKey)
        {
            if (childListDict.ContainsKey(enumType))
            {
                return childListDict[enumType].Select(x => GetEnumByKey(x, strKey)).SingleOrDefault(x => x != null);
            }
            else if(dict.ContainsKey(enumType))
            {
                return dict[enumType].TryGetValue(strKey.Trim(), out BaseEnumerator value) ? value : null;
            }
            else
            {
                return null;
            }
        }

        protected static List<BaseEnumerator> GetEnumList(Type enumType)
        {
            if (childListDict.ContainsKey(enumType))
            {
                return childListDict[enumType].SelectMany(x => GetEnumList(x)).ToList();
            }
            else if (dict.ContainsKey(enumType))
            {
                return dict[enumType].Values.ToList();
            }
            else
            {
                return null;
            }
        }



        public bool Equals(BaseEnumerator enumerator)
        {
            return enumerator != null && enumerator.GetType() == this.GetType() && enumerator.StrKey == this.StrKey;
        }


        public override string ToString()
        {
            return StrKey;
        }


        public static void EvaluateAllEnumerators()
        {
            Assembly.GetAssembly(typeof(BaseEnumerator)).GetTypes().Where(t => typeof(BaseEnumerator).IsAssignableFrom(t)).ToList().ForEach(x => x.GetFields().Where(f => typeof(BaseEnumerator).IsAssignableFrom(f.FieldType)).ToList().ForEach(y => x.GetField(y.Name).GetValue(null)));
        }
    }
}
