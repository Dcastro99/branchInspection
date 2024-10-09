namespace genscoSQLProject1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public  string CategoryName { get; set; }
        public int? BranchInspectionId { get; set; }
        public  BranchInspection BranchInspection { get; set; }  // Navigation property
        public ICollection<Asset> Assets { get; set; }
        public  ICollection<ChecklistItem> ChecklistItems { get; set; }  // Navigation to ChecklistItems
        public  ICollection<Comments> Comments { get; set; }  // Navigation to Comments

    }
}
