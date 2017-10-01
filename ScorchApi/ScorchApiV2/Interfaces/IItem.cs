namespace ScorchApiV2.Interfaces
{
    public interface IItem
    {
        string Name         { get; set; }
        string Description  { get; set; }
        string ItemClass    { get; set; }
        string ItemType     { get; set; }
        string Cost         { get; set; }
        int Weight          { get; set; }
    }
}
