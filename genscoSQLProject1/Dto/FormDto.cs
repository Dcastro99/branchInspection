namespace genscoSQLProject1.Dto
{
    public class FormDto
    {
        public BranchInspectionDto BranchInspection { get; set; }
        public List<FormItemsDto> FormItems { get; set; }
        public List<FormAssetsDto> FormAssets { get; set; }
    }
}
