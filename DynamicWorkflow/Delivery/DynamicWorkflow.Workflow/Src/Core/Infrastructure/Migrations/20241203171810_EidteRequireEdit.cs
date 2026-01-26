using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EidteRequireEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRequireEdit",
                table: "RequestTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RequireEditFormStepId",
                table: "RequestTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequireEditToId",
                table: "RequestTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestTransactions_RequireEditToId",
                table: "RequestTransactions",
                column: "RequireEditToId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditToId",
                table: "RequestTransactions",
                column: "RequireEditToId",
                principalTable: "RequestTemplateSteps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditToId",
                table: "RequestTransactions");

            migrationBuilder.DropIndex(
                name: "IX_RequestTransactions_RequireEditToId",
                table: "RequestTransactions");

            migrationBuilder.DropColumn(
                name: "IsRequireEdit",
                table: "RequestTransactions");

            migrationBuilder.DropColumn(
                name: "RequireEditFormStepId",
                table: "RequestTransactions");

            migrationBuilder.DropColumn(
                name: "RequireEditToId",
                table: "RequestTransactions");
        }
    }
}
