using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using System;
using Amazon;

namespace ScorchApi.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string tableName = "DnD-Characters";

//        [HttpGet]
//        public async Task<IList<Character>> Get()
//        {
//            try
//            {
//                var table = Table.LoadTable(client, tableName);
//                var response = await table.GetItemAsync("Test", "Test");
//                return new List<Character>()
//                {
//                    new Character(response)
//                };
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//  
//        }

        [HttpGet]
        public string Get()
        {
            throw new InvalidOperationException("WHYYY");
        }
    }
}
