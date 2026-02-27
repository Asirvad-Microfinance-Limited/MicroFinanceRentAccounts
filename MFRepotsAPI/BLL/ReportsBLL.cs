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
    public class ReportsBLL
    {

        #region ReportsBLL
        private readonly static Lazy<ReportsBLL> m_instance;

        public static ReportsBLL Instance
        {
            get
            {
                return ReportsBLL.m_instance.Value;
            }
        }

        static ReportsBLL()
        {
            ReportsBLL.m_instance = new Lazy<ReportsBLL>(() => new ReportsBLL());
        }

        #endregion
     
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
        public Response<ReportsDetailsResponse> ReportDetails()
        {
            ReportsDetailsResponse reportsDetailsResponse = new ReportsDetailsResponse();
            Response<ReportsDetailsResponse> response = new Response<ReportsDetailsResponse>();
            try
            {
                reportsDetailsResponse = new ReportsDataSource().ReportDetails();

                if (reportsDetailsResponse.isDataAvailable)
                {
                    response.Data = reportsDetailsResponse;
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
        public Response<GenerateReportResponse> GenerateReport(GenerateReportRequests request)
        {
            GenerateReportResponse generateReportResponse = new GenerateReportResponse();
            Response<GenerateReportResponse> response = new Response<GenerateReportResponse>();
            try
            {
                generateReportResponse = new ReportsDataSource().GenerateReport(request);

                if (generateReportResponse.isDataAvailable)
                {
                    response.Data = generateReportResponse;
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
        public Response<GenerateReportResponse> ReportsData(ReportsDatarequest request)
        {
            GenerateReportResponse generateReportResponse = new GenerateReportResponse();
            Response<GenerateReportResponse> response = new Response<GenerateReportResponse>();
            try
            {
                generateReportResponse = new ReportsDataSource().ReportsData(request);

                if (generateReportResponse.isDataAvailable)
                {
                    response.Data = generateReportResponse;
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
        public Response<GenerateReportResponse> ReportsDrillDown(DrilldownReportsRequest request)
        {
            GenerateReportResponse generateReportResponse = new GenerateReportResponse();
            Response<GenerateReportResponse> response = new Response<GenerateReportResponse>();
            try
            {
                generateReportResponse = new ReportsDataSource().ReportsDrillDown(request);

                if (generateReportResponse.isDataAvailable)
                {
                    response.Data = generateReportResponse;
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
              

        #region ReportsLevelThree
        /// <summary>
        /// API Number : REP006
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: Get ReportsLevelThree
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        public Response<GenerateReportResponse> ReportsLevelThree(ReportsDatarequest request)
        {
            GenerateReportResponse generateReportResponse = new GenerateReportResponse();
            Response<GenerateReportResponse> response = new Response<GenerateReportResponse>();
            try
            {
                generateReportResponse = new ReportsDataSource().ReportsLevelThree(request);

                if (generateReportResponse.isDataAvailable)
                {
                    response.Data = generateReportResponse;
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


     

      
        //#region GenerateNewReport
        ///// <summary>
        ///// API Number : REP009
        ///// Created on : 28-Jul-2021
        ///// Created By : 100367
        ///// Description: GeneratenewReport
        ///// Modify Date:
        ///// Modify By  : 
        ///// Description:
        ///// </summary>
        //public Response<GenerateNewReportResponse> GenerateNewReport(GetNewDataReportRequest request)
        //{
        //    GenerateNewReportResponse generateNewReportResponse = new GenerateNewReportResponse();
        //    Response<GenerateNewReportResponse> response = new Response<GenerateNewReportResponse>();
        //    try
        //    {
        //        generateNewReportResponse = new ReportsDataSource().GenerateNewReport(request);

        //        if (generateNewReportResponse.isDataAvailable)
        //        {
        //            response.Data = generateNewReportResponse;
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
        public Response<GenerateAllReportResponse> GeneratAllReport(GetNewDataReportRequest request)
        {
            GenerateAllReportResponse generateAllReportResponse = new GenerateAllReportResponse();
            Response<GenerateAllReportResponse> response = new Response<GenerateAllReportResponse>();
            try
            {
                generateAllReportResponse = new ReportsDataSource().GeneratAllReport(request);

                if (generateAllReportResponse.isDataAvailable)
                {
                    response.Data = generateAllReportResponse;
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
        public Response<DynamicReportResponse> DynamicReport(DynamicReportRequest request)
        {
            DynamicReportResponse dynamicReportResponse = new DynamicReportResponse();
            Response<DynamicReportResponse> response = new Response<DynamicReportResponse>();
            try
            {
                dynamicReportResponse = new ReportsDataSource().DynamicReport(request);

                if (dynamicReportResponse.isDataAvailable)
                {
                    response.Data = dynamicReportResponse;
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
        public Response<GenerateDynamicReportResponse> GenerateDynamicReport(GenerateDynamicReportRequest request)
        {
            GenerateDynamicReportResponse generateDynamicReportResponse = new GenerateDynamicReportResponse();
            Response<GenerateDynamicReportResponse> response = new Response<GenerateDynamicReportResponse>();
            try
            {
                generateDynamicReportResponse = new ReportsDataSource().GenerateDynamicReport(request);

                if (generateDynamicReportResponse.isDataAvailable)
                {
                    response.Data = generateDynamicReportResponse;
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
        public Response<ComboFillResponse> Combofill(ComboFillRequest request)
        {
            ComboFillResponse comboFillResponse = new ComboFillResponse();
            Response<ComboFillResponse> response = new Response<ComboFillResponse>();
            try
            {
                comboFillResponse = new ReportsDataSource().Combofill(request);

                if (comboFillResponse.isDataAvailable)
                {
                    response.Data = comboFillResponse;
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
        public Response<CustomerStatementResponse> CustomerStatement(CustomerStatementRequest request)
        {
            CustomerStatementResponse customerStatementResponse = new CustomerStatementResponse();
            Response<CustomerStatementResponse> response = new Response<CustomerStatementResponse>();
            try
            {
                customerStatementResponse = new ReportsDataSource().CustomerStatement(request);

                if (customerStatementResponse.isDataAvailable)
                {
                    response.Data = customerStatementResponse;
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
        public Response<AssignReportComboResponse> AssignReportComboFill(AssignReportComboRequest request)
        {
            AssignReportComboResponse assignReportComboResponse = new AssignReportComboResponse();
            Response<AssignReportComboResponse> response = new Response<AssignReportComboResponse>();
            try
            {
                assignReportComboResponse = new ReportsDataSource().AssignReportComboFill(request);

                if (assignReportComboResponse.isDataAvailable)
                {
                    response.Data = assignReportComboResponse;
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
        public Response<AssignReportResponse> AssignReport(AssignReportRequest request)
        {
            AssignReportResponse assignReportResponse = new AssignReportResponse();
            Response<AssignReportResponse> response = new Response<AssignReportResponse>();
            try
            {
                assignReportResponse = new ReportsDataSource().AssignReport(request);

                if (assignReportResponse.isDataAvailable)
                {
                    response.Data = assignReportResponse;
                    response.status = ResponseTypeContants.SUCCESS;
                    response.apiStatus = ApiStatusConstants.COMPLETED;
                    response.responseMsg = assignReportResponse.message;
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
        #region PhotoPunch
        public Response<PhotoPunchingReportResponse> PhotoPunch(PhotoPunchingReportRequest request)
        {
            PhotoPunchingReportResponse photoPunchingReportResponse = new PhotoPunchingReportResponse();
            Response<PhotoPunchingReportResponse> response = new Response<PhotoPunchingReportResponse>();
            try
            {
                photoPunchingReportResponse = new ReportsDataSource().PhotoPunch(request);

                if (photoPunchingReportResponse.isDataAvailable)
                {
                    response.Data = photoPunchingReportResponse;
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
