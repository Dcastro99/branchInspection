using System.Collections.Generic;
using System.Threading.Tasks;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IAssetRepository
    {
        Task<ICollection<Asset>> GetAllAssetsAsync(); 
        Task<Asset> GetAssetAsync(int assetId);
        Task<ICollection<Asset>> GetAssetByBranchAsync(int branchNumber);
        Task<ICollection<Branch>> GetBranchByAssetAsync(int assetId); 
        Task<bool> AssetExistsAsync(int assetId); 
        Task<bool> CreateAssetAsync(Asset asset); 
        Task<bool> UpdateAssetAsync(Asset asset); 
        Task<bool> DeleteAssetAsync(Asset asset); 
        Task<bool> SaveAsync(); 
    }
}
