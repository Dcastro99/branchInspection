//using genscoSQLProject1.Data;
//using genscoSQLProject1.Interfaces;
//using genscoSQLProject1.Models;

//namespace genscoSQLProject1.Repository
//{
//    public class FormCategoryRepository: IFormCategoryRepository
//    {
//        DataContext _context;
//        public FormCategoryRepository(DataContext context)
//        {
//            _context = context;
//        }

//        public bool CreateFormCategory(FormCategory formCategory)
//        {
//            _context.Add(formCategory);
//            return Save();
//        }

//        public bool DeleteFormCategory(FormCategory formCategory)
//        {
//            _context.Remove(formCategory);
//            return Save();
//        }

//        public bool FormCategoryExists(int formCategoryId)
//        {
//            return _context.FormCategories.Any(f => f.FormCategoryId == formCategoryId);
//        }

//        public bool FormCategoriesExists(int categoryId, int branchInspectionId)
//        {
//            return _context.FormCategories.Any(f => f.CategoryId == categoryId && f.BranchInspectionId == branchInspectionId);
//        }

//        public ICollection<FormCategory> GetAllFormCategories()
//        {
//            return _context.FormCategories.ToList();
//        }

//        public ICollection<Category> GetCategoryByFormCategory(int formCategoryId)
//        {
//            return _context.Categories.Where(c => c.CategoryId == formCategoryId).ToList();
//        }

//        public FormCategory GetFormCategory(int formCategoryId)
//        {
//            return _context.FormCategories.Where(f => f.FormCategoryId == formCategoryId).FirstOrDefault();
//        }

//        public ICollection<FormCategory> GetFormCategoryByCategoryId(int categoryId)
//        {
//            return _context.FormCategories.Where(f => f.CategoryId == categoryId).ToList();
//        }

//        public bool Save()
//        {
//            return _context.SaveChanges() >= 0 ? true : false;
//        }

//        public bool UpdateFormCategory(FormCategory formCategory)
//        {
//            _context.Update(formCategory);
//            return true;
//        }
//    }
//}
