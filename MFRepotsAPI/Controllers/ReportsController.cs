using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base;
using DTO.MFReportsAPI.Request;
using DTO.MFReportsAPI.Response;
using DTO.Response;
using MFReportsAPI.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MFReportsAPI.Controllers
{
    [Route("api/Reports")]   
    public class ReportsController : BaseController
    {       

        #region ReportDetails
        /// <summary>
        /// API Number : REP001
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: Get ReportDetails
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpGet("reportdetails")]
        public ActionResult<Response<ReportsDetailsResponse>> ReportDetails()
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.ReportDetails();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region GenerateReport
        /// <summary>
        /// API Number : REP007
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: GenerateReport
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("generatereport")]
        public ActionResult<Response<GenerateReportResponse>> GenerateReport([FromBody]GenerateReportRequests request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.GenerateReport(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region ReportsData
        /// <summary>
        /// API Number : REP002
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: Get ReportDetailsData By ID
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("reportsdata")]
        public ActionResult<Response<GenerateReportResponse>> ReportsData([FromBody]ReportsDatarequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.ReportsData(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

     
         #region ReportsDrillDown
        /// <summary>
        /// API Number : REP003
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: Get Report drill Down
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("reportsdrilldown")]
        public ActionResult<Response<GenerateReportResponse>> ReportsDrillDown([FromBody]DrilldownReportsRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.ReportsDrillDown(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion


        //#region ReportsLevelThree
        ///// <summary>
        ///// API Number : REP006
        ///// Created on : 28-Jul-2021
        ///// Created By : 100367
        ///// Description: Get ReportsLevelThree
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("reportslevelthree")]
        //public ActionResult<Response<GenerateReportResponse>> ReportsLevelThree([FromBody]ReportsDatarequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return ReportsBLL.Instance.ReportsLevelThree(request);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
        //#endregion

       

      

       
    
        // #region GenerateNewReport
        ///// <summary>
        ///// API Number : REP009
        ///// Created on : 28-Jul-2021
        ///// Created By : 100367
        ///// Description: GeneratenewReport
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("generatenewreport")]
        //public ActionResult<Response<GenerateNewReportResponse>> GenerateNewReport([FromBody]GetNewDataReportRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return ReportsBLL.Instance.GenerateNewReport(request);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
        //#endregion



   


        #region GeneratAllReport
        /// <summary>
        /// API Number : REP009
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: Combofill
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("generateallreport")]
        public ActionResult<Response<GenerateAllReportResponse>> GeneratAllReport([FromBody]GetNewDataReportRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.GeneratAllReport(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion


    
  
        #region DynamicReport
        /// <summary>
        /// API Number : REP011
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: Get ReportDetails
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("dynamicreport")]
        public ActionResult<Response<DynamicReportResponse>> DynamicReport([FromBody]DynamicReportRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.DynamicReport(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion


       

            #region GenerateDynamicReport
        /// <summary>
        /// API Number : LOS038
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: GenerateDynamicReport
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("generatedynamicreport")]
        public ActionResult<Response<GenerateDynamicReportResponse>> GenerateDynamicReport([FromBody]GenerateDynamicReportRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.GenerateDynamicReport(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region Combofill
        /// <summary>
        /// API Number : REP009
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: Combofill
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("combofill")]
        public ActionResult<Response<ComboFillResponse>> Combofill([FromBody]ComboFillRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.Combofill(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion


     

        #region CustomerStatement
        /// <summary>
        /// API Number : REP009
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: CustomerStatement
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("customerstatement")]
        public ActionResult<Response<CustomerStatementResponse>> CustomerStatement([FromBody]CustomerStatementRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.CustomerStatement(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region AssignReportComboFill
        /// <summary>
        /// API Number : REP012
        /// Created on :28-Jul-2021
        /// Created By : 100367
        /// Description: AssignReportComboFill
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("assignreportcombofill")]
        public ActionResult<Response<AssignReportComboResponse>> AssignReportComboFill([FromBody]AssignReportComboRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.AssignReportComboFill(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region AssignReport
        /// <summary>
        /// API Number : 
        /// Created on :28-Jul-2021
        /// Created By : 100367
        /// Description: AssignReport
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("assignreport")]
        public ActionResult<Response<AssignReportResponse>> AssignReport([FromBody]AssignReportRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.AssignReport(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

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
        [HttpPost("photopunchreport")]
        public ActionResult<Response<PhotoPunchingReportResponse>> PhotoPunch([FromBody]PhotoPunchingReportRequest request)
        {
            if (ModelState.IsValid)
            {
                return ReportsBLL.Instance.PhotoPunch(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion
    }
}
