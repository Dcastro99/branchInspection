
using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace genscoSQLProject1.Repository
{
    public class BranchInspectionRepository : IBranchInspectionRepository
    {
        private readonly DataContext _context;

        public BranchInspectionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> BranchInspectionExistsAsync(int branchInspectionId)
        {
            return await _context.BranchInspections.AnyAsync(bi => bi.BranchInspectionId == branchInspectionId);
        }

        public async Task<bool> CreateBranchInspectionAsync(BranchInspection branchInspection)
        {
            await _context.BranchInspections.AddAsync(branchInspection);
            return await SaveAsync();
        }

        public async Task<bool> DeleteBranchInspectionAsync(BranchInspection branchInspection)
        {
            _context.BranchInspections.Remove(branchInspection);
            return await SaveAsync();
        }

        public async Task<BranchInspection> GetBranchInspectionAsync(int branchInspectionId)
        {
            return await _context.BranchInspections.FirstOrDefaultAsync(bi => bi.BranchInspectionId == branchInspectionId);
        }

        public async Task<ICollection<BranchInspection>> GetBranchInspectionByBranchAsync(int branchId)
        {
            return await _context.BranchInspections.Where(bi => bi.BranchId == branchId).ToListAsync();
        }

        public async Task<ICollection<BranchInspection>> GetAllBranchInspectionsAsync()
        {
            return await _context.BranchInspections.ToListAsync();
        }

        public async Task<ICollection<BranchInspection>> GetBranchInspectionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.BranchInspections
                .Where(bi => bi.ApprovedDate >= startDate && bi.ApprovedDate <= endDate)
                .ToListAsync();
        }

        public async Task<ICollection<BranchInspection>> GetBranchInspectionsByMonthAsync(DateTime month)
        {
            return await _context.BranchInspections
                .Where(bi => bi.ApprovedDate.Value.Month == month.Month)
                .ToListAsync();
        }

        public async Task<BranchInspection> GetMostRecentBranchInspectionByBranchAsync(int branchId)
        {
            return await _context.BranchInspections
                .Where(bi => bi.BranchId == branchId)
                .OrderByDescending(bi => bi.CreatedDate)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> UpdateBranchInspectionAsync(BranchInspection branchInspection)
        {
            _context.BranchInspections.Update(branchInspection);
            return await SaveAsync();
        }
    }
}
