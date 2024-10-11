namespace genscoSQLProject1.Dto
{
    public class AssetItemsDto
    {
        public int AssetItemsId { get; set; }
        public int FormAssetsId { get; set; }
        public int ChecklistItemId { get; set; }
        public bool? CheckedFlag { get; set; }
        public DateTime? DotInspectionDate { get; set; }
    }
}
