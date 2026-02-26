using System;
using System.Collections.Generic;
using System.Text;


namespace DTO.MFAccountsRentAPI.Response

{
    public class TokenValidatorResponse
    {
        public TokenValidatorResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        
    }
}
