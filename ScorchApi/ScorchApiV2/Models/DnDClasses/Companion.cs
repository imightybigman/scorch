using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScorchApiV2.Models.DnDClasses
{
    public class Companion
    {
        public string Type { get; set; }
        public string Size { get; set; }
        public int Hp { get; set; }
        public int AC { get; set; }
        public List<BonusFeature> Attacks { get; set; }
    }
}
