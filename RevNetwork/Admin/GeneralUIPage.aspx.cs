using Entity;
using General;
using Newtonsoft.Json;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeEnumerator;
using UIEntityMap;
using Utility;

namespace RevNetwork
{
    public partial class GeneralUIPage : System.Web.UI.Page
    {
        public string m_strPageTitle;
        public BaseUIEntityMap.UIEntityPropertyMap.PageModes m_EUIMPageMode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserInfo"] != null)
            {
                m_strPageTitle = string.Empty;
                m_EUIMPageMode = default;

                if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
                {
                    EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]));

                    if (!default(EntityUIParameter).Equals(parameter))
                    {
                        try
                        {
                            BaseUIEntityMap uiMap = BaseUIEntityMap.GetUIEntityMapByClassName(parameter.StrEntityClassName);

                            if (!UserAccess.CheckRoleAuthorisation(uiMap.AuthorisedRoles.ToList()))
                                Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

                            m_strPageTitle = uiMap.StrPageTitleDispText;
                            m_EUIMPageMode = parameter.EUIMRequestMode;
                            BtnSubmit.DataBind();
                            BtnEdit.DataBind();
                            BtnCancel.DataBind();

                            BaseEntity entity = null;

                            if (BaseUIEntityMap.UIEntityPropertyMap.PageModes.NEW == parameter.EUIMRequestMode)
                                entity = (BaseEntity)typeof(BaseEntity).Assembly.GetTypes().Single(x => x.Name == parameter.StrEntityClassName).GetConstructor(new Type[] { }).Invoke(new object[] { });
                            else if ((new BaseUIEntityMap.UIEntityPropertyMap.PageModes[] { BaseUIEntityMap.UIEntityPropertyMap.PageModes.VIEW, BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT }).Contains(parameter.EUIMRequestMode))
                                entity = (BaseEntity)uiMap.TypeInterfaceClass.GetMethod("GetByPrimaryKey", new Type[] { typeof(string) }).Invoke(null, new object[] { parameter.StrParameter });

                            foreach (BaseUIEntityMap.UIEntityPropertyMap property in uiMap.UIEPMPropertyMaps)
                            {
                                if (property.AIMAvailableInModes.Contains(parameter.EUIMRequestMode))
                                {
                                    Panel rowPanel = new Panel { ID = string.Format("DivRow{0}", property.StrPropertyName), CssClass = "row" };

                                    Panel blockPanel = new Panel { ID = string.Format("DivBlock{0}", property.StrPropertyName), CssClass = "col-md-12 mb-3" };

                                    Label label = new Label
                                    {
                                        ID = string.Format("Lbl{0}", property.StrPropertyName),
                                        Text = property.StrLabelText
                                    };

                                    Control inputControl = null;

                                    if ((new Type[] { typeof(string), typeof(decimal?), typeof(int?), typeof(DateTime?) }).Any(x => x.IsAssignableFrom(Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType)))
                                    {
                                        if ((new BaseUIEntityMap.UIEntityPropertyMap.PageModes[] { BaseUIEntityMap.UIEntityPropertyMap.PageModes.NEW, BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT }).Contains(parameter.EUIMRequestMode))
                                        {
                                            TextBoxMode txtMode = default;
                                            switch (property.DtDataType)
                                            {
                                                case BaseUIEntityMap.UIEntityPropertyMap.DataType.PLAIN_TEXT:
                                                    txtMode = TextBoxMode.SingleLine;
                                                    break;
                                                case BaseUIEntityMap.UIEntityPropertyMap.DataType.INT:
                                                case BaseUIEntityMap.UIEntityPropertyMap.DataType.DECIMAL:
                                                    txtMode = TextBoxMode.Number;
                                                    break;
                                                case BaseUIEntityMap.UIEntityPropertyMap.DataType.DATE:
                                                    txtMode = TextBoxMode.Date;
                                                    break;
                                                case BaseUIEntityMap.UIEntityPropertyMap.DataType.PASSWORD:
                                                    txtMode = TextBoxMode.Password;
                                                    break;
                                            }

                                            inputControl = new TextBox
                                            {
                                                ID = string.Format("Txt{0}", property.StrPropertyName),
                                                Text = BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT == parameter.EUIMRequestMode ? Common.GetPropertyByPath(entity, property.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, property.StrPropertyName)).ToString() : string.Empty,
                                                CssClass = "form-control",
                                                TextMode = txtMode
                                            };
                                        }
                                        else if (BaseUIEntityMap.UIEntityPropertyMap.PageModes.VIEW == parameter.EUIMRequestMode)
                                        {
                                            inputControl = new TextBox
                                            {
                                                ID = string.Format("Txt{0}", property.StrPropertyName),
                                                Text = Common.GetPropertyByPath(entity, property.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, property.StrPropertyName)).ToString(),
                                                CssClass = "form-control",
                                                ReadOnly = true
                                            };
                                        }
                                    }
                                    else if (typeof(bool).IsAssignableFrom(Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType))
                                    {
                                        inputControl = new CheckBox
                                        {
                                            ID = string.Format("Chk{0}", property.StrPropertyName),
                                            Text = property.StrLabelText,
                                            Checked = bool.TryParse(Common.GetPropertyByPath(entity, property.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, property.StrPropertyName)).ToString(), out bool output) && output,
                                            CssClass = "form-control"
                                        };
                                    }
                                    else if (typeof(BaseEnumerator).IsAssignableFrom(entity.GetType().GetProperty(property.StrPropertyName).PropertyType))
                                    {
                                        if ((new BaseUIEntityMap.UIEntityPropertyMap.PageModes[] { BaseUIEntityMap.UIEntityPropertyMap.PageModes.NEW, BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT }).Contains(parameter.EUIMRequestMode))
                                        {
                                            if (property.IMInputMode == null)
                                                inputControl = new DropDownList
                                                {
                                                    ID = string.Format("Ddl{0}", property.StrPropertyName),
                                                    CssClass = "form-control"
                                                };
                                            else if (property.IMInputMode == BaseUIEntityMap.UIEntityPropertyMap.InputModes.RADIO_BUTTON)
                                                inputControl = new RadioButtonList
                                                {
                                                    ID = string.Format("Rbl{0}", property.StrPropertyName),
                                                    CssClass = "rbl"
                                                };

                                            ((ListControl)inputControl).DataSource = typeof(BaseEnumerator).Assembly.GetTypes().Single(x => x.Name == Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType.Name).GetMethod("GetEnumList", new Type[] { }).Invoke(null, null);
                                            ((ListControl)inputControl).DataTextField = "StrDispText";
                                            ((ListControl)inputControl).DataValueField = "StrKey";
                                            if (BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT == parameter.EUIMRequestMode)
                                                ((ListControl)inputControl).SelectedValue = ((BaseEnumerator)Common.GetPropertyByPath(entity, property.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, property.StrPropertyName))).StrKey;
                                            ((ListControl)inputControl).DataBind();
                                        }
                                        else if (BaseUIEntityMap.UIEntityPropertyMap.PageModes.VIEW == parameter.EUIMRequestMode)
                                        {
                                            inputControl = new TextBox
                                            {
                                                ID = string.Format("Txt{0}", property.StrPropertyName),
                                                Text = ((BaseEnumerator)Common.GetPropertyByPath(entity, property.StrPropertyName).GetValue(Common.GetPropertyInstanceByPath(entity, property.StrPropertyName))).StrDispText,
                                                CssClass = "form-control",
                                                ReadOnly = true
                                            };
                                        }
                                    }

