using System.Collections.Generic;
using System.Threading.Tasks;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IAssetRepository
    {
        Task<ICollection<Asset>> GetAllAssetsAsync(); // Updated to async
        Task<Asset> GetAssetAsync(int assetId); // Updated to async
        Task<ICollection<Asset>> GetAssetByBranchAsync(int branchNumber); // Updated to async
        Task<ICollection<Branch>> GetBranchByAssetAsync(int assetId); // Updated to async
        Task<bool> AssetExistsAsync(int assetId); // Updated to async
        Task<bool> CreateAssetAsync(Asset asset); // Updated to async
        Task<bool> UpdateAssetAsync(Asset asset); // Updated to async
        Task<bool> DeleteAssetAsync(Asset asset); // Updated to async
        Task<bool> SaveAsync(); // Updated to async
    }
}
