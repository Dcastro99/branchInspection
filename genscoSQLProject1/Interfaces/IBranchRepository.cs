using genscoSQLProject1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace genscoSQLProject1.Interfaces
{
    public interface IBranchRepository
    {
        Task<ICollection<Branch>> GetAllBranchesAsync();
        Task<Branch> GetBranchAsync(int branchNumber);
        Task<bool> BranchExistsAsync(int branchId);
        Task<bool> CreateBranchAsync(Branch branch);
        Task<bool> UpdateBranchAsync(Branch branch);
        Task<bool> DeleteBranchAsync(Branch branch);
        Task<bool> SaveAsync();
    }
}
