using System;
using System.Collections.Generic;
using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models
{
    public class Quiver : Item
    {
        public override string ItemClass                       { get; set; } = typeof(Quiver).Name;
        public Dictionary<string, ArrowCounter> Projectiles   { get; set; }
        public string Slot                                    { get; set; }

        public Quiver() { }
    }
}
