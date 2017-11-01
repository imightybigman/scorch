using System;
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
    public class ChapterController : Controller
    {
        private static AmazonDynamoDBClient _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        private static IOptions<AppSettings> _appSettings;
        private static Table _chapterTable;

        public ChapterController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            var tableName = _appSettings.Value.DynamoTables["DnD-Chapters"];
            _chapterTable = Table.LoadTable(_client, tableName);
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