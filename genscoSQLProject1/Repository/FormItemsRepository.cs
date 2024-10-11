using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class FormItemsRepository: IFormItemsRepository
    {
        DataContext _context;

        public FormItemsRepository(DataContext context)
        {
            _context = context;
        }

       

        public bool CreateFormItems(FormItems formItems)
        {
            _context.Add(formItems);
            return Save();
        }

        public bool DeleteFormItems(FormItems formItems)
        {
            _context.Remove(formItems);
            return Save();
        }

        public bool FormItemsExists(int formItemsId)
        {
            return _context.FormItems.Any(f => f.FormItemsId == formItemsId);
        }

        public ICollection<FormItems> GetAllFormItems()
        {
            return _context.FormItems.ToList();
        }

        public ICollection<BranchInspection> GetBranchInspectionByFormItems(int formItemsId)
        {
            return _context.BranchInspections.Where(b => b.FormItems.Any(f => f.FormItemsId == formItemsId)).ToList();
        }

        public FormItems GetFormItems(int formItemsId)
        {
            return _context.FormItems.Where(f => f.FormItemsId == formItemsId).FirstOrDefault();
        }

        public ICollection<FormItems> GetFormItemsByBranchInspectionId(int branchInspectionId)
        {
            return _context.FormItems.Where(f => f.BranchInspectionId == branchInspectionId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateFormItems(FormItems formItems)
        {
            _context.Update(formItems);
            return Save();
        }
    }
}
