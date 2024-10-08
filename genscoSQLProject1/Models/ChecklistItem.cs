namespace genscoSQLProject1.Models
{
    public class ChecklistItem
    {
        public int ChecklistItemId { get; set; }
        public  string Name { get; set; }
        public bool CheckedFlag { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime LastMeetingDate { get; set; }
        public DateTime DateCartridgeInstalled { get; set; }
        public  string LoadCapacity { get; set; }
        public bool NotApplicable { get; set; }

        public int CategoryId { get; set; }
        public  Category Category { get; set; }  // Navigation property

        public int AssetId { get; set; }
        public  Asset Asset { get; set; }  // Navigation property to Asset
    }
}
