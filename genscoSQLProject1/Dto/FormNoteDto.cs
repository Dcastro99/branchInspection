namespace genscoSQLProject1.Dto
{
    public class FormNoteDto
    {
        public int FormNoteId { get; set; }
        public int BranchInspectionId { get; set; }
        public string Note { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
