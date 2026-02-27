using ConnectionHandler;
using DTO.MFReportsAPI.Data;
using DTO.MFReportsAPI.Request;
using DTO.MFReportsAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFReportsAPI.DataSource
{
    public class PhotoPunchingReportDataSource
    {
    //    #region PhotoPunchReport
    //    /// <summary>
    //    /// API Number : REP014
    //    /// Created on : 28-Jul-2021
    //    /// Created By : 100367
    //    /// Description: PhotoPunchReport
    //    /// Modify Date:
    //    /// Modify By  : 
    //    /// Description:
    //    /// </summary>

    //    public PhotoPunchingReportResponse PhotoPunch(PhotoPunchingReportRequest request)
    //    {
    //        PhotoPunchingReportResponse photoPunchingReportResponse = new PhotoPunchingReportResponse();
    //        OracleBaseMethodRequest oracleBaseMethodRequest = new OracleBaseMethodRequest();
    //        OracleBaseMethodResponse oracleBaseMethodResponse = new OracleBaseMethodResponse();
    //        OracleBaseMethod oracleBaseMethod = new OracleBaseMethod();
    //        oracleBaseMethodRequest.parameterId = "REP013";
    //        oracleBaseMethodRequest.parameterValue = request.fromDate + "^" + request.toDate + "^" + request.employeeCode;
    //        oracleBaseMethodResponse = oracleBaseMethod.BaseMethodReport(oracleBaseMethodRequest);

    //        var photoPunchingList = new OracleDBAccessHelper().GetRecords<PhotoPunchingReportData1>(oracleBaseMethodResponse.query, oracleBaseMethodResponse.parameters);



    //        List<PhotoPunchingReportData> punchData = new List<PhotoPunchingReportData>();
    //        if (photoPunchingList.Count > 0)
    //        {
    //            for (int i = 0; i < photoPunchingList.Count; i++)
    //            {
    //                string base64StringM = null;
    //                string base64StringE = null;

    //                if (photoPunchingList[i].mPhoto != null)
    //                {
    //                    byte[] imagebyteM = photoPunchingList[i].mPhoto;
    //                    base64StringM = Convert.ToBase64String(imagebyteM, 0, imagebyteM.Length);

    //                }
    //                if (photoPunchingList[i].ePhoto != null)
    //                {


    //                    byte[] imagebyteE = photoPunchingList[i].ePhoto;
    //                    base64StringE = Convert.ToBase64String(imagebyteE, 0, imagebyteE.Length);

    //                }

    //                punchData.Add(new PhotoPunchingReportData
    //                {
    //                    empCode = photoPunchingList[i].empCode,
    //                    empName = photoPunchingList[i].empName,
    //                    mBranch = photoPunchingList[i].mBranch,
    //                    eBranch = photoPunchingList[i].eBranch,
    //                    mLocation = photoPunchingList[i].mLocation,
    //                    eLocation = photoPunchingList[i].eLocation,
    //                    currentDate = photoPunchingList[i].currentDate,
    //                    mTime = photoPunchingList[i].mTime,
    //                    eTime = photoPunchingList[i].eTime,
    //                    mPhoto = base64StringM,
    //                    ePhoto = base64StringE,
    //                });
    //            }
    //            photoPunchingReportResponse.photoPunchingList = punchData;
    //            photoPunchingReportResponse.isDataAvailable = true;

    //        }



    //        return photoPunchingReportResponse;
    //    }
    }
  
}
