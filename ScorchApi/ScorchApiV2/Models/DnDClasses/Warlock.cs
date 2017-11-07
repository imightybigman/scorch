using System.Collections.Generic;
using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models.DnDClasses
{
    public class Warlock : CharacterClass
    {
        public BonusFeature Pact                                { get; set; }
        public AdditionalFeature OtherworldyPatron              { get; set; }
        public Dictionary<string, int> CantripsKnown            { get; set; }
        public Dictionary<string, int> SpellsKnown              { get; set; }
        public Dictionary<string, int> InvocationsKnown         { get; set; }
        public Dictionary<string, List<SpellSlot>> SpellSlots   { get; set; }
        public Warlock() { }
    }
}
