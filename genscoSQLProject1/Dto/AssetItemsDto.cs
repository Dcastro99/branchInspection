namespace genscoSQLProject1.Dto
{
    public class AssetItemsDto
    {
        public int ChecklistItemId { get; set; }
        public int AssetId { get; set; }
        public int BranchInspectionId { get; set; }
        public bool? CheckedFlag { get; set; }
        public DateTime? DotInspectionDate { get; set; }
    }
}
