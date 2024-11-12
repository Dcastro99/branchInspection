using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class AddFormNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedsApproval",
                table: "BranchInspections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "FormNotes",
                columns: table => new
                {
                    FormNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchInspectionId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormNotes", x => x.FormNoteId);
                    table.ForeignKey(
                        name: "FK_FormNotes_BranchInspections_BranchInspectionId",
                        column: x => x.BranchInspectionId,
                        principalTable: "BranchInspections",
                        principalColumn: "BranchInspectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormNotes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormNotes_BranchInspectionId",
                table: "FormNotes",
                column: "BranchInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormNotes_CreatedByUserId",
                table: "FormNotes",
                column: "CreatedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormNotes");

            migrationBuilder.DropColumn(
                name: "NeedsApproval",
                table: "BranchInspections");
        }
    }
}
