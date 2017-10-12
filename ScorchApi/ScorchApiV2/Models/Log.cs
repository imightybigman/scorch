using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using Newtonsoft.Json;
using ScorchApiV2.Static;

namespace ScorchApiV2.Models
{
    public class Log
    {
        public Guid LogId           { get; set; }
        public DateTime LogDate     { get; set; }
        public string LogMessage    { get; set; }

        public Log() { }

        public Log(Document doc)
        {
            LogId = new Guid(doc["LogId"]);
            LogDate = DatetimeExtensions.FromUnixTimestamp(doc["LogDate"]);
        }
    }
}
