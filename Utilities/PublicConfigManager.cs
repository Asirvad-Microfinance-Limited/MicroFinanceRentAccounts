using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utilities
{
   public class PublicConfigManager
    {

        #region summary
        /// <summary>       
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: PublicConfigManager
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>

        #endregion

        #region Declarations
        //-----DB Connection-----//
       
        public static string baseUrl;
        public static string siteUrl;

        //-----Public API Urls-----//
        public static string accountsApiUrl;
        public static string accountsRentApiUrl;
        public static string customerApiUrl;
        public static string generalApiUrl;
        public static string lmsApiUrl;
        public static string losApiUrl;
        public static string EquifaxapiUrl;
        public static string crifUrl;
        public static string CKYCUrl;
        public static string PROJECTTRACKERAPIUrl;
        public static string adharDtaurl;
        public static string adharotpurl;
        public static string collectionApiUrl;
        public static string reportsApiUrl;
        public static string googleAPIKeyUrl;
        public static string flagGoogleAPISettings;
        public static string sharedPath;
        public static string HRMSApiUrl;
        public static string tmsAPIUrl;

        //-------MongoDB Connections-------------//

        public static string mongoDbName;
        public static string mongoDbPassword;
        public static string mongoUsername;
        public static string mongoAddress;

        #endregion

        #region PublicConfigManager
        public PublicConfigManager()
        {
            string property = string.Empty;

            try
            {
                //-----GET Shared folder Data-----//
                var configurationBuilder = new ConfigurationBuilder();
                sharedPath = new AppConfigManager().getsharedPath;
                var path = Path.Combine(sharedPath, "SharedSettings.json");
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();

                //--------Public API URLS------------//
                accountsApiUrl = root.GetSection("MFAccountsAPIUrl").Value;
                accountsRentApiUrl = root.GetSection("MFAccountsRentAPIUrl").Value;

                customerApiUrl = root.GetSection("MFCustomerAPIUrl").Value;
                generalApiUrl = root.GetSection("MFGeneralAPIUrl").Value;
                lmsApiUrl = root.GetSection("MFLMSAPIUrl").Value;
                losApiUrl = root.GetSection("MFLOSAPIUrl").Value;
                collectionApiUrl = root.GetSection("MFCOLLECTIONAPIUrl").Value;
                EquifaxapiUrl = root.GetSection("EQUIFAXUrl").Value;
                crifUrl = root.GetSection("CRIFSERURL").Value;
                reportsApiUrl = root.GetSection("MFReportsAPIUrl").Value;
                adharDtaurl = root.GetSection("ADHARDATAURL").Value;
                adharotpurl = root.GetSection("ADHAROTPURL").Value;
                HRMSApiUrl = root.GetSection("MFHRMSAPIUrl").Value;
                CKYCUrl = root.GetSection("CKYCURL").Value;
                PROJECTTRACKERAPIUrl = root.GetSection("PROJECTTRACKERAPI").Value;
                tmsAPIUrl = root.GetSection("MFTreasuryAPIUrl").Value;



                //--------Mongo DB Connection----//          
                mongoDbName = root.GetSection("MongoDbName").Value;
                mongoDbPassword = root.GetSection("MongoDbPasword").Value;
                mongoUsername = root.GetSection("MongoUsername").Value;
                mongoAddress = root.GetSection("MongoAddress").Value;


            }
            catch (Exception exception)
            {
                string stackTrace = exception.StackTrace;
            }

        }

        #endregion

        #region Properties

     
        public string getBaseUrl
        {
            get => baseUrl;
        }
        public string getSiteUrl
        {
            get => siteUrl;
        }

        public string getadhardataurl
        {
            get => adharDtaurl;
        }
        public string getadharOtpurl
        {
            get => adharotpurl;
        }
        public string getaccountsRentApiUrl
        {
            get => accountsRentApiUrl;
        }
        public string getaccountsApiUrl
        {
            get => accountsApiUrl;
        }
        public string getcustomerApiUrl
        {
            get => customerApiUrl;
        }
        public string getgeneralApiUrl
        {
            get => generalApiUrl;
        }
        public string getlmsApiUrl
        {
            get => lmsApiUrl;
        }
        public string getlosApiUrl
        {
            get => losApiUrl;
        }
        public string getcollectionApiUrl
        {
            get => collectionApiUrl;
        }
        public string getHRMSApiUrl
        {
            get => HRMSApiUrl;
        }

        public string getEquifaxapiUrl
        {
            get => EquifaxapiUrl;
        }

        public string getcrifapiUrl
        {
            get => crifUrl;
        }
        public string getCKYCUrl
        {
            get => CKYCUrl;
        }
        public string getsharedPath
        {
            get => sharedPath;
        }
        public string getmongoDbName
        {
            get => mongoDbName;

        }
        public string getPROJECTTRACKERAPIUrl
        {
            get => PROJECTTRACKERAPIUrl;
        }

        public string getmongoDbPassword
        {
            get => mongoDbPassword;

        }

        public string getmongoUsername
        {
            get => mongoUsername;

        }

        public string getmongoAddress
        {
            get => mongoAddress;

        }
        public string getreportsApiUrl
        {
            get => reportsApiUrl;
        }
        public string gettmsAPIUrl
        {
            get => tmsAPIUrl;
        }
        #endregion
    }
}
