using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TypeEnumerator
{
    public class IDTypeEnumerator : BaseEnumerator
    {
        public struct Inputs
        {
            public string strIdNum;
            public DateTime? dteDateOfBirth;
            public GenderEnumerator gender;
        }

        public enum ErrorCodes
        {
            INVALID_FORMAT,
            INCORESPOND_DOB,
            INCORESPOND_GENDER
        }

        public static readonly IDTypeEnumerator IdTypeMysNewIC = new IDTypeEnumerator("MYS-IC-NEW", "New Malaysian Identity Card (MyKad)", "typeEnum.idType.mys.ic.new", IsValidMysNewIC);
        public static readonly IDTypeEnumerator IdTypeMysOldIC = new IDTypeEnumerator("MYS-IC-OLD", "Old Malaysian Identity Card", "typeEnum.idType.mys.ic.old", IsValidMysOldIC);
        //public static readonly IDTypeEnumerator IdTypeMysBirthCertificate = new IDTypeEnumerator("MYS-KID", "Malaysian Birth Certificate (MyKid)", "typeEnum.idType.mys.mykid", IsValidMysNewIC);
        public static readonly IDTypeEnumerator IdTypeMysArmyID = new IDTypeEnumerator("MYS-ARMY", "Malaysian Army Identity (BAT C. 10)", "typeEnum.idType.mys.armyID", IsValidMysNewIC);
        public static readonly IDTypeEnumerator IdTypeMysPoliceID = new IDTypeEnumerator("MYS-POLICE", "Malaysian Police Identity", "typeEnum.idType.mys.policeID", null);
        public static readonly IDTypeEnumerator IdTypeMysPermanentResident = new IDTypeEnumerator("MYS-PR", "Malaysian Permanent Resident (MyPR)", "typeEnum.idType.mys.pr", IsValidMysNewIC);
        public static readonly IDTypeEnumerator IdTypeICAOPassport = new IDTypeEnumerator("ICAO-PASSPORT", "Passport (ICAO)", "typeEnum.idType.passport.icao", IsValidICAOPassport);
        public static readonly IDTypeEnumerator IdTypePassport = new IDTypeEnumerator("PASSPORT", "Passport", "typeEnum.idType.passport", null);

        public Func<IDTypeEnumerator.Inputs, List<IDTypeEnumerator.ErrorCodes>> Validator;

        private static readonly Dictionary<string, IDTypeEnumerator> dict
            = new Dictionary<string, IDTypeEnumerator>{{ IdTypeMysNewIC.StrKey, IdTypeMysNewIC },
                                                           { IdTypeMysOldIC.StrKey, IdTypeMysOldIC },
                                                           //{ IdTypeMysBirthCertificate.StrKey, IdTypeMysBirthCertificate },
                                                           { IdTypeMysArmyID.StrKey, IdTypeMysArmyID },
                                                           { IdTypeMysPoliceID.StrKey, IdTypeMysPoliceID },
                                                           { IdTypeMysPermanentResident.StrKey, IdTypeMysPermanentResident },
                                                           { IdTypeICAOPassport.StrKey, IdTypeICAOPassport },
                                                           { IdTypePassport.StrKey, IdTypePassport }};

        public IDTypeEnumerator(string strKey, string strDispText, string strResxKey, Func<IDTypeEnumerator.Inputs, List<IDTypeEnumerator.ErrorCodes>> validator) : base(strKey, strResxKey)
        {
            this.Validator = validator;
        }

        public static IDTypeEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out IDTypeEnumerator value))
                return value;
            else
                return null;
        }



        public static List<IDTypeEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }

        private static List<IDTypeEnumerator.ErrorCodes> IsValidMysNewIC(IDTypeEnumerator.Inputs inputs)
        {
            List<IDTypeEnumerator.ErrorCodes> errorList = new List<IDTypeEnumerator.ErrorCodes>();

            if (inputs.strIdNum != null)
            {
                if (IsValidMysNewICFormat(inputs.strIdNum))
                {
                    if (inputs.dteDateOfBirth != null && !IsMysIcNumCorrespondDob(inputs.strIdNum, (DateTime)inputs.dteDateOfBirth))
                        errorList.Add(IDTypeEnumerator.ErrorCodes.INCORESPOND_DOB);
                    if (inputs.gender != null && !IsMysIcNumCorrespondGender(inputs.strIdNum, inputs.gender))
                        errorList.Add(IDTypeEnumerator.ErrorCodes.INCORESPOND_GENDER);
                }
                else
                {
                    errorList.Add(IDTypeEnumerator.ErrorCodes.INVALID_FORMAT);
                }
            }
            return errorList;
        }

        private static bool IsValidMysNewICFormat(string strIcNumber)
        {
            bool result;
            result = Regex.IsMatch(strIcNumber, @"[0-9]{6}-[0-9]{2}-[0-9]{4}");
            if (result)
            {
                string[] parts = strIcNumber.Split(new char[]{'-'});
                result = DateTime.TryParseExact(parts[0], "yyMMdd", null, DateTimeStyles.None, out _);

                if (result)
                    result = getAllMysValidStateCode().Contains(parts[1]);
            }
            return result;
        }

        private static string[] getAllMysValidStateCode()
        {
            if (validIcStateCode == null)
            {
                List<string> stateCodes = new List<string>();

                stateCodes.AddRange(Resource.MysIcValidStateCodeJohor.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeKedah.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeKelantan.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeMelaka.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeNSembilan.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodePahang.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodePPinang.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodePerak.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodePerlis.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeSelangor.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeTerengganu.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeSabah.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeSarawak.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeWPKualaLumpur.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeWPLabuan.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeWPPutrajaya.Split(',').Select(x => x.Trim()).ToList());
                stateCodes.AddRange(Resource.MysIcValidStateCodeUnknownState.Split(',').Select(x => x.Trim()).ToList());

                validIcStateCode = stateCodes.ToArray();
            }

            return validIcStateCode;
        }

        private static string[] validIcStateCode;

        private static bool IsMysIcNumCorrespondDob(string strIcNum, DateTime dteDob)
        {
            return strIcNum.Substring(0, 6).Equals(dteDob.ToString("yyMMdd"));
        }

        private static bool IsMysIcNumCorrespondGender(string strIcNum, GenderEnumerator gender)
        {
            if (GenderEnumerator.GenderMale.Equals(gender))
            {
                return Math.Abs(int.Parse(strIcNum.Substring(strIcNum.Length - 1))) % 2 > 0;
            }
            else if (GenderEnumerator.GenderFemale.Equals(gender))
            {
                return Math.Abs(int.Parse(strIcNum.Substring(strIcNum.Length - 1))) % 2 <= 0;
            }
            else
            {
                return false;
            }
        }

        private static List<IDTypeEnumerator.ErrorCodes> IsValidMysOldIC(IDTypeEnumerator.Inputs inputs)
        {
            bool result;

            result = Regex.IsMatch(inputs.strIdNum, @"[0-9]{7}");

            if (result)
                result = long.Parse(inputs.strIdNum) >= 1;

            return result ? new List<IDTypeEnumerator.ErrorCodes>() : new List<IDTypeEnumerator.ErrorCodes> { IDTypeEnumerator.ErrorCodes.INVALID_FORMAT } ;
        }



        private static List<IDTypeEnumerator.ErrorCodes> IsValidICAOPassport(IDTypeEnumerator.Inputs inputs)
        {
            return Regex.IsMatch(inputs.strIdNum, @"[0-9 a-z A-Z]{9}") ? new List<IDTypeEnumerator.ErrorCodes>() : new List<IDTypeEnumerator.ErrorCodes> { IDTypeEnumerator.ErrorCodes.INVALID_FORMAT } ;
        }
    }
}
