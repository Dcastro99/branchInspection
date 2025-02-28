

using System.ComponentModel.DataAnnotations.Schema;

namespace genscoSQLProject1.Models
{
    public class ChecklistItem
    {
        public int ChecklistItemId { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        //public int? CatRefId { get; set; }
        //public int? BranchInspectionId { get; set; }
        //public int? AssetId { get; set; }
        //public bool? IsChecked { get; set; }
        //public DateTime? StatePosterDatePosted { get; set; }
        //public DateTime? SafetyLastMeetingDate { get; set; }
        //public DateTime? DateCartridgeInstalled { get; set; }
        //public DateTime? FireAlarmDateTested { get; set; }
        //public DateTime? SprinklerSystemDateTested { get; set; }
        //public DateTime? SecurityAlarmDateTested { get; set; }
        //public DateTime? DotInspectionDate { get; set; }
        //public string? LoadCapacity { get; set; }
        //public bool? NotApplicable { get; set; }


        //-----------------FRONTEND PROERTIES-----------------//

        public bool? IsCheckedNeeded { get; set; }
        
        public bool? NotApplicableNeeded { get; set; }
        
        public bool? LoadCapacityNeeded { get; set; }
        
        public bool? DateCartridgeNeeded { get; set; }
        
        public bool? SafetyLastMeetingDateNeeded { get; set; }
        
        public bool? StatePosterDatePostedNeeded { get; set; }
        
        public bool? FireAlarmDateTestedNeeded { get; set; }
        
        public bool? SprinklerSystemDateTestedNeeded { get; set; }
        
        public bool? SecurityAlarmDateTestedNeeded { get; set; }
        
        public bool? DotInspectionDateNeeded { get; set; }


        //---------NAVIGATION PROPERTIES-----------//

        public Category Category { get; set; }
        //public BranchInspection BranchInspection { get; set; }
        //public Asset Assets { get; set; }

        public ICollection<FormChecklistItems> FormChecklistItems { get; set; } = new List<FormChecklistItems>();
    }

}

