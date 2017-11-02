using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models
{
    public class Accessory : Item
    {
        public override string ItemClass { get; set; } = typeof(Accessory).Name;
        public string Slot               { get; set; }

        public Accessory() { }
    }
}
