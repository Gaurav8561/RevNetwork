using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TypeEnumerator;
using Utility;
using Entity;
using System.Drawing;
using System.Resources;
using System.Web.Security;
using Security;
using System.Globalization;
using System.Collections;
using System.Reflection;

namespace RevNetwork
{
    public partial class config : System.Web.UI.Page
    {
        private static readonly List<UserRoleEnumerator> m_LstAuthorisedRoles
            = new List<UserRoleEnumerator>(AdminRoleEnumerator.GetEnumList());

        public string m_strPageTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserAccess.CheckRoleAuthorisation(m_LstAuthorisedRoles))
                Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

            if (HttpContext.Current.Session["UserInfo"] != null)
            {
                if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
                {
                    if (Assembly.GetAssembly(typeof(ConfigurationNameEnumerator)).GetTypes().Any(x => x.AssemblyQualifiedName == Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM])))
                    {
                        Type configType = Type.GetType(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]));

                        m_strPageTitle = configType.GetProperty("StrConfigPageTitleDispText").GetValue(null) as string;

                        foreach (ConfigurationNameEnumerator configName in ((IList)configType.GetMethod("GetEnumList").Invoke(null, null)).Cast<ConfigurationNameEnumerator>())
                        {
                            TextBoxMode txtMode = default;
                            switch (configName.DtDataType)
                            {
                                case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_STRING:
                                    txtMode = TextBoxMode.SingleLine;
                                    break;
                                case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_INT:
                                case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DECIMAL:
                                    txtMode = TextBoxMode.Number;
                                    break;
                                case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DATE:
                                    txtMode = TextBoxMode.Date;
                                    break;
                                case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_PASSWORD:
                                    txtMode = TextBoxMode.Password;
                                    break;
                            }
                            ConfigurationEntity config = ConfigurationInterface.GetConfigurationByConfigurationName(configName.StrKey);

                            Panel rowPanel = new Panel { ID = string.Format("DivRow{0}", configName.StrKey), CssClass = "row" };

                            Panel blockPanel = new Panel { ID = string.Format("DivBlock{0}", configName.StrKey), CssClass = "col-md-12 mb-3" };

                            Label lbl = new Label
                            {
                                ID = string.Format("Lbl{0}", configName.StrKey),
                                Text = configName.StrDispText
                            };

                            string value;
                            if (configName.FuncParser != null)
                            {
                                switch (configName.DtDataType)
                                {
                                    case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DATE:
                                        value = ((DateTime)configName.FuncParser(config.StrConfigurationValue)).ToString("yyyy-MM-dd");
                                        break;
                                    case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_INT:
                                        value = ((int)configName.FuncParser(config.StrConfigurationValue)).ToString();
                                        break;
                                    case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DECIMAL:
                                        value = ((decimal)configName.FuncParser(config.StrConfigurationValue)).ToString();
                                        break;
                                    case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_BOOLEAN:
                                        value = ((bool)configName.FuncParser(config.StrConfigurationValue)).ToString();
                                        break;
                                    default:
                                        value = configName.FuncParser(config.StrConfigurationValue).ToString();
                                        break;
                                }
                            }
                            else
                            {
                                value = config.StrConfigurationValue;
                            }

                            Control inputControl;

                            switch (configName.DtDataType)
                            {
                                case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_BOOLEAN:
                                    inputControl = new CheckBox
                                    {
                                        ID = string.Format("Chk{0}", configName.StrKey),
                                        Text = configName.StrDispText,
                                        Checked = bool.TryParse(value, out bool output) && output,
                                        CssClass = "form-control"
                                    };
                                    break;
                                default:
                                    inputControl = new TextBox
                                    {
                                        ID = string.Format("Txt{0}", configName.StrKey),
                                        Text = value,
                                        CssClass = "form-control",
                                        TextMode = txtMode
                                    };
                                    break;
                            }

                            blockPanel.Controls.Add(new Literal() { Text = "<label>" });
                            blockPanel.Controls.Add(lbl);
                            blockPanel.Controls.Add(new Literal() { Text = "</label>" });
                            blockPanel.Controls.Add(inputControl);

                            rowPanel.Controls.Add(blockPanel);

                            pnlConfig.Controls.Add(rowPanel);
                        }
                    }
                    else
                    {
                        Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);
                    }
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (ConfigurationNameEnumerator configName in ((IList)Type.GetType(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM])).GetMethod("GetEnumList").Invoke(null, null)).Cast<ConfigurationNameEnumerator>())
            {
                string value;

                if (ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_BOOLEAN.Equals(configName.DtDataType))
                    value = (pnlConfig.FindControl(string.Format("DivRow{0}", configName.StrKey)).FindControl(string.Format("DivBlock{0}", configName.StrKey)).FindControl(string.Format("Chk{0}", configName.StrKey)) as CheckBox).Checked.ToString();
                else
                    value = (pnlConfig.FindControl(string.Format("DivRow{0}", configName.StrKey)).FindControl(string.Format("DivBlock{0}", configName.StrKey)).FindControl(string.Format("Txt{0}", configName.StrKey)) as TextBox).Text;

                if (ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_PASSWORD.Equals(configName.DtDataType) && !string.IsNullOrWhiteSpace(value))
                {
                    value = Encryption.Encrypt(value);
                }

                bool isValid = true;

                if (string.IsNullOrWhiteSpace(value) && !ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_PASSWORD.Equals(configName.DtDataType))
                {
                    isValid = false;
                    (pnlConfig.FindControl(string.Format("DivRow{0}", configName.StrKey)).FindControl(string.Format("DivBlock{0}", configName.StrKey)).FindControl(string.Format("Lbl{0}", configName.StrKey)) as Label).ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    switch (configName.DtDataType)
                    {
                        case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_INT:
                            isValid = int.TryParse(value, out _);
                            break;
                        case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DECIMAL:
                            isValid = decimal.TryParse(value, out _);
                            break;
                        case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_BOOLEAN:
                            isValid = bool.TryParse(value, out _);
                            break;
                        case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DATE:
                            isValid = DateTime.TryParse(value, out _);
                            break;
                    }

                    if (!isValid)
                    {
                        (pnlConfig.FindControl(string.Format("DivRow{0}", configName.StrKey)).FindControl(string.Format("DivBlock{0}", configName.StrKey)).FindControl(string.Format("Lbl{0}", configName.StrKey)) as Label).ForeColor = System.Drawing.Color.Red;
                    }
                }
                if (isValid)
                {
                    ConfigurationEntity config = ConfigurationInterface.GetConfigurationByConfigurationName(configName.StrKey);

                    if (configName.FuncFormatter != null)
                    {
                        switch (configName.DtDataType)
                        {
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DATE:
                                config.StrConfigurationValue = configName.FuncFormatter(DateTime.Parse(value.Trim()));
                                break;
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_INT:
                                config.StrConfigurationValue = configName.FuncFormatter(int.Parse(value.Trim()));
                                break;
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DECIMAL:
                                config.StrConfigurationValue = configName.FuncFormatter(decimal.Parse(value.Trim()));
                                break;
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_BOOLEAN:
                                config.StrConfigurationValue = configName.FuncFormatter(bool.Parse(value.Trim()));
                                break;
                            default:
                                config.StrConfigurationValue = configName.FuncFormatter(value.Trim());
                                break;
                        }
                    }
                    else
                    {
                        config.StrConfigurationValue = value.Trim();
                    }

                    ConfigurationInterface.UpdateConfiguration(config);
                }
            }
        }
    }
}