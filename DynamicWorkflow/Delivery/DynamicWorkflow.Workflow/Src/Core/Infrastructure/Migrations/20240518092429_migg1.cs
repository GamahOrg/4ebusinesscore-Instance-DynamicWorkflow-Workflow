using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTemplates_RequestCategoryType_RequestCategoryTypeId",
                table: "RequestTemplates");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestCategoryTypeId",
                table: "RequestTemplates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "FromSeed",
                table: "RequestCategoryType",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FromSeed",
                table: "RequestCategories",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTemplates_RequestCategoryType_RequestCategoryTypeId",
                table: "RequestTemplates",
                column: "RequestCategoryTypeId",
                principalTable: "RequestCategoryType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTemplates_RequestCategoryType_RequestCategoryTypeId",
                table: "RequestTemplates");

            migrationBuilder.DropColumn(
                name: "FromSeed",
                table: "RequestCategoryType");

            migrationBuilder.DropColumn(
                name: "FromSeed",
                table: "RequestCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestCategoryTypeId",
                table: "RequestTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTemplates_RequestCategoryType_RequestCategoryTypeId",
                table: "RequestTemplates",
                column: "RequestCategoryTypeId",
                principalTable: "RequestCategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
