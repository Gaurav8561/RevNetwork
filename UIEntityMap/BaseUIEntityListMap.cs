using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;
using Utility;

namespace UIEntityMap
{
    public class BaseUIEntityListMap
    {
        public class UIEntityListGridPropertyMap
        {
            public string StrPropertyName { get; set; }
            public string StrResxKey { get; set; }
            public string StrLabelText { get { return ResxManager.ResourceManager.GetString(StrResxKey); } }
            public string StrDisplayFormat { get; set; }
            public string StrParameterPropertyName { get; set; }

            internal UIEntityListGridPropertyMap(string strPropertyName, string strResxKey, string strDisplayFormat, string strParameter)
            {
                StrPropertyName = strPropertyName;
                StrResxKey = strResxKey;
                StrDisplayFormat = strDisplayFormat;
                StrParameterPropertyName = strParameter;
            }
        }

        public class UIEntityListSearcheablePropertyMap
        {
            public string StrPropertyName { get; set; }
            public string StrResxKey { get; set; }
            public string StrLabelText { get { return ResxManager.ResourceManager.GetString(StrResxKey); } }
          

            internal UIEntityListSearcheablePropertyMap(string strPropertyName, string strResxKey)
            {
                StrPropertyName = strPropertyName;
                StrResxKey = strResxKey;
            }
        }

        public static readonly Action EvaluateAllUIEntityListMap = new Action(() => typeof(BaseUIEntityListMap).Assembly.GetTypes().Where(x => typeof(BaseUIEntityListMap).IsAssignableFrom(x) && x.Name != typeof(BaseUIEntityListMap).Name).ToList().ForEach(x => x.GetField("EntityUIListMap").GetValue(null)));

        private static readonly List<BaseUIEntityListMap> LstUIEMList
                = new List<BaseUIEntityListMap>();

        public Type TypeEntityClass { get; private set; }
        public Type TypeInterfaceClass { get; private set; }
        public string StrPageTitleResxKey { get; private set; }
        public string StrPageTitleDispText { get { return ResxManager.ResourceManager.GetString(StrPageTitleResxKey); } }
        public string StrNewButtonResxKey { get; private set; }
        public string StrNewButtonDispText { get { return ResxManager.ResourceManager.GetString(StrNewButtonResxKey); } }
        public UserRoleEnumerator[] AuthorisedRoles { get; private set; }
        public UIEntityListGridPropertyMap[] UIEPMPropertyMaps { get; private set; }
        public UIEntityListSearcheablePropertyMap[] UIELSPMSearcheablePropertyMaps { get; private set; }
        public Func<UserEntity, List<BaseEntity>> FuncEntityListPopulater { get; private set; }

        protected BaseUIEntityListMap(Type typeEntityClass, Type typeInterfaceClass, string strPageTitleResxKey, string strNewButtonResxKey, UserRoleEnumerator[] authorisedRoles, UIEntityListGridPropertyMap[] uiepmPropertyMaps, UIEntityListSearcheablePropertyMap[] uielspmSearcheablePropertyMaps, Func<UserEntity, List<BaseEntity>> funcEntityListPopulater)
        {
            TypeEntityClass = typeEntityClass;
            TypeInterfaceClass = typeInterfaceClass;
            StrPageTitleResxKey = strPageTitleResxKey;
            StrNewButtonResxKey = strNewButtonResxKey;
            AuthorisedRoles = authorisedRoles;
            UIEPMPropertyMaps = uiepmPropertyMaps;
            UIELSPMSearcheablePropertyMaps = uielspmSearcheablePropertyMaps;
            FuncEntityListPopulater = funcEntityListPopulater;

            if (GetUIEntityListMapByClassName(typeEntityClass.Name) == null)
                LstUIEMList.Add(this);
        }

        public static BaseUIEntityListMap GetUIEntityListMapByClassName(string strClassName)
        {
            return LstUIEMList.SingleOrDefault(x => x.TypeEntityClass.Name == strClassName);
        }
    }
}
