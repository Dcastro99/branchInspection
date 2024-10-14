using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ChecklistItem, ChecklistItemDto>();
            CreateMap<ChecklistItemDto, ChecklistItem>();
            CreateMap<Asset, AssetDto>();
            CreateMap<AssetDto, Asset>();
            CreateMap<Branch, BranchDto>();
            CreateMap<BranchDto, Branch>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<BranchInspection, BranchInspectionDto>();
            CreateMap<BranchInspectionDto, BranchInspection>();
            //CreateMap<AssetItems, AssetItemsDto>();
            //CreateMap<AssetItemsDto, AssetItems>();
            //CreateMap<FormAssets, FormAssetsDto>();
            //CreateMap<FormAssetsDto, FormAssets>();
            CreateMap<FormCategory, FormCategoryDto>();
            CreateMap<FormCategoryDto, FormCategory>();

        }
    }
}
