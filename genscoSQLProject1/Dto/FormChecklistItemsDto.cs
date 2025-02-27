namespace genscoSQLProject1.Dto
{
    public class FormChecklistItemsDto
    {
        public int FormChecklistItemId { get; set; }
        public int BranchInspectionId { get; set; }
        public int ChecklistItemId { get; set; }
        public int? AssetId { get; set; }
        public bool? IsChecked { get; set; }
        public DateTime? StatePosterDatePosted { get; set; }
        public DateTime? SafetyLastMeetingDate { get; set; }
        public DateTime? DateCartridgeInstalled { get; set; }
        public DateTime? FireAlarmDateTested { get; set; }
        public DateTime? SprinklerSystemDateTested { get; set; }
        public DateTime? SecurityAlarmDateTested { get; set; }
        public DateTime? DotInspectionDate { get; set; }
        public string? LoadCapacity { get; set; }
        public bool? NotApplicable { get; set; }
    }
}
