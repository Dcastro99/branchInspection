using genscoSQLProject1.Models;

namespace genscoSQLProject1.Dto
{
    public class ChecklistItemDto
    {
        public int ChecklistItemId { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }

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


    }
}
