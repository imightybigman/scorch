using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ScorchApiV2.ModelBinders;
using ScorchApiV2.Models;
using ScorchApiV2.Abstract;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private static AmazonDynamoDBClient _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static IOptions<AppSettings> _appSettings;
        private static Table _characterTable;

        public CharacterController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            var tableName = _appSettings.Value.DynamoTables["DnD-Characters"];
            _characterTable = Table.LoadTable(_client, tableName);
        }

        [HttpGet]
        public async Task<IList<Character>> Get()
        {
            var scanFilter = new ScanFilter();
            var search = _characterTable.Scan(scanFilter);
            var characterList = new List<Character>();
            do
            {
                var documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    var json = document.ToJson();
                    var ch = JsonConvert.DeserializeObject<Character>(json);
                    ch.OrganizeAbilities();
                    characterList.Add(ch);
                }
            } while (!search.IsDone);

            return characterList;
        }

        [HttpGet("{characterId}")]
        public async Task<Character> GetCharacter(Guid characterId)
        {
            var document = await _characterTable.GetItemAsync(characterId);

            var ch = document != null ? JsonConvert.DeserializeObject<Character>(document.ToJson()) : null;
            ch?.OrganizeAbilities();

            return ch;
        }

        [HttpPost]
        public async Task<Character> PostCharacter([FromBody]Character character)
        {
            character.CharacterId = Guid.NewGuid();
            
            var document = Document.FromJson(JsonConvert.SerializeObject(character));

            await _characterTable.PutItemAsync(document);

            return character;
        }

        [HttpPut("{characterId}")]
        public async Task<Character> PutCharacter(Guid characterId, [FromBody] Character character)
        {
            var document = Document.FromJson(JsonConvert.SerializeObject(character));
            document["CharacterId"] = characterId.ToString();

            await _characterTable.PutItemAsync(document);

            return character;
        }

        [HttpPatch("{characterId}")]
        public async Task PatchCharacter(Guid characterId, [FromBody]Dictionary<string, object> props)
        {
            var document = new Document{ ["CharacterId"] = characterId.ToString() };
            foreach (var x in props) 
            {
                if (x.Key == "Stats")
                {
                    document[x.Key] = Document.FromJson(JsonConvert.SerializeObject(x.Value));
                }
                else
                {
                    document[x.Key] = (Int64) x.Value;
                }
            }

            await _characterTable.UpdateItemAsync(document);
        }

        [HttpPost("{characterId}/inventory")]
        public async Task PostItemInInventory(Guid characterId, [FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))] Item item)
        {
            var itemController = new ItemController(_appSettings);
            var itemId = item.ItemId;
            var itemCount = item.Count;
            // if no item id was passed in , assume it is a new item
            if (itemId == Guid.Empty)
            {
                item = await itemController.PostItem(item);
            }
            else
            {
                item = await itemController.GetItem(item.ItemId);
                if (item == null)
                {
                    throw new KeyNotFoundException("Item Id: " + itemId + " was not found");
                }
            }

            var character = await GetCharacter(characterId);
            item.Count = itemCount;
            character.Inventory.Add(item);
            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));

            await _characterTable.UpdateItemAsync(updateDocument);
        }

        [HttpPut("{characterId}/inventory")]
        public async Task PutItemInInventory(Guid characterId, [FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))] Item item)
        {
            var itemId = item.ItemId;
            // if no item id was passed in , assume it is a new item
            if (itemId == Guid.Empty)
            {
                throw new InvalidOperationException("Item does not contain an item id");
            }

            var character = await GetCharacter(characterId);
            var itemIndex = character.Inventory.FindIndex(x => x.ItemId == itemId);
            if (itemIndex == -1)
            {
                throw new InvalidOperationException("Character does not have this item");
            }
            character.Inventory[itemIndex] = item;

            // Also need to update the character equipment if they have that equipped
            character.UpdateEquipment(item);

            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));
            await _characterTable.UpdateItemAsync(updateDocument);
        }


        [HttpDelete("{characterId}")]
        public async Task DeleteCharacter(Guid characterId)
        {
            await _characterTable.DeleteItemAsync(characterId);
        }

        [HttpDelete("{characterId}/inventory/sell")]
        public async Task SellItemFromInventory(Guid characterId, Guid itemId)
        {
            var character = await GetCharacter(characterId);
            var item = character.Inventory.Find(x => x.ItemId == itemId);
            character.Inventory.RemoveAll(x => x.ItemId == itemId);
            character.Gold += Convert.ToInt32(item.Cost);

            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));
            await _characterTable.UpdateItemAsync(updateDocument);
        }

        [HttpDelete("{characterId}/inventory/delete")]
        public async Task RemoveItemFromInventory(Guid characterId, Guid itemId)
        {
            var character = await GetCharacter(characterId);
            character.Inventory.RemoveAll(x => x.ItemId == itemId);

            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));
            await _characterTable.UpdateItemAsync(updateDocument);
        }

        [HttpPut("{characterId}/spells")]
        public async Task<Spell> PutSpell(Guid characterId, [FromBody] Spell spell)
        {
            // if no item id was passed in , assume it is a new item
            if (spell.SpellId == Guid.Empty)
            {
                var spellsController = new SpellsController(_appSettings);
                spell = await spellsController.PostSpell(spell);
            }

            var character = await GetCharacter(characterId);
            character.Spells.Add(spell);
            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));

            await _characterTable.UpdateItemAsync(updateDocument);

            return spell;
        }

        [HttpDelete("{characterId}/spells")]
        public async Task DeleteSpell(Guid characterId, Guid spellId)
        {
            var character = await GetCharacter(characterId);
            character.Spells.RemoveAll(x => x.SpellId == spellId);

            var updateDocument = Document.FromJson(JsonConvert.SerializeObject(character));
            await _characterTable.UpdateItemAsync(updateDocument);
        }

        [HttpPut("{characterId}/equipment")]
        public async Task<Equipment> PutCharacterEquipment(Guid characterId, [FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))] Item equipment)
        {
            var character = await GetCharacter(characterId);
            character.Equip(equipment);
            var doc = new Document
            {
                ["CharacterId"] = characterId,
                ["Equipment"] = Document.FromJson(JsonConvert.SerializeObject(character.Equipment))
            };

            await _characterTable.UpdateItemAsync(doc);

            return character.Equipment;
        }

        [HttpDelete("{characterId}/equipment")]
        public async Task DeleteCharacterEquipment(Guid characterId, string slot)
        {
            var character = await GetCharacter(characterId);
            character.Unequip(slot);
            var doc = new Document
            {
                ["CharacterId"] = characterId,
                ["Equipment"] = Document.FromJson(JsonConvert.SerializeObject(character.Equipment))
            };

            await _characterTable.UpdateItemAsync(doc);
        }
    }
}
