using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScorchApiV2.Models
{
    public class Enemy
    {
        public string Name { get; set; }
        public List<BonusFeature> Traits { get; set; }
        public List<BonusFeature> Actions { get; set; } 
        public List<BonusFeature> LegendaryActions { get; set; }
        public Stats Stats { get; set; }
    }
}
