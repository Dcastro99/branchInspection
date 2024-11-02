namespace genscoSQLProject1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public  string CategoryName { get; set; }
        public int? BranchInspectionId { get; set; }
        public string? CategoryComment { get; set; }


        //-----------NAVIGATION PROPERTIES------------//
        public  ICollection<ChecklistItem> ChecklistItems { get; set; }  
        public BranchInspection BranchInspection { get; set; }


    }
}
