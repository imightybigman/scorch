using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScorchApiV2.Models;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class LogsController : Controller
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string tableName = "DnD-Logs";
        private static Table logsTable;

        public LogsController()
        {
            logsTable = Table.LoadTable(client, tableName);
        }

//        [HttpGet]
//        public List<Log> GetLogs(DateTime startDate, DateTime endDate)
//        {
//            
//        }

        [HttpGet]
        public Log Get()
        {
            var log = new Log
            {
                LogDate = DateTime.Now,
                LogMessage = "Message"
            };

            return log;
        }

        [HttpPost]
        public Log PostLog(Log log)
        {
            var x = log;

            return x;
        }

    }
}