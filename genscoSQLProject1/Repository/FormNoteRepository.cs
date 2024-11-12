using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace genscoSQLProject1.Repository
{
    public class FormNoteRepository : IFormNoteRepository
    {
        private readonly DataContext _context;

        public FormNoteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateFormNoteAsync(FormNote formNote)
        {
            await _context.FormNotes.AddAsync(formNote);
            return await SaveAsync();
        }

        public async Task<bool> DeleteFormNoteAsync(FormNote formNote)
        {
            _context.FormNotes.Remove(formNote);
            return await SaveAsync();
        }

        public async Task<bool> FormNoteExistsAsync(int formNoteId)
        {
            return await _context.FormNotes.AnyAsync(fn => fn.FormNoteId == formNoteId);
        }

        public async Task<IEnumerable<FormNote>> GetAllFormNotesAsync()
        {
            return await _context.FormNotes.ToListAsync();
        }

        public async Task<FormNote?> GetFormNoteAsync(int formNoteId)
        {
            return await _context.FormNotes.FindAsync(formNoteId);
        }

        public async Task<IEnumerable<FormNote>> GetFormNotesByBranchInspectionIdAsync(int branchInspectionId)
        {
            return await _context.FormNotes
                                 .Where(fn => fn.BranchInspectionId == branchInspectionId)
                                 .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateFormNoteAsync(FormNote formNote)
        {
            _context.FormNotes.Update(formNote);
            return await SaveAsync();
        }
    }

}
