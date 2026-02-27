using Amazon.Runtime.Internal;
using Base;
using DTO.MFAccountsRentAPI.Request;
using DTO.MFAccountsRentAPI.Response;
using DTO.Response;
using MFAccountsRentAPI.DataSource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;

using Utilities;

using static System.Net.WebRequestMethods;

namespace MFAccountsRentAPI.BLL
{
    public class AccountsBLL
    {
        #region AccountsBLL
        private readonly static Lazy<AccountsBLL> m_instance;

        public static AccountsBLL Instance
        {
            get
            {
                return AccountsBLL.m_instance.Value;
            }
        }

        static AccountsBLL()
        {
            AccountsBLL.m_instance = new Lazy<AccountsBLL>(() => new AccountsBLL());
        }

        #endregion

        

        
        

        

        

        

        

        

        
        

        


        

        #region Token Validator
        /// <summary>
        /// Created on : 29-Mar-2022
        /// Created By : 100367
        /// Description: Token Validator
        /// </summary>
        public Response<TokenValidatorResponse> TokenValidator(string authHeader)
        {
            TokenValidatorResponse TokenValidatorResponse = new TokenValidatorResponse();
            Response<TokenValidatorResponse> response = new Response<TokenValidatorResponse>();
            try
            {
                TokenValidatorResponse = new AccountsDataSource().TokenValidator(authHeader);

                if (TokenValidatorResponse.isDataAvailable)
                {
                    response.Data = TokenValidatorResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = TokenValidatorResponse.message;
                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = TokenValidatorResponse.message;
                    response.Data = TokenValidatorResponse;
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);
            }

            return response;
        }
        #endregion

        

        #region User Session
        /// <summary>
        /// API Number : ACC003
        /// Created on : 03-Apr-2023
        /// Created By : 100428
        /// Description: Get Account No and Name
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        public Response<UserSessionResponse> UserSession(UserSessionRequest request)
        {
            UserSessionResponse userSessionResponse = new UserSessionResponse();
            Response<UserSessionResponse> response = new Response<UserSessionResponse>();
            try
            {
                userSessionResponse = new AccountsDataSource().UserSession(request);

                if (userSessionResponse.isDataAvailable)
                {
                    response.Data = userSessionResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = ResponseTypeContants.SUCCESS;

                  
                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = userSessionResponse.message;
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);
            }

            return response;
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
        public Response<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse loginResponse = new LoginResponse();
            Response<LoginResponse> response = new Response<LoginResponse>();
            try
            {
                loginResponse = new AccountsDataSource().Login(request);

                if (loginResponse.isDataAvailable)
                {
                    response.Data = loginResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = loginResponse.message;


                }
                else
                {
                    if (loginResponse.branchId == -1)
                    {
                        response.status = ResponseTypeContants.FAIL;
                        response.apiStatus = ApiStatusConstants.COMPLETED;
                        response.responseMsg = "Invalid employee code";
                    }
                    else
                    {
                        response.status = ResponseTypeContants.FAIL;
                        response.apiStatus = ApiStatusConstants.COMPLETED;
                        response.responseMsg = loginResponse.message;
                    }

                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);

            }

            return response;
        }

