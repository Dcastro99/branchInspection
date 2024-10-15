namespace genscoSQLProject1.Dto
{
    public class BranchInspectionDto
    {
        public int BranchInspectionId { get; set; }
        public string? CompanyId { get; set; }
        public int BranchId { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ApprovedByUserId { get; set; }
        public DateTime? RevisedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DateLastMaintained { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
