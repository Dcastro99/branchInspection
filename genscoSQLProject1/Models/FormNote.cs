namespace genscoSQLProject1.Models
{
    public class FormNote
    {
        public int FormNoteId { get; set; } 
        public int BranchInspectionId { get; set; }  
        public string Note { get; set; }
        public int CreatedByUserId { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public BranchInspection BranchInspection { get; set; }
        public User CreatedByUser { get; set; }
    }
}
