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
    public class EntityController : Controller
    {
        private static AmazonDynamoDBClient _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string _entityTableName = "DnD-Entity";
        private static Table _entityTable;

        public EntityController()
        {
            _entityTable = Table.LoadTable(_client, _entityTableName);
        }

        [HttpGet("{entityId}")]
        public async Task<Entity> GetEntity(Guid entityId)
        {
            var document = await _entityTable.GetItemAsync(entityId);

            return document != null ? JsonConvert.DeserializeObject<Entity>(document.ToJson()) : null;
        }

        [HttpPost]
        public async Task<Entity> PostEntity([FromBody]Entity entity)
        {
            entity.EntityId = Guid.NewGuid();
            var document = Document.FromJson(JsonConvert.SerializeObject(entity));
            await _entityTable.PutItemAsync(document);

            return entity;
        }

        [HttpPut("{entityId}")]
        public async Task<Entity> PutEntity(Guid entityId, [FromBody] Entity entity)
        {
            entity.EntityId = entityId;
            var document = Document.FromJson(JsonConvert.SerializeObject(entity));
            await _entityTable.PutItemAsync(document);

            return entity;
        }

        [HttpDelete("{entityId}")]
        public async Task DeleteEntity(Guid entityId)
        {
            await _entityTable.DeleteItemAsync(entityId);
        }
    }
}