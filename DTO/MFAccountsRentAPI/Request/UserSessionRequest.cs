using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Request
{
   public  class UserSessionRequest
    {

        public string typeID { get; set; }
        public long userID { get; set; }
        public string branchID { get; set; }
        public string token { get; set; }
        public string sessionID { get; set; }

        public string encryptedRqstStr { get; set; }

    }
}
