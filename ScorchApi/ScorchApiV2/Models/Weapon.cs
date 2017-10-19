using System;
using System.Collections.Generic;
using ScorchApiV2.Interfaces;

namespace ScorchApiV2.Models
{
    public class Weapon : IItem
    {
        public Guid ItemId          { get; set; }
        public string Name          { get; set; }
        public string Description   { get; set; }
        public string ItemClass     { get; set; } = typeof(Weapon).Name;
        public string ItemType      { get; set; }
        public string Cost          { get; set; }
        public int Weight           { get; set; }

        public string Damage                { get; set; }
        public string DamageType             { get; set; }
        public string Slot                  { get; set; }
        public List<string> Properties      { get; set; }
        public List<Modifiers> Modifiers    { get; set; }
        public int ShortRange               { get; set; }
        public int LongRange                { get; set; }

        public Weapon(){ }
    }
}
