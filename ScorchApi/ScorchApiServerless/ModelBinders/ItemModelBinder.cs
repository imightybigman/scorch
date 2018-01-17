using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScorchApiServerless.Models.Items;

namespace ScorchApiServerless.ModelBinders
{
    public class ItemModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var content = bindingContext.HttpContext.Request;
            string json = GetBody(content);
            dynamic obj = JObject.Parse(json);

            bindingContext.Result = GetItemClass(obj, json);
            return Task.CompletedTask;
        }

        private ModelBindingResult GetItemClass(dynamic item, string json)
        {
            if (item.ItemClass == null)
            {
                return ModelBindingResult.Success(JsonConvert.DeserializeObject(json, typeof(AdventurerGear)));
            }

            var itemTypes = new[] {typeof(Weapon), typeof(Armor), typeof(AdventurerGear), typeof(Quiver), typeof(Accessory)};
            var matchedType = itemTypes.Single(x => x.Name == item.ItemClass.ToString());
            if (matchedType != null)
            {
                return ModelBindingResult.Success(JsonConvert.DeserializeObject(json, matchedType));
            }

            return ModelBindingResult.Success(JsonConvert.DeserializeObject(json, typeof(AdventurerGear)));
 
        }

        private string GetBody(HttpRequest request)
        {
            var inputStream = request.Body;

            using (var reader = new StreamReader(inputStream))
            {
                var body = reader.ReadToEnd();
                return body;
            }
        }
    }
}
