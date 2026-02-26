using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Data
{
  public   class ReportsDetailsData
    { 
        public string reportId { get; set; }      
        public string reportName { get; set; }  
        public string reportParm1 { get; set; }     
        public string reportParm2 { get; set; }  
        public string reportParm22 { get; set; }   
        public string reportParm3 { get; set; }      
        public string reportParm41 { get; set; }      
        public string reportParm42 { get; set; }      
        public string reportParm5 { get; set; }      
        public string status { get; set; }     
        public string updatedDate { get; set; }
        public string flag { get; set; }
        public string buttonHeader { get; set; }
        public string chartType { get; set; }
    }
}
