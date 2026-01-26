using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignkeyRequireEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditToId",
                table: "RequestTransactions");

            migrationBuilder.DropIndex(
                name: "IX_RequestTransactions_RequireEditToId",
                table: "RequestTransactions");

            migrationBuilder.DropColumn(
                name: "RequireEditToId",
                table: "RequestTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTransactions_RequireEditFormStepId",
                table: "RequestTransactions",
                column: "RequireEditFormStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditFormStepId",
                table: "RequestTransactions",
                column: "RequireEditFormStepId",
                principalTable: "RequestTemplateSteps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditFormStepId",
                table: "RequestTransactions");

            migrationBuilder.DropIndex(
                name: "IX_RequestTransactions_RequireEditFormStepId",
                table: "RequestTransactions");

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
    }
}
