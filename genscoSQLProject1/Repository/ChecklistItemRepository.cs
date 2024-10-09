using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class ChecklistItemRepository : IChecklistItemRepository
    {
        DataContext _context;

        public ChecklistItemRepository(DataContext context)
        {
            _context = context;
        }
        public bool ChecklistItemExists(int checklistItemId)
        {
            return _context.ChecklistItems.Any(c => c.ChecklistItemId == checklistItemId);
        }

        public bool CreateChecklistItem(ChecklistItem checklistItem)
        {
            if (checklistItem == null)
                return false;

            _context.ChecklistItems.Add(checklistItem);
            return Save();
        }

        public bool DeleteChecklistItem(ChecklistItem checklistItem)
        {
            _context.ChecklistItems.Remove(checklistItem);
            return Save();
        }

        public ICollection<ChecklistItem> GetAllChecklistItems()
        {
            return _context.ChecklistItems.ToList();
        }


        public ChecklistItem GetChecklistItem(int checklistItemId)
        {
            return _context.ChecklistItems.FirstOrDefault(c => c.ChecklistItemId == checklistItemId);
        }

        public ICollection<ChecklistItem> GetChecklistItemByCategory(int categoryId)
        {
            return _context.ChecklistItems.Where(c => c.CategoryId == categoryId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateChecklistItem(ChecklistItem checklistItem)
        {
            _context.ChecklistItems.Update(checklistItem);
            return Save();
        }
    }
}
