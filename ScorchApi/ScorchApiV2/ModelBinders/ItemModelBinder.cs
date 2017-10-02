using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScorchApiV2.Models;

namespace ScorchApiV2.ModelBinders
{
    public class ItemModelBinder : IModelBinder
    {
        readonly JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

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
            var itemTypes = new[] {typeof(Weapon), typeof(Armor), typeof(AdventurerGear), typeof(Quiver)};
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
