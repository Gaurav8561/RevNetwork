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

namespace RevNetwork.Admin
{
    public partial class Voucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<string> getVoucherNames(string Vouchertext)
        {
            List<string> tbl_Voucher = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString_Local"].ConnectionString;
                //string QueryString = "exec usp_SearchVoucher @VoucherName";
                SqlCommand cmd = new SqlCommand("usp_SearchVoucher", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetVoucherName");
                cmd.Parameters.AddWithValue("@VoucherName", Vouchertext);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        tbl_Voucher.Add(rdr["VoucherName"].ToString());
                    }
                }
                conn.Close();
                return tbl_Voucher;
            }
        }


        [WebMethod]
        public static List<string> getVoucherCode(string VoucherCode)
        {
            List<string> tbl_Voucher = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString_Local"].ConnectionString;
                //string QueryString = "exec usp_SearchVoucher @VoucherName";
                SqlCommand cmd = new SqlCommand("usp_SearchVoucher", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetVoucherCode");
                cmd.Parameters.AddWithValue("@VoucherCode", VoucherCode);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        tbl_Voucher.Add(rdr["VoucherCode"].ToString());
                    }
                }
                conn.Close();
                return tbl_Voucher;
            }
        }
    }
}