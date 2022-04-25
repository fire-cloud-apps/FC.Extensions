using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FC.Extension.HTTP.APIHandler
{
    /// <summary>
    /// MongoDB Parameter Configuration
    /// </summary>
    public class MongoDBParams<TController>
    {
        public ILogger<TController>? Logger { get; set; }
        public IConfiguration Configuration { get; set; }
        public IConnectionService ConnectionService { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public string DBURL_ConfigurationValue { get; set; }
        public string DBName_ConfigurationValue { get; set; }
    }

}