using AutoMapper;
using genscoSQLProject1.Dto;
using genscoSQLProject1.Models;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        CreateMap<ChecklistItem, ChecklistItemDto>();
        CreateMap<ChecklistItemDto, ChecklistItem>();
        //CreateMap<ChecklistItem, ChecklistItemDto>()
        //.ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.ItemType));

        //CreateMap<ChecklistItemDto, ChecklistItem>()
        //.ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.ItemType));

        CreateMap<Branch, BranchDto>();
        CreateMap<BranchDto, Branch>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<BranchInspection, BranchInspectionDto>();
        CreateMap<BranchInspectionDto, BranchInspection>();
        CreateMap<BranchInspection, BranchInspectionDetailDto>()
          .ForMember(dest => dest.Assets, opt => opt.MapFrom(src => src.Assets))
          .ForMember(dest => dest.ChecklistItems, opt => opt.MapFrom(src => src.ChecklistItems))
          .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));

        CreateMap<FormNote, FormNoteDto>();
        CreateMap<FormNoteDto, FormNote>();

        CreateMap<AssetDto, Asset>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.BranchId, opt => opt.Ignore()); // Ignore BranchId for now

        CreateMap<Asset, AssetDto>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.BranchNumber, opt => opt.MapFrom(src => src.BranchNumber));
    }
}
