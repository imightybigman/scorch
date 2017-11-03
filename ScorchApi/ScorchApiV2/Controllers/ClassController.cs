using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ScorchApiV2.Abstract;
using ScorchApiV2.ModelBinders;
using ScorchApiV2.Models.DnDClasses;

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

        [HttpGet]
        public IEnumerable<CharacterClass> GetCharacterClasses()
        {
            return new CharacterClass[] { new Fighter(), new Warlock(), new Bard(), new Ranger(), new Paladin() };
        }

        [HttpPost]
        public async Task<CharacterClass> PostClass([FromBody, ModelBinder(BinderType = typeof(CharacterClassModelBinder))] CharacterClass characterClass)
        {
            var document = Document.FromJson(JsonConvert.SerializeObject(characterClass));

            await _classTable.PutItemAsync(document);

            return characterClass;
        }
    }
}