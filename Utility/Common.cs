using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Xml;
using System.Data.Common;
using System.Security.Cryptography;
using TypeEnumerator;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Utility
{
    public class Common
    {
        //public static UserInfo GetUserInfo()
        //{
        //    UserInfo usriCurrent = new UserInfo();
        //    if (HttpContext.Current != null)
        //    {
        //        if (HttpContext.Current.Session["UserInfo"] != null)
        //        {
        //            usriCurrent = (UserInfo)HttpContext.Current.Session["UserInfo"];
        //        }
        //        //else if(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated && Request.Cookies["UserInfo"] != null)
        //        //{
        //        //    //throw new Exception(GetResourceValue("Message", "UserInfoInvalid"));
        //        //}
        //    }
        //    return usriCurrent;
        //}

        //public static bool CheckRoleAuthorisation(List<UserRoleEnumerator> authorisedRoles)
        //{
        //    return authorisedRoles.Contains(UserRoleEnumerator.GetEnumByKey(GetUserInfo().Role));
        //}



        public static void LogToFile(string sMessage)
        {
            string sLogFolderPath = string.Empty;
            string sLogFileName = string.Empty;

            sLogFolderPath = HttpContext.Current.Server.MapPath("~") + "System Log";

            sLogFileName = sLogFolderPath + "\\" + DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + ".txt";

            if (!Directory.Exists(sLogFolderPath))
            {
                Directory.CreateDirectory(sLogFolderPath);
            }

            using (StreamWriter writer = new StreamWriter(sLogFileName, true))
            {
                writer.WriteLine(String.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), sMessage));
                writer.WriteLine();
                writer.Close();
            }
        }



        //public static bool VerifyAccess()
        //{
        //    UserInfo usriCurrent = UserInfo.GetUserInfo();

        //    return ((!(String.IsNullOrEmpty(usriCurrent.Username))));
        //}



        public static string FormatScriptValue(string sValue)
        {
            sValue = sValue.Replace("\\", "\\\\");
            sValue = sValue.Replace("'", "\\'");
            sValue = sValue.Replace("\"", "\\\"");
            sValue = sValue.Replace(System.Environment.NewLine, "\\n");

            return sValue.Trim();
        }



        public static string GenerateRandomString(int intLength, String sampleSpace)
        {
            StringBuilder res = new StringBuilder();
            byte[] uintBuffer = new byte[sizeof(uint)];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < intLength; i++)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(sampleSpace[(int)(num % (uint)sampleSpace.Length)]);
                }
            }
            return res.ToString();
        }



        public static string GenerateAphaNumeric(int intLength)
        {
            return GenerateRandomString(intLength, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890");
        }



        //public static string Encrypt(string clearText, string EncryptionKey)
        //{
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    Aes encryptor = Aes.Create();
        //    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //    encryptor.Key = pdb.GetBytes(32);
        //    encryptor.IV = pdb.GetBytes(16);
        //    MemoryStream ms = new MemoryStream();
        //    CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);
        //    cs.Write(clearBytes, 0, clearBytes.Length);
        //    cs.Close();
        //    return Convert.ToBase64String(ms.ToArray());
        //}



        //public static string Decrypt(string cipherText, string EncryptionKey)
        //{
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    Aes encryptor = Aes.Create();
        //    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //    encryptor.Key = pdb.GetBytes(32);
        //    encryptor.IV = pdb.GetBytes(16);
        //    MemoryStream ms = new MemoryStream();
        //    CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);
        //    cs.Write(cipherBytes, 0, cipherBytes.Length);
        //    cs.Close();
        //    return Encoding.Unicode.GetString(ms.ToArray());
        //}



        //public static string Encrypt(string clearText)
        //{
        //    string strKey = GenerateAphaNumeric(8);
        //    string cipherText =  strKey + Encrypt(clearText, strKey);
        //    try
        //    {
        //        if (Decrypt(cipherText) != clearText)
        //        {
        //            return Encrypt(clearText);
        //        }
        //        else
        //        {
        //            return cipherText;
        //        }
        //    } catch (FormatException)
        //    {
        //        return Encrypt(cipherText);
        //    }
        //}



        public static string ConvertStringToHex(String input)
        {
            Byte[] stringBytes = System.Text.Encoding.Unicode.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }



        public static string ConvertHexToString(String hexInput)
        {
            try
            {
                int numberChars = hexInput.Length;
                byte[] bytes = new byte[numberChars / 2];
                for (int i = 0; i < numberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
                }
                return System.Text.Encoding.Unicode.GetString(bytes);
            }
            catch (Exception)
            {
                return hexInput;
            }
        }



        //public static string Decrypt(string cipherText)
        //{
        //    return Decrypt(cipherText.Substring(8), cipherText.Substring(0, 8));
        //}



        public static DateTime? ParseDateFromDatabase(object rawDate)
        {
            return !string.IsNullOrEmpty(rawDate.ToString()) ? (DateTime?)DateTime.Parse(rawDate.ToString()) : null;
        }



        public static decimal ParseDecimalFromDatabase(object rawDecimal)
        {
            return !string.IsNullOrEmpty(rawDecimal.ToString()) ? Decimal.Parse(rawDecimal.ToString()) : 0;
        }



        public static Int32 ParseIntegerFromDatabase(object rawInteger)
        {
            return !string.IsNullOrEmpty(rawInteger.ToString()) ? Int32.Parse(rawInteger.ToString()) : 0;
        }



        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }



        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, "^[0-9 \\+\\-]*$");
        }



        //public static object FollowPropertyPath_bk(object value, string path)
        //{
        //    Type currentType = value.GetType();

        //    foreach (string propertyName in path.Split('.'))
        //    {
        //        PropertyInfo property = currentType.GetProperty(propertyName);
        //        if(value != null)
        //            value = property.GetValue(value, null);
        //        currentType = property.PropertyType;
        //    }
        //    return value ?? "";
        //}


        public static object FollowPropertyPath(object objProperty, string strPath)
        {
            if (objProperty == null)
                return string.Empty;
            else if (strPath.Contains('.'))
                return FollowPropertyPath(objProperty.GetType().GetProperty(strPath.Substring(0, strPath.IndexOf('.'))).GetValue(objProperty), strPath.Substring(strPath.IndexOf('.') + 1));
            else
                return objProperty.GetType().GetProperty(strPath).GetValue(objProperty);
        }



        public static PropertyInfo GetPropertyByPath(object objInstance, string strPath)
        {
            return GetPropertyByPath(objInstance, strPath.Split('.'));
        }


        public static PropertyInfo GetPropertyByPath(object objInstance, string[] strArraylisedPath)
        {
            if (strArraylisedPath.Length > 1)
                return GetPropertyByPath(objInstance.GetType().GetProperty(strArraylisedPath[0]).GetValue(objInstance), strArraylisedPath.Skip(1).ToArray());
            else
                return objInstance.GetType().GetProperty(strArraylisedPath[0]);
        }


        public static object GetPropertyInstanceByPath(object objInstance, string strPath)
        {
            return GetPropertyInstanceByPath(objInstance, strPath.Split('.'));
        }


        public static object GetPropertyInstanceByPath(object objInstance, string[] strArraylisedPath)
        {
            if (strArraylisedPath.Length > 1)
                return GetPropertyInstanceByPath(objInstance.GetType().GetProperty(strArraylisedPath[0]).GetValue(objInstance), strArraylisedPath.Skip(1).ToArray());
            else
                return objInstance;
        }


        public static bool IsEqualPassword(string sNewPassword, string sRetypeNewPassword)
        {
            if (sNewPassword.Trim().Equals(sRetypeNewPassword.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static bool IsEqualOTP(string sNewOTP, string sRetypeOTP)
        {
            if (sNewOTP.Trim().Equals(sRetypeOTP.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static bool IsEqual(object val1, object val2)
        {
            if ((val1 == null && val2 != null) || (val1 != null && val2 == null))
                return false;
            else if (val1 != null)
                return val1.Equals(val2);
            else if (val2 != null)
                return val2.Equals(val1);
            else
                return true;
        }

        public static bool IsEmpty(object val)
        {
            if (val == null)
                return true;
            else if (val is string)
                return string.IsNullOrWhiteSpace(val as string);
            else if (decimal.TryParse(val.ToString(), out _))
                return val != (object)(default(decimal));
            else if (val.GetType().IsValueType)
                return Activator.CreateInstance(val.GetType()) == val;
            else
                return val == null;


            //else if (val != null && Nullable.GetUnderlyingType(val.GetType()) == null && val.GetType().IsValueType)
            //if ((new Type[] { typeof(decimal), typeof(int), typeof(bool) }).Any(x => val != null && x.IsAssignableFrom(val.GetType())))
            //if (decimal.TryParse(val.ToString(), out _))
            //    return val != (object)(default(decimal));
            //else if (bool.TryParse(val.ToString(), out _))
            //    return val != (object)(default(bool));
            //else
            //    return true;

            //return (bool)val.GetType().GetMethod("TryParse", new Type[] { typeof(string), val.GetType().MakeByRefType() }).Invoke(null, new object[] { val.ToString(), null });
            //    return Activator.CreateInstance(val.GetType()) == val;
            //else
            //    return val == null;
        }

        //public static DateTime GetNextBusinessDay(DateTime dteStartDate, int intNoOfDays, DateTime[] dteBankHolidays)
        //{
        //    DateTime dteEndDate = dteStartDate.AddDays(intNoOfDays);

        //    Dictionary<DayOfWeek, int> result = Enumerable.Range(0, intNoOfDays + 1).Select(x => dteStartDate.AddDays(x)).GroupBy(x => x.DayOfWeek).Select(x => new { day = x.Key, count = x.Count() }).ToDictionary(x => x.day, x => x.count);

        //    dteEndDate = dteEndDate.AddDays((new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday }).Where(x => result.ContainsKey(x)).Select(x => result[x]).Sum());

        //    if (dteBankHolidays != null)
        //        dteEndDate = dteEndDate.AddDays(dteBankHolidays.Where(x => x >= dteStartDate && x <= dteEndDate).Count());

        //    while ((new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday }).Contains(dteEndDate.DayOfWeek) || (dteBankHolidays != null && dteBankHolidays.Contains(dteEndDate)))
        //        dteEndDate = dteEndDate.AddDays(1);

        //    return dteEndDate;
        //}

        public static DateTime[] GetAllDatesBetween(DateTime dteStartDate, DateTime dteEndDate)
        {
            return Enumerable.Range(0, Math.Abs((dteEndDate - dteStartDate).Days) + 1).Select(x => dteStartDate.AddDays(x * (dteEndDate >= dteStartDate ? 1 : -1))).ToArray();
        }

        public static int GetNumberOfNonBusinessDaysInBetween(DateTime dteStartDate, DateTime dteEndDate, DateTime[] dteBankHolidays)
        {
            return GetAllDatesBetween(dteStartDate, dteEndDate).Count(x => (new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday }).Any(y => x.DayOfWeek == y) || (dteBankHolidays != null && dteBankHolidays.Contains(x)));
        }

        public static int GetNumberOfBusinessDaysInBetween(DateTime dteStartDate, DateTime dteEndDate, DateTime[] dteBankHolidays)
        {
            return (dteEndDate - dteStartDate).Days - GetNumberOfNonBusinessDaysInBetween(dteStartDate, dteEndDate, dteBankHolidays);
        }

        public static DateTime GetNextBusinessDayAfter(DateTime dteStartDate, uint intNoOfDays, DateTime[] dteBankHolidays, bool isCountOnlyBusinessDays)
        {
            DateTime dteResult = dteStartDate.AddDays(intNoOfDays + (isCountOnlyBusinessDays ? GetNumberOfNonBusinessDaysInBetween(dteStartDate, dteStartDate.AddDays(intNoOfDays), dteBankHolidays) : 0));

            while (isCountOnlyBusinessDays ? (GetNumberOfBusinessDaysInBetween(dteStartDate, dteResult, dteBankHolidays) < intNoOfDays) : ((new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday }).Contains(dteResult.DayOfWeek) || (dteBankHolidays != null && dteBankHolidays.Contains(dteResult))))
                dteResult = dteResult.AddDays(1);

            return dteResult;
        }



        public static int GenerateRandomInteger(int intMinValue, int intMaxValue)
        {
            Random random = new Random();

            return random.Next(intMinValue, intMaxValue);
        }
    }



    //public struct UserInfo
    //{
    //    public string Username { get; set; }
    //    public string Password { get; set; }
    //    public string Name { get; set; }
    //    public string Role { get; set; }
    //    public string Gate { get; set; }
    //    public DateTime LastLogin { get; set; }

    //    public bool isAdmin()
    //    {
    //        return !default(UserInfo).Equals(this) && UserRoleEnumerator.GetEnumByKey(this.Role) == UserRoleEnumerator.UserRoleAdmin;
    //    }



    //    public bool isAgent()
    //    {
    //        return !default(UserInfo).Equals(this) && AgentRoleEnumerator.GetEnumByKey(this.Role) != null;
    //    }
    //}
}
