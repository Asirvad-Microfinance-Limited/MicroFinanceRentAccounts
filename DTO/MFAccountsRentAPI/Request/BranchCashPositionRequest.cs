using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Request
{
    //public class BranchCashPositionRequest
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

    //    public long branchId { get; set; }
    //    public long typeId { get; set; }
    //    public long c2000 { get; set; }
    //    public long c200 { get; set; }
    //    public long c500 { get; set; }
    //    public long c100 { get; set; }
    //    public long c50 { get; set; }
    //    public long c20 { get; set; }
    //    public long c10 { get; set; }
    //    public long c5 { get; set; }
    //    public long c2 { get; set; }
    //    public long c1 { get; set; }
    //    public long lateCash { get; set; }
    //    public long cashTotal { get; set; }
    //    public long sysTotal { get; set; }
    //    public long userId { get; set; }
    //    public long autherId { get; set; }
    //    //public string password { get; set; }
    //    public long coinAmt { get; set; }
    //    public string remark { get; set; }
    //    public long burglary { get; set; }
    //    public long firm { get; set; }
    //    public long safeStrong { get; set; }
    //    public long ups { get; set; }
    //    public long gps { get; set; }
    //    public long panicSwicth { get; set; }
    //    public long wirSwitch { get; set; }
    //    public long ipcam { get; set; }

    //}

    public class BranchCashPositionRequest
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
      //  public string branchID { get; set; }  //usersession
       // public long userID { get; set; }  //usersession
       // public string typeID { get; set; }
        public long branchId { get; set; }
        public long typeId { get; set; }
        public long c2000 { get; set; }
        public long c200 { get; set; }
        public long c500 { get; set; }
        public long c100 { get; set; }
        public long c50 { get; set; }
        public long c20 { get; set; }
        public long c10 { get; set; }
        public long c5 { get; set; }
        public long c2 { get; set; }
        public long c1 { get; set; }
        public long lateCash { get; set; }
        public long cashTotal { get; set; }
        public long sysTotal { get; set; }
        public long UserId { get; set; }
        public long autherId { get; set; }
        public string password { get; set; }
        public long coinAmt { get; set; }
        public string remark { get; set; }
        public string burglary { get; set; }
        public long firm { get; set; }
        public string safeStrong { get; set; }
        public string ups { get; set; }
        public string gps { get; set; }
        public string panicSwicth { get; set; }
        public string wirSwitch { get; set; }
        public string ipcam { get; set; }
        public string encryptedRqstStr { get; set; }


    }
}
