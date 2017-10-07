using System;
using System.Collections.Generic;
using ScorchApiV2.Interfaces;

namespace ScorchApiV2.Models
{
    public class Character
    {
        public Guid CharacterId         { get; set; }
        public string Firstname         { get; set; }
        public string Lastname          { get; set; }
        public string Race              { get; set; }
        public string Class             { get; set; }
        public string Sex               { get; set; }
        public int Age                  { get; set; }
        public string Align             { get; set; }
        public int Hp                   { get; set; }
        public int MaxHp                { get; set; }
        public int Gold                 { get; set; }
        public int Exp                  { get; set; }
        public int Level                { get; set; }
        public int Proficiency          { get; set; }
        public Stats Stats              { get; set; }
        public Equipment Equipment      { get; set; } 
        public List<Trait> Traits       { get; set; } = new List<Trait>();
        public List<Skill> Skills       { get; set; } = new List<Skill>();
        public List<Spell> Spells       { get; set; } = new List<Spell>();
        public List<IItem> Inventory    { get; set; } = new List<IItem>();
        public List<string> Notes       { get; set; } = new List<string>();
        
        public Character() { }


    }
}
    