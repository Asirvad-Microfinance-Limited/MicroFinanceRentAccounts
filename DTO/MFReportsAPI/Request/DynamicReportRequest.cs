using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
   public  class DynamicReportRequest
    {

      
        public long accessLevelId { get; set; }
        public long userId { get; set; }
        public long branchId { get; set; }
        public long moduleId { get; set; }
       // public string encryptedRqstStr { get; set; }
    }
}
