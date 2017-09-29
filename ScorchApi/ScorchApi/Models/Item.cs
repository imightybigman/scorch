using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.S3.Model;

namespace ScorchApi.Models
{
    public class Item
    {
        public string Name          { get; set; }
        public string Description   { get; set; }
        public string Attribute     { get; set; }

        public Item() { }

        public Item(DynamoDBEntry entry)
        {
            var doc         = entry.AsDocument();
            Name            = doc["Name"].AsString();
            Description     = doc["Description"].AsString();
            Attribute       = doc["Attribute"].AsString();
        }
    }
}
