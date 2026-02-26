using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
    public class ReportDetailsResponse
    {
        public List<ReportDetailsProperties> resultset { get; set; }
        public List<ReportPropertyNames> PropertyTypes { get; set; }
        public List<string> Urls { get; set; }
    }
}
