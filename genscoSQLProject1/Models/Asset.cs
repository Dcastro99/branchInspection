namespace genscoSQLProject1.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        public string AssetNumber { get; set; }  
        public  string AssetType { get; set; }
        public int? BranchId { get; set; }

        //----------------Navigation Properties-----------------//
        public Branch Branch { get; set; }
        public ICollection<FormAssets> FormAssets { get; set; }
 
    }
}
