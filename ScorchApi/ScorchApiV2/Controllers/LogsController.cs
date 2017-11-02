using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ScorchApiV2.Models;
using ScorchApiV2.Static;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class LogsController : Controller
    {
        private static AmazonDynamoDBClient _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static IOptions<AppSettings> _appSettings;
        private static Table _logsTable;

        public LogsController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            var tableName = _appSettings.Value.DynamoTables["DnD-Logs"];
            _logsTable = Table.LoadTable(_client, tableName);
        }


        [HttpGet]
        public async Task<List<Log>> GetLogs(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue || !endDate.HasValue)
            {
                return await GetAllLogs();
            }

            return await GetLogsBetweenDates(startDate.Value, endDate.Value);
        }

        private async Task<List<Log>> GetAllLogs()
        {
            var scanFilter = new ScanFilter();
            var search = _logsTable.Scan(scanFilter);
            var logs = new List<Log>();
            do
            {
                var documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    logs.Add(new Log(document));
                }
            } while (!search.IsDone);

            return logs;
        }

        private async Task<List<Log>> GetLogsBetweenDates(DateTime startDate, DateTime endDate)
        {
            ScanFilter scanFilter = new ScanFilter();
            scanFilter.AddCondition("LogDate", ScanOperator.Between, startDate.ToUnixTimestamp(), endDate.ToUnixTimestamp());
            var scan = _logsTable.Scan(scanFilter);
            var allItems = await scan.GetRemainingAsync();
     
            return allItems.Select(x => new Log(x)).ToList();
        }

        [HttpPost]
        public async Task PostLog([FromBody]Log log)
        {
            var document = log.ToDocument();
            await _logsTable.PutItemAsync(document);
        }
    }
}