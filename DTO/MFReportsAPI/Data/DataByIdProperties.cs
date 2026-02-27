using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Data
{
   public  class DataByIdProperties
    {
        public string loan_id { get; set; }
        public string installment_no { get; set; }
        public string installment_amount { get; set; }
        public string interest_amount { get; set; }
        public string closing_balance { get; set; }
    }
}
