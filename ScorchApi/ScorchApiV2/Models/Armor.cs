﻿using System.Collections.Generic;
using ScorchApiV2.Interfaces;

namespace ScorchApiV2.Models
{
    public class Armor : IItem
    {
        public string Name          { get; set; }
        public string Description   { get; set; }
        public string ItemClass     { get; set; } = typeof(Armor).Name;
        public string ItemType      { get; set; }
        public string Cost          { get; set; }
        public int Weight           { get; set; }

        public int AC { get; set; }
        public bool StealthAdvantage { get; set; }
        public List<string> Properties { get; set; }
        public List<Modifiers> Modifiers { get; set; }

        public Armor() { }
    }
}
