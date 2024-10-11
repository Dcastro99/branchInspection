using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class FormAssetsRepository: IFormAssetsRepository

    {
        DataContext _context;
        public FormAssetsRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateFormAssets(FormAssets formAssets)
        {
            _context.Add(formAssets);
            return Save();
        }

        public bool DeleteFormAssets(FormAssets formAssets)
        {
            _context.Remove(formAssets);
            return Save();
        }

        public bool FormAssetsExists(int formAssetsId)
        {
            return _context.FormAssets.Any(f => f.FormAssetsId == formAssetsId);
        }

        public ICollection<FormAssets> GetAllFormAssets()
        {
            return _context.FormAssets.ToList();
        }

        public ICollection<Asset> GetAssetsByBranchInspectionId(int branchInspectionId)
        {
            return _context.FormAssets
                .Where(fa => fa.BranchInspectionId == branchInspectionId)
                .Select(fa => fa.Assets)
                .SelectMany(a => a) 
                .ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateFormAssets(FormAssets formAssets)
        {
            _context.Update(formAssets);
            return Save();
        }
    }
}
