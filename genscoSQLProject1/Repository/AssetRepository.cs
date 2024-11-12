using Microsoft.EntityFrameworkCore;
using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly DataContext _context;

        public AssetRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AssetExistsAsync(int assetId)
        {
            return await _context.Assets.AnyAsync(a => a.AssetId == assetId);
        }

        public async Task<bool> CreateAssetAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
            return await _context.SaveChangesAsync() > 0; 
        }


        public async Task<bool> DeleteAssetAsync(Asset asset)
        {
            _context.Remove(asset);
            return await SaveAsync();
        }

        public async Task<Asset> GetAssetAsync(int assetId)
        {
            return await _context.Assets.FirstOrDefaultAsync(a => a.AssetId == assetId);
        }

        public async Task<ICollection<Asset>> GetAssetByBranchAsync(int branchNumber)
        {
            return await _context.Assets.Where(a => a.BranchNumber == branchNumber).ToListAsync();
        }

        public async Task<ICollection<Asset>> GetAllAssetsAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<ICollection<Branch>> GetBranchByAssetAsync(int assetId)
        {
            return await _context.Branches
                .Where(b => b.Assets.Any(a => a.AssetId == assetId))
                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved >= 0;
        }

        public async Task<bool> UpdateAssetAsync(Asset asset)
        {
            _context.Update(asset);
            return await SaveAsync();
        }
    }
}
