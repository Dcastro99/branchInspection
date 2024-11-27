namespace genscoSQLProject1.Models
{
    public class FormNote
    {
        public int FormNoteId { get; set; } 
        public int BranchInspectionId { get; set; }  
        public string? SectionNote { get; set; }
        public int CreatedByUserId { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? generalNotes { get; set; }
        public int CategoryId { get; set; }

        // Navigation Properties
        public BranchInspection BranchInspection { get; set; }
        public Category Category { get; set; }
        public User CreatedByUser { get; set; }
    }
}
