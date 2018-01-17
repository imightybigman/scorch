using ScorchApiServerless.Abstract;

namespace ScorchApiServerless.Models.Items
{
    public class AdventurerGear : Item
    {
        public override string ItemClass { get; set; } = typeof(AdventurerGear).Name;

        public AdventurerGear() { }
    }
}
