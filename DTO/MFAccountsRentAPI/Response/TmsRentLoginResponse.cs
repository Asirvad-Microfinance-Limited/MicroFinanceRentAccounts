using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Response
{

    public class TmsRentLoginResponse
    {
        /// <summary>
        /// API Number : GEN017
        /// Created on : 26-Dec-2019
        /// Created By : 100101
        /// Description: Login API
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>

        public TmsRentLoginResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public long userId { get; set; }
        public long accessLevelId { get; set; }
        public string userName { get; set; }
        public long branchId { get; set; }
        public string branchName { get; set; }
        public string token { get; set; }
        public long mpin { get; set; }
        public string message { get; set; }
        public string accessLevelName { get; set; }
        public string menuList { get; set; }
        public string mobileNumber { get; set; }
        public long otpFlag { get; set; }
        public string encryptedResStr { get; set; }

    }
}



