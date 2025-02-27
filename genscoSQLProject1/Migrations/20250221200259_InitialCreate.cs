using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistItems",
                columns: table => new
                {
                    ChecklistItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsCheckedNeeded = table.Column<bool>(type: "bit", nullable: true),
                    NotApplicableNeeded = table.Column<bool>(type: "bit", nullable: true),
                    LoadCapacityNeeded = table.Column<bool>(type: "bit", nullable: true),
                    DateCartridgeNeeded = table.Column<bool>(type: "bit", nullable: true),
                    SafetyLastMeetingDateNeeded = table.Column<bool>(type: "bit", nullable: true),
                    StatePosterDatePostedNeeded = table.Column<bool>(type: "bit", nullable: true),
                    FireAlarmDateTestedNeeded = table.Column<bool>(type: "bit", nullable: true),
                    SprinklerSystemDateTestedNeeded = table.Column<bool>(type: "bit", nullable: true),
                    SecurityAlarmDateTestedNeeded = table.Column<bool>(type: "bit", nullable: true),
                    DotInspectionDateNeeded = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistItems", x => x.ChecklistItemId);
                    table.ForeignKey(
                        name: "FK_ChecklistItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchNumber = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BranchInspectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "BranchInspections",
                columns: table => new
                {
                    BranchInspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchNumber = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    RevisedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastMaintained = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NeedsApproval = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchInspections", x => x.BranchInspectionId);
                    table.ForeignKey(
                        name: "FK_BranchInspections_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormChecklistItems",
                columns: table => new
                {
                    FormChecklistItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchInspectionId = table.Column<int>(type: "int", nullable: false),
                    ChecklistItemId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: true),
                    StatePosterDatePosted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SafetyLastMeetingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCartridgeInstalled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FireAlarmDateTested = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SprinklerSystemDateTested = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecurityAlarmDateTested = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DotInspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoadCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotApplicable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormChecklistItems", x => x.FormChecklistItemId);
                    table.ForeignKey(
                        name: "FK_FormChecklistItems_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId");
                    table.ForeignKey(
                        name: "FK_FormChecklistItems_BranchInspections_BranchInspectionId",
                        column: x => x.BranchInspectionId,
                        principalTable: "BranchInspections",
                        principalColumn: "BranchInspectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormChecklistItems_ChecklistItems_ChecklistItemId",
                        column: x => x.ChecklistItemId,
                        principalTable: "ChecklistItems",
                        principalColumn: "ChecklistItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormComments",
                columns: table => new
                {
                    FormCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchInspectionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormComments", x => x.FormCommentId);
                    table.ForeignKey(
                        name: "FK_FormComments_BranchInspections_BranchInspectionId",
                        column: x => x.BranchInspectionId,
                        principalTable: "BranchInspections",
                        principalColumn: "BranchInspectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormComments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormNotes",
                columns: table => new
                {
                    FormNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchInspectionId = table.Column<int>(type: "int", nullable: false),
                    SectionNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    generalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_FormNotes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastMaintained = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultLocationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveInd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_BranchId",
                table: "Assets",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_BranchInspectionId",
                table: "Assets",
                column: "BranchInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchInspections_BranchId",
                table: "BranchInspections",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchInspections_CreatedByUserId",
                table: "BranchInspections",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistItems_CategoryId",
                table: "ChecklistItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FormChecklistItems_AssetId",
                table: "FormChecklistItems",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_FormChecklistItems_BranchInspectionId",
                table: "FormChecklistItems",
                column: "BranchInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormChecklistItems_ChecklistItemId",
                table: "FormChecklistItems",
                column: "ChecklistItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FormComments_BranchInspectionId",
                table: "FormComments",
                column: "BranchInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormComments_CategoryId",
                table: "FormComments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FormNotes_BranchInspectionId",
                table: "FormNotes",
                column: "BranchInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormNotes_CategoryId",
                table: "FormNotes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FormNotes_CreatedByUserId",
                table: "FormNotes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedByUserId",
                table: "Roles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_BranchInspections_BranchInspectionId",
                table: "Assets",
                column: "BranchInspectionId",
                principalTable: "BranchInspections",
                principalColumn: "BranchInspectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchInspections_Users_CreatedByUserId",
                table: "BranchInspections",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormNotes_Users_CreatedByUserId",
                table: "FormNotes",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedByUserId",
                table: "Roles",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatedByUserId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "FormChecklistItems");

            migrationBuilder.DropTable(
                name: "FormComments");

            migrationBuilder.DropTable(
                name: "FormNotes");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "ChecklistItems");

            migrationBuilder.DropTable(
                name: "BranchInspections");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
