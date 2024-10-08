
using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    
    public class BranchRepository : IBranchRepository
    {
        DataContext _context;
        public BranchRepository(DataContext context)
        {
            _context = context;
        }
        public bool BranchExists(int branchId)
        {
            return _context.Branches.Any(b => b.BranchId == branchId);
        }

        public bool CreateBranch(Branch branch)
        {
            _context.Add(branch);
            return Save();
        }

        public bool DeleteBranch(Branch branch)
        {
            _context.Remove(branch);
            return Save();
        }

        public Branch GetBranch(int branchId)
        {
            return _context.Branches.Where(b => b.BranchId == branchId).FirstOrDefault();
        }

        public ICollection<Branch> GetBranches()
        {
            return _context.Branches.ToList();
        }

        public ICollection<Asset> GetAssetsByBranch(int branchId)
        {
            return _context.Assets.Where(a => a.BranchId == branchId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateBranch(Branch branch)
        {
            _context.Update(branch);
            return Save();
        }

        public ICollection<Branch> GetAllBranches()
        {
            return _context.Branches.ToList();
        }
    }
    
    
}
