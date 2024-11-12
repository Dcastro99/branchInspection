using genscoSQLProject1.Models;

public class ChecklistItemBuilder
{
    private readonly ChecklistItem _checklistItem;

    public ChecklistItemBuilder(string name, int categoryId)
    {
        _checklistItem = new ChecklistItem
        {
            Name = name,
            CategoryId = categoryId
        };
    }

   
    public ChecklistItemBuilder SetIsCheckedNeeded(bool value)
    {
        _checklistItem.IsCheckedNeeded = value;
        return this;
    }
    public ChecklistItemBuilder SetNotApplicableNeeded(bool value)
    {
        _checklistItem.NotApplicableNeeded = value;
        return this;
    }
    public ChecklistItemBuilder SetloadCapacityNeeded(bool LoadCapacityNeeded)
    {
        _checklistItem.LoadCapacityNeeded = LoadCapacityNeeded;
        return this;
    }
    public ChecklistItemBuilder SetDateCartridgeNeeded(bool DateCartridgeNeeded)
    {
        _checklistItem.DateCartridgeNeeded = DateCartridgeNeeded;
        return this;
    }
    public ChecklistItemBuilder SetSafetyLastMeetingDateNeeded(bool SafetyLastMeetingDateNeeded)
    {
        _checklistItem.SafetyLastMeetingDateNeeded = SafetyLastMeetingDateNeeded;
        return this;
    }
    public ChecklistItemBuilder SetStatePosterDatePostedNeeded(bool StatePosterDatePostedNeeded)
    {
        _checklistItem.StatePosterDatePostedNeeded = StatePosterDatePostedNeeded;
        return this;
    }
    public ChecklistItemBuilder SetFireAlarmDateTestedNeeded(bool FireAlarmDateTestedNeeded)
    {
        _checklistItem.FireAlarmDateTestedNeeded = FireAlarmDateTestedNeeded;
        return this;
    }
    public ChecklistItemBuilder SetSprinklerSystemDateTestedNeeded(bool SprinklerSystemDateTestedNeeded)
    {
        _checklistItem.SprinklerSystemDateTestedNeeded = SprinklerSystemDateTestedNeeded;
        return this;
    }
    public ChecklistItemBuilder SetSecurityAlarmDateTestedNeeded(bool SecurityAlarmDateTestedNeeded)
    {
        _checklistItem.SecurityAlarmDateTestedNeeded = SecurityAlarmDateTestedNeeded;
        return this;
    }

    public ChecklistItemBuilder SetDotInspectionDateNeeded(bool DotInspectionDateNeeded)
    {
        _checklistItem.DotInspectionDateNeeded = DotInspectionDateNeeded;
        return this;
    }



    // Build method to retrieve the ChecklistItem object
    public ChecklistItem Build()
    {
        return _checklistItem;
    }
}
