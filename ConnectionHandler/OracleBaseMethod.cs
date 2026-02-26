using MongoDB.Bson;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConnectionHandler
{
    public  class OracleBaseMethod
    {
      
        public OracleBaseMethodResponse BaseMethodLms(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();          

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_paramid", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_paramlist", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorstatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;          
            response.query = "proc_query_result_lms";       
           
            return response;

        }
        public OracleBaseMethodResponse BaseMethodLos(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_paramid", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_paramlist", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorstatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;          
            response.query = "proc_query_result_los";          
            return response;

        }
        public OracleBaseMethodResponse BaseMethodCustomer(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_paramid", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_paramlist", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorstatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;         
            response.query = "proc_query_result_customer";
          
            return response;

        }
        public OracleBaseMethodResponse BaseMethodUsers(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_paramid", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_paramlist", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorstatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;          
            response.query = "proc_query_result_users";
          
            return response;

        }
        public OracleBaseMethodResponse BaseMethodAccounts(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_paramid", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_paramlist", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorstatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;
            response.query = "proc_query_result_accounts";
          
            return response;

        }
        public OracleBaseMethodResponse BaseMethodLosReport(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_ParamID", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_ParamList", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryResult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorStatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;
            response.query = "proc_pending_report";

            return response;

        }
        public OracleBaseMethodResponse BaseMethodOnline(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_paramid", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_paramlist", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorstatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;
            response.query = "proc_query_result_online";

            return response;

        }

        public OracleBaseMethodResponse BaseMethodReport(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_paramid", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_paramlist", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorstatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;
            response.query = "proc_query_result_reports";

            return response;

        }

        public OracleBaseMethodResponse BaseMethodHRMS(OracleBaseMethodRequest request)
        {
            OracleBaseMethodResponse response = new OracleBaseMethodResponse();

            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_paramid", OracleDbType.Varchar2);
            parameters[0].Value = request.parameterId;
            parameters[0].Direction = ParameterDirection.Input;

            parameters[1] = new OracleParameter("p_paramlist", OracleDbType.Varchar2);
            parameters[1].Value = request.parameterValue;
            parameters[1].Direction = ParameterDirection.Input;

            parameters[2] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            parameters[3] = new OracleParameter("p_errorstatus", OracleDbType.Int32);
            parameters[3].Direction = ParameterDirection.Output;

            response.parameters = parameters;
            response.query = "proc_query_result_hrm";

            return response;

        }

        
    }
    public class OracleBaseMethodRequest
    {
        public string parameterId { get; set; }
        public string parameterValue { get; set; }      

    }
    public class OracleBaseMethodResponse
    {
        public OracleParameter[] parameters { get; set; }
        public string query { get; set; }

    }

    public class MongoBaseMethod
    {    
        public ObjectId Id { get; set; }
        public string fileId { get; set; }       
        public string fileName { get; set; }
        public string fileType { get; set; }
        public byte[] data { get; set; }
        public string customerCode { get; set; }
        public string customerName { get; set; }


    }


    public class MongoBaseMethodstring
    {
        public ObjectId Id { get; set; }
        public string fileId { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public string  data { get; set; }



    }
}
