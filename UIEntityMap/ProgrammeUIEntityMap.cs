using Entity;
using Newtonsoft.Json;
using System;
using TypeEnumerator;

namespace UIEntityMap
{
    public class ProgrammeUIEntityMap : BaseUIEntityMap
    {
        public static readonly ProgrammeUIEntityMap EntityUIMap
            = new ProgrammeUIEntityMap(typeof(ProgrammeEntity),
                                        typeof(ProgrammeInterface),
                                        "titlePageProgrammeMaintainence",
                                        AdminRoleEnumerator.GetEnumList().ToArray(),
                                        new UIEntityPropertyMap[]
                                        {
                                            new UIEntityPropertyMap("StrProgrammeCode", UIEntityPropertyMap.DataType.PLAIN_TEXT, "fieldLabelProgrammeCode", null,
                                                new UIEntityPropertyMap.PageModes[]
                                                {
                                                    UIEntityPropertyMap.PageModes.NEW,
                                                    UIEntityPropertyMap.PageModes.EDIT,
                                                    UIEntityPropertyMap.PageModes.VIEW
                                                },
                                                new UIFieldValidation[]
                                                {
                                                    UIFieldValidation.RequiredFieldValidation
                                                }),
                                            new UIEntityPropertyMap("StrProgrammeTitle", UIEntityPropertyMap.DataType.PLAIN_TEXT, "fieldLabelProgrammeTitle", null,
                                                new UIEntityPropertyMap.PageModes[]
                                                {
                                                    UIEntityPropertyMap.PageModes.NEW,
                                                    UIEntityPropertyMap.PageModes.EDIT,
                                                    UIEntityPropertyMap.PageModes.VIEW
                                                },
                                                new UIFieldValidation[]
                                                {
                                                    UIFieldValidation.RequiredFieldValidation
                                                }),
                                            new UIEntityPropertyMap("DecProgrammeCommission", UIEntityPropertyMap.DataType.DECIMAL, "fieldLabelProgrammeCommission", null,
                                                new UIEntityPropertyMap.PageModes[]
                                                {
                                                    UIEntityPropertyMap.PageModes.NEW,
                                                    UIEntityPropertyMap.PageModes.EDIT,
                                                    UIEntityPropertyMap.PageModes.VIEW
                                                },
                                                new UIFieldValidation[]
                                                {
                                                    UIFieldValidation.RequiredFieldValidation,
                                                    UIFieldValidation.NonNegativeDecimalFieldValidation
                                                }),
                                            new UIEntityPropertyMap("StatusProgrammeStatus", null, "fieldLabelStatus", UIEntityPropertyMap.InputModes.RADIO_BUTTON,
                                                new UIEntityPropertyMap.PageModes[]
                                                {
                                                    UIEntityPropertyMap.PageModes.EDIT,
                                                    UIEntityPropertyMap.PageModes.VIEW
                                                },
                                                null)
                                        }, new Func<string, BaseEntity>(x => JsonConvert.DeserializeObject<ProgrammeEntity>(x)));

        private ProgrammeUIEntityMap(Type typeEntityClass, Type typeInterfaceClass, string strPageTitleResxKey, UserRoleEnumerator[] authorisedRoles, UIEntityPropertyMap[] uiepmPropertyMaps, Func<string, BaseEntity> funcDeserialiser) : base(typeEntityClass, typeInterfaceClass, strPageTitleResxKey, authorisedRoles, uiepmPropertyMaps, funcDeserialiser)
        {
        }

    }
}
