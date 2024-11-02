
using System.ComponentModel.DataAnnotations.Schema;

namespace genscoSQLProject1.Models
{
    public class ChecklistItem
    {
        public int ChecklistItemId { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public int? BranchInspectionId { get; set; }
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

        
        //-------------------NOT MAPPED PROPERTIES-----------------//
       
        [NotMapped]
        public bool? IsCheckedNeeded { get; set; }
        [NotMapped]
        public bool? NotApplicableNeeded { get; set; }
        [NotMapped]
        public bool? LoadCapacityNeeded { get; set; }
        [NotMapped]
        public bool? DateCartridgeNeeded { get; set; }
        [NotMapped]
        public bool? SafetyLastMeetingDateNeeded { get; set; }
        [NotMapped]
        public bool? StatePosterDatePostedNeeded { get; set; }
        [NotMapped]
        public bool? FireAlarmDateTestedNeeded { get; set; }
        [NotMapped]
        public bool? SprinklerSystemDateTestedNeeded { get; set; }
        [NotMapped]
        public bool? SecurityAlarmDateTestedNeeded { get; set; }
        [NotMapped]
        public bool? DotInspectionDateNeeded { get; set; }


        //---------NAVIGATION PROPERTIES-----------//
      
        public Category Category { get; set; }
      
        public BranchInspection BranchInspection { get; set; }
        public Asset Assets { get; set; }

    }
}

   