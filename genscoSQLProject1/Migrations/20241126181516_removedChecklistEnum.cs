using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class removedChecklistEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "ChecklistItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "ChecklistItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
