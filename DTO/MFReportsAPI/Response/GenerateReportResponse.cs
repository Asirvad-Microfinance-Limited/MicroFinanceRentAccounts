using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
    public class GenerateReportResponse
    {
        public GenerateReportResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }

        public List<GetReportsProperties> resulset { get; set; }
        public string header { get; set; }
        public string alignment { get; set; }
        public string Urls { get; set; }
        public string urlParams { get; set; }
        public string linkFields { get; set; }
        public int lastLevel { get; set; }
        public string chartType { get; set; }
        public string xParam { get; set; }
        public string yParam { get; set; }

    }
}
