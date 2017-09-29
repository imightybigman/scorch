using System.Collections.Generic;
using Amazon.DynamoDBv2.DocumentModel;

namespace ScorchApi.Models
{
    public class Character
    {
        public string Firstname     { get; set; }
        public string Lastname      { get; set; }
        public string Race          { get; set; }
        public string Class         { get; set; }
        public string Sex           { get; set; }
        public int Age              { get; set; }
        public string Align         { get; set; }
        public int Hp               { get; set; }
        public int MaxHp            { get; set; }
        public int Gold             { get; set; }
        public int Exp              { get; set; }
        public Stats Stats          { get; set; }
        public Equipment Inventory  { get; set; }
        public List<Trait> Traits   { get; set; }
        public List<Skill> Skills   { get; set; }
        public List<Spell> Spells   { get; set; }
        public List<string> Notes   { get; set; }
        
        public Character() { }

        public Character(Document doc)
        {
            Firstname   = doc["Firstname"].AsString();
            Lastname    = doc["Lastname"].AsString();
            Race        = doc["Race"].AsString();
            Class       = doc["Class"].AsString();
            Sex         = doc["Sex"].AsString();
            Age         = doc["Age"].AsInt();
            Align       = doc["Align"].AsString();
            Hp          = doc["Hp"].AsInt();
            MaxHp       = doc["MaxHp"].AsInt();
            Gold        = doc["Gold"].AsInt();
            Exp         = doc["Exp"].AsInt();
            Stats       = new Stats(doc["Stats"]);
            Inventory   = new Equipment(doc["Inventory"]);
        }

        public Document ToDocument()
        {
            var doc = new Document
            {
                ["Firstname"]   = Firstname,
                ["Lastname"]    = Lastname,
                ["Race"]        = Race,
                ["Class"]       = Class,
                ["Sex"]         = Sex,
                ["Age"]         = Age,
                ["Align"]       = Align,
                ["Hp"]          = Hp,
                ["MaxHp"]       = MaxHp,
                ["Gold"]        = Gold,
                ["Exp"]         = Exp,
                ["Stats"]       = Stats.ToDocument(),
                ["Inventory"]   = Inventory.ToDocument(),
            };
            return doc;
        }

    }
}
    