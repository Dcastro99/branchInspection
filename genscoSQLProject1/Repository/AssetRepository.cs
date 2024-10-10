using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class AssetRepository : IAssetRepository
    {
        DataContext _context;
        public AssetRepository(DataContext context)
        {
            _context = context;
        }
        public bool AssetExists(int assetId)
        {
            return _context.Assets.Any(a => a.AssetId == assetId);
        }

        public bool CreateAsset(Asset asset)
        {
            _context.Add(asset);
            return Save();
        }

        public bool DeleteAsset(Asset asset)
        {
            _context.Remove(asset);
            return Save();
        }

        public Asset GetAsset(int assetId)
        {
            return _context.Assets.Where(a => a.AssetId == assetId).FirstOrDefault();
        }

        public ICollection<Asset> GetAssetByBranch(int branchNumber)
        {
            return _context.Assets.Where(a => a.BranchNumber == branchNumber).ToList();
        }

        public ICollection<Asset> GetAllAssets()
        {
            return _context.Assets.ToList();
        }

        public ICollection<Branch> GetBranchByAsset(int assetId)
        {
            return _context.Branches.Where(b => b.Assets.Any(a => a.AssetId == assetId)).ToList();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateAsset(Asset asset)
        {
            _context.Update(asset);
            return Save();
        }
    }
}
