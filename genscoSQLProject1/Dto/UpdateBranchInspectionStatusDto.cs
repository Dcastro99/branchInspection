namespace genscoSQLProject1.Dto
{
    public class UpdateBranchInspectionStatusDto

    {
        public int BranchInspectionId { get; set; }
        public bool IsApproved { get; set; } 
        public int? ApprovedByUserId { get; set; } 
        public DateTime? ApprovedDate { get; set; }
    }
}
