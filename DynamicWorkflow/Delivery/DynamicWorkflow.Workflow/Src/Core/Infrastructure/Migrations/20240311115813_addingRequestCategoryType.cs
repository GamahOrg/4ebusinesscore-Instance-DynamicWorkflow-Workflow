using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingRequestCategoryType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RequestCategoryTypeId",
                table: "RequestTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RequestCategoryType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCategoryType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestCategoryType_RequestCategories_RequestCategoryId",
                        column: x => x.RequestCategoryId,
                        principalTable: "RequestCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestTemplates_RequestCategoryTypeId",
                table: "RequestTemplates",
                column: "RequestCategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCategoryType_RequestCategoryId",
                table: "RequestCategoryType",
                column: "RequestCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTemplates_RequestCategoryType_RequestCategoryTypeId",
                table: "RequestTemplates",
                column: "RequestCategoryTypeId",
                principalTable: "RequestCategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTemplates_RequestCategoryType_RequestCategoryTypeId",
                table: "RequestTemplates");

            migrationBuilder.DropTable(
                name: "RequestCategoryType");

            migrationBuilder.DropIndex(
                name: "IX_RequestTemplates_RequestCategoryTypeId",
                table: "RequestTemplates");

            migrationBuilder.DropColumn(
                name: "RequestCategoryTypeId",
                table: "RequestTemplates");
        }
    }
}
