using DTO.MFReportsAPI.Request;
using DTO.MFReportsAPI.Response;
using DTO.Response;
using MFReportsAPI.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFReportsAPI.BLL
{
    #region PhotoPunchReport
    /// <summary>
    /// API Number : REP014
    /// Created on : 28-Jul-2021
    /// Created By : 100367
    /// Description: PhotoPunchReport
    /// Modify Date:
    /// Modify By  : 
    /// Description:
    /// </summary>
    public class PhotoPunchingReportBLL
    {
        #region ReportsBLL
        private readonly static Lazy<PhotoPunchingReportBLL> m_instance;

        public static PhotoPunchingReportBLL Instance
        {
            get
            {
                return PhotoPunchingReportBLL.m_instance.Value;
            }
        }

        static PhotoPunchingReportBLL()
        {
            PhotoPunchingReportBLL.m_instance = new Lazy<PhotoPunchingReportBLL>(() => new PhotoPunchingReportBLL());
        }

        #endregion
        //public Response<PhotoPunchingReportResponse> PhotoPunch(PhotoPunchingReportRequest request)
        //{
        //    PhotoPunchingReportResponse photoPunchingReportResponse = new PhotoPunchingReportResponse();
        //    Response<PhotoPunchingReportResponse> response = new Response<PhotoPunchingReportResponse>();
        //    try
        //    {
        //        photoPunchingReportResponse = new PhotoPunchingReportDataSource().PhotoPunch(request);

        //        if (photoPunchingReportResponse.isDataAvailable)
        //        {
        //            response.Data = photoPunchingReportResponse;
        //            response.status = ResponseTypeContants.SUCCESS;
        //            response.apiStatus = ApiStatusConstants.COMPLETED;
        //            response.responseMsg = ResponseTypeContants.SUCCESS;
        //        }
        //        else
        //        {
        //            response.status = ResponseTypeContants.FAIL;
        //            response.apiStatus = ApiStatusConstants.COMPLETED;
        //            response.responseMsg = "No data found";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Exception exception = ex;
        //        response.status = "Exception";
        //        response.responseMsg = "Internal Server Error";
        //        response.SetExceptionError(ex.Message);

        //    }

        //    return response;
        //}
    }
    #endregion
}
