namespace genscoSQLProject1.Models
{
    public class BranchInspection
    {
        public int branchInspectionId { get; set; }
        public string companyId { get; set; }
        public int branchId { get; set; }
        public int createdByUserId { get; set; }
        public int approvedByUserId { get; set; }
        public DateTime revisedDate { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime dateLastMaintained { get; set; }
        public string deleteFlag { get; set; }
        public DateTime submittedDate { get; set; }
        public DateTime approvedDate { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
