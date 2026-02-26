using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Data
{
   public  class QueryNewReportProperties
    {
        public string query { get; set; }
        public string header { get; set; }
        public string url { get; set; }
        public string Url_Params { get; set; }
        public string link_fields { get; set; }
        public string view_model { get; set; }
        public string main_header { get; set; }
        public string align_status { get; set; }
        public int sub_rpt_id { get; set; }
        public string Style_Format { get; set; }
        public int querry_format { get; set; }
        public int report_dtl_id { get; set; }
        // public string parameters { get; set; }
    }
}
