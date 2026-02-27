using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Request
{
    public class ImageRequest

    {
        #region ImageRequest
        /// <summary>
        /// API Number : 
        /// Created on : 02-sep-2020
        /// Created By : 100450
        /// Description: Retrieve ImageIDs from Mongo DB for various cases
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        /// 

        // [Required(ErrorMessage = RequireValidationMessages.recordingId)]

        public string recordingId { get; set; }

        //  [Required(ErrorMessage = RequireValidationMessages.collectionName)]

        public string collectionName { get; set; }
        public string fileType { get; set; }
        public long editFlag { get; set; }
        public string encryptedRqstStr { get; set; }
    }
    #endregion
}
