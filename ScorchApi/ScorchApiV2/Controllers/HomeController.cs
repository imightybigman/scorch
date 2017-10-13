using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace ScorchApiV2.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public Info GetHome()
        {
            return new Info
            {
                Title = "ScorchApi Dev",
                Version = "v2",
                Description = "DnD Api Backend Service",
                TermsOfService = "Lol"
            };
        }
    }
}