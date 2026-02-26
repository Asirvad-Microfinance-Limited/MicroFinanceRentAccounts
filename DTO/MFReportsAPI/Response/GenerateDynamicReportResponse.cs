using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
  public  class GenerateDynamicReportResponse
    {
        public GenerateDynamicReportResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public string headers { get; set; }
        public string linkField { get; set; }
        public string linklevelId { get; set; }
        public List<GenerateDynamicReportData> reportDatas { get; set; }
        public string panelValue { get; set; }
        public string encryptedResStr { get; set; }


    }
}
