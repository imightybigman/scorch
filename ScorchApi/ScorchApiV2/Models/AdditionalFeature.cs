using System.Collections.Generic;

namespace ScorchApiV2.Models
{
    public class AdditionalFeature
    {
        public string Name                                          { get; set; }
        public Dictionary<string, List<BonusFeature>> Features      { get; set; }
    }
}
