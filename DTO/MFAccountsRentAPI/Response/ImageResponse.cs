using DTO.MFAccountsRentAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;



namespace DTO.MFAccountsRentAPI.Response
{
    public class ImageResponse
    {
        #region ImagesResponse
        /// <summary>
        /// API Number : 
        /// Created on : 03-sep-2021
        /// Created By : 100450
        /// Description: Retrieve ImageIDs from Mongo DB for various cases
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        /// 
        public ImageResponse()
        {
            isDataAvilable = false;
        }
        public bool isDataAvilable { get; set; }
        public byte[] imageString { get; set; }
        public string fileType { get; set; }

        public string encryptedResStr;
        public List<ImageData> ImageData { get; set; }
        #endregion
    }
    public class ImageStringResponse
    {
        #region ImagesResponse
        /// <summary>
        /// API Number : 
        /// Created on : 03-sep-2021
        /// Created By : 100450
        /// Description: Retrieve ImageIDs from Mongo DB for various cases
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        /// 
        public ImageStringResponse()
        {
            isDataAvilable = false;
        }
        public bool isDataAvilable { get; set; }
        public string imageString { get; set; }
        public string fileType { get; set; }

        public string encryptedResStr;


        #endregion
    }

    public class ImageData
    {
        #region Image List Response
        /// <summary>
        /// API Number : 
        /// Created on : 03-Sep-2021
        /// Created By : 100450
        /// Description: Retrieve ImageIDs from Mongo DB for various cases
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>

        public byte[] imageString { get; set; }
        public string fileType { get; set; }

        #endregion
    }
}
