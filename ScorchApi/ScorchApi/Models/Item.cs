using Amazon.DynamoDBv2.DocumentModel;

namespace ScorchApi.Models
{
    public class Item
    {
        public string Name          { get; set; }
        public string Description   { get; set; }
        public string Cost          { get; set; }

        public Item() { }

        public Item(DynamoDBEntry entry)
        {
            var doc         = entry.AsDocument();
            Name            = doc["Name"].AsString();
            Description     = doc["Description"].AsString();
            Cost            = doc["Cost"].AsString();
        }

        public Document ToDocument()
        {
            var doc = new Document
            {
                ["Name"]        = Name,
                ["Description"] = Description,
                ["Cost"]        = Cost
            };

            return doc;
        }
    }
}
