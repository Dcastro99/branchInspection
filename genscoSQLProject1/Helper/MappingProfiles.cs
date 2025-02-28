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
        CreateMap<RoleModel, RoleDto>();
        CreateMap<RoleDto, RoleModel>();
        CreateMap<BranchInspection, BranchInspectionDto>();
        CreateMap<BranchInspectionDto, BranchInspection>();
        CreateMap<BranchInspection, BranchInspectionDetailDto>()
          .ForMember(dest => dest.Assets, opt => opt.MapFrom(src => src.Assets))
          .ForMember(dest => dest.FormChecklistItems, opt => opt.MapFrom(src => src.FormChecklistItems));

        CreateMap<FormNote, FormNoteDto>();
        CreateMap<FormNoteDto, FormNote>();
        CreateMap<FormChecklistItems, FormChecklistItemsDto>();
        CreateMap<FormChecklistItemsDto, FormChecklistItems>()
        .ForMember(dest => dest.BranchInspectionId, opt => opt.MapFrom(src => src.BranchInspectionId));


        CreateMap<AssetDto, Asset>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.BranchId, opt => opt.Ignore()); // Ignore BranchId for now

        CreateMap<Asset, AssetDto>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.BranchNumber, opt => opt.MapFrom(src => src.BranchNumber));
        CreateMap<FormComment, FormCommentDto>();
        CreateMap<FormCommentDto, FormComment>();
    }
}
