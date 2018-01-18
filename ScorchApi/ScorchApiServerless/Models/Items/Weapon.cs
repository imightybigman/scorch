using System.Collections.Generic;
using ScorchApiServerless.Abstract;

namespace ScorchApiServerless.Models.Items
{
    public class Weapon : Item
    {
        public override string ItemClass        { get; set; } = typeof(Weapon).Name;
        public string Damage                    { get; set; }
        public string DamageType                { get; set; }
        public string Slot                      { get; set; }
        public List<Modifiers> StatModifiers    { get; set; }
        public bool Versatile                   { get; set; }
        public string VersatileDamage           { get; set; }
        public int ShortRange                   { get; set; }
        public int LongRange                    { get; set; }

        public Weapon() { }
    }
}
