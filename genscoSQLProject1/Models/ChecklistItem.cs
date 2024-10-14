namespace genscoSQLProject1.Models
{
    public class ChecklistItem
    {
        public int ChecklistItemId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }


        //---------NAVIGATION PROPERTIES-----------//
        public ICollection<FormItems> FormItems { get; set; }
        public Category Category { get; set; }
        public ICollection<AssetItems> AssetItems { get; set; }

    }
}

   