using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAssetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Branches_BranchId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "BranchNumber",
                table: "Assets");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Assets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryId",
                table: "Assets",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Branches_BranchId",
                table: "Assets",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Categories_CategoryId",
                table: "Assets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Branches_BranchId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Categories_CategoryId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_CategoryId",
                table: "Assets");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchNumber",
                table: "Assets",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Branches_BranchId",
                table: "Assets",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
