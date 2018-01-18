using System.Collections.Generic;
using ScorchApiServerless.Abstract;

namespace ScorchApiServerless.Models.Items
{
    public class Armor : Item
    {
        public override string ItemClass        { get; set; } = typeof(Armor).Name;
        public int AC                           { get; set; }
        public bool DexterityBonus              { get; set; }
        public string Slot                      { get; set; }
        public bool StealthAdvantage            { get; set; }
        public List<Modifiers> StatModifiers    { get; set; }

        public Armor() { }
    }
}
