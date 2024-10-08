namespace genscoSQLProject1.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        public string AssetNumber { get; set; }  // Changed to string
        public  string AssetType { get; set; }
        public int CategoryId { get; set; }
        public int BranchId { get; set; }
        public Category Category { get; set; }  // Navigation property

        public ICollection<ChecklistItem> ChecklistItems { get; set; }  // Add this for ChecklistItems
    }
}
