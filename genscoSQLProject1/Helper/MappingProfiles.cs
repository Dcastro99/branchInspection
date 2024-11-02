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
            //CreateMap<FormCategory, FormCategoryDto>();
            //CreateMap<FormCategoryDto, FormCategory>();
            //CreateMap<FormItems, FormItemsDto>();
            //CreateMap<FormItemsDto, FormItems>();
            CreateMap<FormDto, BranchInspection>();
            CreateMap<BranchInspection, FormDto>();

            CreateMap<FormDto, BranchInspection>()
                .ForMember(dest => dest.ChecklistItems, opt => opt.MapFrom(src => src.Items)) // Map Items to ChecklistItems
                .ForMember(dest => dest.Assets, opt => opt.MapFrom(src => src.Assets)) // Map Assets correctly
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Category)); // If Category exists in BranchInspection

            CreateMap<BranchInspection, FormDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ChecklistItems)) // Map ChecklistItems to Items
                .ForMember(dest => dest.Assets, opt => opt.MapFrom(src => src.Assets)) // Map FormAssets to Assets
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Categories)); // If Category exists in FormDto



        }
    }
}
