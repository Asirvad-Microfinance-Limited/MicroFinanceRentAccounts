
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
   public  class GetNewDataReportRequest
    {
        [Required(ErrorMessage = "reportId is required")]
        public int reportId { get; set; }
        public int DtlreportId { get; set; }
        public int loan_id { get; set; }
        public string type { get; set; }

        [Required(ErrorMessage = "firm id is required")]
        //  [Range(Constants.Ints.rangeValidatorFrom_1, int.MaxValue, ErrorMessage = Invalid.firmID)]
        [JsonProperty("FirmID")]
        public int FirmID { get; set; }


        [Required(ErrorMessage = "peoduct id is required")]
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }

    }
}
