using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFReportsAPI.Request
{
    public class CustomerStatementRequest
    {
        public long typeId { get; set; }
        public string parameters { get; set; }
    }
}
