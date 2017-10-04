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
    public class ItemController
    {
        private static AmazonDynamoDBClient client  = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string itemTableName         = "DnD-Items";
        private static Table itemTable;

        public ItemController()
        {
            itemTable = Table.LoadTable(client, itemTableName);
        }

        [HttpGet]
        public async Task<IList<IItem>> Get()
        {
            var scanFilter      = new ScanFilter();
            var search          = itemTable.Scan(scanFilter);
            var itemList        = new List<IItem>();
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
        public async Task<IItem> GetItem(Guid itemId)
        {
            var document = await itemTable.GetItemAsync(itemId);
            
            return document != null ? ParseItem(document) : null;
        }

        /// <summary>
        /// Create a DnD Item
        /// </summary>
        /// <param name="item">Item thingy</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IItem> PostItem([FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))]IItem item)
        {
            item.ItemId = Guid.NewGuid();
            Document doc = Document.FromJson(JsonConvert.SerializeObject(item));
            await itemTable.PutItemAsync(doc);

            return item;
        }

        [HttpPut("{itemId}")]
        public async Task<IItem> PutItem(Guid itemId, [FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))]IItem item)
        {
            item.ItemId = itemId;
            Document doc = Document.FromJson(JsonConvert.SerializeObject(item));
            await itemTable.PutItemAsync(doc);

            return item;
        }

        [HttpDelete("{itemId}")]
        public async Task DeleteItem(Guid itemId)
        {
            await itemTable.DeleteItemAsync(itemId);
        }

        private IItem ParseItem(Document document)
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

            return JsonConvert.DeserializeObject<AdventurerGear>(itemJson);
        }
    }
}
