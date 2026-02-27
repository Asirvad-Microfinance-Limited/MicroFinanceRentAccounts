using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
    public class AssignReportResponse
    {
        public AssignReportResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }

        public string message { get; set; }
    }
}
