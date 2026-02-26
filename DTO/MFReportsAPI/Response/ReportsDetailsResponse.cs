using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
   public  class ReportsDetailsResponse
    {
        public ReportsDetailsResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public List<ReportsDetailsData> reportDetailsList { get; set; }
    }
}
