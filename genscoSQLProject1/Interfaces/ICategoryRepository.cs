using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetAllCategories();
        Category GetCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
