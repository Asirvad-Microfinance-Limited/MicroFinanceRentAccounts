using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
   public class AssignReportRequest
    {
        public long reportId { get; set; }
        public long empCode { get; set; }
        public long userId { get; set; }
    }
}
