using DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace Base
{
    public class Token : IToken
    {
        //public IDBAccessHelper helper;

        //public Token(IDBAccessHelper _helper)
        //{
        //    helper = _helper;

        //}
        //public bool isValidToken(string userContextObj)
        //{
        //    bool isValidToken = false;

        //    try
        //    {
        //        OracleParameter[] parm_coll = new OracleParameter[3];

        //        parm_coll[0] = new OracleParameter("var_token", OracleDbType.Varchar2);
        //        parm_coll[0].Value = userContextObj;
        //        parm_coll[0].Direction = ParameterDirection.Input;
        //        parm_coll[1] = new OracleParameter("var_otp_duration", OracleDbType.Decimal);
        //        parm_coll[1].Value = (int)Durations.LoginOTP;
        //        parm_coll[1].Direction = ParameterDirection.Input;
        //        parm_coll[2] = new OracleParameter("out_status", OracleDbType.Decimal);
        //        parm_coll[2].Direction = ParameterDirection.Output;

        //        helper.ExecuteNonQuery("proc_ValidateToken", parm_coll);
        //        if (parm_coll[2].Value.ToString() == "1")
        //        {
        //            isValidToken = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        isValidToken = false;
        //    }
        //    return isValidToken;
        //}

        public bool isValidToken(string userContextObj)
        {

        //    ValidTokenResponse validTokenResponse = new ValidTokenResponse();
        //    ValidTokenRequest validTokenRequest = new ValidTokenRequest();
        //    Response<ValidTokenResponse> response = new Response<ValidTokenResponse>();
           bool isValidToken = false;
        //    try
        //    {
        //        PublicConfigManager appConfigManager = new PublicConfigManager();
        //        validTokenRequest.userContextObj = userContextObj;
        //        //------Call Token ValidationAPI--//
        //        response = new ApiManager().InvokePostHttpClient<Response<ValidTokenResponse>, ValidTokenRequest>(validTokenRequest, appConfigManager.getgeneralApiUrl + "api/login/validatetoken", null).Item1;
        //        if (response.status == "SUCCESS")
        //        {
        //            validTokenResponse.flag = response.Data.flag;
        //            isValidToken = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Exception exception = ex;
        //        response.status = "Exception";
        //        response.responseMsg = "Internal Server Error";
        //        response.SetExceptionError(ex.Message);

        //    }

            return isValidToken;
        }
    }
}
