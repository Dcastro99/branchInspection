using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace genscoSQLProject1.Repository
{
    public class FormChecklistItemRepository : IFormChecklistItemsRepository

    {
        DataContext _context;

        public FormChecklistItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateFormChecklistItemAsync(FormChecklistItems formChecklistItem)
        {
            if (formChecklistItem == null)
                throw new ArgumentNullException(nameof(formChecklistItem), "Checklist item cannot be null");

            _context.FormChecklistItems.Add(formChecklistItem);
            return await SaveAsync();
        }

        public async Task<bool> DeleteFormChecklistItemAsync(FormChecklistItems formChecklistItem)
        {
            _context.FormChecklistItems.Remove(formChecklistItem);
            return await SaveAsync();
        }

        public async Task<bool> FormChecklistItemExistsAsync(int formChecklistItemId)
        {
            return await _context.FormChecklistItems.AnyAsync(c => c.FormChecklistItemId == formChecklistItemId);
        }

        public async Task<IEnumerable<FormChecklistItems>> GetAllFormChecklistItemsAsync()
        {
            return await _context.FormChecklistItems.ToListAsync();
        }


        public async Task<FormChecklistItems?> GetFormChecklistItemAsync(int formChecklistItemId)
        {
            return await _context.FormChecklistItems.FirstOrDefaultAsync(c => c.FormChecklistItemId == formChecklistItemId);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> UpdateFormChecklistItemAsync(FormChecklistItems formChecklistItem)
        {
            _context.FormChecklistItems.Update(formChecklistItem);
            return await SaveAsync();
        }
    }
}
