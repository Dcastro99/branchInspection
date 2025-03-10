namespace genscoSQLProject1.Models
{
    public class FormComment
    {
        public int FormCommentId { get; set; }
        public int BranchInspectionId { get; set; }
        public int CategoryId { get; set; }
        public int? AssetId { get; set; }
        public string? Comment { get; set; }
        

        // Navigation Properties
        public BranchInspection BranchInspection { get; set; }
        public Category Category { get; set; }
        //public Asset Asset { get; set; }
    }
}
