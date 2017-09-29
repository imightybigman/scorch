using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2.DocumentModel;
using ScorchApi.Models;

namespace ScorchApi.Controllers
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
            var documentList = new List<Document>();
            var characterList = new List<Character>();
            do
            {
                documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    characterList.Add(new Character(document));
                }
            } while (!search.IsDone);

            return characterList;
        }

        [HttpGet("{name}")]
        public async Task<Character> GetCharacter(string name)
        {
            var document = await table.GetItemAsync(name);
            return new Character(document);
        }

        [HttpPost]
        public async Task PostCharacter(Character character)
        {
            var document = character.ToDocument();

            await table.PutItemAsync(document);
        }
        
    }
}
