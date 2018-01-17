using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ScorchApiServerless.Models;

namespace ScorchApiServerless.Controllers
{
    [Route("api/Spells")]
    public class SpellsController : Controller
    {
        private static AmazonDynamoDBClient _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static IOptions<AppSettings> _appSettings;
        private static Table _spellsTable;

        public SpellsController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
//            var tableName = _appSettings.Value.DynamoTables["DnD-Spells"];
//            _spellsTable = Table.LoadTable(_client, tableName);
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return _appSettings.Value.DynamoTables["DnD-Spells"];
        }
    }
}