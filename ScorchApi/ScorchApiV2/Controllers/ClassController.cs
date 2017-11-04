using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ScorchApiV2.Abstract;
using ScorchApiV2.ModelBinders;
using ScorchApiV2.Models;
using ScorchApiV2.Models.DnDClasses;
using Document = Amazon.DynamoDBv2.DocumentModel.Document;

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

        private CharacterClass ParseCharacter(Document document)
        {
            var classJson = document.ToJson();
            if (document["Name"] == "Paladin")
            {
                return JsonConvert.DeserializeObject<Paladin>(classJson);
            }
            if (document["Name"] == "Warlock")
            {
                return JsonConvert.DeserializeObject<Warlock>(classJson);
            }
            if (document["Name"] == "Ranger")
            {
                return JsonConvert.DeserializeObject<Ranger>(classJson);
            }
            if (document["Name"] == "Fighter")
            {
                return JsonConvert.DeserializeObject<Fighter>(classJson);
            }
            if (document["Name"] == "Bard")
            {
                return JsonConvert.DeserializeObject<Bard>(classJson);
            }
            return JsonConvert.DeserializeObject<BaseClass>(classJson);
        }

        [HttpGet]
        public async Task<IEnumerable<CharacterClass>> GetCharacterClasses()
        {
            var scanFilter = new ScanFilter();
            var search = _classTable.Scan(scanFilter);
            var classes = new List<CharacterClass>();
            do
            {
                var documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    classes.Add(ParseCharacter(document));
                }
            } while (!search.IsDone);

            return classes;
        }

        [HttpGet("{name}")]
        public async Task<CharacterClass> GetCharacterClasses(string name)
        {
            var document = await _classTable.GetItemAsync(name);

            return ParseCharacter(document);
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