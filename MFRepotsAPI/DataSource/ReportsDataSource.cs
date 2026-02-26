using ConnectionHandler;
using DTO.MFReportsAPI.Data;
using DTO.MFReportsAPI.Request;
using DTO.MFReportsAPI.Response;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MFReportsAPI.DataSource
{
    public class ReportsDataSource
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
        public ReportsDetailsResponse ReportDetails()
        {
            ReportsDetailsResponse reportsDetailsResponse = new ReportsDetailsResponse();
            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "REP001";
            oracleBaseMethodRequest.parameterValue = "";
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            reportsDetailsResponse.reportDetailsList = new OracleDBAccessHelper().GetRecords<ReportsDetailsData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
            if (reportsDetailsResponse.reportDetailsList.Count > 0)
            {
                reportsDetailsResponse.isDataAvailable = true;
            }
            return reportsDetailsResponse;
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
        public GenerateReportResponse GenerateReport(GenerateReportRequests request)
        {
            GenerateReportResponse generateReportResponse = new GenerateReportResponse();

            List<GetReportsProperties> dataList = new List<GetReportsProperties>();
            ReportParamsProperties params_name = new ReportParamsProperties();
            List<ReportPropertyNames> propname = new List<ReportPropertyNames>();
            List<string> PropertyTypes = new List<string>();
            List<string> urls = new List<string>();
            List<string> headerName = new List<string>();
            QueryProperties query_prp = new QueryProperties();

            string result = "";

            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "REP007";
            oracleBaseMethodRequest.parameterValue = request.reportId.ToString();
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            params_name = new OracleDBAccessHelper().GetRecord<ReportParamsProperties>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
            
            oracleBaseMethodRequest.parameterId = "REP008";
            oracleBaseMethodRequest.parameterValue = request.reportId.ToString()+"^"+request.type;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            query_prp = new OracleDBAccessHelper().GetRecord<QueryProperties>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);


            if (params_name != null)
            {
                result = query_prp.query;

                result = result.Replace(":r1", request.param1).Replace(":r21", '\'' + Convert.ToDateTime(request.param2).ToString("dd/MMM/yyyy") + '\'').Replace(":r22", '\'' + Convert.ToDateTime(request.param3).ToString("dd/MMM/yyyy") + '\'');
                if (params_name.reportParm3 != null)
                {

                    result += "and " + params_name.reportParm3 + "='" + request.param4 + "'";
                }
                if (params_name.reportParm5 != null)
                {

                    result += "and " + params_name.reportParm5 + "='" + request.param5 + "'";
                }
                if (params_name.reportParm41 != null & params_name.reportParm42 != null)
                {
                    result = result.Replace(":r31", '\'' + Convert.ToDateTime(request.param6).ToString("dd/MMM/yyyy") + '\'').Replace(":r32", '\'' + Convert.ToDateTime(request.param7).ToString("dd/MMM/yyyy") + '\'');

                }
                //List<string> excuter = new List<string>();
                //excuter = new OracleDBAccessHelper().GetRecords<string>(result, null);

                List<GetStringData> excuter = new List<GetStringData>();
                excuter = new OracleDBAccessHelper().GetRecords<GetStringData>(result);

                foreach (var items in excuter)
                {
                    dataList.Add(new GetReportsProperties { resultset = items.value });
                }

                //oracleBaseMethodRequest.parameterId = "REP004";
                //oracleBaseMethodRequest.parameterValue = request.reportId + "^" + 0;
                //oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
                //string linkfields = new OracleDBAccessHelper().GetRecord<GetStringData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

                if (dataList.Count > 0)
                {


                    generateReportResponse.header = query_prp.header;
                    generateReportResponse.alignment = query_prp.alignment;
                    generateReportResponse.Urls = query_prp.url;
                    generateReportResponse.urlParams = query_prp.urlParams;
                    generateReportResponse.linkFields = query_prp.linkFields;
                    generateReportResponse.chartType = params_name.chartType;
                    generateReportResponse.resulset = dataList;
                    generateReportResponse.xParam = query_prp.xParam;
                    generateReportResponse.yParam = query_prp.yParam;
                    generateReportResponse.isDataAvailable = true;

                }
            }
            return generateReportResponse;


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
        public GenerateReportResponse ReportsDrillDown(DrilldownReportsRequest request)
        {
            GenerateReportResponse generateReportResponse = new GenerateReportResponse();
            QueryProperties queryprop = new QueryProperties();
            List<GetReportsProperties> dataList = new List<GetReportsProperties>();

            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "REP003";
            oracleBaseMethodRequest.parameterValue = request.reportId + "^" + request.levelNo + "^" + request.linkField + "^" + request.type;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            queryprop = new OracleDBAccessHelper().GetRecord<QueryProperties>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

            string query = queryprop.query;
            if (request.parms != null)
            {
                string[] parameters = request.parms.Split('*');

                for (int i = 0; i <= parameters.Count() - 1; i++)
                {

                    if (parameters[i].Contains("||") == true)
                    {
                        string[] dates = parameters[i].Split("||");
                        if (dates.Count() > 0)
                        {
                            query = query.Replace(":d1", '\'' + Convert.ToDateTime(dates[0]).ToString("dd/MMM/yyyy") + '\'').Replace(":d2", '\'' + Convert.ToDateTime(dates[1]).ToString("dd/MMM/yyyy") + '\'');
                            query = query.Replace(":d3", '\'' + Convert.ToDateTime(dates[0]).ToString("dd/MMM/yyyy") + '\'').Replace(":d4", '\'' + Convert.ToDateTime(dates[1]).ToString("dd/MMM/yyyy") + '\'');
                        }

                    }
                    else
                    {
                        query = query.Replace(":r" + i + 1 + "", parameters[i]);
                    }


                    //}


                }

            }
            if (request.link_value != null)
            {
                query = query.Replace(":l1", request.link_value);
            }

            List<GetStringData> excuter = new List<GetStringData>();
            excuter = new OracleDBAccessHelper().GetRecords<GetStringData>(query);         

            foreach (var items in excuter)
            {
                dataList.Add(new GetReportsProperties { resultset = items.value });
            }

            GetStringData getStringData = new GetStringData();
            oracleBaseMethodRequest.parameterId = "REP004";
            oracleBaseMethodRequest.parameterValue = request.reportId + "^" + 0;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            getStringData = new OracleDBAccessHelper().GetRecord<GetStringData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

            GetIntData getIntData = new GetIntData();
            oracleBaseMethodRequest.parameterId = "REP005";
            oracleBaseMethodRequest.parameterValue = request.reportId;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            getIntData = new OracleDBAccessHelper().GetRecord<GetIntData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

            if (getIntData.value == Convert.ToInt32(request.levelNo))
            {
                generateReportResponse.lastLevel = 1;
            }
            else
            {
                generateReportResponse.lastLevel = 0;
            }
            generateReportResponse.header = queryprop.header;
            generateReportResponse.Urls = queryprop.url;
            generateReportResponse.urlParams = queryprop.urlParams;
            generateReportResponse.linkFields = getStringData.value;
            generateReportResponse.resulset = dataList;
            generateReportResponse.xParam = queryprop.xParam;
            generateReportResponse.yParam = queryprop.yParam;
            generateReportResponse.isDataAvailable = true;

            return generateReportResponse;


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
        //public GenerateNewReportResponse GenerateNewReport(GetNewDataReportRequest request)
        //{
        //    GenerateNewReportResponse generateNewReportResponse = new GenerateNewReportResponse();

        //    List<GetReportsProperties> dataList = new List<GetReportsProperties>();
        //    ReportParamsProperties params_name = new ReportParamsProperties();
        //    List<ReportPropertyNames> propname = new List<ReportPropertyNames>();
        //    List<string> PropertyTypes = new List<string>();
        //    List<string> urls = new List<string>();
        //    List<string> headerName = new List<string>();
        //    QueryNewReportProperties query_prp = new QueryNewReportProperties();
        //    List<QueryNewReportProperties> qry_prp_list = new List<QueryNewReportProperties>();
        //    string query = "";
        //    int Querry_Format = 0;
        //    byte[] imageData;
        //    string result = "";
        //    string base64String = "";
        //    int dtlreqoid = 0;
        //    if (request.DtlreportId == 0)
        //    {
        //        dtlreqoid = 101;

        //    }
        //    else
        //    {
        //        dtlreqoid = request.DtlreportId;

        //    }



        //    OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
        //    OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
        //    OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
        //    oracleBaseMethodRequest.parameterId = "REP007";
        //    oracleBaseMethodRequest.parameterValue = request.reportId.ToString();
        //    oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
        //    params_name = new OracleDBAccessHelper().GetRecord<ReportParamsProperties>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);


        //    oracleBaseMethodRequest.parameterId = "REP008";
        //    oracleBaseMethodRequest.parameterValue = request.reportId.ToString();
        //    oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
        //    query_prp = new OracleDBAccessHelper().GetRecord<QueryNewReportProperties>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);


        //    if (params_name != null)
        //    {
        //        result = query_prp.query;
        //        Querry_Format = query_prp.querry_format;
        //        List<string> excuter = new List<string>();
        //        if (Querry_Format == 0)
        //        {
        //            result = result.Replace(":l1", request.loan_id.ToString());

        //            excuter = new OracleDBAccessHelper().GetRecords<string>(result, null);
        //            foreach (var items in excuter)
        //            {
        //                dataList.Add(new GetReportsProperties { resultset = items });
        //            }
        //        }
        //        else
        //        {
        //            imageData = new OracleDBAccessHelper().GetRecord<byte[]>(result, null);
        //            base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
        //        }

        //        oracleBaseMethodRequest.parameterId = "REP004";
        //        oracleBaseMethodRequest.parameterValue = request.reportId + "^" + 0;
        //        oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
        //        string linkfields = new OracleDBAccessHelper().GetRecord<string>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

        //        oracleBaseMethodRequest.parameterId = "REP009";
        //        oracleBaseMethodRequest.parameterValue = request.reportId + "^" + 0;
        //        oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
        //        string buttonHeader = new OracleDBAccessHelper().GetRecord<string>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);


        //        if (dataList.Count > 0)
        //        {
        //            generateNewReportResponse.header = query_prp.header;
        //            generateNewReportResponse.Urls = query_prp.url;
        //            generateNewReportResponse.Url_Params = query_prp.Url_Params;
        //            generateNewReportResponse.link_fields = linkfields;
        //            generateNewReportResponse.view_model = query_prp.view_model;
        //            generateNewReportResponse.main_header = query_prp.main_header;
        //            generateNewReportResponse.align_status = query_prp.align_status;
        //            generateNewReportResponse.resulset = dataList;
        //            generateNewReportResponse.DisplayImage = base64String;
        //            generateNewReportResponse.buttonHeader = buttonHeader;
        //            generateNewReportResponse.sub_rpt_id = query_prp.sub_rpt_id;
        //            generateNewReportResponse.ChartType = params_name.chartType;
        //            generateNewReportResponse.isDataAvailable = true;
        //        }
        //    }

        //    return generateNewReportResponse;


        //}
        //#endregion



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
        public GenerateReportResponse ReportsData(ReportsDatarequest request)
        {
            List<DataByIdProperties> resultset = new List<DataByIdProperties>();
            List<GetReportsProperties> dataList = new List<GetReportsProperties>();
            List<ReportPropertyNames> propname = new List<ReportPropertyNames>();
            List<string> PropertyTypes = new List<string>();
            List<string> urls = new List<string>();
            List<string> headerName = new List<string>();
            string result = "";

            QueryProperties query_prp = new QueryProperties();

            GenerateReportResponse generateReportResponse = new GenerateReportResponse();
            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "REP002";
            oracleBaseMethodRequest.parameterValue = request.reportId + "^" + request.typeId;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            query_prp = new OracleDBAccessHelper().GetRecord<QueryProperties>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

            if (query_prp != null)
            {
                result = query_prp.query;
                if (request.parms != null)
                {
                    string[] parameters_val = request.parms.Split('*');
                    int i = 0;
                    int j = 0;

                    while (i <= parameters_val.Count() - 1)
                    {

                        j = i + 1;

                        string r = ":r" + j + "";
                        result = result.Replace(r.Trim(), parameters_val[i]);
                        i++;


                    }

                }
                List<string> excuter = new List<string>();
                excuter = new OracleDBAccessHelper().GetRecords<string>(result, null);
                foreach (var items in excuter)
                {
                    dataList.Add(new GetReportsProperties { resultset = items });
                }

                generateReportResponse.isDataAvailable = true;
                generateReportResponse.header = query_prp.header;
                generateReportResponse.Urls = query_prp.url;
                generateReportResponse.urlParams = query_prp.urlParams;
                generateReportResponse.resulset = dataList;

            }
            return generateReportResponse;


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
        public GenerateReportResponse ReportsLevelThree(ReportsDatarequest request)
        {
            GenerateReportResponse generateReportResponse = new GenerateReportResponse();
            List<DataByIdProperties> resultset = new List<DataByIdProperties>();
            List<GetReportsProperties> dataList = new List<GetReportsProperties>();
            List<ReportPropertyNames> propname = new List<ReportPropertyNames>();
            List<string> PropertyTypes = new List<string>();
            List<string> urls = new List<string>();
            List<string> headerName = new List<string>();
            string result = "";

            QueryProperties query_prp = new QueryProperties();

            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "REP006";
            oracleBaseMethodRequest.parameterValue = request.reportId + "^" + request.typeId;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            query_prp = new OracleDBAccessHelper().GetRecord<QueryProperties>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
            if (query_prp != null)
            {
                result = query_prp.query;
                if (request.parms != null)
                {
                    string[] parameters_val = request.parms.Split('*');
                    int i = 0;
                    int j = 0;

                    while (i <= parameters_val.Count() - 1)
                    {

                        j = i + 1;
                        string r = ":r" + j + "";

                        result = result.Replace(r.Trim(), parameters_val[i]);
                        i++;

                    }


                }
                List<string> excuter = new List<string>();
                excuter = new OracleDBAccessHelper().GetRecords<string>(result, null);

                foreach (var items in excuter)
                {
                    dataList.Add(new GetReportsProperties { resultset = items });
                }

                generateReportResponse.header = query_prp.header;
                generateReportResponse.Urls = query_prp.url;
                generateReportResponse.urlParams = query_prp.urlParams;
                generateReportResponse.resulset = dataList;
                generateReportResponse.isDataAvailable = true;

            }
            return generateReportResponse;

            
        }
        #endregion

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
        public GenerateAllReportResponse GeneratAllReport(GetNewDataReportRequest request)
        {
            GenerateAllReportResponse generateAllReportResponse = new GenerateAllReportResponse();

            List<GetReportsProperties> dataList = new List<GetReportsProperties>();
            ReportParamsProperties params_name = new ReportParamsProperties();
            List<ReportPropertyNames> propname = new List<ReportPropertyNames>();
            List<string> PropertyTypes = new List<string>();
            List<string> urls = new List<string>();
            List<string> headerName = new List<string>();
            List<QueryNewReportProperties> query_prp = new List<QueryNewReportProperties>();
            List<QueryNewReportProperties> qry_prp_list = new List<QueryNewReportProperties>();
            List<string> header = new List<string>();
            List<string> url = new List<string>();
            List<string> url_params = new List<string>();
            List<string> view_model = new List<string>();
            List<string> main_header = new List<string>();
            List<string> align_status = new List<string>();
            List<string> sub_rpt_id = new List<string>();
            List<string> reportDtlid = new List<string>();
            string query = "";
            int Querry_Format = 0;
            byte[] imageData;
            string result = "";
            string base64String = "";
            int dtlreqoid = 0;
            if (request.DtlreportId == 0)
            {
                dtlreqoid = 101;

            }
            else
            {
                dtlreqoid = request.DtlreportId;

            }

            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "REP007";
            oracleBaseMethodRequest.parameterValue = request.reportId.ToString() ;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);

            query = new OracleDBAccessHelper().GetRecord<string>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);


            oracleBaseMethodRequest.parameterId = "REP008";
            oracleBaseMethodRequest.parameterValue = request.reportId.ToString();
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);

            query_prp = new OracleDBAccessHelper().GetRecords<QueryNewReportProperties>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);



            if (params_name != null)
            {
                foreach (var loopvar in query_prp)
                {
                    result = loopvar.query;
                    Querry_Format = loopvar.querry_format;
                    List<string> excuter = new List<string>();
                    if (Querry_Format == 0)
                    {
                        result = result.Replace(":l1", request.loan_id.ToString());

                        excuter = new OracleDBAccessHelper().GetRecords<string>(result,  null);
                        foreach (var items in excuter)
                        {
                            dataList.Add(new GetReportsProperties { resultset = items });
                        }
                    }
                    else
                    {
                        imageData = new OracleDBAccessHelper().GetRecord<byte[]>(result,  null);
                        base64String = Convert.ToBase64String(imageData, 0, imageData.Length);

                    }
                    header.Add(loopvar.header);
                    url.Add(loopvar.url);
                    url_params.Add(loopvar.Url_Params);
                    view_model.Add(loopvar.view_model);
                    main_header.Add(loopvar.main_header);
                    align_status.Add(loopvar.align_status);
                    sub_rpt_id.Add(loopvar.sub_rpt_id.ToString());
                    reportDtlid.Add(loopvar.report_dtl_id.ToString());
                }
                oracleBaseMethodRequest.parameterId = "REP004";
                oracleBaseMethodRequest.parameterValue = request.reportId + "^" + 0;
                oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
                string linkfields = new OracleDBAccessHelper().GetRecord<string>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

                oracleBaseMethodRequest.parameterId = "REP009";
                oracleBaseMethodRequest.parameterValue = request.reportId + "^" + 0;
                oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
                string buttonHeader = new OracleDBAccessHelper().GetRecord<string>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);


                if (dataList.Count > 0)
                {
                    generateAllReportResponse.header = header;
                    generateAllReportResponse.Urls = url;
                    generateAllReportResponse.Url_Params = url_params;
                    generateAllReportResponse.link_fields = linkfields;
                    generateAllReportResponse.view_model = view_model;
                    generateAllReportResponse.main_header = main_header;
                    generateAllReportResponse.align_status = align_status;
                    generateAllReportResponse.resulset = dataList;
                    generateAllReportResponse.DisplayImage = base64String;
                    generateAllReportResponse.buttonHeader = buttonHeader;
                    generateAllReportResponse.sub_rpt_id = sub_rpt_id;                  
                    generateAllReportResponse.ChartType = params_name.chartType;
                    generateAllReportResponse.isDataAvailable = true;
                }
            }

            return generateAllReportResponse;
            
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
        public DynamicReportResponse DynamicReport(DynamicReportRequest request)
        {
            DynamicReportResponse dynamicReportResponse = new DynamicReportResponse();
            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "REP011";
            oracleBaseMethodRequest.parameterValue = request.accessLevelId.ToString() + "^" + request.userId + "^" + request.branchId + "^" + request.moduleId;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            dynamicReportResponse.dynamicReportDatas = new OracleDBAccessHelper().GetRecords<DynamicReportData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
            if (dynamicReportResponse.dynamicReportDatas.Count > 0)
            {
                dynamicReportResponse.isDataAvailable = true;
            }
            return dynamicReportResponse;
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


        public GenerateDynamicReportResponse GenerateDynamicReport(GenerateDynamicReportRequest request)
        {
            GenerateDynamicReportResponse generateDynamicReportResponse = new GenerateDynamicReportResponse();

            OracleParameter[] parameters = new OracleParameter[16];
            parameters[0] = new OracleParameter("p_reportID", OracleDbType.Long);
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = request.reportId;

            parameters[1] = new OracleParameter("p_levelID", OracleDbType.Long);
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = request.levelId;

            parameters[2] = new OracleParameter("p_userID", OracleDbType.Long);
            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = request.userId;

            parameters[3] = new OracleParameter("p_branchID", OracleDbType.Long);
            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = request.branchId;

            parameters[4] = new OracleParameter("p_comboValue", OracleDbType.Varchar2,1000);
            parameters[4].Direction = ParameterDirection.Input;
            parameters[4].Value = request.comboBoxData;

            parameters[5] = new OracleParameter("p_textboxValue", OracleDbType.Varchar2, 1000);
            parameters[5].Direction = ParameterDirection.Input;
            parameters[5].Value = request.textBoxData;

            parameters[6] = new OracleParameter("p_dateField", OracleDbType.Varchar2, 1000);
            parameters[6].Direction = ParameterDirection.Input;
            parameters[6].Value = request.dateData;

            parameters[7] = new OracleParameter("P_linkField", OracleDbType.Varchar2, 1000);
            parameters[7].Direction = ParameterDirection.Input;
            parameters[7].Value = request.linkField;

            parameters[8] = new OracleParameter("p_headerText", OracleDbType.Varchar2, 1000);
            parameters[8].Direction = ParameterDirection.Output;

            parameters[9] = new OracleParameter("p_LinkText", OracleDbType.Varchar2, 1000);
            parameters[9].Direction = ParameterDirection.Output;

            parameters[10] = new OracleParameter("p_linkLevelID ", OracleDbType.Varchar2, 4000);
            parameters[10].Direction = ParameterDirection.Output;


            parameters[11] = new OracleParameter("p_errorStatus", OracleDbType.Decimal, 500);
            parameters[11].Direction = ParameterDirection.Output;

            parameters[12] = new OracleParameter("p_errorMessage", OracleDbType.Varchar2, 4000);
            parameters[12].Direction = ParameterDirection.Output;

            parameters[13] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[13].Direction = ParameterDirection.Output;

            parameters[14] = new OracleParameter("p_categoryID", OracleDbType.Long);
            parameters[14].Direction = ParameterDirection.Input;
            parameters[14].Value = request.categoryId;

            parameters[15] = new OracleParameter("p_panelValue", OracleDbType.Varchar2, 4000);
            parameters[15].Direction = ParameterDirection.Output;

            



            var data = new OracleDBAccessHelper().GetRecords<GenerateDynamicReportData>("proc_generate_reports", parameters);

           
            List<GenerateDynamicReportData> generateDynamicReportDatas = new List<GenerateDynamicReportData>();
         
            generateDynamicReportDatas = data;
            string headerText = parameters[8].Value.ToString();
            string linkText = parameters[9].Value.ToString();
            string linkLevelId = parameters[10].Value.ToString();
            string panelValue = parameters[15].Value.ToString();
            generateDynamicReportResponse.headers = headerText;
            generateDynamicReportResponse.linkField = linkText;
            generateDynamicReportResponse.linklevelId = linkLevelId;
            generateDynamicReportResponse.panelValue = panelValue;
            if (generateDynamicReportDatas.Count>0)
            {
                generateDynamicReportResponse.isDataAvailable = true;
            }
            generateDynamicReportResponse.reportDatas = generateDynamicReportDatas;


            return generateDynamicReportResponse;
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
        public ComboFillResponse Combofill(ComboFillRequest request)
        {
            ComboFillResponse comboFillResponse = new ComboFillResponse();  

            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("p_userID", OracleDbType.Long);
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = request.userId;

            parameters[1] = new OracleParameter("p_branchID", OracleDbType.Long);
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = request.branchId;

            parameters[2] = new OracleParameter("p_accesslevelID", OracleDbType.Long);
            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = request.accessLevelId;

            parameters[3] = new OracleParameter("p_Query", OracleDbType.Varchar2,4000);
            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = request.query;        

            parameters[4] = new OracleParameter("p_errorStatus", OracleDbType.Decimal, 500);
            parameters[4].Direction = ParameterDirection.Output;

            parameters[5] = new OracleParameter("p_errorMessage", OracleDbType.Varchar2, 4000);
            parameters[5].Direction = ParameterDirection.Output;

            parameters[6] = new OracleParameter("p_queryresult", OracleDbType.RefCursor);
            parameters[6].Direction = ParameterDirection.Output;

            var data = new OracleDBAccessHelper().GetRecords<ComboFillProperties>("proc_Combo_Fill", parameters);

            if(data.Count>0)
            {
                comboFillResponse.isDataAvailable = true;
            }
            comboFillResponse.resultset = data;
            return comboFillResponse;


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
        public CustomerStatementResponse CustomerStatement(CustomerStatementRequest request)
        {
            CustomerStatementResponse customerStatementResponse = new CustomerStatementResponse();

            string requestParameters = string.Empty;
            if (request.typeId==3)
            {
                //1001IGFW000949^30505^04/01/2020^06/03/2020
                string[] parm = request.parameters.Split("^");
                string fromDt = Convert.ToDateTime(parm[2].ToString()).ToString("dd/MMM/yyyy");
                string toDt = Convert.ToDateTime(parm[3].ToString()).ToString("dd/MMM/yyyy");

                requestParameters = parm[0].ToString() + "^" + parm[1].ToString() + "^" + fromDt + "^" + toDt;
            }
            else
            {
                requestParameters = request.parameters;
            }
           
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("p_TypeID", OracleDbType.Long);
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = request.typeId;

            parameters[1] = new OracleParameter("p_params", OracleDbType.Varchar2,4000);
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = requestParameters;        

            parameters[2] = new OracleParameter("p_queryResult", OracleDbType.RefCursor);
            parameters[2].Direction = ParameterDirection.Output;

            var customerStatementResult = new OracleDBAccessHelper().GetRecords<CustomerStatementData>("proc_Customer_Statement", parameters);

          
            customerStatementResponse.isDataAvailable = true;
            
          
            customerStatementResponse.customerStatementResult = customerStatementResult;
            return customerStatementResponse;


        }
        #endregion

        #region AssignReportComboFill
        /// <summary>
        /// API Number : REP012
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: AssignReportComboFill
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        public AssignReportComboResponse AssignReportComboFill(AssignReportComboRequest request)
        {
            AssignReportComboResponse assignReportComboResponse = new AssignReportComboResponse();
            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            oracleBaseMethodRequest.parameterId = "REP012";
            oracleBaseMethodRequest.parameterValue = request.userID.ToString();
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);
            //assignReportComboResponse = new OracleDBAccessHelper().GetRecord<AssignReportComboResponse>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);
            assignReportComboResponse.reportListData = new OracleDBAccessHelper().GetRecords<AssignReportListData>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);

            //if (assignReportComboResponse != null)
            //{
            //    assignReportComboResponse.isDataAvailable = true;
            //}
            if (assignReportComboResponse.reportListData.Count > 0)
            {
                assignReportComboResponse.isDataAvailable = true;
            }
            return assignReportComboResponse;
        }
        #endregion

        #region AssignReport
        /// <summary>
        /// API Number : 
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: AssignReport
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>
        public AssignReportResponse AssignReport(AssignReportRequest request)
        {
            AssignReportResponse assignReportResponse = new AssignReportResponse();

            OracleParameter[] parameters = new OracleParameter[5];

            parameters[0] = new OracleParameter("p_ReportID", OracleDbType.Decimal);
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[0].Value = request.reportId;

            parameters[1] = new OracleParameter("p_EmpCode", OracleDbType.Decimal);
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = request.empCode;

            parameters[2] = new OracleParameter("p_UserID", OracleDbType.Decimal);
            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = request.userId;

            parameters[3] = new OracleParameter("p_errorStatus", OracleDbType.Decimal);
            parameters[3].Direction = ParameterDirection.Output;

            parameters[4] = new OracleParameter("p_errorMessage", OracleDbType.Varchar2, 4000);
            parameters[4].Direction = ParameterDirection.Output;

            new OracleDBAccessHelper().ExecuteNonQuery("proc_assign_report", parameters);

            string errorStatus = parameters[3].Value.ToString();
            string errorMessage = parameters[4].Value.ToString();

            if (errorStatus == "1" || errorStatus == "0")
            {
                assignReportResponse.isDataAvailable = true;
            }
            

            assignReportResponse.message = errorMessage;
            return assignReportResponse;
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

        public PhotoPunchingReportResponse PhotoPunch(PhotoPunchingReportRequest request)
        {
            PhotoPunchingReportResponse photoPunchingReportResponse = new PhotoPunchingReportResponse();
            OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
            OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
            OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
            if (request.employeeCode > 0)
            {
                oracleBaseMethodRequest.parameterId = "REP013"; //REP014 in production
            }
            else
            {
                oracleBaseMethodRequest.parameterId = "REP014"; //REP015 in production
            }
            oracleBaseMethodRequest.parameterValue = request.fromDate + "^" + request.toDate + "^" + request.employeeCode+ "^" + request.branchId;
            oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);

            var photoPunchingList = new OracleDBAccessHelper().GetRecords<PhotoPunchingReportData1>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);



            List<PhotoPunchingReportData> punchData = new List<PhotoPunchingReportData>();
            if (photoPunchingList.Count > 0)
            {
                for (int i = 0; i < photoPunchingList.Count; i++)
                {
                    string base64StringM = null;
                    string base64StringE = null;
                    string base64StringO = null;

                    if (photoPunchingList[i].mPhoto != null)
                    {
                        byte[] imagebyteM = photoPunchingList[i].mPhoto;
                        base64StringM = Convert.ToBase64String(imagebyteM, 0, imagebyteM.Length);

                    }
                    if (photoPunchingList[i].ePhoto != null)
                    {


                        byte[] imagebyteE = photoPunchingList[i].ePhoto;
                        base64StringE = Convert.ToBase64String(imagebyteE, 0, imagebyteE.Length);

                    }
                    if (photoPunchingList[i].originalPhoto != null)
                    {


                        byte[] imagebyteO = photoPunchingList[i].originalPhoto;
                        base64StringO = Convert.ToBase64String(imagebyteO, 0, imagebyteO.Length);

                    }

                    punchData.Add(new PhotoPunchingReportData
                    {
                        branchID = photoPunchingList[i].branchID,
                        empCode = photoPunchingList[i].empCode,
                        empName = photoPunchingList[i].empName,
                        empDesignation = photoPunchingList[i].empDesignation,
                        empDepartment = photoPunchingList[i].empDepartment,
                        empCategory = photoPunchingList[i].empCategory,
                        mBranch = photoPunchingList[i].mBranch,
                        eBranch = photoPunchingList[i].eBranch,
                        mLocation = photoPunchingList[i].mLocation,
                        eLocation = photoPunchingList[i].eLocation,
                        currentDate = photoPunchingList[i].currentDate,
                        mTime = photoPunchingList[i].mTime,
                        eTime = photoPunchingList[i].eTime,
                        mPhoto = base64StringM,
                        ePhoto = base64StringE,
                        originalPhoto = base64StringO,
                    });
                }
                photoPunchingReportResponse.photoPunchingList = punchData;
                photoPunchingReportResponse.isDataAvailable = true;

            }



            return photoPunchingReportResponse;
        }
        #endregion


       
    }


}

