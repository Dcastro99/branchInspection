//using genscoSQLProject1.Data;
//using genscoSQLProject1.Interfaces;
//using genscoSQLProject1.Models;

//namespace genscoSQLProject1.Repository
//{
//    public class FormAssetsRepository : IFormAssetsRepository

//    {
//        DataContext _context;
//        public FormAssetsRepository(DataContext context)
//        {
//            _context = context;
//        }

//        public bool CreateFormAssets(FormAssets formAssets)
//        {
//            _context.Add(formAssets);
//            return Save();
//        }

//        public bool DeleteFormAssets(int branchInspectionId, int assetId)
//        {
//           var formAssets = _context.FormAssets
//            .FirstOrDefault(fa => fa.BranchInspectionId == branchInspectionId && fa.AssetId == assetId);

//           if (formAssets != null)
//           {
//            _context.FormAssets.Remove(formAssets);
//              return Save();
//           }
//              return false;
//        }

//        public bool FormAssetsExists(int branchInspectionId, int assetId)
//        {
//            return _context.FormAssets.Any(f => f.BranchInspectionId == branchInspectionId && f.AssetId == assetId);
//        }

//        public ICollection<FormAssets> GetAllFormAssets()
//        {
//            return _context.FormAssets.ToList();
//        }

//        public ICollection<Asset> GetAssetsByBranchInspectionId(int branchInspectionId)
//        {
//            return _context.FormAssets.Where(f => f.BranchInspectionId == branchInspectionId).Select(a => a.Assets).ToList();
//        }

//        public bool Save()
//        {
//            return (_context.SaveChanges() >= 0 ? true : false);
//        }

//        public bool UpdateFormAssets(FormAssets formAssets)
//        {
//            _context.Update(formAssets);
//            return Save();
//        }
//    }
//}
