namespace genscoSQLProject1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public  string CategoryName { get; set; }

             
      //-----------NAVIGATION PROPERTIES------------//
        public  ICollection<ChecklistItem> ChecklistItems { get; set; }  
        public FormCategory FormCategory { get; set; }


    }
}
