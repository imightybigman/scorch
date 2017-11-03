using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScorchApiV2.Models.Items;

namespace ScorchApiV2.Abstract
{
    public class ItemConverter : JsonCreationConverter<Item>
    {
        protected override Item Create(Type objectType, JObject jObject)
        {
            if (jObject["ItemClass"] == null)
            {
                return new AdventurerGear();
            }
            var itemClass = jObject["ItemClass"].ToString();
            switch (itemClass)
            {
                case "Weapon":
                    return new Weapon();
                case "Armor":
                    return new Armor();
                case "Quiver":
                    return new Quiver();
                case "Accessory":
                    return new Accessory();
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
