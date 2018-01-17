using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScorchApiServerless.Models;

namespace ScorchApiServerless.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ApiInfo GetHome()
        {
            return new ApiInfo
            {
                Title = "ScorchApi",
                Version = "v2",
                Description = "DnD Api Backend Service",
            };
        }
    }
}