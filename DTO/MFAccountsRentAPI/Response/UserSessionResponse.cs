using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Response
{
    public class UserSessionResponse
    {
        public UserSessionResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }

        public string message { get; set; }
        public string errStatus { get; set; }
        public string tokenId { get; set; }
        public string encryptedResStr { get; set; }

    }
}
