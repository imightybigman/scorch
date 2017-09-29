using Amazon.DynamoDBv2.DocumentModel;

namespace ScorchApi.Models
{
    public class Equip : Item
    {
        public int Modifier     { get; set; }
        public string Stat      { get; set; }

        public Equip() : base() { }

        public Equip(DynamoDBEntry entry) : base(entry)
        {
            var doc     = entry.AsDocument();
            Modifier    = doc["Modifier"].AsInt();
            Stat        = doc["Stat"].AsString();
        }

        public new Document ToDocument()
        {
            var doc         = base.ToDocument();
            doc["Modifier"] = Modifier;
            doc["Stat"]     = Stat;

            return doc;
        }

    }
}
