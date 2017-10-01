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
    public class EquipmentController
    {
        private static AmazonDynamoDBClient client  = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string characterTableName    = "DnD-Characters";
        private static Table characterTable;

        public EquipmentController()
        {
            characterTable = Table.LoadTable(client, characterTableName);
        }

        [HttpGet("{name}")]
        public async Task<Equipment> Get(string name)
        {
            var document = await characterTable.GetItemAsync(name);

            var character = JsonConvert.DeserializeObject<Character>(document.ToJson());

            return character.Equipment;
        }

//        [HttpPost("{name}")]
//        public async Task Post([FromBody])


    }
}
