using System;
using System.Collections.Generic;

namespace ScorchApiV2.Models
{
    public class Spell
    {
        public Guid SpellId         { get; set; }
        public string Name          { get; set; }
        public string Description   { get; set; }
        public string CastTime      { get; set; }
        public List<string> Classes { get; set; }
        public string Damage        { get; set; }  
        public string Duration      { get; set; }
        public int Level            { get; set; }
        public string Range         { get; set; }
        public string School        { get; set; }
        public string DamageType    { get; set; }

        public Spell() { }
    }
}
