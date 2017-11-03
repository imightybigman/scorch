using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models.DnDClasses
{
    public class Fighter : CharacterClass
    {
        public AdditionalFeature MartialArchetype { get; set; }

        public Fighter() { }
    }
}
