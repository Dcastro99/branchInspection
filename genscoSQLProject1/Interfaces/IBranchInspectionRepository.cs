using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IBranchInspectionRepository
    {
        ICollection<BranchInspection> GetBranchInspections();
        BranchInspection GetBranchInspection(int branchInspectionId);
        ICollection<BranchInspection> GetBranchInspectionByBranch(int branchId);
        ICollection<BranchInspection> GetBranchInspectionsByMonth(DateTime month);
        ICollection<BranchInspection> GetBranchInspectionsByDateRange(DateTime startDate, DateTime endDate);
        BranchInspection GetMostRecentBranchInspectionByBranch(int branchId);
        bool BranchInspectionExists(int branchInspectionId);
        bool CreateBranchInspection(BranchInspection branchInspection);
        bool UpdateBranchInspection(BranchInspection branchInspection);
        bool DeleteBranchInspection(BranchInspection branchInspection);
        bool Save();


    }
}
