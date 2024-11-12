using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IFormNoteRepository
    {
        Task<IEnumerable<FormNote>> GetAllFormNotesAsync(); 
        Task<FormNote?> GetFormNoteAsync(int formNoteId); 
        Task<IEnumerable<FormNote>> GetFormNotesByBranchInspectionIdAsync(int branchInspectionId);
        Task<bool> FormNoteExistsAsync(int formNoteId);
        Task<bool> CreateFormNoteAsync(FormNote formNote);
        Task<bool> UpdateFormNoteAsync(FormNote formNote);
        Task<bool> DeleteFormNoteAsync(FormNote formNote);
        Task<bool> SaveAsync();
    }
}
