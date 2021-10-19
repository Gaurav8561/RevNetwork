using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entity;
using Utility;
using System.Globalization;
using TypeEnumerator;
using System.Web.Security;
using General;
using Newtonsoft.Json;
using UIEntityMap;
using Security;

namespace RevNetwork
{
    public partial class GeneralUIList : System.Web.UI.Page
    {
        public string m_strPageTitle;
        public string m_linkLabelNew;

        public class TemplateGenerator : ITemplate 
        {
            private readonly ListItemType LITType;
            private readonly string StrPropertyName;
            private readonly string StrParameterPropertyName;
            private readonly string StrEntityClassName;

            public TemplateGenerator(ListItemType litType, string strPropertyName, string strParameterPropertyName, string strEntityClassName)
            {
                LITType = litType;
                StrPropertyName = strPropertyName;
                StrParameterPropertyName = strParameterPropertyName;
                StrEntityClassName = strEntityClassName;
            }

          
            void ITemplate.InstantiateIn(System.Web.UI.Control container)
            {
                switch (LITType)
                {
                    case ListItemType.Item:
                        HyperLink hyprLnk = new HyperLink();
                        hyprLnk.DataBinding += new EventHandler(HyprLnk_DataBinding);
                        container.Controls.Add(hyprLnk);
                        break;
                }
            }



            void HyprLnk_DataBinding(object sender, EventArgs e)
            {
                HyperLink hyprlnk = (HyperLink)sender;
                GridViewRow container = (GridViewRow)hyprlnk.NamingContainer;

                hyprlnk.Text = DataBinder.Eval(container.DataItem, StrPropertyName).ToString();
                hyprlnk.NavigateUrl = string.Format("/GeneralUIPage.aspx?{0}={1}", Constant.QUERY_STRING_NAME_PARAM, Encryption.EncryptToHex(JsonConvert.SerializeObject(new EntityUIParameter { StrEntityClassName = StrEntityClassName, StrParameter = DataBinder.Eval(container.DataItem, StrParameterPropertyName).ToString(), EUIMRequestMode = BaseUIEntityMap.UIEntityPropertyMap.PageModes.VIEW })));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (HttpContext.Current.Session["UserInfo"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
                    {
                        try
                        {
                            EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]));

                            if (!default(EntityUIParameter).Equals(parameter))
                            {
                                BaseUIEntityListMap uiMap = BaseUIEntityListMap.GetUIEntityListMapByClassName(parameter.StrEntityClassName);

                                if (!UserAccess.CheckRoleAuthorisation(uiMap.AuthorisedRoles.ToList()))
                                    Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

                                m_linkLabelNew = uiMap.StrNewButtonDispText;

                                LoadGrid(uiMap);
                            }
                        }
                        catch (JsonReaderException)
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
        }



        private void LoadGrid(BaseUIEntityListMap uiMap)
        {
            m_strPageTitle = uiMap.StrPageTitleDispText;

            if (uiMap.UIELSPMSearcheablePropertyMaps != null && uiMap.UIELSPMSearcheablePropertyMaps.Length > 0)
            {
                ddlFilterBy.Items.Clear();

                ddlFilterBy.Items.AddRange(
                    (new ListItem[][]
                    {
                        new ListItem[] { new ListItem(Resources.Resources.dropDownTextFilterBy, string.Empty) },
                        uiMap.UIELSPMSearcheablePropertyMaps.Select(property => new ListItem(property.StrLabelText, property.StrPropertyName) ).ToArray()
                    }).SelectMany(x => x).ToArray());

                ddlFilterBy.SelectedIndex = 0;
                DivSearchGroup.Visible = true;
            }
            else
            {
                DivSearchGroup.Visible = false;
            }

            gvList.Columns.Clear();

            uiMap.UIEPMPropertyMaps.ToList().ForEach(property => gvList.Columns.Add(
                string.IsNullOrEmpty(property.StrParameterPropertyName) ?
                        (DataControlField)new BoundField
                        {
                            HeaderText = property.StrLabelText,
                            DataField = property.StrPropertyName,
                            DataFormatString = string.IsNullOrEmpty(property.StrDisplayFormat) ? string.Empty : property.StrDisplayFormat
                        }
                        :
                        (DataControlField)new TemplateField
                        {
                            HeaderText = property.StrLabelText,
                            ItemTemplate = new TemplateGenerator(ListItemType.Item, property.StrPropertyName, property.StrParameterPropertyName, uiMap.TypeEntityClass.Name)
                        }));

            List<BaseEntity> list = uiMap.FuncEntityListPopulater(null);

            if (!string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(ddlFilterBy.SelectedValue))
                list = list.Where(x => (new CultureInfo(string.Empty)).CompareInfo.IndexOf(Common.FollowPropertyPath(x, ddlFilterBy.SelectedValue).ToString(), txtSearch.Text, CompareOptions.IgnoreCase) >= 0).ToList();

            gvList.DataSource = list;
            gvList.DataBind();
        }



        protected void gvList_PreRender(object sender, EventArgs e)
        {
            if(gvList.HeaderRow != null)
                gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }



        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;

            if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
            {
                EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]));

                if (!default(EntityUIParameter).Equals(parameter))
                {
                    LoadGrid(BaseUIEntityListMap.GetUIEntityListMapByClassName(parameter.StrEntityClassName));
                }
            }
        }



        protected void LbtNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
            {
                EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]));

                if (!default(EntityUIParameter).Equals(parameter))
                {
                    Response.Redirect(string.Format("/GeneralUIPage.aspx?{0}={1}", Constant.QUERY_STRING_NAME_PARAM, Utility.Encryption.EncryptToHex(JsonConvert.SerializeObject(new General.EntityUIParameter { StrEntityClassName = parameter.StrEntityClassName, EUIMRequestMode = BaseUIEntityMap.UIEntityPropertyMap.PageModes.NEW }))));
                }
            }
        }



        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]))
            {
                EntityUIParameter parameter = JsonConvert.DeserializeObject<EntityUIParameter>(Encryption.DecryptFromHex(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM]));

                if (!default(EntityUIParameter).Equals(parameter))
                {
                    LoadGrid(BaseUIEntityListMap.GetUIEntityListMapByClassName(parameter.StrEntityClassName));
                }
            }
        }
    }
}