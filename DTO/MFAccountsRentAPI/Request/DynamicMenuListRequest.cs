using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Request
{
    public class DynamicMenuListRequest
    {
        //public long accesslevelId { get; set; }
        public long userID { get; set; }
        public long moduleID { get; set; }
        public string encryptedRqstStr { get; set; }

    }
}
