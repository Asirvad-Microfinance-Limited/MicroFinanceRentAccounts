using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
    public class AssignReportComboResponse
    {
        public AssignReportComboResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public List<AssignReportListData> reportListData { get; set; }
       
    }
}
