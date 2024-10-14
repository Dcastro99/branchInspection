namespace genscoSQLProject1.Models
{
    public class FormAssets
    {
      
        public int BranchInspectionId { get; set; }
        public int AssetId { get; set; }

        //---------NAVIGATION PROPERTIES-----------//
        public BranchInspection BranchInspection { get; set; } 
        public Asset Assets { get; set; }
        public ICollection<AssetItems> AssetItems { get; set; }

    }
}
