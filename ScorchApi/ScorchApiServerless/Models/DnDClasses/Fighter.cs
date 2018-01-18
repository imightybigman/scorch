using ScorchApiServerless.Abstract;

namespace ScorchApiServerless.Models.DnDClasses
{
    public class Fighter : CharacterClass
    {
        public AdditionalFeature MartialArchetype { get; set; }

        public Fighter() { }
    }
}
