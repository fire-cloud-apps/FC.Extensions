using FC.Core.Extension.StringHandlers;
using FC.Extension.SQL.Helper;
using FC.Extension.SQL.Interface;
using FC.Extension.SQL.PostgreSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Linq;
using RepoDb;
using RepoDb.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SqlKata;
using System.Diagnostics;

namespace FC.Extension.HTTP.APIHandler
{
    public class TraceDB : BaseTrace
    {
        public override void BeforeBatchQuery(CancellableTraceLog log)
        {
            Console.WriteLine($"BeforeBatchQuery: {log.Statement}, TotalTime: {log.ExecutionTime.TotalSeconds} second(s)");
            //base.BeforeBatchQuery(log);
        }

        public override void AfterBatchQuery(TraceLog log)
        {
            Console.WriteLine($"AfterBatchQuery: {log.Statement}, TotalTime: {log.ExecutionTime.TotalSeconds} second(s)");

        }
    }
}
