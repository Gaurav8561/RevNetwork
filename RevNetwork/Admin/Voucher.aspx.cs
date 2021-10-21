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

namespace RevNetwork.Admin
{
    public partial class Voucher : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindVoucherDetails();
        }
        public void BindVoucherDetails()
        {
            
        }


        [WebMethod]
        public static List<string> getVoucherNames(string Vouchertext)
        {
            List<string> tbl_Voucher = new List<string>();
            SqlParameter[] Parameter = null;
            Parameter = new SqlParameter[2];
            Parameter[0] = new SqlParameter("@Action", "GetVoucherName");
            Parameter[1] = new SqlParameter("@VoucherName", Vouchertext);
            DataTable dt=CommonDB.ExecuteScalarDataTable("usp_SearchVoucher", Parameter);
            for(int i=0;i<dt.Rows.Count;i++)
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