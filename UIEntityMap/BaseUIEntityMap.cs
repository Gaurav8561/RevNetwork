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
    public class BaseUIEntityMap
    {
        public class UIEntityPropertyMap
        {
            public enum DataType
            {
                PLAIN_TEXT,
                PASSWORD,
                EMAIL,
                INT,
                DECIMAL,
                DATE
            }

            public enum PageModes
            {
                NEW,
                EDIT,
                VIEW
            }

            public enum InputModes
            {
               RADIO_BUTTON
            }

            public string StrPropertyName { get; private set; }
            public DataType? DtDataType { get; private set; }
            public string StrResxKey { get; private set; }
            public string StrLabelText { get { return ResxManager.ResourceManager.GetString(StrResxKey); } }
            public InputModes? IMInputMode { get; private set; }
            public PageModes[] AIMAvailableInModes { get; private set; }
            public UIFieldValidation[] UIFVValidations { get; private set; }

            internal UIEntityPropertyMap(string strPropertyName, DataType? dtDataType, string strResxKey, InputModes? imInputMode, PageModes[] aimAvailableInModes, UIFieldValidation[] uifvValidations)
            {
                StrPropertyName = strPropertyName;
                DtDataType = dtDataType;
                StrResxKey = strResxKey;
                IMInputMode = imInputMode;
                AIMAvailableInModes = aimAvailableInModes;
                UIFVValidations = uifvValidations;
            }
        }

        public static readonly Action EvaluateAllUIEntityMap = new Action(() => typeof(BaseUIEntityMap).Assembly.GetTypes().Where(x => typeof(BaseUIEntityMap).IsAssignableFrom(x) && x.Name != typeof(BaseUIEntityMap).Name).ToList().ForEach(x => x.GetField("EntityUIMap").GetValue(null)));

        private static readonly List<BaseUIEntityMap> LstUIEMList
                = new List<BaseUIEntityMap>();

        public Type TypeEntityClass { get; private set; }
        public Type TypeInterfaceClass { get; private set; }
        public string StrPageTitleResxKey { get; private set; }
        public string StrPageTitleDispText { get { return ResxManager.ResourceManager.GetString(StrPageTitleResxKey); } }
        public UserRoleEnumerator[] AuthorisedRoles { get; private set; }
        public UIEntityPropertyMap[] UIEPMPropertyMaps { get; private set; }

        public Func<string, BaseEntity> FuncDeserialiser { get; private set; }

        protected BaseUIEntityMap(Type typeEntityClass, Type typeInterfaceClass, string strPageTitleResxKey, UserRoleEnumerator[] authorisedRoles, UIEntityPropertyMap[] uiepmPropertyMaps, Func<string, BaseEntity> funcDeserialiser)
        {
            TypeEntityClass = typeEntityClass;
            TypeInterfaceClass = typeInterfaceClass;
            StrPageTitleResxKey = strPageTitleResxKey;
            AuthorisedRoles = authorisedRoles;
            UIEPMPropertyMaps = uiepmPropertyMaps;
            FuncDeserialiser = funcDeserialiser;

            if (GetUIEntityMapByClassName(typeEntityClass.Name) == null)
                LstUIEMList.Add(this);
        }

        public static BaseUIEntityMap GetUIEntityMapByClassName(string strClassName)
        {
            return LstUIEMList.SingleOrDefault(x => x.TypeEntityClass.Name == strClassName);
        }
    }
}
