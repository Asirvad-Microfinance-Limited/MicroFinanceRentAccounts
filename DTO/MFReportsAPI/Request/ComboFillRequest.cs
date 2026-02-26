using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
    //public  class ComboFillRequest
    // {
    //     public int comboId { get; set; }
    //     public int reportId { get; set; }
    //     public int flag { get; set; }// 1 if 1st combo and 2nd combo depends 
    //     public string id { get; set; }
    //     public int productId { get; set; }
    //     public int firmId { get; set; }
    // }


    public class ComboFillRequest
    {
        public long userId { get; set; }
        public long branchId { get; set; }
        public long accessLevelId { get; set; }
        public string query { get; set; }
        public string encryptedRqstStr { get; set; }

    }
}
