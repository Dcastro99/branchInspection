namespace genscoSQLProject1.Dto
{
    public class FormCommentDto
    {
        public int FormCommentId { get; set; }
        public int BranchInspectionId { get; set; }
        public int CategoryId { get; set; }
        public string? Comment { get; set; }
    }
}
