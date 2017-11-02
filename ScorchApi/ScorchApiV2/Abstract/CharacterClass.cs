using System.Collections.Generic;
using Newtonsoft.Json;
using ScorchApiV2.Models;

namespace ScorchApiV2.Abstract
{
    [JsonConverter(typeof(CharacterClassConverter))]
    public abstract class CharacterClass
    {
        public string Name { get; set; }
        public Dictionary<int, BonusFeature> BonusFeatures { get; set; }

    }
}
