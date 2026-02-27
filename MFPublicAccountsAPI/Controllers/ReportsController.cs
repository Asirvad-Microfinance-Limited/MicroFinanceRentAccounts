using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.MFReportsAPI.Request;
using DTO.MFReportsAPI.Response;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Utilities;

namespace MFPublicAccountsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {


        //#region GenerateReport
        ///// <summary>
        ///// API Number : REP007
        ///// Created on : 16-sep-2021
        ///// Created By : 100450
        ///// Description: GenerateReport
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("generatereport")]
        //public ActionResult<Response<GenerateReportResponse>> GenerateReport([FromBody]GenerateReportRequests request)

        //{

        //    Response<GenerateReportResponse> response = new Response<GenerateReportResponse>();

        //    if (ModelState.IsValid)
        //    {

        //        try
        //        {
        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {
        //                authHeader = authToken.First();
        //                PublicConfigManager appConfigManager = new PublicConfigManager();
        //                //------Call generatereport API-----REP007        
        //                return new ApiManager().InvokePostHttpClient<Response<GenerateReportResponse>, GenerateReportRequests>(request, new AppConfigManager().getSiteUrl + "/api/reports/generatereport", authHeader).Item1;

        //            }
        //            else
        //            {
        //                return BadRequest(ModelState);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Exception exception = ex;
        //            response.status = "Exception";
        //            response.responseMsg = "Internal Server Error";
        //            response.SetExceptionError(ex.Message);

        //        }

        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return response;


        //}

        //#endregion







        #region Combofill
        /// <summary>
        /// API Number : REP009
        /// Created on : 17-Apr-2020
        /// Created By : 100101
        /// Description: Combofill
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("combofill")]
        public ActionResult<Response<ComboFillResponse>> Combofill([FromBody] ComboFillRequest request)

        {

            Response<ComboFillResponse> response = new Response<ComboFillResponse>();

            if (ModelState.IsValid)
            {

                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        //------Call combofill API-----REP009        
                        return new ApiManager().InvokePostHttpClient<Response<ComboFillResponse>, ComboFillRequest>(request, new AppConfigManager().getSiteUrl + "/api/reports/combofill", authHeader).Item1;

                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                catch (Exception ex)
                {
                    Exception exception = ex;
                    response.status = "Exception";
                    response.responseMsg = "Internal Server Error";
                    response.SetExceptionError(ex.Message);

                }

            }
            else
            {
                return BadRequest(ModelState);
            }

            return response;


        }

        #endregion




        #region DynamicReport
        /// <summary>
        /// API Number : REP011
        /// Created on : 16-sep-2021
        /// Created By : 100450
        /// Description: Get ReportDetails
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("dynamicreport")]
        public ActionResult<Response<DynamicReportResponse>> DynamicReport([FromBody] DynamicReportRequest request)

        {

            Response<DynamicReportResponse> response = new Response<DynamicReportResponse>();

            if (ModelState.IsValid)
            {

                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        //------Call dynamicreport API-----REP011      
                        return new ApiManager().InvokePostHttpClient<Response<DynamicReportResponse>, DynamicReportRequest>(request, new AppConfigManager().getSiteUrl + "/api/reports/dynamicreport", authHeader).Item1;

                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                catch (Exception ex)
                {
                    Exception exception = ex;
                    response.status = "Exception";
                    response.responseMsg = "Internal Server Error";
                    response.SetExceptionError(ex.Message);

                }

            }
            else
            {
                return BadRequest(ModelState);
            }

            return response;


        }

        #endregion

        #region GenerateDynamicReport
        /// <summary>
        /// API Number : LOS038
        /// Created on : 16-sep-2021
        /// Created By : 100450
        /// Description: GenerateDynamicReport
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("generatedynamicreport")]
        public ActionResult<Response<GenerateDynamicReportResponse>> GenerateDynamicReport([FromBody] GenerateDynamicReportRequest request)

        {

            Response<GenerateDynamicReportResponse> response = new Response<GenerateDynamicReportResponse>();

            if (ModelState.IsValid)
            {

                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        //------Call generatedynamicreport API-----REP011      
                        return new ApiManager().InvokePostHttpClient<Response<GenerateDynamicReportResponse>, GenerateDynamicReportRequest>(request, new AppConfigManager().getSiteUrl + "/api/reports/generatedynamicreport", authHeader).Item1;

                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                catch (Exception ex)
                {
                    Exception exception = ex;
                    response.status = "Exception";
                    response.responseMsg = "Internal Server Error";
                    response.SetExceptionError(ex.Message);

                }

            }
            else
            {
                return BadRequest(ModelState);
            }

            return response;


        }

        #endregion







    }
}