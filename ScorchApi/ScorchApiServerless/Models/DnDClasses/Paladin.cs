using System.Collections.Generic;
using ScorchApiServerless.Abstract;

namespace ScorchApiServerless.Models.DnDClasses
{
    public class Paladin : CharacterClass
    {
        public AdditionalFeature SacredOath { get; set; }
        public Dictionary<string, List<SpellSlot>> SpellSlots { get; set; }

        public Paladin() { }
    }
}
