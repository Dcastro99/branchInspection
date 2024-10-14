namespace genscoSQLProject1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public  string CategoryName { get; set; }

             
      //-----------NAVIGATION PROPERTIES------------//
        public  ICollection<ChecklistItem> ChecklistItems { get; set; }  
        public ICollection<FormCategory> FormCategory { get; set; }


    }
}