                                    blockPanel.Controls.Add(new Literal() { Text = "<label>" });
                                    blockPanel.Controls.Add(label);
                                    blockPanel.Controls.Add(new Literal() { Text = "</label>" });
                                    blockPanel.Controls.Add(inputControl);

                                    rowPanel.Controls.Add(blockPanel);

                                    pnlContent.Controls.Add(rowPanel);
                                }
                            }
                        }
                        catch (JsonReaderException)
                        {
                            Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);
                        }
                    }
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DivErrorDisplay.Visible = false;
            LblErrorDisplay.Text = string.Empty;

            List<UIFieldValidation.UIFieldValidationResult> lstValidationResults = new List<UIFieldValidation.UIFieldValidationResult>();

            if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
            {
                try
                {
                    EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM])));

                    if (!default(EntityUIParameter).Equals(parameter))
                    {
                        BaseUIEntityMap uiMap = BaseUIEntityMap.GetUIEntityMapByClassName(parameter.StrEntityClassName);

                        if (!UserAccess.CheckRoleAuthorisation(uiMap.AuthorisedRoles.ToList()))
                            Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

                        m_EUIMPageMode = parameter.EUIMRequestMode;
                        m_strPageTitle = uiMap.StrPageTitleDispText;
                        BtnSubmit.DataBind();
                        BtnEdit.DataBind();
                        BtnCancel.DataBind();

                        BaseEntity entity = null;

                        if (BaseUIEntityMap.UIEntityPropertyMap.PageModes.NEW == parameter.EUIMRequestMode)
                            entity = (BaseEntity)typeof(BaseEntity).Assembly.GetTypes().Single(x => x.Name == parameter.StrEntityClassName).GetConstructor(new Type[] { }).Invoke(new object[] { });
                        else if ((new BaseUIEntityMap.UIEntityPropertyMap.PageModes[] { BaseUIEntityMap.UIEntityPropertyMap.PageModes.VIEW, BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT }).Contains(parameter.EUIMRequestMode))
                            entity = (BaseEntity)uiMap.TypeInterfaceClass.GetMethod("GetByPrimaryKey", new Type[] { typeof(string) }).Invoke(null, new object[] { parameter.StrParameter });

                        foreach (BaseUIEntityMap.UIEntityPropertyMap property in uiMap.UIEPMPropertyMaps)
                        {
                            if (property.AIMAvailableInModes.Contains(parameter.EUIMRequestMode))
                            {
                                (pnlContent.FindControl(string.Format("DivRow{0}", property.StrPropertyName)).FindControl(string.Format("DivBlock{0}", property.StrPropertyName)).FindControl(string.Format("Lbl{0}", property.StrPropertyName)) as Label).ForeColor = System.Drawing.Color.Black;

                                string value = string.Empty;

                                if ((new Type[] { typeof(string), typeof(decimal?), typeof(int?), typeof(DateTime?) }).Any(x => x.IsAssignableFrom(Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType)))
                                {
                                    value = (pnlContent.FindControl(string.Format("DivRow{0}", property.StrPropertyName)).FindControl(string.Format("DivBlock{0}", property.StrPropertyName)).FindControl(string.Format("Txt{0}", property.StrPropertyName)) as TextBox).Text;
                                }
                                else if (typeof(bool).IsAssignableFrom(Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType))
                                {
                                    value = (pnlContent.FindControl(string.Format("DivRow{0}", property.StrPropertyName)).FindControl(string.Format("DivBlock{0}", property.StrPropertyName)).FindControl(string.Format("Chk{0}", property.StrPropertyName)) as CheckBox).Checked.ToString();
                                }
                                else if (typeof(BaseEnumerator).IsAssignableFrom(entity.GetType().GetProperty(property.StrPropertyName).PropertyType))
                                {
                                    if (property.IMInputMode == null)
                                    {
                                        value = (pnlContent.FindControl(string.Format("DivRow{0}", property.StrPropertyName)).FindControl(string.Format("DivBlock{0}", property.StrPropertyName)).FindControl(string.Format("Ddl{0}", property.StrPropertyName)) as DropDownList).SelectedValue.ToString();
                                    }
                                    else if (property.IMInputMode == BaseUIEntityMap.UIEntityPropertyMap.InputModes.RADIO_BUTTON)
                                    {
                                        value = (pnlContent.FindControl(string.Format("DivRow{0}", property.StrPropertyName)).FindControl(string.Format("DivBlock{0}", property.StrPropertyName)).FindControl(string.Format("Rbl{0}", property.StrPropertyName)) as RadioButtonList).SelectedValue.ToString();
                                    }
                                }

                                UIFieldValidation.UIFieldValidationResult[] validationResult = property.UIFVValidations != null ? property.UIFVValidations.Select(x => x.Validate(property.StrPropertyName, new object[] { value })).ToArray() : new UIFieldValidation.UIFieldValidationResult[] { };

                                if (validationResult.Any(x => x.ReturnCode != UIFieldValidation.ReturnCodes.INPUT_VALID))
                                {
                                    lstValidationResults.AddRange(validationResult);
                                }
                                else
                                {
                                    if (typeof(string).IsAssignableFrom(Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType))
                                    {
                                        Common.GetPropertyByPath(entity, property.StrPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, property.StrPropertyName), value);
                                    }
                                    else if (Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType.IsValueType)
                                    {
                                        object[] param = new object[] { value, null };

                                        Common.GetPropertyByPath(entity, property.StrPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, property.StrPropertyName), ((bool)(Nullable.GetUnderlyingType(Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType) ?? Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType).GetMethod("TryParse", new Type[] { typeof(string), (Nullable.GetUnderlyingType(Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType) ?? Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType).MakeByRefType() }).Invoke(null, param)) ? param[1] : null);
                                    }
                                    else if (typeof(BaseEnumerator).IsAssignableFrom(entity.GetType().GetProperty(property.StrPropertyName).PropertyType))
                                    {
                                        Common.GetPropertyByPath(entity, property.StrPropertyName).SetValue(Common.GetPropertyInstanceByPath(entity, property.StrPropertyName), Common.GetPropertyByPath(entity, property.StrPropertyName).PropertyType.GetMethod("GetEnumByKey").Invoke(null, new object[] { value }));
                                    }
                                }
                            }
                        }

                        if (lstValidationResults.Any(x => x.ReturnCode != UIFieldValidation.ReturnCodes.INPUT_VALID))
                        {
                            LblErrorDisplay.Text = Resources.Resources.errorRequiredCheckErrorBeforeProceed + ":<br /><br />";

                            if (lstValidationResults.Any(x => x.ReturnCode == UIFieldValidation.ReturnCodes.REQUIRED_FIELD_EMPTY))
                            {
                                LblErrorDisplay.Text += UIFieldValidation.RequiredFieldValidation.StrErrorPromptDispText + ":<br />" + string.Join("", lstValidationResults.Where(x => x.ReturnCode == UIFieldValidation.ReturnCodes.REQUIRED_FIELD_EMPTY).Select(x => string.Format("- {0}<br /> ", uiMap.UIEPMPropertyMaps.Single(y => y.StrPropertyName == x.StrPropertyName).StrLabelText)).ToArray()) + "<br />";

                                lstValidationResults.Where(x => x.ReturnCode == UIFieldValidation.ReturnCodes.REQUIRED_FIELD_EMPTY).ToList().ForEach(x => (pnlContent.FindControl(string.Format("DivRow{0}", x.StrPropertyName)).FindControl(string.Format("DivBlock{0}", x.StrPropertyName)).FindControl(string.Format("Lbl{0}", x.StrPropertyName)) as Label).ForeColor = System.Drawing.Color.Red);
                            }

                            if (lstValidationResults.Any(x => typeof(UIFieldValidation).GetFields().Where(v => typeof(UIFieldValidation).IsAssignableFrom(v.FieldType) && ((UIFieldValidation)v.GetValue(null)).VCValidationClass == UIFieldValidation.ValidationClass.FORMAT_VALIDATION).Select(v => ((UIFieldValidation)v.GetValue(null)).InvalidReturnCode).Contains(x.ReturnCode) && !lstValidationResults.Where(y => y.ReturnCode == UIFieldValidation.ReturnCodes.REQUIRED_FIELD_EMPTY).Any(y => y.StrPropertyName == x.StrPropertyName)))
                            {
                                LblErrorDisplay.Text += string.Join("", lstValidationResults.Where(x => typeof(UIFieldValidation).GetFields().Where(v => typeof(UIFieldValidation).IsAssignableFrom(v.FieldType) && ((UIFieldValidation)v.GetValue(null)).VCValidationClass == UIFieldValidation.ValidationClass.FORMAT_VALIDATION).Select(v => ((UIFieldValidation)v.GetValue(null)).InvalidReturnCode).Contains(x.ReturnCode) && !lstValidationResults.Where(y => y.ReturnCode == UIFieldValidation.ReturnCodes.REQUIRED_FIELD_EMPTY).Any(y => y.StrPropertyName == x.StrPropertyName)).Select(x => string.Format("- {0}<br />", string.Format(((UIFieldValidation)typeof(UIFieldValidation).GetFields().Where(v => typeof(UIFieldValidation).IsAssignableFrom(v.FieldType)).Single(v => typeof(UIFieldValidation).GetFields().Where(v1 => typeof(UIFieldValidation).IsAssignableFrom(v1.FieldType) && ((UIFieldValidation)v.GetValue(null)).VCValidationClass == UIFieldValidation.ValidationClass.FORMAT_VALIDATION).Select(v1 => ((UIFieldValidation)v1.GetValue(null)).InvalidReturnCode).Contains(((UIFieldValidation)v.GetValue(null)).InvalidReturnCode)).GetValue(null)).StrErrorPromptDispText, x.ObjInputs[0], uiMap.UIEPMPropertyMaps.Single(y => y.StrPropertyName == x.StrPropertyName).StrLabelText))).ToArray());

                                lstValidationResults.Where(x => typeof(UIFieldValidation).GetFields().Where(v => typeof(UIFieldValidation).IsAssignableFrom(v.FieldType) && ((UIFieldValidation)v.GetValue(null)).VCValidationClass == UIFieldValidation.ValidationClass.FORMAT_VALIDATION).Select(v => ((UIFieldValidation)v.GetValue(null)).InvalidReturnCode).Contains(x.ReturnCode) && !lstValidationResults.Where(y => y.ReturnCode == UIFieldValidation.ReturnCodes.REQUIRED_FIELD_EMPTY).Any(y => y.StrPropertyName == x.StrPropertyName)).ToList().ForEach(x => (pnlContent.FindControl(string.Format("DivRow{0}", x.StrPropertyName)).FindControl(string.Format("DivBlock{0}", x.StrPropertyName)).FindControl(string.Format("Lbl{0}", x.StrPropertyName)) as Label).ForeColor = System.Drawing.Color.Red);
                            }

                            LblErrorDisplay.Text += "<br />";
                            DivErrorDisplay.Visible = true;
                        }
                        else
                        {
                            if (BaseUIEntityMap.UIEntityPropertyMap.PageModes.NEW == parameter.EUIMRequestMode)
                            {
                                entity = (BaseEntity)uiMap.TypeInterfaceClass.GetMethod("New", new Type[] { entity.GetType() }).Invoke(null, new object[] { entity });
                                Response.Redirect(string.Format("/GeneralUIList.aspx?{0}={1}", Constant.QUERY_STRING_NAME_PARAM, Encryption.EncryptToHex(JsonConvert.SerializeObject(new EntityUIParameter { StrEntityClassName = parameter.StrEntityClassName }))));
                            }
                            else if (BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT == parameter.EUIMRequestMode)
                            {
                                entity = (BaseEntity)uiMap.TypeInterfaceClass.GetMethod("Update", new Type[] { entity.GetType() }).Invoke(null, new object[] { entity });
                                Response.Redirect(string.Format("/GeneralUIPage.aspx?{0}={1}", Constant.QUERY_STRING_NAME_PARAM, Encryption.EncryptToHex(JsonConvert.SerializeObject(new EntityUIParameter { StrEntityClassName = parameter.StrEntityClassName, StrParameter = parameter.StrParameter, EUIMRequestMode = BaseUIEntityMap.UIEntityPropertyMap.PageModes.VIEW }))));
                            }
                        }
                    }
                }
                catch (JsonReaderException)
                {
                    Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);
                }
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            DivErrorDisplay.Visible = false;
            LblErrorDisplay.Text = string.Empty;

            if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
            {
                try
                {
                    EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM])));

                    if (!default(EntityUIParameter).Equals(parameter))
                    {
                        BaseUIEntityMap uiMap = BaseUIEntityMap.GetUIEntityMapByClassName(parameter.StrEntityClassName);

                        if (!UserAccess.CheckRoleAuthorisation(uiMap.AuthorisedRoles.ToList()))
                            Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

                        m_EUIMPageMode = parameter.EUIMRequestMode;
                        m_strPageTitle = uiMap.StrPageTitleDispText;
                        BtnSubmit.DataBind();
                        BtnEdit.DataBind();
                        BtnCancel.DataBind();

                        Response.Redirect(string.Format("/GeneralUIPage.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Encryption.EncryptToHex(JsonConvert.SerializeObject(new General.EntityUIParameter { StrEntityClassName = parameter.StrEntityClassName, StrParameter = parameter.StrParameter, EUIMRequestMode = BaseUIEntityMap.UIEntityPropertyMap.PageModes.EDIT }))));
                    }

                }
                catch (JsonReaderException)
                {
                    Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            DivErrorDisplay.Visible = false;
            LblErrorDisplay.Text = string.Empty;

            if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
            {
                try
                {
                    EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM])));

                    if (!default(EntityUIParameter).Equals(parameter))
                    {
                        BaseUIEntityMap uiMap = BaseUIEntityMap.GetUIEntityMapByClassName(parameter.StrEntityClassName);

                        if (!UserAccess.CheckRoleAuthorisation(uiMap.AuthorisedRoles.ToList()))
                            Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

                        m_EUIMPageMode = parameter.EUIMRequestMode;
                        m_strPageTitle = uiMap.StrPageTitleDispText;
                        BtnSubmit.DataBind();
                        BtnEdit.DataBind();
                        BtnCancel.DataBind();

                        Response.Redirect(string.Format("/GeneralUIPage.aspx?{0}={1}", Utility.Constant.QUERY_STRING_NAME_PARAM, Utility.Encryption.EncryptToHex(JsonConvert.SerializeObject(new General.EntityUIParameter { StrEntityClassName = parameter.StrEntityClassName, StrParameter = parameter.StrParameter, EUIMRequestMode = BaseUIEntityMap.UIEntityPropertyMap.PageModes.VIEW }))));
                    }

                }
                catch (JsonReaderException)
                {
                    Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);
                }
            }
        }

        protected void LbtBackToListing_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
            {
                try
                {
                    EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM])));

                    if (!default(EntityUIParameter).Equals(parameter))
                    {
                        BaseUIEntityMap uiMap = BaseUIEntityMap.GetUIEntityMapByClassName(parameter.StrEntityClassName);

                        if (!UserAccess.CheckRoleAuthorisation(uiMap.AuthorisedRoles.ToList()))
                            Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

                        Response.Redirect(string.Format("/GeneralUIList.aspx?{0}={1}", Constant.QUERY_STRING_NAME_PARAM, Encryption.EncryptToHex(JsonConvert.SerializeObject(new EntityUIParameter { StrEntityClassName = parameter.StrEntityClassName }))));
                    }
                }
                catch (JsonReaderException)
                {
                    Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);
                }
            }
        }
    }
}