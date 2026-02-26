using DTO.MFAccountsRentAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;



namespace DTO.MFAccountsRentAPI.Response
{
    public class InsertImageResponse
    {
        public InsertImageResponse()
        {
            isDataAvilable = false;
        }
        public bool isDataAvilable { get; set; }
        public string message { get; set; }
        //public string expence_id { get; set; }

    }
}
