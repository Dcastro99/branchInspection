namespace genscoSQLProject1.Models
{
    public class BranchInspection
    {
        public int BranchInspectionId { get; set; }
        public  string? CompanyId { get; set; }
        public int BranchId { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ApprovedByUserId { get; set; }
        public DateTime? RevisedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DateLastMaintained { get; set; }
        public  string? DeleteFlag { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }

        //-----------Navigation Properties-------------//
        public Branch Branch { get; set; }
        public ICollection<FormAssets> FormAssets { get; set; }
        public ICollection<FormItems> FormItems { get; set; }
        public ICollection<FormCategory> FormCategory { get; set; }

    }
}

