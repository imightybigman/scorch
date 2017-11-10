using System;
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
using ScorchApiV2.Models.Items;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class ItemController
    {
        private static AmazonDynamoDBClient _client  = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static IOptions<AppSettings> _appSettings;
        private static Table _itemTable;

        public ItemController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            var tableName = _appSettings.Value.DynamoTables["DnD-Items"];
            _itemTable = Table.LoadTable(_client, tableName);
        }


        [HttpGet]
        public async Task<IList<Item>> Get()
        {
            var scanFilter      = new ScanFilter();
            var search          = _itemTable.Scan(scanFilter);
            var itemList        = new List<Item>();
            do
            {
                var documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    itemList.Add(ParseItem(document));
                }
            } while (!search.IsDone);

            return itemList;
        }


        [HttpGet("{itemId}")]
        public async Task<Item> GetItem(Guid itemId)
        {
            var document = await _itemTable.GetItemAsync(itemId);
            
            return document != null ? ParseItem(document) : null;
        }

        /// <summary>
        /// Create a DnD Item
        /// </summary>
        /// <param name="item">Item thingy</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Item> PostItem([FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))]Item item)
        {
            item.ItemId = Guid.NewGuid();
            Document doc = Document.FromJson(JsonConvert.SerializeObject(item));
            await _itemTable.PutItemAsync(doc);

            return item;
        }

        [HttpPut("{itemId}")]
        public async Task<Item> PutItem(Guid itemId, [FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))]Item item)
        {
            item.ItemId = itemId;
            Document doc = Document.FromJson(JsonConvert.SerializeObject(item));
            await _itemTable.UpdateItemAsync(doc);

            return item;
        }

        [HttpDelete("{itemId}")]
        public async Task DeleteItem(Guid itemId)
        {
            await _itemTable.DeleteItemAsync(itemId);
        }

        private Item ParseItem(Document document)
        {
            var itemJson = document.ToJson();
            if (document["ItemClass"] == "Quiver")
            {
                return JsonConvert.DeserializeObject<Quiver>(itemJson);
            }
            if (document["ItemClass"] == "Weapon")
            {
                return JsonConvert.DeserializeObject<Weapon>(itemJson);
            }
            if (document["ItemClass"] == "Armor")
            {
                return JsonConvert.DeserializeObject<Armor>(itemJson);
            }
            if (document["ItemClass"] == "Accessory")
            {
                return JsonConvert.DeserializeObject<Accessory>(itemJson);
            }

            return JsonConvert.DeserializeObject<AdventurerGear>(itemJson);
        }
    }
}
