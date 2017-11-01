using System;
using System.Collections.Generic;
using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models
{
    public class AdventurerGear : Item
    {
        public override string ItemClass { get; set; } = typeof(AdventurerGear).Name;

        public AdventurerGear() { }
    }
}
