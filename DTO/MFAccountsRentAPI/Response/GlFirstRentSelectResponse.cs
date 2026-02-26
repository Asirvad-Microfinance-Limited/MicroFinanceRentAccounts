using DTO.MFAccountsRentAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;



namespace DTO.MFAccountsRentAPI.Response
{
    public class GlFirstRentSelectResponse
    {
        public GlFirstRentSelectResponse()
        {
            isDataAvailable = false;
            Message = "";
            QueryResult = null;
        }

        public bool isDataAvailable { get; set; }
        public string Message { get; set; }
        public List<GlFirstRentData>? QueryResult { get; set; }
        public string encryptedResStr { get; set; }
        public string token { get; set; }
    }
}
