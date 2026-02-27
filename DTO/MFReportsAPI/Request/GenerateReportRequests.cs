using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
  public   class GenerateReportRequests
    {
        [Required(ErrorMessage = "reportId is required")]


        public int reportId { get; set; }
        public string type { get; set; }
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string param3 { get; set; }
        public string param4 { get; set; }
        public string param5 { get; set; }

        public string param6 { get; set; }
        public string param7 { get; set; }
        public int firmId { get; set; }
        public int productId { get; set; }
    }
}
