using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace genscoSQLProject1.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.CategoryId == categoryId);
        }
        public async Task<bool> CategoriesExistsAsync(int categoryId, int branchInspectionId)
        {
            return _context.Categories.Any(f => f.CategoryId == categoryId && f.BranchInspectionId == branchInspectionId);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category cannot be null");

            await _context.Categories.AddAsync(category);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
                throw new InvalidOperationException("Failed to save category to the database.");

            return result > 0;
        }

        //public async Task<bool> CreateCategoryAsync(Category category)
        //{
        //    if (category == null)
        //        return false;

        //    await _context.Categories.AddAsync(category);
        //    return await SaveAsync();
        //}

        public async Task CreateCategoriesAsync(List<Category> categories)
        {
            await _context.Categories.AddRangeAsync(categories);
            await SaveAsync();
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            return await SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }


    }
}
