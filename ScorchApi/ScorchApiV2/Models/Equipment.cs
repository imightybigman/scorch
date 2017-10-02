namespace ScorchApiV2.Models
{
    public class Equipment
    {
        public Armor Helm                   { get; set; }
        public AdventurerGear Necklace      { get; set; }
        public Armor Chest                  { get; set; }
        public Armor Legs                   { get; set; }
        public Armor Gauntlets              { get; set; }
        public Armor Boots                  { get; set; }
        public AdventurerGear LeftRing      { get; set; }
        public AdventurerGear RightRing     { get; set; }
        public Weapon MainHand              { get; set; }
        public Weapon OffHand               { get; set; }
        public Quiver Quiver                { get; set; }

        public Equipment() { }

    }
}
