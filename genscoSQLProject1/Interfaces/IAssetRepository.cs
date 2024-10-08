using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IAssetRepository
    {
        ICollection<Asset> GetAssets();
        Asset GetAsset(int assetId);
        ICollection<Asset> GetAssetByBranch(int branchId);
        ICollection<Branch> GetBranchByAsset(int assetId);
        bool AssetExists(int assetId);
        bool CreateAsset(Asset asset);
        bool UpdateAsset(Asset asset);
        bool DeleteAsset(Asset asset);
        bool Save();



    }
}
