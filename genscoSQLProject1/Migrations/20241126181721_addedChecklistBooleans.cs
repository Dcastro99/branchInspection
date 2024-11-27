using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class addedChecklistBooleans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DateCartridgeNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DotInspectionDateNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FireAlarmDateTestedNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LoadCapacityNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotApplicableNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafetyLastMeetingDateNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SecurityAlarmDateTestedNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SprinklerSystemDateTestedNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StatePosterDatePostedNeeded",
                table: "ChecklistItems",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCartridgeNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "DotInspectionDateNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "FireAlarmDateTestedNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "IsCheckedNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "LoadCapacityNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "NotApplicableNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "SafetyLastMeetingDateNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "SecurityAlarmDateTestedNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "SprinklerSystemDateTestedNeeded",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "StatePosterDatePostedNeeded",
                table: "ChecklistItems");
        }
    }
}
