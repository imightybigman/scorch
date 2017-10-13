using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
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

            return document != null ? JsonConvert.DeserializeObject<Character>(document.ToJson()) : null;
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

        [HttpPatch("{characterId}")]
        public async Task PatchCharacter(Guid characterId, [FromBody]Dictionary<string, string> props)
        {
            var document = new Document();
            document["CharacterId"] = characterId.ToString();
            foreach (var x in props)
            {
                document[x.Key] = x.Value;
            }

            await characterTable.UpdateItemAsync(document);
        }

        [HttpPut("{characterId}/inventory")]
        public async Task PutItemInInventory(Guid characterId, [FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))] IItem item)
        {
            // if no item id was passed in , assume it is a new item
            if (item.ItemId == Guid.Empty)
            {
                var itemController = new ItemController();
                item = await itemController.PostItem(item);
            }

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

            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));
            await characterTable.UpdateItemAsync(updateDocument);
        }

        [HttpPut("{characterId}/spells")]
        public async Task PutSpell(Guid characterId, [FromBody] Spell spell)
        {
            // if no item id was passed in , assume it is a new item
            if (spell.SpellId == Guid.Empty)
            {
                var spellsController = new SpellsController();
                spell = await spellsController.PostSpell(spell);
            }

            var character = await GetCharacter(characterId);
            character.Spells.Add(spell);
            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));

            await characterTable.UpdateItemAsync(updateDocument);
        }

        [HttpDelete("{characterId}/spells/{spellId}")]
        public async Task DeleteSpell(Guid characterId, Guid spellId)
        {
            var character = await GetCharacter(characterId);
            character.Spells.RemoveAll(x => x.SpellId == spellId);

            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));
            await characterTable.UpdateItemAsync(updateDocument);
        }
    }
}
