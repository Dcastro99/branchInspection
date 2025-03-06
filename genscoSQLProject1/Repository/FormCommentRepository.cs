using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;


namespace genscoSQLProject1.Repository
{
    public class FormCommentRepository : IFormCommentRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<FormCommentRepository> _logger;

        public FormCommentRepository(DataContext context, ILogger<FormCommentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateFormCommentAsync(FormComment formComment)
        {
            if (string.IsNullOrWhiteSpace(formComment.Comment) && formComment.CategoryId == 0)
            {
                _logger.LogWarning("Attempted to create a FormComment with empty Comment and CategoryId.");
                return false;
            }

            await _context.FormComments.AddAsync(formComment);
            return await SaveAsync();
        }

        public async Task<bool> DeleteFormCommentAsync(FormComment formComment)
        {
           _context.FormComments.Remove(formComment);
            return await SaveAsync();
        }

        public async Task<bool> FormCommentExistsAsync(int formCommentId)
        {
            return await _context.FormComments.AnyAsync(fc => fc.FormCommentId == formCommentId);
        }

        public async Task<IEnumerable<FormComment>> GetAllFormCommentsAsync()
        {
            return await _context.FormComments.ToListAsync();
        }

        public async Task<FormComment?> GetFormCommentByIdAsync(int formCommentId)
        {
            return await _context.FormComments.FindAsync(formCommentId);
        }

        public async Task<IEnumerable<FormComment>> GetFormCommentsByBranchInspectionIdAsync(int branchInspectionId)
        {
            return await _context.FormComments
                                 .Where(fc => fc.BranchInspectionId == branchInspectionId)
                                 .ToListAsync();
        }
        public async Task<FormComment> GetFormCommentByBranchInspectionAndCategoryAsync(int branchInspectionId, int categoryId)
        {
            return await _context.FormComments
                .FirstOrDefaultAsync(fn => fn.BranchInspectionId == branchInspectionId && fn.CategoryId == categoryId);
        }
        public async Task<bool> UpdateFormCommentAsync(FormComment formComment)
        {
            // Check if the entity is detached
            if (_context.Entry(formComment).State == EntityState.Detached)
            {
                // Re-attach the entity
                _context.FormComments.Attach(formComment);
            }

            _context.FormComments.Update(formComment);  // Update the entity
            return await SaveAsync();  // Save changes
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
