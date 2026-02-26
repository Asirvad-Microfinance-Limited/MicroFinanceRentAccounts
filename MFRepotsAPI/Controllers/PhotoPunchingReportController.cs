using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.MFReportsAPI.Request;
using DTO.MFReportsAPI.Response;
using DTO.Response;
using MFReportsAPI.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MFReportsAPI.Controllers
{
    [Route("api/[PhotoPunchingReport]")]
    [ApiController]
    public class PhotoPunchingReportController : ControllerBase
    {
        //#region PhotoPunchReport
        ///// <summary>
        ///// API Number : REP014
        ///// Created on : 28-Jul-2021
        ///// Created By : 100367
        ///// Description: PhotoPunchReport
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("photopunch")]
        //public ActionResult<Response<PhotoPunchingReportResponse>> PhotoPunch([FromBody]PhotoPunchingReportRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return PhotoPunchingReportBLL.Instance.PhotoPunch(request);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
        //#endregion
    }
}