using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Response
{
    //public class BranchCashPositionResponse
    //{
    //    /// <summary>
    //    /// API Number : PROC_BRANCH_CASH_POSITION
    //    /// Created on : 25-Sep-2021
    //    /// Created By : 100367
    //    /// Description: Branch Cash Position
    //    /// Modify Date:
    //    /// Modify By  : 
    //    /// Description:
    //    /// </summary>
    //    public BranchCashPositionResponse()
    //    {
    //        isDataAvailable = false;
    //    }
    //    public bool isDataAvailable { get; set; }
    //    public string message { get; set; } //added for denomination entry
    //    public long sysAmount { get; set; }

    //    public string Token { get; set; }
    //}

    public class BranchCashPositionResponse
    {
        /// <summary>
        /// API Number : PROC_BRANCH_CASH_POSITION
        /// Created on : 25-Sep-2021
        /// Created By : 100367
        /// Description: Branch Cash Position
        /// Modify Date:
        /// Modify By  :
        /// Description:
        /// </summary>
        public BranchCashPositionResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }
        public string message { get; set; } //added for denomination entry
        public long sysAmount { get; set; }

        public string mobileNumber { get; set; }
        public string encryptedResStr { get; set; }

       // public string token { get; set; }

    }

}
