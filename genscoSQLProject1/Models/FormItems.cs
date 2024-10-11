namespace genscoSQLProject1.Models
{
    public class FormItems
    {
        public int FormItemsId { get; set; }
        public int ChecklistItemId { get; set; }
        public int BranchInspectionId { get; set; }
        public bool? CheckedFlag { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? LastMeetingDate { get; set; }
        public DateTime? DateCartridgeInstalled { get; set; }
        public string? LoadCapacity { get; set; }
        public bool? NotApplicable { get; set; }

        //-----------Navigation Properties-------------//
        public ChecklistItem ChecklistItem { get; set; }  
        public BranchInspection BranchInspection { get; set; }  

    }
}
