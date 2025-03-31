namespace genscoSQLProject1.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int BranchNumber { get; set; }


        //---------NAVIGATION PROPERTIES-----------//
        public ICollection<BranchInspection> BranchInspections { get; set; } 
        public ICollection<Asset> Assets { get; set; }  
    }

}
