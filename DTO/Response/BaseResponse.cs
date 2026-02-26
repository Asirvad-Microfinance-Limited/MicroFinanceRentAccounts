using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class BaseResponse
    {
        public string trackerId { get; set; }
        //public string response_code { get; set; }
        //public string response_msg { get; set; }
        //public string env { get; set; }
        //public string transaction_status { get; set; }
        //public string request_timestamp { get; set; }
        //public string response_timestamp { get; set; }
    }
    //public class PayUBaseResponse
    //{
    //    public PayUBaseResponse()
    //    {
    //        status = new PayUResponseStatus();
    //        status.flag = ProcessStatus.failed;
    //        status.code = APIStatus.failed;
    //        status.message = "Failed";
    //        status.timeStamp = DateTime.Now.ToString(Constants.Strings.dateTimeFormat);
    //    }
    //    public PayUResponseStatus status { get; set; }
    //}
    //public class PayUResponseStatus
    //{
    //    public ProcessStatus flag { get; set; }
    //    public APIStatus code { get; set; }
    //    public string message { get; set; }
    //    public string timeStamp { get; set; }
    //}

}
