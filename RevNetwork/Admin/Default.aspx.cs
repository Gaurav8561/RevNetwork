using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Utility;
using Security;
using System.Web.Security;
using TypeEnumerator;
using System.Reflection;
using Entity;
using Newtonsoft.Json;
using General;
using UIEntityMap;

namespace RevNetwork
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly List<UserRoleEnumerator> m_LstAuthorisedRoles
             = new List<UserRoleEnumerator>(AdminRoleEnumerator.GetEnumList());

        public UserInfo m_usriCurrent = new UserInfo();

        protected void Page_Init(object sender, EventArgs e)
        {
            m_usriCurrent = UserInfo.GetUserInfo();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserAccess.CheckRoleAuthorisation(m_LstAuthorisedRoles))
            {
                Response.Redirect("Dashboard.aspx");
            }

            //var s = ProgrammeInterface.GetByPrimaryKey("PROG-2020-06-29-103518522-949b5a04-a779-4503-a385-57435ecf5011");
            //var jo = JsonConvert.SerializeObject(new JsonGeneralObjectParameter { TypeValueType = typeof(ProgrammeEntity), ObjValue = ProgrammeInterface.GetProgrammeByPrimaryKey("PROG-2020-06-29-103518522-949b5a04-a779-4503-a385-57435ecf5011") });
            //var jo = JsonConvert.SerializeObject(ProgrammeInterface.GetByPrimaryKey("PROG-2020-06-29-103518522-949b5a04-a779-4503-a385-57435ecf5011"));
            //var o = ProgrammeUIEntityMap.EntityUIMap.FuncDeserialiser(jo);
            //var parameterTypes = new[] { typeof(ProgrammeEntity) };
            //    var deserializer = typeof(JsonConvert).GetMethods(BindingFlags.Public | BindingFlags.Static)
            //.Where(i => i.Name.Equals("DeserializeObject", StringComparison.InvariantCulture))
            //.Where(i => i.IsGenericMethod)
            //.Where(i => i.GetParameters().Select(a => a.ParameterType).SequenceEqual(parameterTypes))
            //.Single();
            //    var result = deserializer.Invoke(null, new object[] { jo });
        }



        protected void LnkViewFile_Click(object sender, EventArgs e)
        {
            //Response.ContentType = "Application/pdf";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=UserGuide.pdf");
            //Response.TransmitFile(Server.MapPath("~/Resource/Agent_User_Guide_Student_Referral.pdf"));
            //Response.End();
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserAccess.AuthenticateLogin(txtUsername.Text, txtPassword.Text);
            try
            {
                bool bAuthenticated = false;

                bAuthenticated = UserAccess.AuthenticateLogin(txtUsername.Text, txtPassword.Text);

                if (bAuthenticated)
                {
                    FormsAuthentication.SetAuthCookie(UserInfo.GetUserInfo().Username, true);
                    Response.Redirect(!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? Request.QueryString["ReturnUrl"] : UserAccess.DEFAULT_LANDING_PAGE);
                }
                else
                {
                    lblWarning.Text = "Invalid username or password!";
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message;

                Common.LogToFile(ex.Message.ToString() + ex.StackTrace.ToString());

                Page pgReference = (Page)HttpContext.Current.Handler;
                
                ScriptManager.RegisterClientScriptBlock(pgReference, pgReference.GetType(), "PromptMsg", "ShowPopup('" + Common.FormatScriptValue(ex.Message) + "')", true);
            }
            finally
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }




            







            //Address dummyAdd = new Address(Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), (GeoDataList_CountryInterface.getCountryList()[(new Random()).Next(0, 268)]).StrCountryName);
            ////Address dummyAdd = new Address(Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), (GeoDataList_CountryInterface.getCountryList()[0]).StrCountryName);

            //RegionEntity region = RegionInterface.NewRegion(new RegionEntity(null, Common.GenerateAphaNumeric(10), StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));

            //BranchEntity branchGroup = BranchInterface.NewBranch(new BranchEntity(null, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), BranchRoleEnumerator.branchRoleGroup, dummyAdd, null, region.StrRegionID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));
            //BranchEntity branchCenter = BranchInterface.NewBranch(new BranchEntity(null, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), BranchRoleEnumerator.branchRoleCentre, dummyAdd, branchGroup.StrBranchID, region.StrRegionID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));
            //BranchEntity branch = BranchInterface.NewBranch(new BranchEntity(null, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), BranchRoleEnumerator.branchRoleBranch, dummyAdd, branchCenter.StrBranchID, region.StrRegionID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));
            //branch = BranchInterface.NewBranch(new BranchEntity(null, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), BranchRoleEnumerator.branchRoleBranch, dummyAdd, branchCenter.StrBranchID, region.StrRegionID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));
            //branch = BranchInterface.NewBranch(new BranchEntity(null, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), BranchRoleEnumerator.branchRoleBranch, dummyAdd, branchCenter.StrBranchID, region.StrRegionID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));
            //branch = BranchInterface.NewBranch(new BranchEntity(null, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), BranchRoleEnumerator.branchRoleBranch, dummyAdd, branchCenter.StrBranchID, region.StrRegionID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));

            //UserEntity user = UserInterface.NewUser(new UserEntity(null, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), UserRoleEnumerator.userRoleBranchAdmin, DateTime.Now, branch.StrBranchID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));

            //AgentEntity agent = AgentInterface.NewAgent(new AgentEntity(null, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), IDTypeEnumerator.IdTypeMysNewIC, Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), Common.GenerateAphaNumeric(10), dummyAdd, DateTime.Now, branch.StrBranchID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));

            //ReferralCodeEntity refCode = ReferralCodeInterface.NewReferralCode(new ReferralCodeEntity(null, Common.GenerateAphaNumeric(10), ReferralCodeTypeEnumerator.RefCodeTypeReuse, DateTime.Now.AddDays(100), agent.StrAgentID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));

            //PotentialStudentEntity pStudent = PotentialStudentInterface.NewPotentialStudent(new PotentialStudentEntity(null, Common.GenerateAphaNumeric(10), IDTypeEnumerator.IdTypeMysNewIC, Common.GenerateAphaNumeric(10), DateTime.Now.AddDays(-1 * (new Random()).Next(5000, 10000)), Common.GenerateAphaNumeric(10), GenderEnumerator.genderMale, MaritalStatusEnumerator.maritalStatSingle, Common.GenerateAphaNumeric(10), dummyAdd, DateTime.Now, DateTime.Now, agent.StrAgentID, branch.StrBranchID, StatusEnumerator.statusActive, null, new DateTime(), null, new DateTime()));

            //pStudent.AgentPotenStudReferrer.IDTypeAgentIDType = IDTypeEnumerator.IdTypeMysPoliceID;

            //agent = AgentInterface.UpdateAgent(pStudent.AgentPotenStudReferrer);

            //foreach (BranchEntity b in branch.BranchBranchParent.BranchBranchParent.LstBranchChildList[0].BranchBranchParent.LstBranchChildList[0].LstBranchChildList)
            //{
            //    b.StatusBranchStatus = StatusEnumerator.statusSuspended;
            //    BranchInterface.UpdateBranch(b);
            //}

            //pStudent.GenderPotenStudGender = GenderEnumerator.genderFemale;
            //PotentialStudentInterface.UpdatePotentialStudent(pStudent);

            //user.StatusUserStatus = StatusEnumerator.statusSuspended;
            //UserInterface.UpdateUser(user);

            //refCode.RCTRefCodeType = ReferralCodeTypeEnumerator.RefCodeTypeOnetime;
            //ReferralCodeInterface.UpdateReferralCode(refCode);

            //region.StatusRegionStatus = StatusEnumerator.statusDeleted;
            //RegionInterface.UpdateRegion(region);



            //ConfigurationEntity config = ConfigurationInterface.GetConfigurationByConfigurationName(ConfigurationNameEnumerator.configurationNameCommissionRate.StrKey);
            //if (config == null)
            //{
            //    config = new ConfigurationEntity();
            //    config.ConfigNameConfigurationName = ConfigurationNameEnumerator.configurationNameCommissionRate;
            //}
            //config.StrConfigurationValue = (new Random()).Next(100, 1000).ToString();
            //config = ConfigurationInterface.UpdateConfiguration(config);

            //StringBuilder sb = new StringBuilder();

            //foreach(GeoDataList_CountryEntity country in GeoDataList_CountryInterface.getCountryList())
            //{
            //    sb.AppendLine(country.StrCountryName);
            //}

            //System.Windows.Forms.MessageBox.Show(sb.ToString());
        }
    }
}