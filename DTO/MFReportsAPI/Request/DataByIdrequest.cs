using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
    public class ReportsDatarequest
    {
        public string typeId { get; set; }
        public string reportId { get; set; }    
        public string parms { get; set; }
    }
}
