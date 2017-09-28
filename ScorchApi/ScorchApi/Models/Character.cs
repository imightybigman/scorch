using Amazon.DynamoDBv2.DocumentModel;

namespace ScorchApi.Models
{
    public class Character
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Align { get; set; }
        public int Hp { get; set; }
        public string MaxHp { get; set; }
        public Stats Stats { get; set; }

        public Character() { }

        public Character(Document doc)
        {
            Firstname = doc["Firstname"];
        }

    }
}
    