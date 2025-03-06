using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IFormCommentRepository
    {
        Task<bool> CreateFormCommentAsync(FormComment formComment);
        Task<bool> DeleteFormCommentAsync(FormComment formComment);
        Task<bool> FormCommentExistsAsync(int formCommentId);
        Task<IEnumerable<FormComment>> GetAllFormCommentsAsync();
        Task<FormComment?> GetFormCommentByIdAsync(int formCommentId);
        Task<IEnumerable<FormComment>> GetFormCommentsByBranchInspectionIdAsync(int branchInspectionId);
        Task<FormComment> GetFormCommentByBranchInspectionAndCategoryAsync(int branchInspectionId, int categoryId);
        Task<bool> UpdateFormCommentAsync(FormComment formComment);
        Task<bool> SaveAsync();
    }
}
