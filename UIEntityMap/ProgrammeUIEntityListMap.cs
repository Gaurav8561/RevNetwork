using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using TypeEnumerator;

namespace UIEntityMap
{
    public class ProgrammeUIEntityListMap : BaseUIEntityListMap
    {
        public static readonly ProgrammeUIEntityListMap EntityUIListMap
            = new ProgrammeUIEntityListMap(typeof(ProgrammeEntity),
                                            typeof(ProgrammeInterface),
                                            "titlePageProgrammeMaintainence",
                                            "btnNewProgrammeText",
                                            AdminRoleEnumerator.GetEnumList().ToArray(),
                                            new UIEntityListGridPropertyMap[]
                                            {
                                                new UIEntityListGridPropertyMap("StrProgrammeCode", "fieldLabelProgrammeCode", null, "StrProgrammeID"),
                                                new UIEntityListGridPropertyMap("StrProgrammeTitle", "fieldLabelProgrammeTitle", null, null),
                                                new UIEntityListGridPropertyMap("DecProgrammeCommission", "fieldLabelProgrammeCommission", "{0:C2}", null),
                                                new UIEntityListGridPropertyMap("StatusProgrammeStatus.StrDispText", "fieldLabelStatus", null, null)
                                            },
                                            new UIEntityListSearcheablePropertyMap[]
                                            {
                                                new UIEntityListSearcheablePropertyMap("StrProgrammeCode", "fieldLabelProgrammeCode"),
                                                new UIEntityListSearcheablePropertyMap("StrProgrammeTitle", "fieldLabelProgrammeTitle"),
                                                new UIEntityListSearcheablePropertyMap("StatusProgrammeStatus.StrDispText", "fieldLabelStatus")
                                            }, 
                                            new Func<UserEntity, List<BaseEntity>>(user => ProgrammeInterface.List().Cast<BaseEntity>().ToList()));

        private ProgrammeUIEntityListMap(Type typeEntityClass, Type typeInterfaceClass, string strPageTitleResxKey, string strNewButtonResxKey, UserRoleEnumerator[] authorisedRoles, UIEntityListGridPropertyMap[] uiepmPropertyMaps, UIEntityListSearcheablePropertyMap[] uielspmSearcheablePropertyMaps, Func<UserEntity, List<BaseEntity>> funcEntityListPopulater) : base(typeEntityClass, typeInterfaceClass, strPageTitleResxKey, strNewButtonResxKey, authorisedRoles, uiepmPropertyMaps, uielspmSearcheablePropertyMaps, funcEntityListPopulater)
        {
        }

    }
}
