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
    public class ChapterController : Controller
    {
        private static AmazonDynamoDBClient _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static string _chapterTableName = "DnD-CampaignChapter";
        private static Table _chapterTable;

        public ChapterController()
        {
            _chapterTable = Table.LoadTable(_client, _chapterTableName);
        }

        [HttpGet("{chapterId}")]
        public async Task<Chapter> GetChapter(Guid chapterId)
        {
            var document = await _chapterTable.GetItemAsync(chapterId);

            return document != null ? JsonConvert.DeserializeObject<Chapter>(document.ToJson()) : null;
        }

        [HttpPost]
        public async Task<Chapter> PostChapter([FromBody]Chapter chapter)
        {
            chapter.ChapterId = Guid.NewGuid();
            var document = Document.FromJson(JsonConvert.SerializeObject(chapter));
            await _chapterTable.PutItemAsync(document);

            return chapter;
        }

        [HttpPut("{chapterId}")]
        public async Task<Chapter> PutChapter(Guid chapterId, [FromBody] Chapter chapter)
        {
            chapter.ChapterId = chapterId;
            var document = Document.FromJson(JsonConvert.SerializeObject(chapter));
            await _chapterTable.PutItemAsync(document);

            return chapter;
        }

        [HttpDelete("{chapterId}")]
        public async Task DeleteChapter(Guid chapterId)
        {
            await _chapterTable.DeleteItemAsync(chapterId);
        }
    }
}