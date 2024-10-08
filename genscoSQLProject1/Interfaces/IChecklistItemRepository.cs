using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IChecklistItemRepository
    {
        ICollection<ChecklistItem> GetChecklistItems();
        ChecklistItem GetChecklistItem(int checklistItemId);
        ICollection<ChecklistItem> GetChecklistItemByCategory(int categoryId);
        ICollection<Category> GetCategoryByChecklistItem(int checklistItemId);
        bool ChecklistItemExists(int checklistItemId);
        bool CreateChecklistItem(ChecklistItem checklistItem);
        bool UpdateChecklistItem(ChecklistItem checklistItem);
        bool DeleteChecklistItem(ChecklistItem checklistItem);
        bool Save();
    }
}
