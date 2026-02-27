using System;
using System.Linq;
using DTO.MFAccountsRentAPI.Request;
using DTO.MFAccountsRentAPI.Response;
using DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Utilities;
using Base;
using Newtonsoft.Json;
using System.Net;
using ConnectionHandler;
using System.Globalization;



namespace MFPublicRentAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        


        

        

        

        //#region Images
        ///// <summary>
        ///// API Number : 
        ///// Created on : 03-sep-2021
        ///// Created By : 100450
        ///// Description: Get Images from Mongo DB
        ///// </summary>
        //[HttpPost("images")]
        //public ActionResult<Response<ImageResponse>> TreasurySelectQueries([FromBody] ImageRequest request)
        //{

        //    Response<ImageResponse> response = new Response<ImageResponse>();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))

        //            {
        //                var result = new ConnectionHandler.Authorization(authHeader);

        //                if (result.Status == "0")
        //                {
        //                    response.status = ResponseTypeContants.AUTHERROR;
        //                    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
        //                    response.responseMsg = result.Message;
        //                    return response;
        //                }
        //                PublicConfigManager appConfigManager = new PublicConfigManager();

        //                string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
        //                request = JsonConvert.DeserializeObject<ImageRequest>(DecStr);

        //                //string encryptedRqstStr = request.encryptedRqstStr;

        //                //if (!string.IsNullOrEmpty(encryptedRqstStr))
        //                //{
        //                //    string DecStr = new RequestEncryption().APIDecryptionAES(encryptedRqstStr);

        //                //    if (!string.IsNullOrEmpty(DecStr))
        //                //    {
        //                //        request = JsonConvert.DeserializeObject<ImageRequest>(DecStr);
        //                //    }
        //                //    else
        //                //    {
        //                //        // Handle case where decryption returns null or empty string
        //                //        response.responseMsg = "Decryption returned an empty string.";
        //                //    }
        //                //}
        //                //else
        //                //{
        //                //    // Handle case where encrypted string is null or empty
        //                //    response.responseMsg = "Decryption returned an empty string.";
        //                //}

        //                response = new ApiManager().InvokePostHttpClient<Response<ImageResponse>, ImageRequest>(request, new AppConfigManager().getBaseUrl + "api/accounts/images", authHeader).Item1;



        //                if (response.status == "SUCCESS")
        //                {
        //                    string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
        //                    response.Data = new ImageResponse();
        //                    response.Data.encryptedResStr = EncStr;
        //                }

        //                else
        //                {
        //                    return BadRequest(ModelState);
        //                }
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
        


        


        

        

        


        //#region ConveyanceConfirm
        ///// <summary>
        ///// API Number : proc_conveyance_confirm_data
        ///// Created on : 17-12-2021
        ///// Created By : 100450
        ///// Description: ConveyanceQueries
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("ConveyanceConfirm")]
        //public ActionResult<Response<ConveyanceConfirmResponse>> ConveyanceConfirm([FromBody]ConveyanceConfirmRequest request)
        //{
        //    Response<ConveyanceConfirmResponse> response = new Response<ConveyanceConfirmResponse>();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {
        //                authHeader = authToken.First();
        //                PublicConfigManager appConfigManager = new PublicConfigManager();
        //                return new ApiManager().InvokePostHttpClient<Response<ConveyanceConfirmResponse>, ConveyanceConfirmRequest>(request, new AppConfigManager().getBaseUrl + "api/accounts/ConveyanceConfirm", authHeader).Item1;
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

        
        

        

        //#region MainMenuList    
        ///// <summary>
        ///// API Number :
        ///// Created on : 28-April-2020
        ///// Created By : 110060
        ///// Description: Get MainMenuList
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:  commented by leo for vapt
        ///// </summary>
        //[HttpPost("mainmenulist")]
        //public ActionResult<Response<DynamicMenuListResponse>> MainMenuList([FromBody] DynamicMenuListRequest request)
        //{

        //    Response<DynamicMenuListResponse> response = new Response<DynamicMenuListResponse>();

        //    if (ModelState.IsValid)
        //    {

        //        try
        //        {
        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {
        //                authHeader = authToken.First();

        //                //var result = new ConnectionHandler.Authorization(authHeader);

        //                //if (result.Status == "0")
        //                //{
        //                //    response.status = ResponseTypeContants.AUTHERROR;
        //                //    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
        //                //    response.responseMsg = result.Message;
        //                //    return response;
        //                //}

        //                PublicConfigManager appConfigManager = new PublicConfigManager();

        //                string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
        //                request = JsonConvert.DeserializeObject<DynamicMenuListRequest>(DecStr);
        //                //------Call usermenuslist API--       
        //                response = new ApiManager().InvokePostHttpClient<Response<DynamicMenuListResponse>, DynamicMenuListRequest>(request, appConfigManager.getaccountsApiUrl + "/api/accounts/mainmenulist", authHeader).Item1;
        //               // response = new ApiManager().InvokePostHttpClient<Response<PayratQueryResponse>, PayratQueryRequest>(request, new AppConfigManager().getBaseUrl + "api/accounts/PayratQueries", authHeader).Item1;

        //                if (response.status == "SUCCESS")
        //                {
        //                    string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
        //                    response.Data = new DynamicMenuListResponse();
        //                    response.Data.encryptedResStr = EncStr;
        //                }

        //                return response;
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


        #region User Session
        /// <summary>
        /// API Number : ACC003
        /// Created on : 03-Apr-2023
        /// Created By : 100428
        /// Description: User Session and token Creating
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("UserSession")]
        public ActionResult<Response<UserSessionResponse>> UserSession([FromBody]UserSessionRequest request)
        {
            Response<UserSessionResponse> response = new Response<UserSessionResponse>();

            if (ModelState.IsValid)
            {
                try
                {
                    //    string authHeader = string.Empty;
                    //    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    //    {
                    //        authHeader = authToken.First();

                    //        PublicConfigManager appConfigManager = new PublicConfigManager();

                    //        return new ApiManager().InvokePostHttpClient<Response<UserSessionResponse>, UserSessionRequest>(request, appConfigManager.getaccountsApiUrl + "api/accounts/UserSession", authHeader).Item1;
                    //    }
                    //    else
                    //    {
                    //        return BadRequest(ModelState);
                    //    }
                    //}
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();

                        var result = new ConnectionHandler.Authorization(authHeader);
                       

                        PublicConfigManager appConfigManager = new PublicConfigManager();

                        string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                        request = JsonConvert.DeserializeObject<UserSessionRequest>(DecStr);
                       // response = new ApiManager().InvokePostHttpClient<Response<PrPaymentAtBranchResponse>, PrPaymentAtBranchRequest>(request, new AppConfigManager().getBaseUrl + "api/accounts/PrPaymentAtBranch", authHeader).Item1;
                        response= new ApiManager().InvokePostHttpClient<Response<UserSessionResponse>, UserSessionRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/UserSession", authHeader).Item1;

                        if (response.status == "SUCCESS")
                        {
                            string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                            response.Data = new UserSessionResponse();
                            response.Data.encryptedResStr = EncStr;
                           
                        }
                        //return response;
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

        #region Login
        /// <summary>
        /// API Number : PROC_LOGIN
        /// Created on : 12-Apr-2022
        /// Created By : 100367
        /// Description: Login API
        /// </summary>
        [HttpPost("Login")]
        public ActionResult<Response<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            Response<LoginResponse> response = new Response<LoginResponse>();
            if (ModelState.IsValid)
            {
                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First(); 
                       
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                        request = JsonConvert.DeserializeObject<LoginRequest>(DecStr);
                        request.apiKey = authHeader;
                        //------Call Login API
                        response = new ApiManager().InvokePostHttpClient<Response<LoginResponse>, LoginRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/Login", null).Item1;

                        if (response.status == "SUCCESS")
                        {
                            string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                            response.Data = new LoginResponse();
                            response.Data.encryptedResStr = EncStr;
                        }

                        return response;
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

        //#region Otp
        /// <summary>
        /// API Number : PublicCUS002
        /// Created on : 04-Jan-2020
        /// Created By : 100101
        /// Description: Get Otp
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        //[HttpPost("otp")]
        //public ActionResult<Response<OTPResponse>> Otp([FromBody] OTPRequest request)
        //{
        //    Response<OTPResponse> response = new Response<OTPResponse>();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {
        //                authHeader = authToken.First();
        //                var result = new ConnectionHandler.Authorization(authHeader);

        //                if (result.Status == "0")
        //                {
        //                    response.status = ResponseTypeContants.AUTHERROR;
        //                    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
        //                    response.responseMsg = result.Message;
        //                    return response;
        //                }
        //                PublicConfigManager appConfigManager = new PublicConfigManager();
        //                string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
        //                request = JsonConvert.DeserializeObject<OTPRequest>(DecStr);
        //                ------Call Otp API
        //                response = new ApiManager().InvokePostHttpClient<Response<OTPResponse>, OTPRequest>(request, appConfigManager.getaccountsApiUrl + "api/accounts/OTP", null).Item1;
        //                if (response.status == "SUCCESS")
        //                {
        //                    string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
        //                    response.Data = new OTPResponse();
        //                    response.Data.encryptedResStr = EncStr;
        //                }

        //                return response;
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
        public ActionResult<Response<LogOutResponse>> LogOut([FromBody]LogOutRequest request)
        {

            Response<LogOutResponse> response = new Response<LogOutResponse>();
            if (ModelState.IsValid)
            {

                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();
                        //request.token = authHeader;
                        var result = new ConnectionHandler.Authorization(authHeader);

                        if (result.Status == "0")
                        {
                            response.status = ResponseTypeContants.AUTHERROR;
                            response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
                            response.responseMsg = result.Message;
                            return response;
                        }
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                        request = JsonConvert.DeserializeObject<LogOutRequest>(DecStr);
                        //------Call logout API
                        response = new ApiManager().InvokePostHttpClient<Response<LogOutResponse>, LogOutRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/logout", authHeader).Item1;

                        if (response.status == "SUCCESS")
                        {
                            string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                            response.Data = new LogOutResponse();
                            response.Data.encryptedResStr = EncStr;
                        }

                        return response;
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
        public ActionResult<Response<DynamicMenuListResponse>> MainMenuList([FromBody] DynamicMenuListRequest request)
        {

            Response<DynamicMenuListResponse> response = new Response<DynamicMenuListResponse>();

            if (ModelState.IsValid)
            {

                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();
                        //var result = new ConnectionHandler.Authorization(authHeader);

                        //if (result.Status == "0")
                        //{
                        //    response.status = ResponseTypeContants.AUTHERROR;
                        //    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
                        //    response.responseMsg = result.Message;
                        //    return response;
                        //}
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                        request = JsonConvert.DeserializeObject<DynamicMenuListRequest>(DecStr);


                        //------Call usermenuslist API--       

                        response = new ApiManager().InvokePostHttpClient<Response<DynamicMenuListResponse>, DynamicMenuListRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/mainmenulist", null).Item1;
                        if (response.status == "SUCCESS")
                        {
                            string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                            response.Data = new DynamicMenuListResponse();
                            response.Data.encryptedResStr = EncStr;
                        }

                        return response;
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







        //#region moduledetails
        //[HttpPost("moduledetails")]
        //public ActionResult<Response<ModuleDetailsResponse>> moduledetails([FromBody] ModuleDetailsRequest request)
        //{
        //    Response<ModuleDetailsResponse> response = new Response<ModuleDetailsResponse>();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {
        //                authHeader = authToken.First();

        //                string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
        //                request = JsonConvert.DeserializeObject<ModuleDetailsRequest>(DecStr);

        //                PublicConfigManager appConfigManager = new PublicConfigManager();
        //                UserSessionRequest AuthReq = new UserSessionRequest();
        //                AuthReq.typeID = request.typeID;
        //                AuthReq.userID = request.userID;
        //                AuthReq.branchID = request.branchID;


        //                var AuthRes = new ApiManager().InvokePostHttpClient<Response<UserSessionResponse>, UserSessionRequest>(AuthReq, appConfigManager.getaccountsApiUrl + "api/accounts/UserSession", authHeader).Item1;
        //                if (AuthRes.status == "SUCCESS")
        //                {

        //                    response = new ApiManager().InvokePostHttpClient<Response<ModuleDetailsResponse>, ModuleDetailsRequest>(request, appConfigManager.getaccountsApiUrl + "api/Accounts/moduledetails", authHeader).Item1;

        //                    if (response.status == "SUCCESS")
        //                    {
        //                        response.Data.token = AuthRes.Data.tokenId;
        //                        string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
        //                        response.Data = new ModuleDetailsResponse();
        //                        response.Data.encryptedResStr = EncStr;

        //                    }
        //                    else
        //                    {
        //                        response.status = "FAILED";

        //                    }

        //                }
        //                else
        //                {
        //                    response.status = "FAILED";
        //                    response.responseMsg = AuthRes.responseMsg;

        //                }

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






        //#region Branch Cash Position
        ///// <summary>
        ///// API Number : PROC_BRANCH_CASH_POSITION
        ///// Created on : 25-Sep-2021
        ///// Created By : 100367
        ///// Description: Branch Cash Position
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("BranchCashPosition")]
        //public ActionResult<Response<BranchCashPositionResponse>> BranchCashPosition([FromBody] BranchCashPositionRequest request)
        //{
        //    Response<BranchCashPositionResponse> response = new Response<BranchCashPositionResponse>();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {
        //                authHeader = authToken.First();

        //                PublicConfigManager appConfigManager = new PublicConfigManager();
        //                return new ApiManager().InvokePostHttpClient<Response<BranchCashPositionResponse>, BranchCashPositionRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/BranchCashPosition", authHeader).Item1;
        //            }
        //               //var AuthRes = new ApiManager().InvokePostHttpClient<Response<UserSessionResponse>, UserSessionRequest>(AuthReq, appConfigManager.getaccountsApiUrl + "api/accounts/UserSession", authHeader).Item1;


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
            Response<BranchCashPositionResponse> response = new Response<BranchCashPositionResponse>();
            if (ModelState.IsValid)
            {
                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();
                        //var result = new ConnectionHandler.Authorization(authHeader);

                        //if (result.Status == "0")
                        //{
                        //    response.status = ResponseTypeContants.AUTHERROR;
                        //    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
                        //    response.responseMsg = result.Message;
                        //    return response;
                        //}

                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                        request = JsonConvert.DeserializeObject<BranchCashPositionRequest>(DecStr);

                        response = new ApiManager().InvokePostHttpClient<Response<BranchCashPositionResponse>, BranchCashPositionRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/BranchCashPosition", authHeader).Item1;
                        if (response.status == "SUCCESS")
                        {
                            string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                            response.Data = new BranchCashPositionResponse();
                            response.Data.encryptedResStr = EncStr;
                        }

                        return response;


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


        //#region  GLFirstRent Queries
        ///// <summary>
        ///// API Number :
        ///// Created on : 28-April-2020
        ///// Created By : 110060
        ///// Description: Get MainMenuList
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("GlFirstRentQueries")]
        //public ActionResult<Response<GlFirstRentSelectResponse>> GlFirstRentQueries([FromBody] GlFirstRentSelectRequest request)
        //{

        //    Response<GlFirstRentSelectResponse> response = new Response<GlFirstRentSelectResponse>();

        //    if (ModelState.IsValid)
        //    {

        //        try
        //        {
        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {
        //                authHeader = authToken.First();
        //                var result = new ConnectionHandler.Authorization(authHeader);

        //                if (result.Status == "0")
        //                {
        //                    response.status = ResponseTypeContants.AUTHERROR;
        //                    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
        //                    response.responseMsg = result.Message;
        //                    return response;
        //                }
        //                PublicConfigManager appConfigManager = new PublicConfigManager();
        //                string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
        //                request = JsonConvert.DeserializeObject<GlFirstRentSelectRequest>(DecStr);


        //                //------Call usermenuslist API--       

        //                response = new ApiManager().InvokePostHttpClient<Response<GlFirstRentSelectResponse>, GlFirstRentSelectRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/GlFirstRentQueries", null).Item1;
        //                if (response.status == "SUCCESS")
        //                {
        //                    string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
        //                    response.Data = new GlFirstRentSelectResponse();
        //                    response.Data.encryptedResStr = EncStr;
        //                }

        //                return response;
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



        //#region GlFirstRentQueries
        ///// <summary>
        ///// API Number : proc_payrat_queries
        ///// Created on : 30-Jul-2021
        ///// Created By : 100450
        ///// Description: Payrat Queries
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //[HttpPost("GlFirstRentQueries")]
        //public ActionResult<Response<GlFirstRentSelectResponse>> GlFirstRentQueries([FromBody] GlFirstRentSelectRequest request)
        //{

        //    Response<GlFirstRentSelectResponse> response = new Response<GlFirstRentSelectResponse>();

        //    if (ModelState.IsValid)

        //    {
        //        try
        //        {
        //            string authHeader = string.Empty;
        //            //string DecStrs = JsonConvert.SerializeObject(Request.Headers.TryGetValue("Authorization", out StringValues authToken));
        //            //string DecStrss = JsonConvert.SerializeObject(Request.Headers.TryGetValue("Authorization", out StringValues authToken));
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {


        //                authHeader = authToken.First();
        //                var result = new ConnectionHandler.Authorization(authHeader);

        //                if (result.Status == "0")
        //                {
        //                    response.status = ResponseTypeContants.AUTHERROR;
        //                    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
        //                    response.responseMsg = result.Message;
        //                    return response;
        //                }
        //                string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);

        //                GlFirstRentSelectRequest req = !string.IsNullOrEmpty(DecStr)
        //                    ? JsonConvert.DeserializeObject<GlFirstRentSelectRequest>(DecStr) ?? request
        //                    : request;

        //                // request = JsonConvert.DeserializeObject<GlFirstRentSelectRequest>(DecStr);
        //                PublicConfigManager appConfigManager = new PublicConfigManager();
        //                UserSessionRequest AuthReq = new UserSessionRequest();
        //                AuthReq.typeID = req.typeID;
        //                AuthReq.userID = req.userID;
        //                AuthReq.branchID = req.branchID;


        //                var AuthRes = new ApiManager().InvokePostHttpClient<Response<UserSessionResponse>, UserSessionRequest>(AuthReq, appConfigManager.getaccountsRentApiUrl + "api/accounts/UserSession", authHeader).Item1;
        //                if (AuthRes.status == "SUCCESS")
        //                {


        //                    response = new ApiManager().InvokePostHttpClient<Response<GlFirstRentSelectResponse>, GlFirstRentSelectRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/GlFirstRentQueries", authHeader).Item1;
        //                    if (response.status == "SUCCESS")
        //                    {
        //                        response.Data.token = AuthRes.Data?.tokenId;
        //                        string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
        //                        response.Data = new GlFirstRentSelectResponse { encryptedResStr = EncStr, token = response.Data.token, isDataAvailable = response.Data.isDataAvailable, Message = response.Data.Message, QueryResult = response.Data.QueryResult };


        //                        /*response.Data = new GlFirstRentSelectResponse();
        //                        response.Data.encryptedResStr = EncStr;*/
        //                    }
        //                    //return response;
        //                    else
        //                    {
        //                        response.status = "FAILED";

        //                    }

        //                }
        //                else
        //                {
        //                    response.status = "FAILED";
        //                    response.responseMsg = AuthRes.responseMsg;

        //                }
        //                //response = new ApiManager().InvokePostHttpClient<Response<PayratQueryResponse>, PayratQueryRequest>(request, appConfigManager.getaccountsApiUrl + "api/accounts/PayratQueries", authHeader).Item1;
        //                //response.Data.token = AuthRes.Data.tokenId;
        //            }


        //            //string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
        //            //request = JsonConvert.DeserializeObject<PayratQueryRequest>(DecStr);

        //            //response = new ApiManager().InvokePostHttpClient<Response<PayratQueryResponse>, PayratQueryRequest>(request, new AppConfigManager().getBaseUrl + "api/accounts/PayratQueries", authHeader).Item1;
        //            //if (response.status == "SUCCESS")
        //            //{

        //            //    string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
        //            //    response.Data = new PayratQueryResponse();
        //            //    response.Data.encryptedResStr = EncStr;
        //            //}
        //            ////return response;

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



        #region GlFirstRentQueries
        /// <summary>
        /// API Number : proc_payrat_queries
        /// Created on : 30-Jul-2021
        /// Created By : 100450
        /// Description: Payrat Queries
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("GlFirstRentQueries")]
        public ActionResult<Response<GlFirstRentSelectResponse>> GlFirstRentQueries([FromBody] GlFirstRentSelectRequest request)
        {

            Response<GlFirstRentSelectResponse> response = new Response<GlFirstRentSelectResponse>();

            if (ModelState.IsValid)

            {
                try
                {
                    string authHeader = string.Empty;
                    //string DecStrs = JsonConvert.SerializeObject(Request.Headers.TryGetValue("Authorization", out StringValues authToken));
                    //string DecStrss = JsonConvert.SerializeObject(Request.Headers.TryGetValue("Authorization", out StringValues authToken));
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {


                        authHeader = authToken.First();
                        var result = new ConnectionHandler.Authorization(authHeader);

                        if (result.Status == "0")
                        {
                            response.status = ResponseTypeContants.AUTHERROR;
                            response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
                            response.responseMsg = result.Message;
                            return response;
                        }
                        string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                        request = JsonConvert.DeserializeObject<GlFirstRentSelectRequest>(DecStr);
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        UserSessionRequest AuthReq = new UserSessionRequest();
                        AuthReq.typeID = request.typeID;
                        AuthReq.userID = request.userID;
                        AuthReq.branchID = request.branchID;


                        var AuthRes = new ApiManager().InvokePostHttpClient<Response<UserSessionResponse>, UserSessionRequest>(AuthReq, appConfigManager.getaccountsRentApiUrl + "api/accounts/UserSession", authHeader).Item1;
                        if (AuthRes.status == "SUCCESS")
                        {


                            response = new ApiManager().InvokePostHttpClient<Response<GlFirstRentSelectResponse>, GlFirstRentSelectRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/GlFirstRentQueries", authHeader).Item1;
                            if (response.status == "SUCCESS")
                            {
                                response.Data.token = AuthRes.Data.tokenId;
                                string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                                response.Data = new GlFirstRentSelectResponse();
                                response.Data.encryptedResStr = EncStr;
                            }
                            //return response;
                            else
                            {
                                response.status = "FAILED";

                            }

                        }
                        else
                        {
                            response.status = "FAILED";
                            response.responseMsg = AuthRes.responseMsg;

                        }
                        //response = new ApiManager().InvokePostHttpClient<Response<PayratQueryResponse>, PayratQueryRequest>(request, appConfigManager.getaccountsApiUrl + "api/accounts/PayratQueries", authHeader).Item1;
                        //response.Data.token = AuthRes.Data.tokenId;
                    }


                    //string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                    //request = JsonConvert.DeserializeObject<PayratQueryRequest>(DecStr);

                    //response = new ApiManager().InvokePostHttpClient<Response<PayratQueryResponse>, PayratQueryRequest>(request, new AppConfigManager().getBaseUrl + "api/accounts/PayratQueries", authHeader).Item1;
                    //if (response.status == "SUCCESS")
                    //{

                    //    string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                    //    response.Data = new PayratQueryResponse();
                    //    response.Data.encryptedResStr = EncStr;
                    //}
                    ////return response;

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

        #region RentBranchQueries
        /// <summary>
        /// API Number : proc_payrat_queries
        /// Created on : 30-Jul-2021
        /// Created By : 100450
        /// Description: Payrat Queries
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        [HttpPost("RentBranchQueries")]
        public ActionResult<Response<RentBranchQueriesResponse>> RentBranchQueries([FromBody] RentBranchQueriesRequest request)
        {

            Response<RentBranchQueriesResponse> response = new Response<RentBranchQueriesResponse>();

            if (ModelState.IsValid)

            {
                try
                {
                    string authHeader = string.Empty;
                    //string DecStrs = JsonConvert.SerializeObject(Request.Headers.TryGetValue("Authorization", out StringValues authToken));
                    //string DecStrss = JsonConvert.SerializeObject(Request.Headers.TryGetValue("Authorization", out StringValues authToken));
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {


                        authHeader = authToken.First();
                        //var result = new ConnectionHandler.Authorization(authHeader);

                        //if (result.Status == "0")
                        //{
                        //    response.status = ResponseTypeContants.AUTHERROR;
                        //    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
                        //    response.responseMsg = result.Message;
                        //    return response;
                        //}
                        string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                        request = JsonConvert.DeserializeObject<RentBranchQueriesRequest>(DecStr);
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        UserSessionRequest AuthReq = new UserSessionRequest();
                        AuthReq.typeID = request.typeID;
                        AuthReq.userID = request.userID;
                        AuthReq.branchID = request.branchID;


                        var AuthRes = new ApiManager().InvokePostHttpClient<Response<UserSessionResponse>, UserSessionRequest>(AuthReq, appConfigManager.getaccountsRentApiUrl + "api/accounts/UserSession", authHeader).Item1;
                        if (AuthRes.status == "SUCCESS")
                        {


                            response = new ApiManager().InvokePostHttpClient<Response<RentBranchQueriesResponse>, RentBranchQueriesRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/RentBranchQueries", authHeader).Item1;
                            if (response.status == "SUCCESS")
                            {
                                response.Data.token = AuthRes.Data.tokenId;
                                string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                                response.Data = new RentBranchQueriesResponse();
                                response.Data.encryptedResStr = EncStr;
                            }
                            //return response;
                            else
                            {
                                response.status = "FAILED";

                            }

                        }
                        else
                        {
                            response.status = "FAILED";
                            response.responseMsg = AuthRes.responseMsg;

                        }
                        //response = new ApiManager().InvokePostHttpClient<Response<PayratQueryResponse>, PayratQueryRequest>(request, appConfigManager.getaccountsApiUrl + "api/accounts/PayratQueries", authHeader).Item1;
                        //response.Data.token = AuthRes.Data.tokenId;
                    }


                    //string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
                    //request = JsonConvert.DeserializeObject<PayratQueryRequest>(DecStr);

                    //response = new ApiManager().InvokePostHttpClient<Response<PayratQueryResponse>, PayratQueryRequest>(request, new AppConfigManager().getBaseUrl + "api/accounts/PayratQueries", authHeader).Item1;
                    //if (response.status == "SUCCESS")
                    //{

                    //    string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
                    //    response.Data = new PayratQueryResponse();
                    //    response.Data.encryptedResStr = EncStr;
                    //}
                    ////return response;

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


        //#region Branch Cash Position
        ///// <summary>
        ///// API Number : PROC_BRANCH_CASH_POSITION
        ///// Created on : 25-Sep-2021
        ///// Created By : 100367
        ///// Description: Branch Cash Position
        ///// Modify Date:
        ///// Modify By  :
        ///// Description:
        ///// </summary>
        //[HttpPost("BranchCashPosition")]
        //public ActionResult<Response<BranchCashPositionResponse>> BranchCashPosition([FromBody] BranchCashPositionRequest request)
        //{
        //    Response<BranchCashPositionResponse> response = new Response<BranchCashPositionResponse>();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            string authHeader = string.Empty;
        //            if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
        //            {
        //                authHeader = authToken.First();
        //                var result = new ConnectionHandler.Authorization(authHeader);

        //                if (result.Status == "0")
        //                {
        //                    response.status = ResponseTypeContants.AUTHERROR;
        //                    response.apiStatus = ApiStatusConstants.NOT_COMPLETED;
        //                    response.responseMsg = result.Message;
        //                    return response;
        //                }
        //                string DecStr = new RequestEncryption().APIDecryptionAES(request.encryptedRqstStr);
        //                request = JsonConvert.DeserializeObject<BranchCashPositionRequest>(DecStr);

        //                PublicConfigManager appConfigManager = new PublicConfigManager();
        //                UserSessionRequest AuthReq = new UserSessionRequest();
        //                AuthReq.typeID = request.typeID;
        //                AuthReq.userID = request.userID;
        //                AuthReq.branchID = request.branchID;

        //                var AuthRes = new ApiManager().InvokePostHttpClient<Response<UserSessionResponse>, UserSessionRequest>(AuthReq, appConfigManager.getaccountsRentApiUrl + "api/accounts/UserSession", authHeader).Item1;
        //                if (AuthRes.status == "SUCCESS")
        //                {


        //                    response = new ApiManager().InvokePostHttpClient<Response<BranchCashPositionResponse>, BranchCashPositionRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/BranchCashPosition", authHeader).Item1;
        //                    if (response.status == "SUCCESS")
        //                    {
        //                        response.Data.token = AuthRes.Data.tokenId;


        //                        string EncStr = new RequestEncryption().APIEncryptionAES(JsonConvert.SerializeObject(response.Data));
        //                        response.Data = new BranchCashPositionResponse();
        //                        response.Data.encryptedResStr = EncStr;
        //                    }

        //                    //return response;
        //                    else
        //                    {
        //                        response.status = "FAILED";

        //                    }

        //                }
        //                else
        //                {
        //                    response.status = "FAILED";
        //                    response.responseMsg = AuthRes.responseMsg;
        //                }
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
        #region InsertImages
        /// <summary>
        /// API Number : 
        /// Created on : 11-sep-2021
        /// Created By : 100450
        /// Description: Insert Images to Mongo DB
        /// </summary>

        [HttpPost("insertimage")]
        public ActionResult<Response<InsertImageResponse>> InsertImage([FromBody] InsertImageRequest request)
        {
            Response<InsertImageResponse> response = new Response<InsertImageResponse>();
            if (ModelState.IsValid)
            {
                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        //------Call customerslist API
                        return new ApiManager().InvokePostHttpClient<Response<InsertImageResponse>, InsertImageRequest>(request, new AppConfigManager().getBaseUrl + "api/accounts/insertimage", authHeader).Item1;
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

            Response<TmsRentLoginResponse> response = new Response<TmsRentLoginResponse>();
            if (ModelState.IsValid)
            {

                try
                {
                    PublicConfigManager appConfigManager = new PublicConfigManager();
                    //------Call Login API
                    return new ApiManager().InvokePostHttpClient<Response<TmsRentLoginResponse>, TmsRentLoginRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/TmsRentLogin").Item1;

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

        #region Images
        /// <summary>
        /// API Number : 
        /// Created on : 03-sep-2021
        /// Created By : 100450
        /// Description: Get Images from Mongo DB
        /// </summary>
        [HttpPost("images")]
        public ActionResult<Response<ImageResponse>> images([FromBody] ImageRequest request)
        {

            Response<ImageResponse> response = new Response<ImageResponse>();
            if (ModelState.IsValid)
            {

                try
                {
                    string authHeader = string.Empty;
                    if (Request.Headers.TryGetValue("Authorization", out StringValues authToken))
                    {
                        authHeader = authToken.First();
                        PublicConfigManager appConfigManager = new PublicConfigManager();
                        //------Call Images API----GEN018
                        return new ApiManager().InvokePostHttpClient<Response<ImageResponse>, ImageRequest>(request, appConfigManager.getaccountsRentApiUrl + "api/accounts/images", authHeader).Item1;
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


