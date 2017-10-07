using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScorchApiV2.Abstract;
using ScorchApiV2.Models;

namespace ScorchApiV2.Interfaces
{
    public class IItemConverter : JsonCreationConverter<IItem>
    {

        protected override IItem Create(Type objectType, JObject jObject)
        {
            var itemClass = jObject["ItemClass"].ToString();
            switch (itemClass)
            {
                case "Weapon":
                    return new Weapon();
                case "Armor":
                    return new Armor();
                case "Quiver":
                    return new Quiver();
                default:
                    return new AdventurerGear();
            }
        }

        // because the CanWrite is set to false, this will never get called. so it will serialize as normal
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
