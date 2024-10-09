using genscoSQLProject1.Models;

namespace genscoSQLProject1.Dto
{
    public class ChecklistItemDto
    {
        public int ChecklistItemId { get; set; }
        public string Name { get; set; }
        public bool? CheckedFlag { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? LastMeetingDate { get; set; }
        public DateTime? DateCartridgeInstalled { get; set; }
        public string? LoadCapacity { get; set; }
        public bool? NotApplicable { get; set; }
        public int CategoryId { get; set; }
        public int? AssetId { get; set; }
        public ChecklistItemType ItemType { get; set; }
    }
}
