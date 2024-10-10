namespace genscoSQLProject1.Dto
{
    public class AssetDto
    {
        public int AssetId { get; set; }
        public string AssetNumber { get; set; }  // Changed to string
        public string AssetType { get; set; }
        public int? CategoryId { get; set; }
        public int BranchNumber { get; set; }

      
    }
}
