using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Request
{
    public class RentBranchQueriesRequest
    {
        public string branchID { get; set; }  //usersession
        public long userID { get; set; }  //usersession
        public string typeID { get; set; }
        public string? Flag { get; set; }
        public string? PagVal { get; set; }
        public string? ParVal { get; set; }
        public string? ParVal1 { get; set; }
        public string encryptedRqstStr { get; set; }
    }
}