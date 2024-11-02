using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace genscoSQLProject1.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DataContext _context;

        public BranchRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> BranchExistsAsync(int branchNumber)
        {
            return await _context.Branches.AnyAsync(b => b.BranchNumber == branchNumber);
        }

        public async Task<bool> CreateBranchAsync(Branch branch)
        {
            await _context.AddAsync(branch);
            return await SaveAsync();
        }

        public async Task<bool> DeleteBranchAsync(Branch branch)
        {
            _context.Remove(branch);
            return await SaveAsync();
        }

        public async Task<Branch> GetBranchAsync(int branchNumber)
        {
            return await _context.Branches.FirstOrDefaultAsync(b => b.BranchNumber == branchNumber);
        }

        public async Task<ICollection<Branch>> GetAllBranchesAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<ICollection<Asset>> GetAssetsByBranchAsync(int branchId)
        {
            return await _context.Assets.Where(a => a.BranchId == branchId).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> UpdateBranchAsync(Branch branch)
        {
            _context.Update(branch);
            return await SaveAsync();
        }
    }
}
