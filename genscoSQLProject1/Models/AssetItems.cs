namespace genscoSQLProject1.Models
{
    public class AssetItems
    {
        public int ChecklistItemId { get; set; }
        public int AssetId { get; set; }
        public int BranchInspectionId { get; set; }
        public bool? CheckedFlag { get; set; }
        public DateTime? DotInspectionDate { get; set; }

        // Navigation Properties
        public ChecklistItem ChecklistItem { get; set; }
        public FormAssets FormAssets { get; set; }
    }

}
