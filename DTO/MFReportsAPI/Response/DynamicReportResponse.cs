using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
    public class DynamicReportResponse
    {
        public DynamicReportResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public string encryptedResStr { get; set; }

        
        public List<DynamicReportData> dynamicReportDatas { get; set; }
    }
}
