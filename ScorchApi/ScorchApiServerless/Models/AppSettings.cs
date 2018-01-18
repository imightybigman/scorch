using System.Collections.Generic;

namespace ScorchApiServerless.Models
{
    public class AppSettings
    {
        public Dictionary<string, string> DynamoTables { get; set; }
    }
}
