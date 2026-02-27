//using DTO.Validations;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Text;
//using static DTO.Validations.ValidationExpressions;

//namespace DTO.MFAccountsAPI.Request
//{
//    public class OTPRequest
//    {
//        #region OTPRequest

//        /// <summary>
//        /// API Number : GEN012
//        /// Created on : 23-Dec-2019
//        /// Created By : 100101
//        /// Description: Get OTP
//        /// Modify Date:
//        /// Modify By  : 
//        /// Description:
//        /// </summary>

//        public long userId { get; set; }
//        public string mobileNo { get; set; }
//        public string branchID { get; set; }

//        [Required(ErrorMessage = RequireValidationMessages.typeId)]
//        [Range(Constants.Ints.rangeValidatorFrom_1, 9, ErrorMessage = InvalidValidationMessages.typeId)]
//        public long typeId { get; set; }
//        public string encryptedRqstStr { get; set; }

//        #endregion
//    }
//}

