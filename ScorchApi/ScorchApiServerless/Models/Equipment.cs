﻿using ScorchApiServerless.Models.Items;

namespace ScorchApiServerless.Models
{
    public class Equipment
    {
        public Armor Helm                   { get; set; }
        public Accessory Necklace           { get; set; }
        public Armor Chest                  { get; set; }
        public Armor Legs                   { get; set; }
        public Armor Gauntlets              { get; set; }
        public Armor Boots                  { get; set; }
        public Armor Shield                 { get; set; }
        public Accessory LeftRing           { get; set; }
        public Accessory RightRing          { get; set; }
        public Weapon MainHand              { get; set; }
        public Weapon OffHand               { get; set; }
        public Quiver Quiver                { get; set; }

        public Equipment() { }

    }
}
