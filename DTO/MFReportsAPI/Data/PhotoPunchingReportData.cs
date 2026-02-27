using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Data
{
    public class PhotoPunchingReportData1
    {
        public string branchID { get; set; }
        public string empCode { get; set; }
        public string empName { get; set; }
        public string empDesignation { get; set; }
        public string empDepartment { get; set; }
        public string empCategory { get; set; }
        public string mBranch { get; set; }
        public string eBranch { get; set; }
        public string mLocation { get; set; }
        public string eLocation { get; set; }
        public string currentDate { get; set; }
        public string mTime { get; set; }
        public string eTime { get; set; }
        public byte[] mPhoto { get; set; }
        public byte[] ePhoto { get; set; }
        public byte[] originalPhoto { get; set; }

    }

    public class PhotoPunchingReportData
    {
        public string branchID { get; set; }
        public string empCode { get; set; }
        public string empName { get; set; }
        public string empDesignation { get; set; }
        public string empDepartment { get; set; }
        public string empCategory { get; set; }
        public string mBranch { get; set; }
        public string eBranch { get; set; }
        public string mLocation { get; set; }
        public string eLocation { get; set; }
        public string currentDate { get; set; }
        public string mTime { get; set; }
        public string eTime { get; set; }
        public string mPhoto { get; set; }
        public string ePhoto { get; set; }
        public string originalPhoto { get; set; }

    }

}

