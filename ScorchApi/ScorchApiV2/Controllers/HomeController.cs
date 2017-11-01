using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ScorchApiV2.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private static string tableName;
        public HomeController(IOptions<AppSettings> appSettings)
        {
            tableName = appSettings.Value.DynamoTables["DnDCharactersTable"];
        }

        [HttpGet]
        public Info GetHome()
        {
            return new Info
            {
                Title = "ScorchApi",
                Version = "v2",
                Description = "DnD Api Backend Service",
                TermsOfService = tableName
            };
        }
    }
}