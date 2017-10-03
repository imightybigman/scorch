using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScorchApiV2.Interfaces;
using ScorchApiV2.ModelBinders;
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

        [HttpGet("{characterId}")]
        public async Task<Character> GetCharacter(Guid characterId)
        {
            var document = await characterTable.GetItemAsync(characterId);

            return JsonConvert.DeserializeObject<Character>(document.ToJson());
        }

        [HttpPost]
        public async Task<Character> PostCharacter([FromBody]Character character)
        {
            character.CharacterId = Guid.NewGuid();
            var document = Document.FromJson(JsonConvert.SerializeObject(character));

            await characterTable.PutItemAsync(document);

            return character;
        }

        [HttpPut("{characterId}")]
        public async Task<Character> PutCharacter(Guid characterId, [FromBody] Character character)
        {
            var document = Document.FromJson(JsonConvert.SerializeObject(character));
            document["CharacterId"] = characterId.ToString();

            await characterTable.PutItemAsync(document);

            return character;
        }

        [HttpDelete("{characterId}")]
        public async Task DeleteCharacter(Guid characterId)
        {
            await characterTable.DeleteItemAsync(characterId);
        }

        [HttpPut("{characterId}/inventory")]
        public async Task PutItemInInventory(Guid characterId, [FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))] IItem item)
        {
            var character = await GetCharacter(characterId);
            character.Inventory.Add(item);
            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));

            await characterTable.UpdateItemAsync(updateDocument);
        }

        [HttpDelete("{characterId}/inventory/{itemId}")]
        public async Task DeleteItemFromInventory(Guid characterId, Guid itemId)
        {
            var character = await GetCharacter(characterId);
            character.Inventory.RemoveAll(x => x.ItemId == itemId);
        }
    }
}
