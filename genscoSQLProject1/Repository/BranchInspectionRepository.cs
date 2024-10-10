using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class BranchInspectionRepository : IBranchInspectionRepository
    {
        DataContext _context;
        public BranchInspectionRepository(DataContext context)
        {
            _context = context;
        }
        public bool BranchInspectionExists(int branchInspectionId)
        {
            return _context.BranchInspections.Any(bi => bi.BranchInspectionId == branchInspectionId);
        }

        public bool CreateBranchInspection(BranchInspection branchInspection)
        {
            _context.BranchInspections.Add(branchInspection);
            return Save();
        }

        public bool DeleteBranchInspection(BranchInspection branchInspection)
        {
            _context.BranchInspections.Remove(branchInspection);
            return Save();
        }

        public BranchInspection GetBranchInspection(int branchInspectionId)
        {
            return _context.BranchInspections.FirstOrDefault(bi => bi.BranchInspectionId == branchInspectionId);
        }

        public ICollection<BranchInspection> GetBranchInspectionByBranch(int BranchNumber)
        {
            return _context.BranchInspections.Where(bi => bi.BranchNumber == BranchNumber).ToList();
        }

        public ICollection<BranchInspection> GetAllBranchInspections()
        {
            return _context.BranchInspections.ToList();
        }

        public ICollection<BranchInspection> GetBranchInspectionsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.BranchInspections.Where(bi => bi.ApprovedDate >= startDate && bi.ApprovedDate <= endDate).ToList();
        }

        public ICollection<BranchInspection> GetBranchInspectionsByMonth(DateTime month)
        {
            return _context.BranchInspections.Where(bi => bi.ApprovedDate.Value.Month == month.Month).ToList();
        }

        public BranchInspection GetMostRecentBranchInspectionByBranch(int BranchNumber)
        {
            return _context.BranchInspections.Where(bi => bi.BranchNumber == BranchNumber).OrderByDescending(bi => bi.CreatedDate).FirstOrDefault();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateBranchInspection(BranchInspection branchInspection)
        {
            _context.BranchInspections.Update(branchInspection);
            return Save();
        }
    }
}
