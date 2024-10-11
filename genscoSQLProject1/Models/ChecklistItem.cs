namespace genscoSQLProject1.Models
{
    public class ChecklistItem
    {
        public int ChecklistItemId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }


        //---------NAVIGATION PROPERTIES-----------//
        public FormItems FormItem { get; set; }
        public Category Category { get; set; }
        public AssetItems AssetItems { get; set; }

    }
}

   