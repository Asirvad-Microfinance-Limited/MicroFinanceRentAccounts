using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Validations
{
    public class ValidationExpressions
    {
        public class Constants
        {
            public static class Strings
            {
             
                public const string nameFormat = @"^[a-zA-Z\s]+$";
                public const string numberFormat = "^[0-9]+$";
                public const string alphaNumericFormat = "^[a-zA-Z0-9]*$";
                public const string panNoFormat = @"^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$";
                public const string zeroOneFormat = "^[0-1]{0,1}$";
                public const string decimalFormat = @"^\d+.\d{0,2}$";               
                public const string schemeNameFormat = "^[A-Z]*$";
                public const string custnameFormat = @"^[a-zA-Z\s\.]+$";
            }

            public static class Ints
            {
                public const int rangeValidatorFrom_0 = 0;
                public const int rangeValidatorTo = int.MaxValue;            
                public const int rangeValidatorFrom_1 = 1;
                public const int mobileNumberLength = 10;
                public const int pinCodeLength = 6;
                public const int customerIDLength = 14;
                public const int userId = 7;            

            }
        }

        public enum postOfficeTypeId
        {
            pincode = 1,
            districtId = 2
          
        }

        public enum otpTypeId
        {
            memberOnBoarding = 1,
            mobileVerification =2
        }

        public enum groupProductTypeId
        {
            newCenter = 1,
            existingCenter = 2

        }

        public enum loginTypeId
        {
            password = 1,
            mpin = 2

        }
        public enum centersListTypeID
        {
            CenterId = 1,
            centerName = 2,
            branchID = 3

        }
    }
}
