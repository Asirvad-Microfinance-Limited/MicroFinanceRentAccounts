using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;


namespace DTO.MFReportsAPI.Data
{
  public   class ReportDetailsProperties
    {
        public string loan_id { get; set; }
        public string application_id { get; set; }
        public DateTime loan_date { get; set; }
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string scheme_id { get; set; }
        public string loan_amount { get; set; }
    }
}
