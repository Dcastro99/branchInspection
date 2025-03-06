namespace genscoSQLProject1.Dto
{
    public class FormDto
    {
        public BranchInspectionDto BranchInspection { get; set; }
        public List<FormChecklistItemsDto> Items { get; set; }
        //public List<AssetDto>? Assets { get; set; }
        public List<FormCommentDto>? Comments { get; set; }
      

    }
}
