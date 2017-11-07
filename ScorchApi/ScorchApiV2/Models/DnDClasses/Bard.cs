using System.Collections.Generic;
using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models.DnDClasses
{
    public class Bard : CharacterClass
    {
        public BonusFeature BardCollege { get; set; }
        public AdditionalFeature CollegeFeatures { get; set; }
        public Dictionary<string, int> CantripsKnown { get; set; }
        public Dictionary<string, int> SpellsKnown { get; set; }
        public Dictionary<string, List<SpellSlot>> SpellSlots { get; set; }
        public Bard() { }
    }
}
