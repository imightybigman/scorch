using System.Collections.Generic;
using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models.DnDClasses
{
    public class Ranger : CharacterClass
    {
        public AdditionalFeature Archetype { get; set; }
        public Dictionary<string, int> SpellsKnown { get; set; }
        public Dictionary<string, List<SpellSlot>> SpellSlots { get; set; }
        public Companion Companion { get; set; }

        public Ranger() { }
    }
}
