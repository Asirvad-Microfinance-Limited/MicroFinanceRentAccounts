using Base;
using ConnectionHandler;
using DTO.MFAccountsRentAPI.Data;
using DTO.MFAccountsRentAPI.Request;
using DTO.MFAccountsRentAPI.Response;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Utilities;



namespace MFAccountsRentAPI.DataSource
{
    public class AccountsDataSource
    {
        

        

        

        

        

        

        

        

        
 
        

        

        

        

        #region Token Validator
        /// <summary>
        /// Created on : 29-Mar-2022
        /// Created By : 100367
        /// Description: Token Validator
        /// </summary>

            public TokenValidatorResponse TokenValidator(string authHeader)
        {
            TokenValidatorResponse TVR = new TokenValidatorResponse();
            var Ttoken = authHeader.Replace("Bearer ", "");
            var TDet = Ttoken.Split('^');


            //var base64EncodedBytes = System.Convert.FromBase64String(TDet[1]);
            //authHeader = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);








            //Ttoken = TDet[1];
            string usID = TDet[0].ToString();


            // var TDet = authHeader.Split('^');
            OracleParameter[] parameters = new OracleParameter[5];


            parameters[0] = new OracleParameter("p_TypeId", OracleDbType.Decimal);
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = "1";

            parameters[1] = new OracleParameter("P_UserId", OracleDbType.Decimal);
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = Convert.ToInt32(usID);

            parameters[2] = new OracleParameter("p_Token", OracleDbType.Varchar2);
            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = Ttoken;

            parameters[3] = new OracleParameter("P_ErrorStatus", OracleDbType.Decimal);
            parameters[3].Direction = ParameterDirection.Output;

            parameters[4] = new OracleParameter("P_ErrorMessage", OracleDbType.Varchar2, 4000);
            parameters[4].Direction = ParameterDirection.Output;

            new OracleDBAccessHelper().ExecuteNonQuery("AML_USERS.PROC_ACCOUNTS_TOKEN_VALIDATOR", parameters);

            TVR.status = parameters[3].Value.ToString();
            TVR.message = parameters[4].Value.ToString();
            TVR.isDataAvailable = true;

            return TVR;
        }







        #endregion

        

        #region User Session

        public UserSessionResponse UserSession(UserSessionRequest request)
        {
            UserSessionResponse PPB = new UserSessionResponse();
            OracleBaseMethodResponse OBMRS = new OracleBaseMethodResponse();


            string token = new JwtTokenManager().CreateToken(request.userID);

            var sessionID = request.sessionID.Replace("Bearer ", "");
           // var TDet = Ttoken.Split('^');

            OracleParameter[] parameters = new OracleParameter[7];

            parameters[0] = new OracleParameter("p_TypeId", OracleDbType.Decimal);
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = request.typeID;


            parameters[1] = new OracleParameter("p_UserId", OracleDbType.Decimal);
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = request.userID;

            parameters[2] = new OracleParameter("p_BranchId", OracleDbType.Decimal);
            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = request.branchID;

            parameters[3] = new OracleParameter("p_New_TokenId", OracleDbType.Varchar2);
            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = token;

            parameters[4] = new OracleParameter("p_TokenId", OracleDbType.Varchar2);
            parameters[4].Direction = ParameterDirection.Input;
            
             parameters[4].Value = sessionID;

            parameters[5] = new OracleParameter("p_ErrorStatus", OracleDbType.Decimal);
            parameters[5].Direction = ParameterDirection.Output;

            parameters[6] = new OracleParameter("p_ErrorMessage", OracleDbType.Varchar2, 4000);
            parameters[6].Direction = ParameterDirection.Output;

            new OracleDBAccessHelper().ExecuteNonQuery("proc_account_user_session", parameters);
            string errorStatus = parameters[5].Value.ToString();
            string errorMessage = parameters[6].Value.ToString();
            // PPB.tokenId = parameters[3].Value.ToString();
            //string tokenId = token;



            if (errorStatus == "1")
            {
                PPB.isDataAvailable = true;
                if (request.typeID != "3")
                {
                    PPB.tokenId = token;
                }

            }

            PPB.message = errorMessage;
            PPB.errStatus = errorStatus;



            return PPB;
        }
        #endregion

        #region LoginDetails
        /// <summary>
        /// API Number : ACC003
        /// Created on : 02-Oct-2023
        /// Created By : 100428,100661
        /// Description: Get Account No and Name
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse loginResponse = new LoginResponse();

            // string usid = new RequestEncryption().DecryptStringAES(request.userId.ToString());
            //int empID = Convert.ToInt32(usid);

            //string token = new JwtTokenManager().CreateToken(empID);


            string token = new JwtTokenManager().CreateToken(request.userId);
            token = request.userId + "^" + token;
            byte[] hashedDataBytes;
            // hashedDataBytes = new EncryptDecryptUtil().getEdata(request.userId.ToString(), request.password);
            string password = new RequestEncryption().DecryptStringAES(request.password);
            hashedDataBytes = new EncryptDecryptUtil().getEdata(request.userId.ToString(), password);

            OracleParameter[] parm_coll = new OracleParameter[16];
            parm_coll[0] = new OracleParameter("p_TypeID", OracleDbType.Decimal);
            parm_coll[0].Value = request.typeId;
            parm_coll[0].Direction = ParameterDirection.Input;

            parm_coll[1] = new OracleParameter("p_UserID", OracleDbType.Decimal);
            parm_coll[1].Value = request.userId;
            parm_coll[1].Direction = ParameterDirection.Input;

            parm_coll[2] = new OracleParameter("p_Password", OracleDbType.Raw, 1000);
            parm_coll[2].Value = hashedDataBytes;//c;   ctr+alt+i      
            parm_coll[2].Direction = ParameterDirection.Input;

            parm_coll[3] = new OracleParameter("p_Token", OracleDbType.Varchar2);
            parm_coll[3].Value = token;
            parm_coll[3].Direction = ParameterDirection.Input;

