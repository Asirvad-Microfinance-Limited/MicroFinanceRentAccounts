using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Data
{
   public  class DynamicReportData
    {    

        public string reportId { get; set; }
        public string reportName { get; set; }
        public string comboId { get; set; }
        public string comboQuery { get; set; }
        public string dateField { get; set; }
        public string maxLevel { get; set; }
        public string textFieldId { get; set; }
        public string textFieldCaption { get; set; }

    }
}
