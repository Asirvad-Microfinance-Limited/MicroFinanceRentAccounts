using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
   public class DrilldownReportsRequest
    {
        public string type { get; set; }
        public string reportId { get; set; }
        public string levelNo { get; set; }
        public string parms { get; set; }
        public string linkField { get; set; }
        public string link_value { get; set; }
        public int productId { get; set; }
        public int firmId { get; set; }
    }
}
