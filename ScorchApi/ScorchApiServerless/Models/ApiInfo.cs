using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace ScorchApiServerless.Models
{
    public class ApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }

        public ApiInfo() { }
    }
}
