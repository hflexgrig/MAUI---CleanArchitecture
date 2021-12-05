namespace MAUI.CleanArchitecture.Domain
{
    public class MainModel
    {
        public int TotalQuantity => SubItems.Sum(x => x.Quantity);
        public IList<SubItem> SubItems { get; set; } = new List<SubItem>();
    }
}