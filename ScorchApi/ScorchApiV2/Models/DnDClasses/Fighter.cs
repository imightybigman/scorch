using ScorchApiV2.Abstract;

namespace ScorchApiV2.Models.DnDClasses
{
    public class Fighter : CharacterClass
    {
        public string MartialNess { get; set; }
        public Fighter()
        {
            Name = typeof(Fighter).Name;

        }
    }
}
