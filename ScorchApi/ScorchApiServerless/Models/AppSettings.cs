using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScorchApiServerless.Models
{
    public class AppSettings
    {
        public Dictionary<string, string> DynamoTables { get; set; }
    }
}
