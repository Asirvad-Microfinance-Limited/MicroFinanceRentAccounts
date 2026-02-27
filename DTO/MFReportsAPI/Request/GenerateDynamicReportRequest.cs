using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
    public class GenerateDynamicReportRequest
    {
       
        public long reportId { get; set; }
        public long levelId { get; set; }
        public long userId { get; set; }
        public long branchId { get; set; }
        public string linkField { get; set; }
        //public List<GenerateDynamicReportTextBoxData> textBoxData { get; set; }        
        //public List<GenerateDynamicReportComboBoxData> comboBoxData { get; set; }
        //public List<GenerateDynamicReportDateData> dateData { get; set; }

        public string textBoxData { get; set; }
        public string comboBoxData { get; set; }
        public string dateData { get; set; }

        public long categoryId { get; set; }
        public string encryptedRqstStr { get; set; }
    }
}
