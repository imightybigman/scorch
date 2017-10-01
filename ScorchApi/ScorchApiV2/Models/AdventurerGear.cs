using ScorchApiV2.Interfaces;

namespace ScorchApiV2.Models
{
    public class AdventurerGear : IItem
    {
        public string Name          { get; set; }
        public string Description   { get; set; }
        public string ItemClass     { get; set; } = "AdventurerGear";
        public string ItemType      { get; set; }
        public string Cost          { get; set; }
        public int Weight           { get; set; }

        public AdventurerGear() { }

    }
}
