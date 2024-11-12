using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAllCategoriesAsync(); 
        Task<Category> GetCategoryAsync(int categoryId); 
        Task<bool> CategoryExistsAsync(int categoryId);
        Task<bool> CategoriesExistsAsync(int categoryId, int branchInspectionId);
        Task<bool> CreateCategoryAsync(Category category); 
        Task CreateCategoriesAsync(List<Category> categories); 
        Task<bool> UpdateCategoryAsync(Category category); 
        Task<bool> DeleteCategoryAsync(Category category); 
        Task<bool> SaveAsync(); 
    }
}