            parm_coll[4] = new OracleParameter("p_Device_ID", OracleDbType.Varchar2);
            parm_coll[4].Value = request.deviceId;
            parm_coll[4].Direction = ParameterDirection.Input;

            parm_coll[5] = new OracleParameter("p_BranchID", OracleDbType.Decimal);
            parm_coll[5].Direction = ParameterDirection.Output;

            parm_coll[6] = new OracleParameter("p_UserName", OracleDbType.Varchar2, 500);
            parm_coll[6].Direction = ParameterDirection.Output;

            parm_coll[7] = new OracleParameter("p_BranchName", OracleDbType.Varchar2, 500);
            parm_coll[7].Direction = ParameterDirection.Output;

            parm_coll[8] = new OracleParameter("p_UserType", OracleDbType.Decimal);
            parm_coll[8].Direction = ParameterDirection.Output;

            parm_coll[9] = new OracleParameter("p_MobNum", OracleDbType.Varchar2, 20);
            parm_coll[9].Direction = ParameterDirection.Output;

            parm_coll[10] = new OracleParameter("p_OtpFlag", OracleDbType.Decimal);
            parm_coll[10].Direction = ParameterDirection.Output;

            parm_coll[11] = new OracleParameter("p_errorStatus", OracleDbType.Decimal, 500);
            parm_coll[11].Direction = ParameterDirection.Output;

            parm_coll[12] = new OracleParameter("p_errorMessage", OracleDbType.Varchar2, 4000);
            parm_coll[12].Direction = ParameterDirection.Output;

            parm_coll[13] = new OracleParameter("p_UserTypeName", OracleDbType.Varchar2, 4000);
            parm_coll[13].Direction = ParameterDirection.Output;

            parm_coll[14] = new OracleParameter("p_Version", OracleDbType.Decimal);
            parm_coll[14].Value = request.version;
            parm_coll[14].Direction = ParameterDirection.Input;

            parm_coll[15] = new OracleParameter("p_ModuleID", OracleDbType.Decimal);
            parm_coll[15].Value = request.moduleId;
            parm_coll[15].Direction = ParameterDirection.Input;

            new OracleDBAccessHelper().ExecuteNonQuery("aml_users.PROC_VALIDATE_USER_ACCOUNTS", parm_coll);

            string errorStatus = parm_coll[11].Value.ToString();
            string errorMessage = parm_coll[12].Value.ToString();

