using System.Collections.Generic;

namespace ScorchApiServerless.Models.DnDClasses
{
    public class OtherworldyPatron
    {
        public string Name { get; set; }
        public Dictionary<string, List<BonusFeature>> Features { get; set; }

        public OtherworldyPatron() { }
    }
}
