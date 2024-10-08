namespace genscoSQLProject1.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public string BranchNumber { get; set; }

        public ICollection<Asset> Assets { get; set; }  // Navigation property
    }

}
