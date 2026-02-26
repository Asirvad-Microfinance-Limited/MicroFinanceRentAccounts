using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
    public class PhotoPunchingReportRequest
    {
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public long employeeCode { get; set; }
        public long branchId { get; set; }
        

    }
}