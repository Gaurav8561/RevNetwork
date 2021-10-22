using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Entity;
using Database;

namespace RevNetwork.Admin.Backend
{
    public partial class Voucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindVoucherDetails();
        }

        [WebMethod]
        public static string GetVoucherName(string searchTerm)
        {
            string query = "usp_ManageVoucher";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "GetAll");
            cmd.Parameters.AddWithValue("@VoucherName", searchTerm);
            return GetData(cmd).GetXml();
        }

        [WebMethod]
        public static string GetVoucherValue(string searchTerm)
        {
            string query = "usp_ManageVoucher";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "GetAll");
            cmd.Parameters.AddWithValue("@VoucherCode", searchTerm);
            return GetData(cmd).GetXml();
        }

        [WebMethod]
        public static string GetVoucherStatus(string searchTerm)
        {
            string query = "usp_ManageVoucher";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "GetAll");
            cmd.Parameters.AddWithValue("@VoucherStatus", searchTerm);
            return GetData(cmd).GetXml();
        }

        private static DataSet GetData(SqlCommand cmd)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConnString_Local"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds, "tbl_Voucher");
                        return ds;
                    }
                }
            }
        }

        public void BindVoucherDetails()
        {
            DataTable dtRpt = new DataTable();
            SqlParameter[] Parameter = null;
            Parameter = new SqlParameter[1];
            Parameter[0] = new SqlParameter("@Action", "GetAll");
            dtRpt = CommonDB.ExecuteScalarDataTable("usp_ManageVoucher", Parameter);
            rptVoucher.DataSource = dtRpt;
            rptVoucher.DataBind();
        }

        [WebMethod]
        public static List<string> getVoucherNames(string Vouchertext)
        {
            List<string> tbl_Voucher = new List<string>();
            SqlParameter[] Parameter = null;
            Parameter = new SqlParameter[2];
            Parameter[0] = new SqlParameter("@Action", "GetVoucherName");
            Parameter[1] = new SqlParameter("@VoucherName", Vouchertext);
            DataTable dt = CommonDB.ExecuteScalarDataTable("usp_SearchVoucher", Parameter);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_Voucher.Add(dt.Rows[i]["VoucherName"].ToString());
            }
            return tbl_Voucher;
        }


        [WebMethod]
        public static List<string> getVoucherCode(string VoucherCode)
        {
            List<string> tbl_Voucher = new List<string>();
            SqlParameter[] Parameter = null;
            Parameter = new SqlParameter[2];
            Parameter[0] = new SqlParameter("@Action", "GetVoucherCode");
            Parameter[1] = new SqlParameter("@VoucherCode", VoucherCode);
            DataTable dt = CommonDB.ExecuteScalarDataTable("usp_SearchVoucher", Parameter);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_Voucher.Add(dt.Rows[i]["VoucherCode"].ToString());
            }
            return tbl_Voucher;
        }

    }
}