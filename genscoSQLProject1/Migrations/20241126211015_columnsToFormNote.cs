using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class columnsToFormNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "FormNotes",
                newName: "SectionNote");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FormNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "generalNotes",
                table: "FormNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormNotes_CategoryId",
                table: "FormNotes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormNotes_Categories_CategoryId",
                table: "FormNotes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormNotes_Categories_CategoryId",
                table: "FormNotes");

            migrationBuilder.DropIndex(
                name: "IX_FormNotes_CategoryId",
                table: "FormNotes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FormNotes");

            migrationBuilder.DropColumn(
                name: "generalNotes",
                table: "FormNotes");

            migrationBuilder.RenameColumn(
                name: "SectionNote",
                table: "FormNotes",
                newName: "Note");
        }
    }
}
