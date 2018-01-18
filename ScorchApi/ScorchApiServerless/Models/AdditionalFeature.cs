using System.Collections.Generic;

namespace ScorchApiServerless.Models
{
    public class AdditionalFeature
    {
        public string Name                                          { get; set; }
        public Dictionary<string, List<BonusFeature>> Features      { get; set; }

        public AdditionalFeature() { }
    }
}
