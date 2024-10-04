namespace genscoSQLProject1.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public BranchInspection BranchInspection { get; set; }

    }
}
