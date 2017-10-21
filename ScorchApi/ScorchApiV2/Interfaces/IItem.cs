using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ScorchApiV2.Interfaces
{
    [JsonConverter(typeof(IItemConverter))]
    public interface IItem
    {
        Guid ItemId             { get; set; }
        string Name             { get; set; }
        string Description      { get; set; }
        string ItemClass        { get; set; }
        string ItemType         { get; set; }
        double Cost             { get; set; }
        int Weight              { get; set; }
        List<string> Properties { get; set; }
    }
}
