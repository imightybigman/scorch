using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ScorchApiV2.Abstract
{
    [JsonConverter(typeof(ItemConverter))]
    public abstract class Item
    {
        public Guid ItemId                      { get; set; }
        public string Name                      { get; set; }
        public string Description               { get; set; }
        public abstract string ItemClass        { get; set; }
        public string ItemType                  { get; set; }
        public double Cost                      { get; set; }
        public int Weight                       { get; set; }
        public int? Count                       { get; set; }
        public List<string> Properties          { get; set; }
    }
}
