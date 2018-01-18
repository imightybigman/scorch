using System.Collections.Generic;
using ScorchApiServerless.Abstract;

namespace ScorchApiServerless.Models.Items
{
    public class Quiver : Item
    {
        public override string ItemClass                       { get; set; } = typeof(Quiver).Name;
        public Dictionary<string, ArrowCounter> Projectiles   { get; set; }
        public string Slot                                    { get; set; }

        public Quiver() { }
    }
}
