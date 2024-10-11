using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IAssetItemsRepository
    {
        ICollection<AssetItems> GetAllAssetItems();
        AssetItems GetAssetItems(int assetItemsId);
        ICollection<AssetItems> GetAssetItemsByAsset(int assetId);
      
        bool AssetItemsExists(int assetItemsId);
        bool CreateAssetItems(AssetItems assetItems);
        bool UpdateAssetItems(AssetItems assetItems);
        bool DeleteAssetItems(AssetItems assetItems);
        bool Save();

    }
}
