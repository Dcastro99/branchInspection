using System.Threading.Tasks;
using System.Collections.Generic;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IBranchInspectionRepository
    {
        Task<ICollection<BranchInspection>> GetAllBranchInspectionsAsync();
        Task<IEnumerable<BranchInspection>> GetBranchInspectionsNeedingApprovalAsync();
        Task<BranchInspection?> GetBranchInspectionWithDetailsAsync(int branchInspectionId);
        Task<BranchInspection> GetBranchInspectionAsync(int branchInspectionId);
        Task<ICollection<BranchInspection>> GetBranchInspectionByBranchAsync(int branchNumber);
        Task<ICollection<BranchInspection>> GetBranchInspectionsByMonthAsync(DateTime month);
        Task<ICollection<BranchInspection>> GetBranchInspectionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<BranchInspection> GetMostRecentBranchInspectionByBranchAsync(int branchNumber);
        Task<bool> BranchInspectionExistsAsync(int branchInspectionId);
        Task<bool> CreateBranchInspectionAsync(BranchInspection branchInspection);
        Task<bool> UpdateBranchInspectionAsync(BranchInspection branchInspection);
        Task<bool> DeleteBranchInspectionAsync(BranchInspection branchInspection);
        Task<bool> SaveAsync();
    }
}
