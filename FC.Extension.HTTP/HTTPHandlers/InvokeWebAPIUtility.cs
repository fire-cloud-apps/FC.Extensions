using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FC.Extension.HTTP.HTTPHandlers
{
    /// <summary>
    /// RestUtility inovkes Web API URL and provides the result.
    /// </summary>
    public static class InvokeWebAPIUtility
    {
        #region Resusable Methods
        /// <summary>
        /// Invoke Web API URL
        /// </summary>
        /// <param name="apiUrl">API URI Object</param>
        /// <param name="restClient">rest client object</param>
        /// <param name="method">POST or GET or any HTTP Method</param>
        /// <param name="parameterModel"></param>
        /// <param name="headersList"></param>
        /// <param name="fileList"></param>
        /// <example>
        /// <code>
        /// RestClient _client = null;//some initialization here.
        /// var param = new MyClass { IntData = 1, StringData = "test123" };
        /// ...
        /// { "Authorization", "Bearer " + HttpContext.Session.GetString("AuthToken") } //in the dictionary header
        /// ...
        /// var apiResponse = InvokeApi("API-URL", _client, Method.POST, param, headers)
        /// </code>
        /// </example>
        /// <returns>returns RestResponse with JObject</returns>
        public static async Task<IRestResponse<JObject>> InvokeApi(Uri apiUrl, RestClient restClient, Method method, dynamic parameterModel = null, Dictionary<string, string> headersList = null, Dictionary<string, string> fileList = null)
        {
            if (restClient == null)
            {
                throw new ArgumentNullException("The parameter apiURL is null");
            }
            var restRequest = new RestRequest(apiUrl, method);
            if (headersList != null)
            {
                foreach (KeyValuePair<string, string> header in headersList)
                {
                    restRequest.AddHeader(header.Key, header.Value);
                }
            }

            if (parameterModel != null)
            {
                restRequest.AddJsonBody(parameterModel);
            }

            if (fileList != null)
            {
                foreach (KeyValuePair<string, string> files in fileList)
                {
                    restRequest.AddFile(files.Key, files.Value);
                }
                restRequest.AlwaysMultipartFormData = true;
                restRequest.AddHeader("Content-Type", "multipart/form-data");
            }

            return await restClient.ExecuteAsync<JObject>(restRequest);
        }
        
        #endregion

        
    }
}
