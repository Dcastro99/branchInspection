

using System.ComponentModel.DataAnnotations.Schema;

namespace genscoSQLProject1.Models
{
    public class ChecklistItem
    {
        public int ChecklistItemId { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }

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
        public ICollection<FormChecklistItems> FormChecklistItems { get; set; } = new List<FormChecklistItems>();
    }

}

