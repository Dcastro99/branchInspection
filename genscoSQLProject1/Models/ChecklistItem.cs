namespace genscoSQLProject1.Models
{
    public class ChecklistItem
    {
        public int ChecklistItemId { get; set; }
        public string Name { get; set; }
        public bool? CheckedFlag { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? LastMeetingDate { get; set; }
        public DateTime? DateCartridgeInstalled { get; set; }
        public string? LoadCapacity { get; set; }
        public string? DotInspectionDate { get; set; }
        public bool? NotApplicable { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  // Navigation property
        public int? AssetId { get; set; }
        public Asset Asset { get; set; }  // Navigation property to Asset
        public ChecklistItemType ItemType { get; set; }
    }
}

    public enum ChecklistItemType
    {
        GeneralWarehouse, //0
        Forklift,//1
        OrderPicker,//2
        DeliveryVehicle,//3
        OtherEquipment //4
    }
