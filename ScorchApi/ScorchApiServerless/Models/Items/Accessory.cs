using ScorchApiServerless.Abstract;

namespace ScorchApiServerless.Models.Items
{
    public class Accessory : Item
    {
        public override string ItemClass { get; set; } = typeof(Accessory).Name;
        public string Slot               { get; set; }

        public Accessory() { }
    }
}
