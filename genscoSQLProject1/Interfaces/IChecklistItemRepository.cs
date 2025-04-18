﻿using System.Collections.Generic;
using System.Threading.Tasks;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface IChecklistItemRepository
    {
        Task<IEnumerable<ChecklistItem>> GetAllChecklistItemsAsync();
        Task<ChecklistItem?> GetByNameAndCategoryAsync(string name, int categoryId);
        Task<ChecklistItem?> GetChecklistItemAsync(int checklistItemId);
        Task<CategoryDto?> GetCategoryByChecklistItemIdAsync(int checklistItemId);
        Task<IEnumerable<ChecklistItem>> GetChecklistItemsByCategoryAsync(int categoryId);
        Task<bool> ChecklistItemExistsAsync(int checklistItemId);
        Task<bool> CreateChecklistItemAsync(ChecklistItem checklistItem);
        Task<bool> UpdateChecklistItemAsync(ChecklistItem checklistItem);
        Task<bool> DeleteChecklistItemAsync(ChecklistItem checklistItem);
        Task<bool> SaveAsync();
    }
}
