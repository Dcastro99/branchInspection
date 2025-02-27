using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IFormChecklistItemsRepository
    {
        Task<IEnumerable<FormChecklistItems>> GetAllFormChecklistItemsAsync();
        Task<FormChecklistItems?> GetFormChecklistItemAsync(int formChecklistItemId);
        Task<bool> FormChecklistItemExistsAsync(int formChecklistItemId);
        Task<bool> CreateFormChecklistItemAsync(FormChecklistItems formChecklistItem);
        Task<bool> UpdateFormChecklistItemAsync(FormChecklistItems formChecklistItem);
        Task<bool> DeleteFormChecklistItemAsync(FormChecklistItems formChecklistItem);
        Task<bool> SaveAsync();
    }
}
