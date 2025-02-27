using genscoSQLProject1.Data;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;


namespace genscoSQLProject1.Repository
{
    public class ChecklistItemRepository : IChecklistItemRepository
    {
        DataContext _context;

        public ChecklistItemRepository(DataContext context)
        {
            _context = context;
        }
       

        public async Task<bool> ChecklistItemExistsAsync(int checklistItemId)
        {
            return await _context.ChecklistItems.AnyAsync(c => c.ChecklistItemId == checklistItemId);
        }

        public async Task<bool> CreateChecklistItemAsync(ChecklistItem checklistItem)
        {
            if (checklistItem == null)
                throw new ArgumentNullException(nameof(checklistItem), "Checklist item cannot be null");

            _context.ChecklistItems.Add(checklistItem); 
            return await SaveAsync(); 
        }


        public async Task<bool> DeleteChecklistItemAsync(ChecklistItem checklistItem)
        {
            _context.ChecklistItems.Remove(checklistItem);
            return await SaveAsync();
        }

        public async Task<IEnumerable<ChecklistItem>> GetAllChecklistItemsAsync()
        {
            return await _context.ChecklistItems.ToListAsync();
        }

        public async Task<ChecklistItem?> GetChecklistItemAsync(int checklistItemId)
        {
            return await _context.ChecklistItems.FirstOrDefaultAsync(c => c.ChecklistItemId == checklistItemId);
        }

        public async Task<IEnumerable<ChecklistItem>> GetChecklistItemsByCategoryAsync(int categoryId)
        {
            return await _context.ChecklistItems.Where(c => c.CategoryId == categoryId).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> UpdateChecklistItemAsync(ChecklistItem checklistItem)
        {
            _context.ChecklistItems.Update(checklistItem);
            return await SaveAsync();
        }

        public async Task<ChecklistItem?> GetByNameAndCategoryAsync(string name, int categoryId)
        {
            return await _context.ChecklistItems
                .FirstOrDefaultAsync(c => c.Name.ToUpper() == name.ToUpper() && c.CategoryId == categoryId);
        }


        public async Task<CategoryDto?> GetCategoryByChecklistItemIdAsync(int checklistItemId)
        {
            return await _context.ChecklistItems
                .Where(c => c.ChecklistItemId == checklistItemId)
                .Select(c => new CategoryDto
                {
                    CategoryId = c.Category.CategoryId,
                    CategoryName = c.Category.CategoryName
                })
                .FirstOrDefaultAsync();
        }



    }
}
