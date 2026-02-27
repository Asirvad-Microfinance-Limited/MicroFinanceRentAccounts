using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
  public  class ApiManager
    {
        #region summary
        /// <summary>       
        /// Created on : 28-Jul-2021
        /// Created By : 100367
        /// Description: ApiManager
        /// Modify Date:
        /// Modify By  : 
        /// Description:
        /// </summary>

        #endregion

        #region ApiManager
        AppConfigManager appConfigManager;
        public ApiManager()
        {
            appConfigManager = new AppConfigManager();
        }
        #endregion

        #region Methods
        public T InvokeGetHttpClientWithoutRequest<T>(string url, string token = null)
        {

            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            //string baseUrl = appConfigManager.getBaseUrl;
            var jsonResponse = string.Empty;
            Object ob = new object();
            var cts = new CancellationTokenSource();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                if (token != null)
                {
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                }
                cts.CancelAfter(httpClient.Timeout);
                //response = httpClient.GetAsync(baseUrl + url).Result;
                response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {

                    jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                    ob = JsonConvert.DeserializeObject<T>(jsonResponse);

                }

            }

            return (T)ob;
        }
        public Tuple<T, string> InvokeGetHttpClientWithoutRequest<T>(string url)
        {

            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };

            var jsonResponse = string.Empty;
            Object ob = new object();
            using (var httpClient = new HttpClient())
            {
                response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                    ob = JsonConvert.DeserializeObject<T>(jsonResponse);
                }
            }
            return Tuple.Create((T)ob, jsonResponse);
        }
        public string InvokeGetHttpClientsendsms(string url, string token = null)
        {

            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            string baseUrl = appConfigManager.getBaseUrl;
            var jsonResponse = string.Empty;

            using (var httpClient = new HttpClient())
            {
                if (token != null)
                {
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                }
                response = httpClient.GetAsync(baseUrl + url).Result;

                jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();


            }

            return jsonResponse;
        }
        public Tuple<T, string> InvokePostHttpClient<T, F>(F obj, string url, string authToken = null)
        {
           
            string baseUrl = url;
            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            string contents = JsonConvert.SerializeObject(obj);
            var jsonResponse = string.Empty;
            Object ob = new object();
            var cts = new CancellationTokenSource();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    if (authToken != null)
                    {
                        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authToken);
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authToken);
                    }
               
                    ServicePointManager.ServerCertificateValidationCallback = delegate {
                        return true;
                    };


                    cts.CancelAfter(httpClient.Timeout);
                    response = httpClient.PostAsync(baseUrl, new StringContent(contents, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                        ob = JsonConvert.DeserializeObject<T>(jsonResponse);
                        return Tuple.Create((T)ob, jsonResponse);
                    }
                    else
                    {
                        T Obj = Activator.CreateInstance<T>();
                        jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                        return Tuple.Create(Obj, jsonResponse);
                    }


                }

            }
            catch (Exception ex)
            {
                T Obj = Activator.CreateInstance<T>();
                jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                return Tuple.Create(Obj, jsonResponse);

            }

        }

        public Tuple<string, string, string> InvokeHttpClientAadharApiData(string url, string xml)
        {
            string baseUrl = url;
            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };

            var jsonResponse = string.Empty;
            var outputResponse = string.Empty;
            Object ob = new object();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var postParams = new Dictionary<string, string>();
                    postParams.Add("aadhar", xml);
                   
                    using (var postContent = new FormUrlEncodedContent(postParams))
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(300); 
                        response = httpClient.PostAsync(baseUrl, postContent).Result;

                        string xmlResponse = response.Content.ReadAsStringAsync().Result.ToString();
                        outputResponse = xmlResponse;
                        var repo = "utf-8";
                        repo = @"<?xml version=""1.0"" encoding=""utf-8""?>";
                        jsonResponse = outputResponse.Replace(repo, "").Trim();
                        //XmlDocument xmlDoc = new XmlDocument();
                        //xmlDoc.LoadXml(jsonResponse);
                        //jsonResponse = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.None, true);



                        return Tuple.Create(jsonResponse, xml, outputResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create(jsonResponse, xml, outputResponse);
            }

        }
        public Tuple<string, string, string> InvokeHttpClientAadharApiOtp(string url, string xml,string aid)
        {
            string baseUrl = url;
            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };

            var jsonResponse = string.Empty;
            var outputResponse = string.Empty;
            Object ob = new object();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var postParams = new Dictionary<string, string>();
                    postParams.Add("otp", xml);
                    postParams.Add("aid", aid);

                    using (var postContent = new FormUrlEncodedContent(postParams))
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(300); ;
                        response = httpClient.PostAsync(baseUrl, postContent).Result;

                        string xmlResponse = response.Content.ReadAsStringAsync().Result.ToString();
                        outputResponse = xmlResponse;
                        var repo = "utf-8";
                        repo = @"<?xml version=""1.0"" encoding=""utf-8""?>";
                        jsonResponse = outputResponse.Replace(repo, "").Trim();
                        //XmlDocument xmlDoc = new XmlDocument();
                        //xmlDoc.LoadXml(jsonResponse);
                        //jsonResponse = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.None, true);



                        return Tuple.Create(jsonResponse, xml, outputResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create(jsonResponse, xml, outputResponse);
            }

        }
        public Tuple<T, string> InvokePostHttpClientPayment<T, F>(F obj, string url, string authToken = null)
        {

            string baseUrl = url;
            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            string contents = JsonConvert.SerializeObject(obj);
            var jsonResponse = string.Empty;
            Object ob = new object();
            var cts = new CancellationTokenSource();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (authToken != null)
                    {
                        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authToken);
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authToken);
                    }
                    //System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    // Skip validation of SSL/TLS certificate
                    ServicePointManager.ServerCertificateValidationCallback = delegate {
                        return true;
                    };


                    cts.CancelAfter(httpClient.Timeout);
                    httpClient.DefaultRequestHeaders.Clear();
                    response = httpClient.PostAsync(baseUrl, new StringContent(contents, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                        ob = JsonConvert.DeserializeObject<T>(jsonResponse);
                        return Tuple.Create((T)ob, jsonResponse);
                    }
                    else
                    {
                        T Obj = Activator.CreateInstance<T>();
                        jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                        return Tuple.Create(Obj, jsonResponse);
                    }


                }

            }
            catch (Exception ex)
            {
                T Obj = Activator.CreateInstance<T>();
                jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                return Tuple.Create(Obj, jsonResponse);

            }

        }

        public Tuple<string> InvokePostHttpClient<F>(F obj, string url, string authToken = null)
        {

            string baseUrl = url;
            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest };
            string contents = JsonConvert.SerializeObject(obj);
            var jsonResponse = string.Empty;
            Object ob = new object();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (authToken != null)
                    {
                        httpClient.DefaultRequestHeaders.Add("","");
                    }

                    response = httpClient.PostAsync(baseUrl,null).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                      
                        return Tuple.Create(jsonResponse);
                    }
                    else
                    {
                        jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                        return Tuple.Create(jsonResponse);
                    }


                }

            }
            catch (Exception ex)
            {
               
                jsonResponse = response.Content.ReadAsStringAsync().Result.ToString();
                return Tuple.Create(jsonResponse);

            }

        }
        #endregion
    }
}
