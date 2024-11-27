namespace genscoSQLProject1.Dto
{
    public class FormNoteDto
    {
        public int FormNoteId { get; set; }
        public int BranchInspectionId { get; set; }
        public string? SectionNote { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? generalNotes { get; set; }
        public int CategoryId { get; set; }
    }
}
