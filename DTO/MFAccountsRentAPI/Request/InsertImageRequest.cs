using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Request
{
    public class InsertImageRequest
    {
        public long typeId { get; set; }
        public byte[] image { get; set; }
        public string collectionName { get; set; }
        public string fileName { get; set; }
        public string recordingId { get; set; }
        public string imageType { get; set; }


    }
}
