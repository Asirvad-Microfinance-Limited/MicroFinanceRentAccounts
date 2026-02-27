using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
    public class GenerateNewReportResponse
    {
        public GenerateNewReportResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }

        public List<GetReportsProperties> resulset { get; set; }
        public List<string> paragraph { get; set; }
        public string header { get; set; }
        public string Urls { get; set; }
        public string Url_Params { get; set; }
        public string link_fields { get; set; }
        public int last_level { get; set; }
        public string view_model { get; set; }
        public string main_header { get; set; }
        public string align_status { get; set; }
        public int sub_rpt_id { get; set; }
        public string Style_Format { get; set; }
        public string DisplayImage { get; set; }
        public string buttonHeader { get; set; }
        public string ChartType { get; set; }
    }
}
