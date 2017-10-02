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

        [HttpGet("{name}")]
        public async Task<IList<IItem>> Get(string name)
        {
            var scanFilter      = new ScanFilter();
            var search          = itemTable.Scan(scanFilter);
            var itemList        = new List<IItem>();
            do
            {
                var documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    var itemJson = document.ToJson();
                    if (document["ItemClass"] == "Quiver")
                    {
                        itemList.Add(JsonConvert.DeserializeObject<Quiver>(itemJson));
                    }
                    else if (document["ItemClass"] == "Weapon")
                    {
                        itemList.Add(JsonConvert.DeserializeObject<Weapon>(itemJson));
                    }
                    else if (document["ItemClass"] == "Armor")
                    {
                        itemList.Add(JsonConvert.DeserializeObject<Armor>(itemJson));
                    }
                    else 
                    {
                        itemList.Add(JsonConvert.DeserializeObject<AdventurerGear>(itemJson));
                    }
                }
            } while (!search.IsDone);

            return itemList;
        }

        [HttpPost]
        public async Task<IItem> PostItem([FromBody, ModelBinder(BinderType = typeof(ItemModelBinder))]IItem item)
        {
            Document doc = null;
            if (item.ItemClass == typeof(AdventurerGear).Name)
            {
                doc = Document.FromJson(JsonConvert.SerializeObject((AdventurerGear)item));
            }
            else if (item.ItemClass == typeof(Weapon).Name)
            {
                doc = Document.FromJson(JsonConvert.SerializeObject((Weapon)item));
            }
            else if (item.ItemClass == typeof(Armor).Name)
            {
                doc = Document.FromJson(JsonConvert.SerializeObject((Armor)item));
            }
            else if (item.ItemClass == typeof(Quiver).Name)
            {
                doc = Document.FromJson(JsonConvert.SerializeObject((Quiver)item));
            }

            await itemTable.PutItemAsync(doc);

            return item;
        }

    }
}
