using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models.DnDClasses
{
    public class Wizard : CharacterClass
    {
        public int SpellSlots { get; set; }

        public Wizard()
        {
            Name = typeof(Wizard).Name;
        }
    }
}
