using System;
using System.Collections.Generic;
using System.Text;
using static DTO.Validations.ValidationExpressions;

namespace DTO.MFAccountsRentAPI.Request
{
    public class TmsRentLoginRequest
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

        public long typeId { get; set; } //-------1-Password, 2-MPIN, 3-Agent Writeoff
        public long moduleId { get; set; }
        public long userId { get; set; }
        public string password { get; set; }
        public string deviceId { get; set; }
        public decimal version { get; set; }
        public string apiKey { get; set; }
        public string encryptedRqstStr { get; set; }

    }
}
