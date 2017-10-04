using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DocumentModel;
using Newtonsoft.Json;
using ScorchApiV2.Models;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class SpellsController : Controller
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string spellsTableName = "DnD-Spells";
        private static Table spellsTable;

        public SpellsController()
        {
            spellsTable = Table.LoadTable(client, spellsTableName);
        }

        [HttpGet]
        public async Task<IList<Spell>> Get()
        {
            var scanFilter = new ScanFilter();
            var search = spellsTable.Scan(scanFilter);
            var SpellList = new List<Spell>();
            do
            {
                var documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    var json = document.ToJson();
                    SpellList.Add(JsonConvert.DeserializeObject<Spell>(json));
                }
            } while (!search.IsDone);

            return SpellList;
        }


        [HttpGet("{spellId}")]
        public async Task<Spell> GetSpell(Guid spellId)
        {
            var document = await spellsTable.GetItemAsync(spellId);

            return document != null ? JsonConvert.DeserializeObject<Spell>(document.ToJson()) : null;
        }

        [HttpPost]
        public async Task<Spell> PostSpell([FromBody]Spell spell)
        {
            spell.SpellId = Guid.NewGuid();
            var document = Document.FromJson(JsonConvert.SerializeObject(spell));
            await spellsTable.PutItemAsync(document);

            return spell;
        }

        [HttpPut("{spellId}")]
        public async Task<Spell> PutSpell(Guid spellId, [FromBody] Spell spell)
        {
            spell.SpellId = spellId;
            var document = Document.FromJson(JsonConvert.SerializeObject(spell));
            await spellsTable.PutItemAsync(document);

            return spell;
        }

        [HttpDelete("{spellId}")]
        public async Task DeleteSpell(Guid spellId)
        {
            await spellsTable.DeleteItemAsync(spellId);
        }
    }
}