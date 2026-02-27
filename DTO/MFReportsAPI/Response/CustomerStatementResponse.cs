using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
   public  class CustomerStatementResponse
    {
        public CustomerStatementResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
    
        public List<CustomerStatementData> customerStatementResult { get; set; }
    }
}
