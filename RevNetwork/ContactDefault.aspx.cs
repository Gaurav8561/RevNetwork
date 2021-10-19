using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Utility;
using Entity;
using TypeEnumerator;
using System.Resources;
using Controller;
using General;
using System.Threading;
using System.Web.Security;
using System.Globalization;
using Security;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace RevNetwork
{
    public partial class ContactDefault : System.Web.UI.Page
    {
        //private static readonly List<UserRoleEnumerator> m_LstAuthorisedRoles
        //     = new List<UserRoleEnumerator>(ContactRoleEnumerator.GetEnumList());

        //public UserInfo m_usriCurrent = new UserInfo();

        public string m_strDoughnutData = string.Empty;
        public string m_strDoughnutData_previousMonth = string.Empty;

        public string m_strLineChartMonthLabels = string.Empty;
        public string m_strLineChartData_totalSubmission = string.Empty;
        public string m_strLineChartData_totalSignedUp = string.Empty;
        public string m_strLineChartData_totalExpired = string.Empty;
        public string m_strLineChartData_totalCommission = string.Empty;


        protected void Page_Init(object sender, EventArgs e)
        {
            //m_usriCurrent = UserInfo.GetUserInfo();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            Session[Constant.SESSION_NAME_QR_TIMER_STATUS] = null;

            //EmailSendingController.SendSMS("This is an automated msg from code. Please do not reply");

            //if (!UserAccess.CheckRoleAuthorisation(m_LstAuthorisedRoles))
            //    Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);


            if (!this.IsPostBack)
            {
                //TmrRefresh.Enabled = true;

                //Session[Constant.SESSION_NAME_PAYMENT_CONTACT_TRANSACTION_TOKEN] = Common.GenerateAphaNumeric(8);

                //GenerateQRCode(m_usriCurrent.UserID);
            }



            




            //ContactEntity contact = ContactInterface.GetContactByPrimaryKey(m_usriCurrent.UserID);

            //if (contact != null)
            //{
            //    LblPaymentPoint.Text = contact.DecContactPaymentPoint.ToString();
            //}


            //decimal decTotalWalletBalance = 0.0M;

            

            //if (HttpContext.Current.Session["UserInfo"] != null)
            //{
                //PocketEntity pocketContactWalletPocketMaster = ContactWalletPocketMasterInterface.GetByCustomColumn("ContactID", m_usriCurrent.UserID);

                //if (pocketContactWalletPocketMaster != null)
                //{
                //    decTotalWalletBalance += pocketContactWalletPocketMaster.DecCreditBalance;
                //}

                //PocketEntity pocketContactWalletPocketBonus = ContactWalletPocketBonusInterface.GetByCustomColumn("ContactID", m_usriCurrent.UserID);

                //if (pocketContactWalletPocketBonus != null)
                //{
                //    decTotalWalletBalance += pocketContactWalletPocketBonus.DecCreditBalance;
                //}

                //PocketEntity pocketContactWalletPocketEarning = ContactWalletPocketEarningInterface.GetByCustomColumn("ContactID", m_usriCurrent.UserID);

                //if (pocketContactWalletPocketEarning != null)
                //{
                //    decTotalWalletBalance += pocketContactWalletPocketEarning.DecCreditBalance;
                //}

                //int pocketNumber = 1;
                //while (ContactWalletPocketInterface.TableExists(pocketNumber))
                //{
                //    ContactWalletPocketInterface.UpdateTableMapping(pocketNumber);
                //    PocketEntity subPocket = ContactWalletPocketInterface.GetByCustomColumn("ContactID", m_usriCurrent.UserID);
                //    if (subPocket != null)
                //    {
                //        decTotalWalletBalance += subPocket.DecCreditBalance;
                //    }
                //    pocketNumber++;
                //}



                //LblWalletBalance.Text = decTotalWalletBalance.ToString();

                //Session["WalletBalance"] = PaymentController.CalculateTotalSpendableAmount(m_usriCurrent.UserID).ToString();

                //LblWalletBalance.Text = Session["WalletBalance"] as string;



                


                //DateTimeFormatInfo dtFmt = (new CultureInfo("en-GB")).DateTimeFormat;


                //GenerateQRCode(m_usriCurrent.UserID);



                //m_strLineChartMonthLabels = string.Format("'{0}', '{1}', '{2}', '{3}', '{4}'", DateTime.Today.AddMonths(-4).ToString("MMM", dtFmt), DateTime.Today.AddMonths(-3).ToString("MMM", dtFmt), DateTime.Today.AddMonths(-2).ToString("MMM", dtFmt), DateTime.Today.AddMonths(-1).ToString("MMM", dtFmt), DateTime.Today.ToString("MMM", dtFmt));

                //int[] intMonthCount;
                //Dictionary<string, int> monthGroupCount;
                //int count;

                ////Total Submission
                //intMonthCount = new int[] { 0, 0, 0, 0, 0 };
                
            //}
            //else
            //{
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        //protected void IbtPayment_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect("ContactPayment.aspx");
        //}



        //protected void TmrRefresh_Tick(object sender, EventArgs e)
        //{
        //    WalletPocketMasterTransactionEntity masterPocketTransaction = WalletPocketMasterTransactionInterface.GetByCustomColumn("TransactionToken", Session[Constant.SESSION_NAME_PAYMENT_CONTACT_TRANSACTION_TOKEN] as string);

        //    if (masterPocketTransaction != null)
        //    {
        //        //LblPaymentAmount.Text = masterPocketTransaction.DecWalletPocketTransactionAmount.ToString();
        //        //TxtPaymentDateTime.Text = masterPocketTransaction.DteWalletPocketTransactionCreatedDate.ToString();
        //        //TxtPaymentTransactionReferenceNo.Text = masterPocketTransaction.StrWalletPocketTransactionReferenceID;

        //        //TmrRefresh.Enabled = false;
        //        //PnlPaymentQR.Visible = false;
        //        //PnlPaymentSummary.Visible = true;

        //        Session[Constant.SESSION_NAME_PAYMENT_CONTACT_TRANSACTION_TOKEN] = null;
        //    }
        //}



        //private void GenerateQRCode(string strContactID)
        //{
        //    //Generate QR Code
        //    BarcodeWriter qr = new BarcodeWriter
        //    {
        //        Format = ZXing.BarcodeFormat.QR_CODE,
        //        Options = new QrCodeEncodingOptions
        //        {
        //            DisableECI = true,
        //            CharacterSet = "UTF-8",
        //            Width = 400,
        //            Height = 400,
        //        }
        //    };

        //    Bitmap result = new Bitmap(qr.Write(string.Format("{0}://{1}{2}/Admin/Payment.aspx?param={3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port), Encryption.EncryptToHex(strContactID + "|" + Session[Constant.SESSION_NAME_PAYMENT_CONTACT_TRANSACTION_TOKEN] as string))));

        //    // Set up string.
        //    Font stringFont = new Font("Arial", 12);
        //    int margin = 10;

        //    //SizeF buildingNameSize;
        //    //using (Graphics g = Graphics.FromImage(new Bitmap(result.Width, result.Height)))
        //    //{
        //    //    buildingNameSize = g.MeasureString(ConfigurationManager.AppSettings["Building"], stringFont, result.Width);
        //    //}

        //    //SizeF visitDateSize;
        //    //using (Graphics g = Graphics.FromImage(new Bitmap(result.Width, result.Height)))
        //    //{
        //    //    visitDateSize = g.MeasureString(lblDate.Text, stringFont, result.Width);
        //    //}

        //    //Bitmap img = new Bitmap(result.Width, result.Height + (int)buildingNameSize.Height + (int)visitDateSize.Height + (margin * 2));
        //    Bitmap img = new Bitmap(result.Width, result.Height);

        //    using (Graphics g = Graphics.FromImage(img))
        //    {
        //        g.Clear(Color.White);
        //        //g.DrawImage(result, 0, buildingNameSize.Height + 10, result.Width, result.Height);
        //        g.DrawImage(result, 0, 10, result.Width, result.Height);
        //        //g.DrawString(ConfigurationManager.AppSettings["Building"], stringFont, Brushes.Black, new PointF((img.Width - buildingNameSize.Width) / 2, margin));
        //        //g.DrawString(lblDate.Text, stringFont, Brushes.Black, new PointF((img.Width - visitDateSize.Width) / 2, buildingNameSize.Height + result.Height + (margin * 2) - 10));
        //    }

        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        img.Save(ms, ImageFormat.Bmp);
        //        resultImage.Src = "data:image/bmp;base64," + Convert.ToBase64String(ms.ToArray());
        //    }

        //    //HdQrFileName.Value = string.Format("QRCode_{0}_{1}_{2}.png", ConfigurationManager.AppSettings["Building"], lblDate.Text, txtName.Text);
        //}



        //private void GenerateQRCode(string strContactID)
        //{
        //    //Generate QR Code
        //    BarcodeWriter qr = new BarcodeWriter
        //    {
        //        Format = ZXing.BarcodeFormat.QR_CODE,
        //        Options = new QrCodeEncodingOptions
        //        {
        //            DisableECI = true,
        //            CharacterSet = "UTF-8",
        //            Width = 400,
        //            Height = 400,
        //        }
        //    };

        //    Bitmap result = new Bitmap(qr.Write(string.Format("{0}://{1}{2}/Payment.aspx?param={3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port), Encryption.EncryptToHex(strContactID))));

        //    // Set up string.
        //    Font stringFont = new Font("Arial", 12);
        //    int margin = 10;

        //    //SizeF buildingNameSize;
        //    //using (Graphics g = Graphics.FromImage(new Bitmap(result.Width, result.Height)))
        //    //{
        //    //    buildingNameSize = g.MeasureString(ConfigurationManager.AppSettings["Building"], stringFont, result.Width);
        //    //}

        //    //SizeF visitDateSize;
        //    //using (Graphics g = Graphics.FromImage(new Bitmap(result.Width, result.Height)))
        //    //{
        //    //    visitDateSize = g.MeasureString(lblDate.Text, stringFont, result.Width);
        //    //}

        //    //Bitmap img = new Bitmap(result.Width, result.Height + (int)buildingNameSize.Height + (int)visitDateSize.Height + (margin * 2));
        //    Bitmap img = new Bitmap(result.Width, result.Height);

        //    using (Graphics g = Graphics.FromImage(img))
        //    {
        //        g.Clear(Color.White);
        //        //g.DrawImage(result, 0, buildingNameSize.Height + 10, result.Width, result.Height);
        //        g.DrawImage(result, 0, 10, result.Width, result.Height);
        //        //g.DrawString(ConfigurationManager.AppSettings["Building"], stringFont, Brushes.Black, new PointF((img.Width - buildingNameSize.Width) / 2, margin));
        //        //g.DrawString(lblDate.Text, stringFont, Brushes.Black, new PointF((img.Width - visitDateSize.Width) / 2, buildingNameSize.Height + result.Height + (margin * 2) - 10));
        //    }

        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        img.Save(ms, ImageFormat.Bmp);
        //        resultImage.Src = "data:image/bmp;base64," + Convert.ToBase64String(ms.ToArray());
        //    }

        //    //HdQrFileName.Value = string.Format("QRCode_{0}_{1}_{2}.png", ConfigurationManager.AppSettings["Building"], lblDate.Text, txtName.Text);
        //}
    }
}