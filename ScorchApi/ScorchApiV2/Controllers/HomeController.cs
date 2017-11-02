using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
                Title = "ScorchApi",
                Version = "v2",
                Description = "DnD Api Backend Service",
                TermsOfService = "LOL"
            };
        }
    }
}