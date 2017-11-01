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
using ScorchApiV2.Abstract;
using ScorchApiV2.ModelBinders;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private static AmazonDynamoDBClient _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static IOptions<AppSettings> _appSettings;
        private static Table _classTable;

        public ClassController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            var tableName = _appSettings.Value.DynamoTables["DnD-Classes"];
            _classTable = Table.LoadTable(_client, tableName);
        }

        [HttpPost]
        public CharacterClass PostClass([FromBody, ModelBinder(BinderType = typeof(CharacterClassModelBinder))] CharacterClass characterClass)
        {
            var x = characterClass;
            return x;
        }
    }
}