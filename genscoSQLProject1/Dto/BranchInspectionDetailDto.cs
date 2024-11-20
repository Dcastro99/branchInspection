namespace genscoSQLProject1.Dto
{
    public class BranchInspectionDetailDto
    {
        public int BranchInspectionId { get; set; }
        public string? CompanyId { get; set; }
        public int BranchId { get; set; }
        public int? BranchNumber { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ApprovedByUserId { get; set; }
        public DateTime? RevisedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool NeedsApproval { get; set; }

        // Related entities
        public ICollection<AssetDto> Assets { get; set; }
        public ICollection<ChecklistItemDto> ChecklistItems { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
    }
}
