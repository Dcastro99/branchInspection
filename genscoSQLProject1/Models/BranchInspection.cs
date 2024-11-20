namespace genscoSQLProject1.Models
{
    public class BranchInspection
    {
        public int BranchInspectionId { get; set; }
        public  string? CompanyId { get; set; }
        public int BranchId { get; set; }
        public int? BranchNumber { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ApprovedByUserId { get; set; }
        public DateTime? RevisedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DateLastMaintained { get; set; }
        public  bool DeleteFlag { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool NeedsApproval { get; set; } = true;


        //-----------Navigation Properties-------------//
        public Branch Branch { get; set; }
        public User CreatedByUser { get; set; }  
        public User ApprovedByUser { get; set; }
        public ICollection<Asset> Assets { get; set; }
        public ICollection<ChecklistItem> ChecklistItems { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}

