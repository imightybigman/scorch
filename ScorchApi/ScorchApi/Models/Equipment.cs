using Amazon.DynamoDBv2.DocumentModel;

namespace ScorchApi.Models
{
    public class Equipment
    {
        public Equip Helm       { get; set; }
        public Equip Necklace   { get; set; }
        public Equip Chest      { get; set; }
        public Equip Legs       { get; set; }
        public Equip Gauntlets  { get; set; }
        public Equip Boots      { get; set; }
        public Equip LeftRing   { get; set; }
        public Equip RightRing  { get; set; }
        public Equip MainHand   { get; set; }
        public Equip OffHand    { get; set; }
        public Equip Quiver     { get; set; }

        public Equipment() { }

        public Equipment(DynamoDBEntry entry)
        {
            var doc     = entry.AsDocument();
            Helm        = new Equip(doc["Helm"]);
            Necklace    = new Equip(doc["Necklace"]);
            Chest       = new Equip(doc["Chest"]); 
            Legs        = new Equip(doc["Legs"]);
            Gauntlets   = new Equip(doc["Gauntlets"]);
            Boots       = new Equip(doc["Boots"]);
            LeftRing    = new Equip(doc["LeftRing"]);
            RightRing   = new Equip(doc["RightRing"]);
            MainHand    = new Equip(doc["MainHand"]);
            OffHand     = new Equip(doc["OffHand"]);
            Quiver      = new Equip(doc["Quiver"]);
        }

        public Document ToDocument()
        {
            var doc = new Document
            {
                ["Helm"]        = Helm.ToDocument(),
                ["Necklace"]    = Necklace.ToDocument(),
                ["Chest"]       = Chest.ToDocument(),
                ["Legs"]        = Legs.ToDocument(),
                ["Gauntlets"]   = Gauntlets.ToDocument(),
                ["Boots"]       = Boots.ToDocument(),
                ["LeftRing"]    = LeftRing.ToDocument(),
                ["RightRing"]   = RightRing.ToDocument(),
                ["MainHand"]    = MainHand.ToDocument(),
                ["OffHand"]     = OffHand.ToDocument(),
                ["Quiver"]      = Quiver.ToDocument()
            };

            return doc;
        }
    }
}
