using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChildRequestTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentRequestTemplateId",
                table: "RequestTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestTemplates_ParentRequestTemplateId",
                table: "RequestTemplates",
                column: "ParentRequestTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTemplates_RequestTemplates_ParentRequestTemplateId",
                table: "RequestTemplates",
                column: "ParentRequestTemplateId",
                principalTable: "RequestTemplates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTemplates_RequestTemplates_ParentRequestTemplateId",
                table: "RequestTemplates");

            migrationBuilder.DropIndex(
                name: "IX_RequestTemplates_ParentRequestTemplateId",
                table: "RequestTemplates");

            migrationBuilder.DropColumn(
                name: "ParentRequestTemplateId",
                table: "RequestTemplates");
        }
    }
}
