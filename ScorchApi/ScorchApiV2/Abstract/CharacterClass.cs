using System.Collections.Generic;
using Newtonsoft.Json;
using ScorchApiV2.Models;

namespace ScorchApiV2.Abstract
{
    [JsonConverter(typeof(CharacterClassConverter))]
    public abstract class CharacterClass
    {
        public string Name                                              { get; set; }
        public string HitDice                                           { get; set; }
        public int HitDiceFlat                                          { get; set; }
        public List<int> AbilityScoreImprovement                        { get; set; }
        public Dictionary<string, List<BonusFeature>> BonusFeatures     { get; set; }
    }
}
