using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IFormAssetsRepository
    {
        ICollection<FormAssets> GetAllFormAssets();
        ICollection<Asset> GetAssetsByBranchInspectionId(int branchInspectionId);
        bool FormAssetsExists(int formAssetsId);
        bool CreateFormAssets(FormAssets formAssets);
        bool UpdateFormAssets(FormAssets formAssets);
        bool DeleteFormAssets(FormAssets formAssets);
        bool Save();
    }
}
