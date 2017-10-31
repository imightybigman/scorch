using System;
using System.Collections.Generic;
using ScorchApiV2.Interfaces;

namespace ScorchApiV2.Models
{
    public class Armor : IItem
    {
        public Guid ItemId                  { get; set; }
        public string Name                  { get; set; }
        public string Description           { get; set; }
        public string ItemClass             { get; set; } = typeof(Armor).Name;
        public string ItemType              { get; set; }
        public double Cost                  { get; set; }
        public int Weight                   { get; set; }

        public int AC                           { get; set; }
        public bool DexterityBonus              { get; set; }
        public string Slot                      { get; set; }
        public bool StealthAdvantage            { get; set; }
        public List<string> Properties          { get; set; }
        public List<Modifiers> StatModifiers    { get; set; }

        public Armor() { }
    }
}
