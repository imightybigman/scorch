using ScorchApiV2.Interfaces;
using System;
using System.Collections.Generic;

namespace ScorchApiV2.Models
{
    public class Accessory : IItem
    {
        public Guid ItemId              { get; set; }
        public string Name              { get; set; }
        public string Description       { get; set; }
        public string ItemClass         { get; set; } = typeof(Accessory).Name;
        public string ItemType          { get; set; }
        public double Cost              { get; set; }
        public int Weight               { get; set; }
        public string Slot              { get; set; }
        public List<string> Properties  { get; set; }

        public Accessory() { }
    }
}
