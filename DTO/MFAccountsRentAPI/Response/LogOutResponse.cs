using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Response
{

    public class LogOutResponse
    {

        public LogOutResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public string message { get; set; }
        public string encryptedResStr { get; set; }

    }
}

