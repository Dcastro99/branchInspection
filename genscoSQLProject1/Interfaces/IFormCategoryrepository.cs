using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IFormCategoryRepository
    {
        ICollection<FormCategory> GetAllFormCategories();
        FormCategory GetFormCategory(int formCategoryId);
        ICollection<FormCategory> GetFormCategoryByCategoryId(int categoryId);
        ICollection<Category> GetCategoryByFormCategory(int formCategoryId);
        bool FormCategoryExists(int formCategoryId);
        bool FormCategoriesExists(int categoryId, int branchInspectionId);
        bool CreateFormCategory(FormCategory formCategory);
        bool UpdateFormCategory(FormCategory formCategory);
        bool DeleteFormCategory(FormCategory formCategory);
        bool Save();


    }
}
