using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class AssetItemsRepository : IAssetItemsRepository
    {

        DataContext _context;

        public AssetItemsRepository(DataContext context)
        {
            _context = context;
        }

        public bool AssetItemsExists(int checklistItemId, int assetId, int branchInspectionId)
        {
            return _context.AssetItems.Any(a => a.ChecklistItemId == checklistItemId && a.AssetId == assetId && a.BranchInspectionId == branchInspectionId);

        }

        public bool CreateAssetItems(AssetItems assetItems)
        {
            _context.Add(assetItems);
            return Save();
        }

        public bool DeleteAssetItems(AssetItems assetItems)
        {
            var assetItem = _context.AssetItems
                .FirstOrDefault(ai => ai.ChecklistItemId == assetItems.ChecklistItemId && ai.AssetId == assetItems.AssetId && ai.BranchInspectionId == assetItems.BranchInspectionId);
            if (assetItem != null) {
                _context.AssetItems.Remove(assetItem);
                return Save();
            }
            return false;
        }

        public ICollection<AssetItems> GetAllAssetItems()
        {
            return _context.AssetItems.ToList();
        }

        public AssetItems GetAssetItems(int checklistItemId, int assetId, int branchInspectionId)
        {
            return _context.AssetItems.FirstOrDefault(ai => ai.ChecklistItemId == checklistItemId && ai.AssetId == assetId && ai.BranchInspectionId == branchInspectionId);
        }

        public ICollection<AssetItems> GetAssetItemsByAsset(int assetId)
        {
            return _context.AssetItems.Where(ai => ai.AssetId == assetId).ToList();
        }

        public ICollection<AssetItems> GetAssetItemsByBranchInspection(int branchInspectionId)
        {
            return _context.AssetItems.Where(ai => ai.BranchInspectionId == branchInspectionId).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0 ? true : false);
        }

        public bool UpdateAssetItems(AssetItems assetItems)
        {
            _context.Update(assetItems);
            return Save();
        }
    }
}
