using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScorchApiV2.Models.DnDClasses
{
    public class OtherworldyPatron
    {
        public string Name { get; set; }
        public Dictionary<string, List<BonusFeature>> Features { get; set; }
    }
}
