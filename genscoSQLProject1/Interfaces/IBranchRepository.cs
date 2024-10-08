using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IBranchRepository
    {
        ICollection<Branch> GetAllBranches();
        Branch GetBranch(int branchId);
        bool BranchExists(int branchId);
        bool CreateBranch(Branch branch);
        bool UpdateBranch(Branch branch);
        bool DeleteBranch(Branch branch);
        bool Save();
    }
}
