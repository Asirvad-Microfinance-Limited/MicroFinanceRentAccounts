using DTO.MFAccountsRentAPI.Request;
using DTO.MFAccountsRentAPI.Response;

using DTO.Response;
using MFAccountsRentAPI.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace MFAccountsRentAPI.Controllers
{
    [Route("api/accounts")]
 
    public class AccountsController : ControllerBase
    {
        

        

        #region Token Validator
        /// <summary>
        /// Created on : 29-Mar-2022
        /// Created By : 100367
        /// Description: Token Validator
        /// </summary>
        [HttpGet("TokenValidator")]
        
        public ActionResult<Response<TokenValidatorResponse>> TokenValidator()
        {
            Response<TokenValidatorResponse> a = new Response<TokenValidatorResponse>();
            if (ModelState.IsValid)
            {
                string authHeader = string.Empty;
                if (Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues authToken))
                {
                    authHeader = authToken.First();
                    return AccountsBLL.Instance.TokenValidator(authHeader);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        //#region MainMenuList
        ///// <summary>
        ///// API Number :
        ///// Created on : 28-April-2020
        ///// Created By : 110060
        ///// Description: Get MainMenuList
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("mainmenulist")]
        //public ActionResult<Response<DynamicMenuListResponse>> MainMenuList([FromBody] DynamicMenuListRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return AccountsBLL.Instance.MainMenuList(request);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
        //#endregion

        #region User Session
        /// <summary>
        /// API Number : ACC003
        /// Created on : 03-apr-2023
        /// Created By : 100428
        /// Description: Get Account No and Name
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("UserSession")]
        public ActionResult<Response<UserSessionResponse>> UserSession([FromBody]UserSessionRequest request)
        {
            if (ModelState.IsValid)
            {
                string authHeader = string.Empty;
                if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                {
                    request.sessionID = authToken.First();
                    return AccountsBLL.Instance.UserSession(request);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region Login

        /// <summary>
        /// API Number : GEN017
        /// Created on : 26-Dec-2019
        /// Created By : 100101
        /// Description: Login API
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("login")]
        public ActionResult<Response<LoginResponse>> Login([FromBody]LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.Login(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion

        //#region OTP
        ///// <summary>
        ///// API Number : GEN012
        ///// Created on : 23-Dec-2019
        ///// Created By : 100101
        ///// Description: Get OTP
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>

        //[HttpPost("otp")]
        //public ActionResult<Response<OTPResponse>> OTP([FromBody] OTPRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return AccountsBLL.Instance.OTP(request);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}


        //#endregion

        #region LogOut
        /// <summary>
        /// API Number : GEN034
        /// Created on : 01-Mar-2020
        /// Created By : 100101
        /// Description: LogOut
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("logout")]
        public ActionResult<Response<LogOutResponse>> LogOut([FromBody] LogOutRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.LogOut(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region MainMenuList
        /// <summary>
        /// API Number :
        /// Created on : 28-April-2020
        /// Created By : 110060
        /// Description: Get MainMenuList
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("mainmenulist")]
        public ActionResult<Response<DynamicMenuListResponse>> MainMenuList([FromBody]DynamicMenuListRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.MainMenuList(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        

        

        //#region moduledetail
        //[HttpPost("moduledetails")]
        //public ActionResult<Response<ModuleDetailsResponse>> moduledetails([FromBody] ModuleDetailsRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return AccountsBLL.Instance.moduledetails(request);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //#endregion


        


        
        #region Branch Cash Position
        /// <summary>
        /// API Number : PROC_BRANCH_CASH_POSITION
        /// Created on : 25-Sep-2021
        /// Created By : 100367
        /// Description: Branch Cash Position
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("BranchCashPosition")]
        public ActionResult<Response<BranchCashPositionResponse>> BranchCashPosition([FromBody] BranchCashPositionRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.BranchCashPosition(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion

        

        #region GlFirstRentQueries 
        /// <summary>
        /// API Number : PROC_BRANCH_CASH_POSITION
        /// Created on : 25-Sep-2021
        /// Created By : 100367
        /// Description: Branch Cash Position
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("GlFirstRentQueries")]
        public ActionResult<Response<GlFirstRentSelectResponse>> GlFirstRentQueries([FromBody] GlFirstRentSelectRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.GlFirstRentQueries(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion

        #region RentBranchQueries 
        /// <summary>
        /// API Number : PROC_BRANCH_CASH_POSITION
        /// Created on : 25-Sep-2021
        /// Created By : 100367
        /// Description: Branch Cash Position
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("RentBranchQueries")]
        public ActionResult<Response<RentBranchQueriesResponse>> RentBranchQueries([FromBody] RentBranchQueriesRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.RentBranchQueries(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion

        #region InsertImage

        [HttpPost("insertimage")]
        public ActionResult<Response<InsertImageResponse>> InsertImage([FromBody] InsertImageRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.InsertImage(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion


        #region TmsRentLogin

        /// <summary>
        /// API Number : GEN017
        /// Created on : 26-Dec-2019
        /// Created By : 100101
        /// Description: Login API
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("TmsRentLogin")]
        public ActionResult<Response<TmsRentLoginResponse>> TmsRentLogin([FromBody] TmsRentLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.TmsRentLogin(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion

        #region Image

        [HttpPost("Images")]
        public ActionResult<Response<ImageResponse>> Images([FromBody] ImageRequest request)
        {
            if (ModelState.IsValid)
            {
                return AccountsBLL.Instance.Images(request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion

    }
}