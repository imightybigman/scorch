using System.Collections.Generic;

namespace ScorchApiV2.Models
{
    public class Character
    {
        public string Firstname     { get; set; }
        public string Lastname      { get; set; }
        public string Race          { get; set; }
        public string Class         { get; set; }
        public string Sex           { get; set; }
        public int Age              { get; set; }
        public string Align         { get; set; }
        public int Hp               { get; set; }
        public int MaxHp            { get; set; }
        public int Gold             { get; set; }
        public int Exp              { get; set; }
        public Stats Stats          { get; set; }
        public Equipment Equipment  { get; set; } = new Equipment();
        public List<Trait> Traits   { get; set; } = new List<Trait>();
        public List<Skill> Skills   { get; set; } = new List<Skill>();
        public List<Spell> Spells   { get; set; } = new List<Spell>();
        public List<string> Notes   { get; set; } = new List<string>();
        
        public Character() { }


    }
}
    