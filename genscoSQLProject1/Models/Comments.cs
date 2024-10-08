namespace genscoSQLProject1.Models
{
    public class Comments
    {
        public int CommentId { get; set; }  
        public  string Comment { get; set; }
        public int CategoryId { get; set; }
        public  Category Category { get; set; }  // Navigation property to Category
    }
}

