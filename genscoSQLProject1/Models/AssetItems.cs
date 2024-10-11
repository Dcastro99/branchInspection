namespace genscoSQLProject1.Models
{
    public class AssetItems
    {
        public int AssetItemsId { get; set; }
        public int FormAssetsId { get; set; }
        public int ChecklistItemId { get; set; }
        public bool? CheckedFlag { get; set; }
        public DateTime? DotInspectionDate { get; set; }

        //---------NAVIGATION PROPERTIES-----------//
        public FormAssets FormAssets { get; set; }
        public ChecklistItem ChecklistItem { get; set; }  
       
    }
}
