using System;
using System.Collections.Generic;
using ScorchApiV2.Interfaces;

namespace ScorchApiV2.Models
{
    public class Quiver : IItem
    {
        public Guid ItemId              { get; set; }
        public string Name              { get; set; }
        public string Description       { get; set; }
        public string ItemClass         { get; set; } = typeof(Quiver).Name;
        public string ItemType          { get; set; }
        public string Cost              { get; set; }
        public int Weight               { get; set; }
        public List<string> Properties  { get; set; }

        public Dictionary<string, int> Container    { get; set; }
        public string Slot                          { get; set; }

        public Quiver() { }
    }
}