        #endregion

       

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
        public Response<LogOutResponse> LogOut(LogOutRequest request)
        {
            LogOutResponse logOutResponse = new LogOutResponse();
            Response<LogOutResponse> response = new Response<LogOutResponse>();
            try
            {
                logOutResponse = new AccountsDataSource().LogOut(request);

                if (logOutResponse.isDataAvailable)
                {
                    response.Data = logOutResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = logOutResponse.message;
                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = logOutResponse.message;
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);

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
        public Response<DynamicMenuListResponse> MainMenuList(DynamicMenuListRequest request)
        {
            DynamicMenuListResponse dynamicMenuListResponse = new DynamicMenuListResponse();
            Response<DynamicMenuListResponse> response = new Response<DynamicMenuListResponse>();
            try
            {
                dynamicMenuListResponse = new AccountsDataSource().MainMenuList(request);

                if (dynamicMenuListResponse.isDataAvailable)
                {
                    response.Data = dynamicMenuListResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = ResponseTypeContants.SUCCESS;


                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = "No data found";
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);

            }

            return response;
        }

        #endregion

        

        


        


        


        
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
        public Response<BranchCashPositionResponse> BranchCashPosition(BranchCashPositionRequest request)
        {
            BranchCashPositionResponse LEARS = new BranchCashPositionResponse();
            Response<BranchCashPositionResponse> response = new Response<BranchCashPositionResponse>();
            try
            {
                LEARS = new AccountsDataSource().BranchCashPosition(request);

                if (LEARS.isDataAvailable)
                {
                    response.Data = LEARS;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = ResponseTypeContants.SUCCESS;
                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = LEARS.message;
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);

            }
            return response;
        }
        #endregion

        

        //#region GlFirstRentQueries
        ///// <summary>
        ///// API Number : PROC_BRANCH_CASH_POSITION
        ///// Created on : 25-Sep-2021
        ///// Created By : 100367
        ///// Description: Branch Cash Position
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //public Response<GlFirstRentSelectResponse> GlFirstRentQueries(GlFirstRentSelectRequest request)
        //{
        //    GlFirstRentSelectResponse LEARS = new GlFirstRentSelectResponse();
        //    Response<GlFirstRentSelectResponse> response = new Response<GlFirstRentSelectResponse>();
        //    try
        //    {
        //        LEARS = new AccountsDataSource().GlFirstRentQueries(request);

        //        if (LEARS.isDataAvailable)
        //        {
        //            response.Data = LEARS;
        //            response.status = ResponseTypeContants.SUCCESS;
        //            response.apiStatus = ApiStatusConstants.COMPLETED;
        //            response.responseMsg = ResponseTypeContants.SUCCESS;
        //        }
        //        else
        //        {
        //            response.status = ResponseTypeContants.FAIL;
        //            response.apiStatus = ApiStatusConstants.COMPLETED;
        //            response.responseMsg = LEARS.Message;
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
        //#endregion


        #region GlFirstRentQueries
        public Response<GlFirstRentSelectResponse> GlFirstRentQueries(GlFirstRentSelectRequest request)
        {
            GlFirstRentSelectResponse GlFirstRentSelectResponse = new GlFirstRentSelectResponse();
            Response<GlFirstRentSelectResponse> response = new Response<GlFirstRentSelectResponse>();
            try
            {
                GlFirstRentSelectResponse = new AccountsDataSource().GlFirstRentQueries(request);

                if (GlFirstRentSelectResponse.isDataAvailable)
                {
                    response.Data = GlFirstRentSelectResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = ResponseTypeContants.SUCCESS;
                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = "No data found";
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);
            }

            return response;
        }
        #endregion

        #region RentBranchQueries
        public Response<RentBranchQueriesResponse> RentBranchQueries(RentBranchQueriesRequest request)
        {
            RentBranchQueriesResponse RentBranchQueriesResponse = new RentBranchQueriesResponse();
            Response<RentBranchQueriesResponse> response = new Response<RentBranchQueriesResponse>();
            try
            {
                RentBranchQueriesResponse = new AccountsDataSource().RentBranchQueries(request);

                if (RentBranchQueriesResponse.isDataAvailable)
                {
                    response.Data = RentBranchQueriesResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = ResponseTypeContants.SUCCESS;
                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = "No data found";
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);
            }

            return response;
        }
        #endregion

        #region InsertImages
        public Response<InsertImageResponse> InsertImage(InsertImageRequest request)
        {
            InsertImageResponse IIR = new InsertImageResponse();
            Response<InsertImageResponse> response = new Response<InsertImageResponse>();
            try
            {
                IIR = new AccountsDataSource().InsertImage(request);

                if (IIR.isDataAvilable)
                {
                    response.Data = IIR;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = ResponseTypeContants.SUCCESS;
                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = "Insertion Failed";
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);
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
        public Response<TmsRentLoginResponse> TmsRentLogin(TmsRentLoginRequest request)
        {
            TmsRentLoginResponse loginResponse = new TmsRentLoginResponse();
            Response<TmsRentLoginResponse> response = new Response<TmsRentLoginResponse>();
            try
            {
                loginResponse = new AccountsDataSource().TmsRentLogin(request);

                if (loginResponse.isDataAvailable)
                {
                    response.Data = loginResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = loginResponse.message;


                }
                else
                {
                    if (loginResponse.branchId == -1)
                    {
                        response.status = ResponseTypeContants.FAIL;
                        response.apiStatus = ApiStatusConstants.COMPLETED;
                        response.responseMsg = "Invalid employee code";
                    }
                    else
                    {
                        response.status = ResponseTypeContants.FAIL;
                        response.apiStatus = ApiStatusConstants.COMPLETED;
                        response.responseMsg = loginResponse.message;
                    }

                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);

            }

            return response;
        }

        #endregion

        #region Images
        public Response<ImageResponse> Images(ImageRequest request)
        {
            ImageResponse imagesResponse = new ImageResponse();
            Response<ImageResponse> response = new Response<ImageResponse>();
            try
            {
                imagesResponse = new AccountsDataSource().Images(request);

                if (imagesResponse.isDataAvilable)
                {
                    response.Data = imagesResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = ResponseTypeContants.SUCCESS;
                }
                else
                {
                    response.status = ResponseTypeContants.FAIL;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = "No data found";
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                response.status = "Exception";
                response.responseMsg = "Internal Server Error";
                response.SetExceptionError(ex.Message);

            }

            return response;
        }
        #endregion
    }
}
