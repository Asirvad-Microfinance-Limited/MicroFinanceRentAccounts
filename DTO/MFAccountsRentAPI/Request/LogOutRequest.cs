using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Request
{
    public class LogOutRequest
    {
        public long userId { get; set; }
        public string token { get; set; }
        public string encryptedRqstStr { get; set; }

    }
}

