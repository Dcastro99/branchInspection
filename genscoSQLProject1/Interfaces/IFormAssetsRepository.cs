using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IFormAssetsRepository
    {
        ICollection<FormAssets> GetAllFormAssets();
        FormAssets GetFormAssets(int formAssetsId);
        ICollection<FormAssets> GetFormAssetsByAssetId(int assetId);
        ICollection<Asset> GetAssetByFormAssets(int formAssetsId);
        bool FormAssetsExists(int formAssetsId);
        bool CreateFormAssets(FormAssets formAssets);
        bool UpdateFormAssets(FormAssets formAssets);
        bool DeleteFormAssets(FormAssets formAssets);
        bool Save();
    }
}
