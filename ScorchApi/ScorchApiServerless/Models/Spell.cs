using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScorchApiServerless.Models
{
    public class Spell
    {
        public Guid SpellId                         { get; set; }
        public string Name                          { get; set; }
        public string Description                   { get; set; }
        public bool AddCastingModifier              { get; set; }
        public string CastingTime                   { get; set; }
        public List<string> Classes                 { get; set; }
        public bool Concentration                   { get; set; }
        public string Damage                        { get; set; }
        public string DamageType                    { get; set; }
        public string Duration                      { get; set; }
        public string Healing                       { get; set; }
        public int? HigherLevelHealing              { get; set; }
        public int? HigherSpellSlotBonus            { get; set; }
        public string HigherSpellSlotDice           { get; set; }
        public int? Level                           { get; set; }
        public string Range                         { get; set; }
        public string Save                          { get; set; }
        public string SaveSuccess                   { get; set; }
        public string SavingThrows                  { get; set; }
        public string School                        { get; set; }
        public string SecondaryDamage               { get; set; }
        public string SecondaryDamageType           { get; set; }
        public string SecondaryHigherSpellSlotDice  { get; set; }
        public string SpellType                     { get; set; }
        public string Target                        { get; set; }
        public Spell(){ }
    }
}
