using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ScorchApiV2.Models;

namespace ScorchApiV2.Controllers
{
    [Route("api/[controller]")]
    public class SpellsController : Controller
    {
        private static AmazonDynamoDBClient _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static IOptions<AppSettings> _appSettings;
        private static Table _spellsTable;

        public SpellsController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            var tableName = _appSettings.Value.DynamoTables["DnD-Spells"];
            AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
            clientConfig.ServiceURL = "http://localhost:8000";
            _client = new AmazonDynamoDBClient(clientConfig);
            _spellsTable = Table.LoadTable(_client, "DnD-Spells");
        }

        [HttpGet]
        public async Task<IList<Spell>> Get()
        {
            var scanFilter = new ScanFilter();
            var search = _spellsTable.Scan(scanFilter);
            var spellList = new List<Spell>();
            do
            {
                var documentList = await search.GetNextSetAsync();
                foreach (var document in documentList)
                {
                    var json = document.ToJson();
                    spellList.Add(JsonConvert.DeserializeObject<Spell>(json));
                }
            } while (!search.IsDone);

            return spellList;
        }


        [HttpGet("{spellId}")]
        public async Task<Spell> GetSpell(Guid spellId)
        {
            var document = await _spellsTable.GetItemAsync(spellId);

            return document != null ? JsonConvert.DeserializeObject<Spell>(document.ToJson()) : null;
        }

        [HttpPost]
        public async Task<Spell> PostSpell([FromBody]Spell spell)
        {
            spell.SpellId = Guid.NewGuid();
            var document = Document.FromJson(JsonConvert.SerializeObject(spell));
            await _spellsTable.PutItemAsync(document);

            return spell;
        }

        [HttpPut("{spellId}")]
        public async Task<Spell> PutSpell(Guid spellId, [FromBody] Spell spell)
        {
            spell.SpellId = spellId;
            var document = Document.FromJson(JsonConvert.SerializeObject(spell));
            await _spellsTable.PutItemAsync(document);

            return spell;
        }

        [HttpDelete("{spellId}")]
        public async Task DeleteSpell(Guid spellId)
        {
            await _spellsTable.DeleteItemAsync(spellId);
        }
    }
}