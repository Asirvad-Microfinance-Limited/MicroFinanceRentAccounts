using DTO.MFReportsAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Response
{
    public class PhotoPunchingReportResponse
    {
        public PhotoPunchingReportResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }

        public List<PhotoPunchingReportData> photoPunchingList { get; set; }
    }
}
