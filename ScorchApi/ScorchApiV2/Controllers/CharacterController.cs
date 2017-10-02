using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json;
using ScorchApiV2.Models;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string tableName = "DnD-Characters";
        private static Table table;

        public CharacterController()
        {
            table = Table.LoadTable(client, tableName);
        }

        [HttpGet]
        public async Task<IList<Character>> Get()
        {
            var scanFilter = new ScanFilter();
            var search = table.Scan(scanFilter);
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
            var document = await table.GetItemAsync(name);

            return JsonConvert.DeserializeObject<Character>(document.ToJson());
        }

        [HttpPost]
        public async Task<Character> PostCharacter([FromBody]Character character)
        {
            var document = Document.FromJson(JsonConvert.SerializeObject(character));

            await table.PutItemAsync(document);

            return character;
        }

        [HttpPut("{name}")]
        public async Task<Character> PutCharacter(string name, [FromBody] Character character)
        {
            var document = Document.FromJson(JsonConvert.SerializeObject(character));
            document["Firstname"] = name;

            await table.PutItemAsync(document);

            return character;
        }

        [HttpDelete("{name}")]
        public async Task DeleteCharacter(string name)
        {
            await table.DeleteItemAsync(name);
        }
    }
}
