using genscoSQLProject1.Controllers;
using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace genscoSQLProject1.Repository
{
    public class FormNoteRepository : IFormNoteRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<FormNoteRepository> _logger;

        public FormNoteRepository(DataContext context, ILogger<FormNoteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateFormNoteAsync(FormNote formNote)
        {
            if (string.IsNullOrWhiteSpace(formNote.SectionNote) && string.IsNullOrWhiteSpace(formNote.generalNotes))
            {
                _logger.LogWarning("Attempted to create a FormNote with empty SectionNote and GeneralNotes.");
                return false;
            }

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

        public async Task<FormNote?> GetFormNoteByIdAsync(int formNoteId)
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
            // Check if the entity is detached
            if (_context.Entry(formNote).State == EntityState.Detached)
            {
                // Re-attach the entity
                _context.FormNotes.Attach(formNote);
            }

            _context.FormNotes.Update(formNote);  // Update the entity
            return await SaveAsync();  // Save changes
        }

        public async Task<FormNote> GetFormNoteByBranchInspectionAndCategoryAsync(int branchInspectionId, int categoryId)
        {
            return await _context.FormNotes
                .FirstOrDefaultAsync(fn => fn.BranchInspectionId == branchInspectionId && fn.CategoryId == categoryId);
        }

    }

}
