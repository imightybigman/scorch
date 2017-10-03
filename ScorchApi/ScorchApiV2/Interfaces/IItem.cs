using System;

namespace ScorchApiV2.Interfaces
{
    public interface IItem
    {
        Guid ItemId         { get; set; }
        string Name         { get; set; }
        string Description  { get; set; }
        string ItemClass    { get; set; }
        string ItemType     { get; set; }
        string Cost         { get; set; }
        int Weight          { get; set; }
    }
}
