using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScorchApiV2.Models;

namespace ScorchApiV2.Abstract
{
    public abstract class MartialArchetype
    {
        public string Name                                          { get; set; }
        public Dictionary<string, List<BonusFeature>> BonusFeatures { get; set; }
    }
}
