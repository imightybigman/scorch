using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScorchApiV2.Models.DnDClasses;

namespace ScorchApiV2.Abstract
{
    public class CharacterClassConverter : JsonCreationConverter<CharacterClass>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override CharacterClass Create(Type objectType, JObject jObject)
        {
            var characterClass = jObject["Name"].ToString();
            switch (characterClass)
            {
                case "Fighter":
                    return new Fighter();
                case "Warlock":
                    return new Warlock();
                default:
                    return new Fighter();
            }
        }
    }
}