            if (errorStatus == "1")
            {
                loginResponse.isDataAvailable = true;
                loginResponse.branchId = Convert.ToInt64(parm_coll[5].Value.ToString());
                loginResponse.branchName = parm_coll[7].Value.ToString();
                loginResponse.token = token;
                loginResponse.userId = request.userId;
                loginResponse.userName = parm_coll[6].Value.ToString();
                loginResponse.accessLevelId = Convert.ToInt64(parm_coll[8].Value.ToString());
                loginResponse.accessLevelName = parm_coll[13].Value.ToString();
                loginResponse.mobileNumber = parm_coll[9].Value.ToString();
                loginResponse.otpFlag = Convert.ToInt64(parm_coll[10].Value.ToString());


            }
            loginResponse.message = errorMessage;
            return loginResponse;
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
        public LogOutResponse LogOut(LogOutRequest request)
        {
            LogOutResponse logOutResponse = new LogOutResponse();

            OracleParameter[] parm_coll = new OracleParameter[4];
            parm_coll[0] = new OracleParameter("p_Token", OracleDbType.Varchar2);
            parm_coll[0].Value = request.token;
            parm_coll[0].Direction = ParameterDirection.Input;

            parm_coll[1] = new OracleParameter("p_UserID", OracleDbType.Decimal, 500);
            parm_coll[1].Value = request.userId;
            parm_coll[1].Direction = ParameterDirection.Input;

            parm_coll[2] = new OracleParameter("p_errorStatus", OracleDbType.Decimal, 500);
            parm_coll[2].Direction = ParameterDirection.Output;

            parm_coll[3] = new OracleParameter("p_errorMessage", OracleDbType.Varchar2, 4000);
            parm_coll[3].Direction = ParameterDirection.Output;

            new OracleDBAccessHelper().ExecuteNonQuery("aml_users.proc_accounts_logout", parm_coll);

            string errorStatus = parm_coll[2].Value.ToString();
            string errorMessage = parm_coll[3].Value.ToString();

            if (errorStatus == "1")
            {
                logOutResponse.isDataAvailable = true;
            }
            logOutResponse.message = errorMessage;
            return logOutResponse;
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
        //public OTPResponse OTP(OTPRequest request)
        //{
        //    string mobileNo = string.Empty;
        //    if (request.typeId == 4)
        //    {
        //        OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
        //        OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
        //        OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
        //        oracleBaseMethodRequest.parameterId = "GEN048";
        //        oracleBaseMethodRequest.parameterValue = request.userId.ToString();
        //        oracleBaseMethodResponse = oracleBaseMethod.BaseMethodUsers(oracleBaseMethodRequest);
        //        MobileData mobileData = new MobileData();
        //        mobileData = new OracleDBAccessHelper().GetRecord<MobileData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

        //        if (mobileData.mobileNo != string.Empty)
        //        {
        //            request.mobileNo = mobileData.mobileNo;
        //            mobileNo = mobileData.mobileNo;
        //        }
        //    }
        //    else
        //    {
        //        if (request.typeId == 6)
        //        {
        //            mobileNo = request.mobileNo;
        //        }
        //        else
        //        {
        //            mobileNo = new RequestEncryption().DecryptStringAES(request.mobileNo);

        //        }

        //    }

        //    OTPResponse oTPResponse = new OTPResponse();
        //    string otp = generateOTP();

        //    //-------Call SMS Method
        //    //SmsResponse smsResponse = new SmsResponse();
        //    //SmsRequest smsRequest = new SmsRequest();
        //    //smsRequest.message = "Dear Customer - otp  is" + " " + otp;
        //    //smsRequest.mobileNo = request.mobileNo;
        //    //smsRequest.accountType = SMSAccMode.transactionsms;
        //    //smsResponse = new SMS.SMS().SendSMS(smsRequest);

        //    SmsFormatData smsFormatData = new SmsFormatData();

        //    if (request.typeId > 0)
        //    {

        //        OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
        //        OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
        //        OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
        //        oracleBaseMethodRequest.parameterId = "GEN031";
        //        oracleBaseMethodRequest.parameterValue = request.typeId.ToString() + "^" + (request.branchID ?? "");
        //        oracleBaseMethodResponse = oracleBaseMethod.BaseMethodUsers(oracleBaseMethodRequest);

        //        smsFormatData = new OracleDBAccessHelper().GetRecord<SmsFormatData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
        //    }
        //    else
        //    {

        //        OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
        //        OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
        //        OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
        //        oracleBaseMethodRequest.parameterId = "GEN031";
        //        oracleBaseMethodRequest.parameterValue = "2" + "^" + (request.branchID ?? "");
        //        oracleBaseMethodResponse = oracleBaseMethod.BaseMethodUsers(oracleBaseMethodRequest);

        //        smsFormatData = new OracleDBAccessHelper().GetRecord<SmsFormatData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
        //    }
        //    #region Code Commented
        //    //if (request.typeId==1)
        //    //{

        //    //    OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
        //    //    OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
        //    //    OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
        //    //    oracleBaseMethodRequest.parameterId = "GEN031";
        //    //    oracleBaseMethodRequest.parameterValue = "1";
        //    //    oracleBaseMethodResponse = oracleBaseMethod.BaseMethodUsers(oracleBaseMethodRequest);

        //    //    smsFormatData = new OracleDBAccessHelper().GetRecord<SmsFormatData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
        //    //}
        //    //else
        //    //{
        //    //    if (request.typeId == 4)
        //    //    {

        //    //        OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
        //    //        OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
        //    //        OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
        //    //        oracleBaseMethodRequest.parameterId = "GEN031";
        //    //        oracleBaseMethodRequest.parameterValue = "4";
        //    //        oracleBaseMethodResponse = oracleBaseMethod.BaseMethodUsers(oracleBaseMethodRequest);

        //    //        smsFormatData = new OracleDBAccessHelper().GetRecord<SmsFormatData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
        //    //    }
        //    //    else
        //    //    {

        //    //        OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
        //    //        OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
        //    //        OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
        //    //        oracleBaseMethodRequest.parameterId = "GEN031";
        //    //        oracleBaseMethodRequest.parameterValue = "2";
        //    //        oracleBaseMethodResponse = oracleBaseMethod.BaseMethodUsers(oracleBaseMethodRequest);

        //    //        smsFormatData = new OracleDBAccessHelper().GetRecord<SmsFormatData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
        //    //    }
        //    //}
        //    #endregion

        //    if (mobileNo.Length < 10 || mobileNo.Length > 12)
        //    {
        //        oTPResponse.message = "Invalid Mobile Number";
        //        return oTPResponse;
        //    }

        //    Response<SmsResponseOtp> SmsResponseOtps = new DTO.Response <SmsResponseOtp>();
        //    SmsRequestMFI smsRequestMFI = new SmsRequestMFI();
        //    smsRequestMFI.message = smsFormatData.message.Replace("<var1>", otp);
        //    smsRequestMFI.mobileNo = mobileNo;
        //    smsRequestMFI.language = smsFormatData.language;
        //    smsRequestMFI.firmid = Convert.ToInt32(otp);
        //    smsRequestMFI.accountType = Convert.ToInt32(SMSAccMode.normal);
        //    //---Nithin---//
        //    SmsResponseOtps = new SMSN().SendOTP(smsRequestMFI);

        //    //----------Add SMS Log
        //    OracleParameter[] parm_coll = new OracleParameter[7];
        //    parm_coll[0] = new OracleParameter("p_TypeID", OracleDbType.Decimal);
        //    parm_coll[0].Value = request.typeId;
        //    parm_coll[0].Direction = ParameterDirection.Input;

        //    parm_coll[1] = new OracleParameter("p_UserID", OracleDbType.Decimal);
        //    parm_coll[1].Value = request.userId;
        //    parm_coll[1].Direction = ParameterDirection.Input;

        //    parm_coll[2] = new OracleParameter("p_MobileNo", OracleDbType.Varchar2);
        //    parm_coll[2].Value = mobileNo;
        //    parm_coll[2].Direction = ParameterDirection.Input;

        //    parm_coll[3] = new OracleParameter("p_Otp", OracleDbType.Decimal);
        //    parm_coll[3].Value = Convert.ToDecimal(otp);
        //    parm_coll[3].Direction = ParameterDirection.Input;

        //    parm_coll[4] = new OracleParameter("p_SendResult", OracleDbType.Varchar2);
        //    parm_coll[4].Value = JsonConvert.SerializeObject(smsResponseMFI);
        //    parm_coll[4].Direction = ParameterDirection.Input;

        //    parm_coll[5] = new OracleParameter("p_errorStatus", OracleDbType.Decimal, 500);
        //    parm_coll[5].Direction = ParameterDirection.Output;

        //    parm_coll[6] = new OracleParameter("p_errorMessage", OracleDbType.Varchar2, 4000);
        //    parm_coll[6].Direction = ParameterDirection.Output;

        //    new OracleDBAccessHelper().ExecuteNonQuery("proc_sms_updation", parm_coll);

        //    string errorStatus = parm_coll[5].Value.ToString();
        //    string errorMessage = parm_coll[6].Value.ToString();

        //    oTPResponse.isDataAvailable = true;
        //    if (request.typeId == 4)
        //    {
        //        oTPResponse.otp = mobileNo;
        //    }
        //    else
        //    {
        //        oTPResponse.otp = "1";
        //    }

        //    oTPResponse.message = errorMessage;

        //    return oTPResponse;
        //}



        //public string generateOTP()
        //{
        //    int lenthofpass = 6;
        //    string allowedChars = "";
        //    allowedChars = "1,2,3,4,5,6,7,8,9";
        //    char[] sep = new[] { ',' };
        //    string[] arr = allowedChars.Split(sep);
        //    string passwordString = "";
        //    string temp = "";
        //    Random rand = new Random();
        //    for (int i = 0; i <= lenthofpass - 1; i++)
        //    {
        //        temp = arr[rand.Next(0, arr.Length)];
        //        passwordString += temp;
        //    }
        //    return passwordString;
        //}

        //#endregion
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

        public DynamicMenuListResponse MainMenuList(DynamicMenuListRequest request)
        {
            DynamicMenuListResponse dynamicMenuListResponse = new DynamicMenuListResponse();

            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "ACC076";
            oracleBaseMethodRequest.parameterValue = request.userID.ToString() + "^" + (request.moduleID == 0 ? "" : request.moduleID.ToString());
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodAccounts(oracleBaseMethodRequest);

            dynamicMenuListResponse.menuList = new OracleDBAccessHelper().GetRecords<MenuListData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
            if (dynamicMenuListResponse.menuList.Count > 0)
            {
                dynamicMenuListResponse.isDataAvailable = true;
            }
            return dynamicMenuListResponse;
        }
        #endregion






        //#region  moduledetails

        //public ModuleDetailsResponse moduledetails(ModuleDetailsRequest request)
        //{

        //    ModuleDetailsResponse MDR = new ModuleDetailsResponse();
        //    OracleBaseMethodResponse OBMRS = new OracleBaseMethodResponse();
        //    ModuleDetailsData md = new ModuleDetailsData();
        //    OracleParameter[] parameters = new OracleParameter[6];

        //    parameters[0] = new OracleParameter("p_typeId", OracleDbType.Decimal);
        //    parameters[0].Direction = ParameterDirection.Input;
        //    parameters[0].Value = request.TypeIDD;

        //    parameters[1] = new OracleParameter("p_flag", OracleDbType.Decimal);
        //    parameters[1].Direction = ParameterDirection.Input;
        //    parameters[1].Value = request.flag;

        //    parameters[2] = new OracleParameter("p_ParamList", OracleDbType.Varchar2, 100);
        //    parameters[2].Direction = ParameterDirection.Input;
        //    parameters[2].Value = request.ParamList;

        //    //parameters[2] = new OracleParameter("p_moduleId", OracleDbType.Decimal, 100);
        //    //parameters[2].Direction = ParameterDirection.Input;
        //    //parameters[2].Value = request.moduleId;

        //    //parameters[2] = new OracleParameter("p_moduleId", OracleDbType.Decimal, 100);
        //    //parameters[2].Direction = ParameterDirection.Input;
        //    //parameters[2].Value = request.moduleId;

        //    parameters[3] = new OracleParameter("p_ErrorStatus", OracleDbType.Decimal);
        //    parameters[3].Direction = ParameterDirection.Output;

        //    parameters[4] = new OracleParameter("p_ErrorMessage", OracleDbType.Varchar2, 4000);
        //    parameters[4].Direction = ParameterDirection.Output;

        //    parameters[5] = new OracleParameter("p_QueryResult", OracleDbType.RefCursor);
        //    parameters[5].Direction = ParameterDirection.Output;

        //    OBMRS.parameters = parameters;
        //    OBMRS.query = "proc_accounts_module_upload";


        //    if (request.TypeIDD == 1)
        //    {
        //        MDR.moduledetails = new OracleDBAccessHelper().GetRecords<Moduledetails>(OBMRS.query, OBMRS.parameters);


        //    }
        //    else if (request.TypeIDD == 2)
        //    {
        //        MDR.menudtl = new OracleDBAccessHelper().GetRecords<MenuDtl>(OBMRS.query, OBMRS.parameters);
        //    }
        //    else if (request.TypeIDD == 3)
        //    {
        //        MDR.confirm1 = new OracleDBAccessHelper().GetRecords<Confirm>(OBMRS.query, OBMRS.parameters);
        //    }


        //    else

        //        new OracleDBAccessHelper().ExecuteNonQuery(OBMRS.query, parameters);



        //    string errorStatus = parameters[3].Value.ToString();
        //    MDR.message = parameters[4].Value.ToString();
        //    //string moduleId = parameters[3].Value.ToString();

        //    if (errorStatus == "1")
        //    {
        //        MDR.isDataAvailable = true;
        //    }
        //    return MDR;

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
        //public BranchCashPositionResponse BranchCashPosition(BranchCashPositionRequest request)
        //{
        //    BranchCashPositionResponse BCPR = new BranchCashPositionResponse();
        //    OracleBaseMethodResponse OBMRS1 = new OracleBaseMethodResponse();

        //    byte[] hashedDataBytes = new byte[0];
        //    //if (request.typeId != 1)
        //    //{
        //    //    string password = new RequestEncryption().DecryptStringAES(request.password);
        //    //    hashedDataBytes = new EncryptDecryptUtil().getEdata(request.autherId.ToString(), password);
        //    //}

        //    OracleParameter[] parameters = new OracleParameter[31];
        //    parameters[0] = new OracleParameter("p_BranchId", OracleDbType.Decimal);
        //    parameters[0].Value = request.branchId;
        //    parameters[0].Direction = ParameterDirection.Input;

        //    parameters[1] = new OracleParameter("p_C2000", OracleDbType.Decimal);
        //    parameters[1].Value = request.c2000;
        //    parameters[1].Direction = ParameterDirection.Input;

        //    parameters[2] = new OracleParameter("p_C200", OracleDbType.Decimal);
        //    parameters[2].Value = request.c200;
        //    parameters[2].Direction = ParameterDirection.Input;

        //    parameters[3] = new OracleParameter("p_C500", OracleDbType.Decimal);
        //    parameters[3].Value = request.c500;
        //    parameters[3].Direction = ParameterDirection.Input;

        //    parameters[4] = new OracleParameter("p_C100", OracleDbType.Decimal);
        //    parameters[4].Value = request.c100;
        //    parameters[4].Direction = ParameterDirection.Input;

        //    parameters[5] = new OracleParameter("p_C50", OracleDbType.Decimal);
        //    parameters[5].Value = request.c50;
        //    parameters[5].Direction = ParameterDirection.Input;

        //    parameters[6] = new OracleParameter("p_C20", OracleDbType.Decimal);
        //    parameters[6].Value = request.c20;
        //    parameters[6].Direction = ParameterDirection.Input;

        //    parameters[7] = new OracleParameter("p_C10", OracleDbType.Decimal);
        //    parameters[7].Value = request.c10;
        //    parameters[7].Direction = ParameterDirection.Input;

        //    parameters[8] = new OracleParameter("p_C5", OracleDbType.Decimal);
        //    parameters[8].Value = request.c5;
        //    parameters[8].Direction = ParameterDirection.Input;

        //    parameters[9] = new OracleParameter("p_C2", OracleDbType.Decimal);
        //    parameters[9].Value = request.c2;
        //    parameters[9].Direction = ParameterDirection.Input;

        //    parameters[10] = new OracleParameter("p_C1", OracleDbType.Decimal);
        //    parameters[10].Value = request.c1;
        //    parameters[10].Direction = ParameterDirection.Input;

        //    parameters[11] = new OracleParameter("p_LateCash", OracleDbType.Decimal);
        //    parameters[11].Value = request.lateCash;
        //    parameters[11].Direction = ParameterDirection.Input;

        //    parameters[12] = new OracleParameter("p_SysTotal", OracleDbType.Decimal);
        //    parameters[12].Value = request.sysTotal;
        //    parameters[12].Direction = ParameterDirection.Input;

        //    parameters[13] = new OracleParameter("p_CashTotal", OracleDbType.Decimal);
        //    parameters[13].Value = request.cashTotal;
        //    parameters[13].Direction = ParameterDirection.Input;

        //    parameters[14] = new OracleParameter("p_UserId", OracleDbType.Decimal);
        //    parameters[14].Value = request.userId;
        //    parameters[14].Direction = ParameterDirection.Input;

        //    parameters[15] = new OracleParameter("p_AutherId", OracleDbType.Decimal);
        //    parameters[15].Value = request.autherId;
        //    parameters[15].Direction = ParameterDirection.Input;

        //    parameters[16] = new OracleParameter("p_Coinamt", OracleDbType.Decimal);
        //    parameters[16].Value = request.coinAmt;
        //    parameters[16].Direction = ParameterDirection.Input;

        //    parameters[17] = new OracleParameter("p_Remark", OracleDbType.Varchar2);
        //    parameters[17].Value = request.remark;
        //    parameters[17].Direction = ParameterDirection.Input;

        //    parameters[18] = new OracleParameter("p_Burglary", OracleDbType.Varchar2);
        //    parameters[18].Value = request.burglary;
        //    parameters[18].Direction = ParameterDirection.Input;

        //    parameters[19] = new OracleParameter("p_Firm", OracleDbType.Decimal);
        //    parameters[19].Value = request.firm;
        //    parameters[19].Direction = ParameterDirection.Input;

        //    parameters[20] = new OracleParameter("p_Safestrong", OracleDbType.Varchar2);
        //    parameters[20].Value = request.safeStrong;
        //    parameters[20].Direction = ParameterDirection.Input;

        //    parameters[21] = new OracleParameter("p_Ups", OracleDbType.Varchar2);
        //    parameters[21].Value = request.ups;
        //    parameters[21].Direction = ParameterDirection.Input;

        //    parameters[22] = new OracleParameter("p_Gps", OracleDbType.Varchar2);
        //    parameters[22].Value = request.gps;
        //    parameters[22].Direction = ParameterDirection.Input;

        //    parameters[23] = new OracleParameter("p_Panic_swicth", OracleDbType.Varchar2);
        //    parameters[23].Value = request.panicSwicth;
        //    parameters[23].Direction = ParameterDirection.Input;

        //    parameters[24] = new OracleParameter("p_Wir_switch", OracleDbType.Varchar2);
        //    parameters[24].Value = request.wirSwitch;
        //    parameters[24].Direction = ParameterDirection.Input;

        //    parameters[25] = new OracleParameter("p_Ipcam", OracleDbType.Varchar2);
        //    parameters[25].Value = request.ipcam;
        //    parameters[25].Direction = ParameterDirection.Input;

        //    //parameters[26] = new OracleParameter("p_password", OracleDbType.Raw, 1000);
        //    //parameters[26].Value = hashedDataBytes;
        //    //parameters[26].Direction = ParameterDirection.Input;

        //    parameters[26] = new OracleParameter("p_TypeId", OracleDbType.Decimal);
        //    parameters[26].Value = request.typeId;
        //    parameters[26].Direction = ParameterDirection.Input;

        //    parameters[27] = new OracleParameter("p_sysAmount", OracleDbType.Decimal, 500);
        //    parameters[27].Direction = ParameterDirection.Output;

        //    parameters[28] = new OracleParameter("p_ErrorStatus", OracleDbType.Decimal, 500);
        //    parameters[28].Direction = ParameterDirection.Output;

        //    parameters[29] = new OracleParameter("p_ErrorMessage", OracleDbType.Varchar2, 1000);
        //    parameters[29].Direction = ParameterDirection.Output;

        //    parameters[30] = new OracleParameter("p_Token", OracleDbType.Varchar2, 1000);
        //    parameters[30].Direction = ParameterDirection.Output;


        //    new OracleDBAccessHelper().ExecuteNonQuery("PROC_BRANCH_CASH_POSITION_ACCOUNTS", parameters);

        //    string errorStatus = parameters[28].Value.ToString();
        //    string errorMessage = parameters[29].Value.ToString();
        //    if (request.typeId == 1)
        //    {
        //        BCPR.sysAmount = Convert.ToInt32(parameters[27].Value.ToString());
        //    }
        //    if (errorStatus == "1")
        //    {
        //        BCPR.isDataAvailable = true;

        //    }
        //    if (request.typeId == 2)
        //    {
        //        BCPR.Token = parameters[30].Value.ToString();
        //    }

        //    BCPR.message = errorMessage;
        //    return BCPR;
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
        public BranchCashPositionResponse BranchCashPosition(BranchCashPositionRequest request)
        {
            BranchCashPositionResponse BCPR = new BranchCashPositionResponse();
            OracleBaseMethodResponse OBMRS1 = new OracleBaseMethodResponse();

            byte[] hashedDataBytes = new byte[0];
            if (request.typeId != 1 && request.typeId != 5 && request.typeId != 4)
            {
                string password = new RequestEncryption().DecryptStringAES(request.password);
                hashedDataBytes = new EncryptDecryptUtil().getEdata(request.autherId.ToString(), password);
            }

            OracleParameter[] parameters = new OracleParameter[32];
            parameters[0] = new OracleParameter("p_BranchId", OracleDbType.Decimal);
            parameters[0].Value = request.branchId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_C2000", OracleDbType.Decimal);
            parameters[1].Value = request.c2000;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_C200", OracleDbType.Decimal);
            parameters[2].Value = request.c200;
            parameters[2].Direction = ParameterDirection.Input;

            parameters[3] = new OracleParameter("p_C500", OracleDbType.Decimal);
            parameters[3].Value = request.c500;
            parameters[3].Direction = ParameterDirection.Input;

            parameters[4] = new OracleParameter("p_C100", OracleDbType.Decimal);
            parameters[4].Value = request.c100;
            parameters[4].Direction = ParameterDirection.Input;

            parameters[5] = new OracleParameter("p_C50", OracleDbType.Decimal);
            parameters[5].Value = request.c50;
            parameters[5].Direction = ParameterDirection.Input;

            parameters[6] = new OracleParameter("p_C20", OracleDbType.Decimal);
            parameters[6].Value = request.c20;
            parameters[6].Direction = ParameterDirection.Input;

            parameters[7] = new OracleParameter("p_C10", OracleDbType.Decimal);
            parameters[7].Value = request.c10;
            parameters[7].Direction = ParameterDirection.Input;

            parameters[8] = new OracleParameter("p_C5", OracleDbType.Decimal);
            parameters[8].Value = request.c5;
            parameters[8].Direction = ParameterDirection.Input;

            parameters[9] = new OracleParameter("p_C2", OracleDbType.Decimal);
            parameters[9].Value = request.c2;
            parameters[9].Direction = ParameterDirection.Input;

            parameters[10] = new OracleParameter("p_C1", OracleDbType.Decimal);
            parameters[10].Value = request.c1;
            parameters[10].Direction = ParameterDirection.Input;

            parameters[11] = new OracleParameter("p_LateCash", OracleDbType.Decimal);
            parameters[11].Value = request.lateCash;
            parameters[11].Direction = ParameterDirection.Input;

            parameters[12] = new OracleParameter("p_SysTotal", OracleDbType.Decimal);
            parameters[12].Value = request.sysTotal;
            parameters[12].Direction = ParameterDirection.Input;

            parameters[13] = new OracleParameter("p_CashTotal", OracleDbType.Decimal);
            parameters[13].Value = request.cashTotal;
            parameters[13].Direction = ParameterDirection.Input;

            parameters[14] = new OracleParameter("p_UserId", OracleDbType.Decimal);
            parameters[14].Value = request.UserId;
            parameters[14].Direction = ParameterDirection.Input;

            parameters[15] = new OracleParameter("p_AutherId", OracleDbType.Decimal);
            parameters[15].Value = request.autherId;
            parameters[15].Direction = ParameterDirection.Input;

            parameters[16] = new OracleParameter("p_Coinamt", OracleDbType.Decimal);
            parameters[16].Value = request.coinAmt;
            parameters[16].Direction = ParameterDirection.Input;

            parameters[17] = new OracleParameter("p_Remark", OracleDbType.Varchar2);
            parameters[17].Value = request.remark;
            parameters[17].Direction = ParameterDirection.Input;

            parameters[18] = new OracleParameter("p_Burglary", OracleDbType.Varchar2);
            parameters[18].Value = request.burglary;
            parameters[18].Direction = ParameterDirection.Input;

            parameters[19] = new OracleParameter("p_Firm", OracleDbType.Decimal);
            parameters[19].Value = request.firm;
            parameters[19].Direction = ParameterDirection.Input;

            parameters[20] = new OracleParameter("p_Safestrong", OracleDbType.Varchar2);
            parameters[20].Value = request.safeStrong;
            parameters[20].Direction = ParameterDirection.Input;

            parameters[21] = new OracleParameter("p_Ups", OracleDbType.Varchar2);
            parameters[21].Value = request.ups;
            parameters[21].Direction = ParameterDirection.Input;

            parameters[22] = new OracleParameter("p_Gps", OracleDbType.Varchar2);
            parameters[22].Value = request.gps;
            parameters[22].Direction = ParameterDirection.Input;

            parameters[23] = new OracleParameter("p_Panic_swicth", OracleDbType.Varchar2);
            parameters[23].Value = request.panicSwicth;
            parameters[23].Direction = ParameterDirection.Input;

            parameters[24] = new OracleParameter("p_Wir_switch", OracleDbType.Varchar2);
            parameters[24].Value = request.wirSwitch;
            parameters[24].Direction = ParameterDirection.Input;

            parameters[25] = new OracleParameter("p_Ipcam", OracleDbType.Varchar2);
            parameters[25].Value = request.ipcam;
            parameters[25].Direction = ParameterDirection.Input;

            parameters[26] = new OracleParameter("p_password", OracleDbType.Raw, 1000);
            parameters[26].Value = hashedDataBytes;
            parameters[26].Direction = ParameterDirection.Input;

            parameters[27] = new OracleParameter("p_TypeId", OracleDbType.Decimal);
            parameters[27].Value = request.typeId;
            parameters[27].Direction = ParameterDirection.Input;

            parameters[28] = new OracleParameter("p_sysAmount", OracleDbType.Decimal, 500);
            parameters[28].Direction = ParameterDirection.Output;

            parameters[29] = new OracleParameter("p_ErrorStatus", OracleDbType.Decimal, 500);
            parameters[29].Direction = ParameterDirection.Output;

            parameters[30] = new OracleParameter("p_ErrorMessage", OracleDbType.Varchar2, 1000);
            parameters[30].Direction = ParameterDirection.Output;

            parameters[31] = new OracleParameter("p_MobNum", OracleDbType.Varchar2, 20);
            parameters[31].Direction = ParameterDirection.Output;


            new OracleDBAccessHelper().ExecuteNonQuery("PROC_BRANCH_CASH_POSITION_OTP", parameters);

            string errorStatus = parameters[29].Value.ToString();
            string errorMessage = parameters[30].Value.ToString();
            if (request.typeId == 1)
            {
                BCPR.sysAmount = Convert.ToInt32(parameters[28].Value.ToString());
            }
            if (request.typeId == 4)

            {
                BCPR.mobileNumber = parameters[31].Value.ToString();
            }

            if (errorStatus == "1")
            {
                BCPR.isDataAvailable = true;

            }
            BCPR.message = errorMessage;
            return BCPR;
        }
        #endregion

        #region GlFirstRentQueries

        public GlFirstRentSelectResponse GlFirstRentQueries(GlFirstRentSelectRequest request)
        {
            GlFirstRentSelectResponse PQR = new GlFirstRentSelectResponse();
            OracleBaseMethodResponse OBMRS = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("p_Flag", OracleDbType.Varchar2);
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = request.Flag;

            parameters[1] = new OracleParameter("p_pageVal", OracleDbType.Varchar2);
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = request.PagVal;

            parameters[2] = new OracleParameter("p_ParVal", OracleDbType.Varchar2);
            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = request.ParVal;

            parameters[3] = new OracleParameter("P_ParVal1", OracleDbType.Varchar2);
            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = request.ParVal1;

            parameters[4] = new OracleParameter("QRY_RESULT", OracleDbType.RefCursor);
            parameters[4].Direction = ParameterDirection.Output;

            OBMRS.parameters = parameters;
            OBMRS.query = "PROC_GLFIRSTRENT_SELECTDATA";

            PQR.QueryResult = new OracleDBAccessHelper().GetRecords<GlFirstRentData>(OBMRS.query, OBMRS.parameters);

            if (PQR.QueryResult.Count > 0)
            {
                PQR.isDataAvailable = true;
                PQR.Message = "Success";
            }
            else
            {
                PQR.isDataAvailable = false;
                PQR.Message = "Failed";
            }
            return PQR;
        }
        #endregion

        #region RentBranchQueries

        public RentBranchQueriesResponse RentBranchQueries(RentBranchQueriesRequest request)
        {
            RentBranchQueriesResponse PQR = new RentBranchQueriesResponse();
            OracleBaseMethodResponse OBMRS = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("p_Flag", OracleDbType.Varchar2);
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = request.Flag;

            parameters[1] = new OracleParameter("p_pageVal", OracleDbType.Varchar2);
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = request.PagVal;

            parameters[2] = new OracleParameter("p_ParVal", OracleDbType.Varchar2);
            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = request.ParVal;

            parameters[3] = new OracleParameter("P_ParVal1", OracleDbType.Varchar2);
            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = request.ParVal1;

            parameters[4] = new OracleParameter("QRY_RESULT", OracleDbType.RefCursor);
            parameters[4].Direction = ParameterDirection.Output;

            OBMRS.parameters = parameters;
            OBMRS.query = "proc_rent_branch_queries";

            PQR.QueryResult = new OracleDBAccessHelper().GetRecords<RentBranchData>(OBMRS.query, OBMRS.parameters);

            if (PQR.QueryResult.Count > 0)
            {
                PQR.isDataAvailable = true;
                PQR.Message = "Success";
            }
            else
            {
                PQR.isDataAvailable = false;
                PQR.Message = "Failed";
            }
            return PQR;
        }
        #endregion

        #region InsertImages
        /// <summary>
        /// API Number : 
        /// Created on : 10-sep-2021
        /// Created By : 100450
        /// Description: Insert Images To  Mongo DB
        /// </summary>

        public InsertImageResponse InsertImage(InsertImageRequest request)
        {
            InsertImageResponse IIR = new InsertImageResponse();
            MongoDBAccessHelper mongoDBAccessHelper = new MongoDBAccessHelper();
            MongoBaseMethod Photo = new MongoBaseMethod();

            Photo.fileId = request.recordingId;
            Photo.fileName = request.fileName;
            Photo.fileType = request.imageType;
            Photo.data = request.image;
            try
            {
                mongoDBAccessHelper.Insert(request.collectionName, Photo);
                IIR.isDataAvilable = true;
                IIR.message = "Image Inserted Successfully..!";
            }
            catch { }
            //IIR.expence_id = Photo.fileId;
            return IIR;
        }
        #endregion


        #region TmsRentLogin
        /// <summary>
        /// API Number : ACC003
        /// Created on : 02-Oct-2023
        /// Created By : 100428,100661
        /// Description: Get Account No and Name
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        public TmsRentLoginResponse TmsRentLogin(TmsRentLoginRequest request)
        {
            TmsRentLoginResponse loginResponse = new TmsRentLoginResponse();

            // string usid = new RequestEncryption().DecryptStringAES(request.userId.ToString());
            //int empID = Convert.ToInt32(usid);

            //string token = new JwtTokenManager().CreateToken(empID);


            string token = new JwtTokenManager().CreateToken(request.userId);
            token = request.userId + "^" + token;
            byte[] hashedDataBytes;
            // hashedDataBytes = new EncryptDecryptUtil().getEdata(request.userId.ToString(), request.password);
            string password = new RequestEncryption().DecryptStringAES(request.password);
            hashedDataBytes = new EncryptDecryptUtil().getEdata(request.userId.ToString(), password);

            OracleParameter[] parm_coll = new OracleParameter[16];
            parm_coll[0] = new OracleParameter("p_TypeID", OracleDbType.Decimal);
            parm_coll[0].Value = request.typeId;
            parm_coll[0].Direction = ParameterDirection.Input;

            parm_coll[1] = new OracleParameter("p_UserID", OracleDbType.Decimal);
            parm_coll[1].Value = request.userId;
            parm_coll[1].Direction = ParameterDirection.Input;

            parm_coll[2] = new OracleParameter("p_Password", OracleDbType.Raw, 1000);
            parm_coll[2].Value = hashedDataBytes;//c;   ctr+alt+i      
            parm_coll[2].Direction = ParameterDirection.Input;

            parm_coll[3] = new OracleParameter("p_Token", OracleDbType.Varchar2);
            parm_coll[3].Value = token;
            parm_coll[3].Direction = ParameterDirection.Input;

            parm_coll[4] = new OracleParameter("p_Device_ID", OracleDbType.Varchar2);
            parm_coll[4].Value = request.deviceId;
            parm_coll[4].Direction = ParameterDirection.Input;

            parm_coll[5] = new OracleParameter("p_BranchID", OracleDbType.Decimal);
            parm_coll[5].Direction = ParameterDirection.Output;

            parm_coll[6] = new OracleParameter("p_UserName", OracleDbType.Varchar2, 500);
            parm_coll[6].Direction = ParameterDirection.Output;

            parm_coll[7] = new OracleParameter("p_BranchName", OracleDbType.Varchar2, 500);
            parm_coll[7].Direction = ParameterDirection.Output;

            parm_coll[8] = new OracleParameter("p_UserType", OracleDbType.Decimal);
            parm_coll[8].Direction = ParameterDirection.Output;

            parm_coll[9] = new OracleParameter("p_MobNum", OracleDbType.Varchar2, 20);
            parm_coll[9].Direction = ParameterDirection.Output;

            parm_coll[10] = new OracleParameter("p_OtpFlag", OracleDbType.Decimal);
            parm_coll[10].Direction = ParameterDirection.Output;

            parm_coll[11] = new OracleParameter("p_errorStatus", OracleDbType.Decimal, 500);
            parm_coll[11].Direction = ParameterDirection.Output;

            parm_coll[12] = new OracleParameter("p_errorMessage", OracleDbType.Varchar2, 4000);
            parm_coll[12].Direction = ParameterDirection.Output;

            parm_coll[13] = new OracleParameter("p_UserTypeName", OracleDbType.Varchar2, 4000);
            parm_coll[13].Direction = ParameterDirection.Output;

            parm_coll[14] = new OracleParameter("p_Version", OracleDbType.Decimal);
            parm_coll[14].Value = request.version;
            parm_coll[14].Direction = ParameterDirection.Input;

            parm_coll[15] = new OracleParameter("p_ModuleID", OracleDbType.Decimal);
            parm_coll[15].Value = request.moduleId;
            parm_coll[15].Direction = ParameterDirection.Input;

            new OracleDBAccessHelper().ExecuteNonQuery("aml_users.PROC_VALIDATE_USER_ACCOUNTS", parm_coll);

            string errorStatus = parm_coll[11].Value.ToString();
            string errorMessage = parm_coll[12].Value.ToString();

            if (errorStatus == "1")
            {
                loginResponse.isDataAvailable = true;
                loginResponse.branchId = Convert.ToInt64(parm_coll[5].Value.ToString());
                loginResponse.branchName = parm_coll[7].Value.ToString();
                loginResponse.token = token;
                loginResponse.userId = request.userId;
                loginResponse.userName = parm_coll[6].Value.ToString();
                loginResponse.accessLevelId = Convert.ToInt64(parm_coll[8].Value.ToString());
                loginResponse.accessLevelName = parm_coll[13].Value.ToString();
                loginResponse.mobileNumber = parm_coll[9].Value.ToString();
                loginResponse.otpFlag = Convert.ToInt64(parm_coll[10].Value.ToString());


            }
            loginResponse.message = errorMessage;
            return loginResponse;
        }

        #endregion

        #region Images
        /// <summary>
        /// API Number : 
        /// Created on : 03-sep-2021
        /// Created By : 100450
        /// Description: Get Images From Mongo DB
        /// </summary>

        public ImageResponse Images(ImageRequest request)
        {
            ImageResponse imagesResponse = new ImageResponse();
            MongoDBAccessHelper mongoDBAccessHelper = new MongoDBAccessHelper();
            var ImageData = mongoDBAccessHelper.SelectMultiple<MongoBaseMethod>(request.collectionName, "fileId", request.recordingId);
            if (ImageData.Count > 0)
            {
                imagesResponse.imageString = ImageData[0].data;
                imagesResponse.fileType = request.fileType;
                imagesResponse.isDataAvilable = true;
                //if (ImageData.Count > 1)
                //{
                List<ImageData> n = new List<ImageData>();
                for (int i = 0; i < ImageData.Count; i++)
                {
                    ImageData a = new ImageData();
                    a.imageString = ImageData[i].data;
                    a.fileType = request.fileType;
                    n.Add(a);
                }
                imagesResponse.ImageData = n;
                //}
            }
            return imagesResponse;
        }

        #endregion

    }
}





