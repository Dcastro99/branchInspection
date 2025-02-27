namespace genscoSQLProject1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        //public int? CatRefId { get; set; }
        public  string CategoryName { get; set; }
        //public int? BranchInspectionId { get; set; }
        //public string? CategoryComment { get; set; }


        //-----------NAVIGATION PROPERTIES------------//
        public  ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();
        public ICollection<FormNote> FormNotes { get; set; } = new List<FormNote>();
        public ICollection<FormComment> FormComments { get; set; } = new List<FormComment>();


        //public BranchInspection BranchInspection { get; set; }


    }
}
