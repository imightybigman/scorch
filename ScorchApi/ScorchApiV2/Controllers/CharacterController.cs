using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScorchApiV2.Models;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string characterTableName = "DnD-Characters";
        private static Table characterTable;

        public CharacterController()
        {
            characterTable = Table.LoadTable(client, characterTableName);
        }

        [HttpGet]
        public async Task<IList<Character>> Get()
        {
            var scanFilter = new ScanFilter();
            var search = characterTable.Scan(scanFilter);
            var characterList = new List<Character>();
            do
            {
                var documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    var json = document.ToJson();
                    characterList.Add(JsonConvert.DeserializeObject<Character>(json));
                }
            } while (!search.IsDone);

            return characterList;
        }

        [HttpGet("{name}")]
        public async Task<Character> GetCharacter(string name)
        {
            var document = await characterTable.GetItemAsync(name);

            return JsonConvert.DeserializeObject<Character>(document.ToJson());
        }

        [HttpPost]
        public async Task<Character> PostCharacter([FromBody]Character character)
        {
            var document = Document.FromJson(JsonConvert.SerializeObject(character));

            await characterTable.PutItemAsync(document);

            return character;
        }

        [HttpPut("{name}")]
        public async Task<Character> PutCharacter(string name, [FromBody] Character character)
        {
            var document = Document.FromJson(JsonConvert.SerializeObject(character));
            document["Firstname"] = name;

            await characterTable.PutItemAsync(document);

            return character;
        }

        [HttpDelete("{name}")]
        public async Task DeleteCharacter(string name)
        {
            await characterTable.DeleteItemAsync(name);
        }
    }
}
