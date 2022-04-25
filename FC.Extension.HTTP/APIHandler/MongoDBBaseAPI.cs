using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FC.Core.Extension.StringHandlers;
using FC.Extension.SQL.Engine;
using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using FC.Extension.SQL.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FC.Extension.HTTP.APIHandler
{

    /// <summary>
    /// Base API which is using MongoDB-NoSQL as a database platform
    /// </summary>
    /// <typeparam name="TModel">Model which is used for execution</typeparam>
    /// <typeparam name="TController">Controller which is used for execution</typeparam>
    public class MongoDBBaseAPI<TModel, TController> : ControllerBase where TModel : class
    {
        #region Variables

        private ILogger<TController>? _logger = null;
        private INoSQLBaseAccess<TModel>? _baseAccess = null;
        private SQLConfig? _sqlConfig = null;

        #endregion

        #region Public Property

        /// <summary>
        /// ILogger to handle in child class
        /// </summary>
        public ILogger<TController>? Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        /// <summary>
        /// Get BaseAccess to have custom definition logic to be built
        /// </summary>
        public INoSQLBaseAccess<TModel>? BaseAccess
        {
            get { return _baseAccess; }
            set { _baseAccess = value; }
        }

        /// <summary>
        /// Get SQLConfig to handle in client class for debugging.
        /// </summary>
        public SQLConfig SQL_NoSQL_Config
        {
            get { return _sqlConfig; }
            set { _sqlConfig = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of ServiceStatus service
        /// </summary>
        /// <param name="logger">Log dependency injection</param>
        /// <param name="configuration">Configuration dependency injection</param>
        /// <param name="connectionService">Connection object which is used to extract connection string</param>
        /// <param name="httpContext">HTTP Context used to extract JWT token</param>
        public MongoDBBaseAPI(ILogger<TController>? logger, IConfiguration configuration,
            IConnectionService connectionService, IHttpContextAccessor httpContext)
        {
            SQLConfig sqlConfig = MongoDBConfig(configuration, typeof(TModel).Name);
            _baseAccess = new MongoDataAccess<TModel>(sqlConfig);
            _logger = logger;
            _logger.LogInformation($"API {nameof(TController)} Initiated.");
        }

        private SQLConfig MongoDBConfig(IConfiguration configuration, string modelName, 
            string server = "MongoSettings:Server", string db="MongoSettings:DataBaseName")
        {
            string clientURL = configuration.GetValue<string>(server);
            string clientDB = configuration.GetValue<string>(db);
            string conectionString = string.Format($"{clientURL}", clientDB);
            SQLExtension.SQLConfig = new SQLConfig()
            {
                Compiler = SQLCompiler.MongoDB,
                DBType = DBType.NoSQL,
                ConnectionString = conectionString,
                DataBaseName = clientDB,
                CollectionName = modelName
            };
            _sqlConfig = SQLExtension.SQLConfig;
            return SQLExtension.SQLConfig;
        }
        
        public MongoDBBaseAPI(MongoDBParams<TController> param)
        {
            SQLConfig sqlConfig = MongoDBConfig(
                param.Configuration,
                typeof(TModel).Name,
                server: param.DBURL_ConfigurationValue,
                db: param.DBName_ConfigurationValue
            );
            _baseAccess = new MongoDataAccess<TModel>(sqlConfig);
            _logger = param.Logger;
            _logger.LogInformation($"API {nameof(TController)} Initiated.");
        }

        public MongoDBBaseAPI()
        {
        }

        #endregion

        #region Basic Get Operations

        /// <summary>
        /// Gets all the items from TModel Table
        /// </summary>
        /// <returns>returns IEnumerable of Type Model</returns>
        [Route("getall")]
        [HttpGet]
        public async Task<IEnumerable<TModel>> GetAll()
        {
            IEnumerable<TModel> models = await _baseAccess.GetAllAsync();
            _logger.LogInformation($"GetAll API Executed Count : {models.Count()}");
            return models;
        }

        /// <summary>
        /// Gets By Id from Model Table
        /// </summary>
        /// <returns>returns IEnumerable of Model Model</returns>
        [Route("getbyId/{id}")]
        [HttpGet]
        public async Task<string> GetById(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            IEnumerable<BsonDocument> models =
                await _baseAccess.GenericCollection.FindAsync(filter).Result.ToListAsync<BsonDocument>();
            //"Id" is the fixed field and it cannot be changed. 
            if (models != null)
            {
                _logger.LogInformation($"Get By ID API Executed : {models.ToJSON()}");
            }

            return models.ToJson();
        }

        #region Yet to be done

        // /// <summary>
        // /// Get the Model details by Batch and splits into Page.
        // /// </summary>
        // /// <param name="start">Page start value usually '0' </param>
        // /// <param name="length">Page length value usually '10' </param>
        // /// <param name="order">Ordering Ascending or Descending </param>
        // /// <returns>returns no of Models</returns>
        // [Route("GetByPage")]
        // [HttpGet]
        // public async Task<IEnumerable<TModel>> GetByPage(int start = 0, int length = 10, string order = "D")
        // {
        //     var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
        //     IEnumerable<BsonDocument> models = await _baseAccess.GenericCollection.FindAsync(filter).Result.ToListAsync <BsonDocument>();
        //     //"Id" is the fixed field and it cannot be changed. 
        //     if (models != null)
        //     {
        //         _logger.LogInformation($"Get By ID API Executed : {models.ToJSON()}");
        //     }
        //
        //     return models.ToJson();
        //    
        // }

        // [Route("GetByBatch")]
        // [HttpPost]
        // public async Task<MetaPagination<TModel>> GetByBatch
        //     (MetaPagingParams metaParams)
        // {
        //     var metaPagination = new MetaPagination<TModel>();
        //     var dataList = await GetDataFromDB(metaParams);
        //     var count = await _baseAccess.GetRecordCountAsync();
        //     metaPagination.Total = count;
        //     metaPagination.TotalNotFiltered = count;
        //     metaPagination.Rows = dataList;
        //     return metaPagination;
        // }
        //
        // private async Task<IEnumerable<TModel>> GetDataFromDB(MetaPagingParams metaParams)
        // {
        //     metaParams.order = string.IsNullOrEmpty(metaParams.order) ? string.Empty : metaParams.order;
        //
        //     var query = new Query(typeof(TModel).Name)
        //         .Limit(metaParams.limit)
        //         .Offset(metaParams.offset);
        //     query = metaParams.order.Equals("asc") ? query.OrderBy("Id") : query.OrderByDesc("Id");
        //     if (!string.IsNullOrEmpty(metaParams.search))
        //     {
        //         query.WhereRaw($"\"{metaParams.searchcolumn}\" ILIKE '%{metaParams.search}%'");
        //     }
        //
        //     IEnumerable<TModel> taxData = await _baseAccess.ExecuteQuery(query);
        //
        //     _logger.LogInformation($"{LogClassAndMethod()} API Executed Count : {taxData.Count()}");
        //     return taxData;
        // }

        #endregion


        #endregion

        #region Basic CRUD Operation

        /// <summary>
        /// Create ServiceStatus based on the Model
        /// </summary>
        /// <param name="model">TModel model</param>
        /// <returns>returns ServiceStatus as json data</returns>
        [Route("create")]
        [HttpPost]
        public async Task<TModel> Create(TModel model)
        {
            TModel resultModel = await _baseAccess.CreateAsync(model);
            return resultModel;

        }

        // /// <summary>
        // /// Update ServiceStatus based on the Model
        // /// </summary>
        // /// <param name="model">ServiceStatus model</param>
        // /// <returns>returns ServiceStatus as json data</returns>
        // [Route("update")]
        // [HttpPut]
        // public async Task<TModel> Update(TModel model)
        // {
        //     _baseAccess.GenericCollection.UpdateOneAsync()
        //     TModel resultModel = await _baseAccess.UpdateAsync(model);
        //     return resultModel;
        // }

        // /// <summary>
        // /// Delete the ServiceStatus data by Id
        // /// </summary>
        // /// <param name="id">Unique Id of ServiceStatus</param>
        // /// <returns>No of items removed.</returns>
        // [Route("delete")]
        // [HttpDelete]
        // public async Task<ResultModel> Delete(int id)
        // {
        //     string resultCount = await _baseAccess.GenericCollection.DeleteOne()
        //
        //     return new ResultModel() { Id = id, Count = long.Parse(resultCount) };
        // }

        #endregion

        #region Basic Aggregation

        /// <summary>
        /// Gets all the items from TModel Table
        /// </summary>
        /// <returns>returns IEnumerable of Type Model</returns>
        [Route("count")]
        [HttpGet]
        public async Task<ResultModel> GetCount()
        {
            var recordCount = await _baseAccess.GetRecordCountAsync();
            ResultModel resultModel = new ResultModel()
            {
                Count = recordCount
            };
            _logger.LogInformation($"'GetCount' Result/Row Count : {resultModel.Count}");
            return resultModel;
        }

        #endregion

        #region Logging Extension

        /// <summary>
        /// Get Class Name and method for easy loging
        /// </summary>
        /// <returns>A string value with class name and method name</returns>
        public static string LogClassAndMethod()
        {
            var stackTrace = new StackTrace(true);
            string logMsg = string.Empty;
            foreach (var r in stackTrace.GetFrames())
            {
                logMsg = $"Filename: {r.GetFileName()} Method: {r.GetMethod()}";
                break;
                //Line: r.GetFileLineNumber(),
                //Column: r.GetFileColumnNumber());
            }

            return logMsg;
        }

        #endregion
    }

}