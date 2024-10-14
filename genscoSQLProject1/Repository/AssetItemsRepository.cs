//using genscoSQLProject1.Data;
//using genscoSQLProject1.Interfaces;
//using genscoSQLProject1.Models;

//namespace genscoSQLProject1.Repository
//{
//    public class AssetItemsRepository : IAssetItemsRepository
//    {

//        DataContext _context;

//        public AssetItemsRepository(DataContext context)
//        {
//            _context = context;
//        }
//        public bool AssetItemsExists(int assetItemsId)
//        {
//            return _context.AssetItems.Any(a => a.AssetItemsId == assetItemsId);
//        }

//        public bool CreateAssetItems(AssetItems assetItems)
//        {
//            _context.AssetItems.Add(assetItems);
//            return Save();
//        }

//        public bool DeleteAssetItems(AssetItems assetItems)
//        {
//            _context.AssetItems.Remove(assetItems);
//            return Save();
//        }

//        public ICollection<AssetItems> GetAllAssetItems()
//        {
//            return _context.AssetItems.ToList();
//        }

      
//        public AssetItems GetAssetItems(int assetItemsId)
//        {
//            return _context.AssetItems.Where(a => a.AssetItemsId == assetItemsId).FirstOrDefault();
//        }

//        public ICollection<AssetItems> GetAssetItemsByAsset(int assetId)
//        {
//            return _context.AssetItems.Where(a => a.FormAssetsId == assetId).ToList();
//        }

//        public bool Save()
//        {
//            return _context.SaveChanges() >= 0 ? true : false;
//        }

//        public bool UpdateAssetItems(AssetItems assetItems)
//        {
//            _context.AssetItems.Update(assetItems);
//            return Save();
//        }
//    }
//}
