using System.Collections.Generic;
using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models.DnDClasses
{
    public class Paladin : CharacterClass
    {
        public AdditionalFeature SacredOath { get; set; }
        public Dictionary<string, List<SpellSlot>> SpellSlots { get; set; }

        public Paladin() { }
    }
}
