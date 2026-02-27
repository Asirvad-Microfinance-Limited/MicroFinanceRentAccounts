using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
   public class ComboFillResponse
    {
        public ComboFillResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public string encryptedResStr;
        public List<ComboFillProperties> resultset { get; set; }
       
    }
}
