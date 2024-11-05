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
        CreateMap<Branch, BranchDto>();
        CreateMap<BranchDto, Branch>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<BranchInspection, BranchInspectionDto>();
        CreateMap<BranchInspectionDto, BranchInspection>();

        CreateMap<AssetDto, Asset>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.BranchId, opt => opt.Ignore()); // Ignore BranchId for now

        CreateMap<Asset, AssetDto>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.BranchNumber, opt => opt.MapFrom(src => src.Branch.BranchNumber));
    }
}
