using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BranchInspections_BranchInspectionId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistItems_Categories_CategoryId",
                table: "ChecklistItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BranchInspections_BranchInspectionId",
                table: "Categories",
                column: "BranchInspectionId",
                principalTable: "BranchInspections",
                principalColumn: "BranchInspectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistItems_Categories_CategoryId",
                table: "ChecklistItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BranchInspections_BranchInspectionId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistItems_Categories_CategoryId",
                table: "ChecklistItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BranchInspections_BranchInspectionId",
                table: "Categories",
                column: "BranchInspectionId",
                principalTable: "BranchInspections",
                principalColumn: "BranchInspectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistItems_Categories_CategoryId",
                table: "ChecklistItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
