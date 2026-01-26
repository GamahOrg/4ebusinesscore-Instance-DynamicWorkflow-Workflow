using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditRequestTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RequestTransactionId",
                table: "AssginRequestInstance",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestInstance_RequestTransactionId",
                table: "AssginRequestInstance",
                column: "RequestTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssginRequestInstance_RequestTransactions_RequestTransactionId",
                table: "AssginRequestInstance",
                column: "RequestTransactionId",
                principalTable: "RequestTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssginRequestInstance_RequestTransactions_RequestTransactionId",
                table: "AssginRequestInstance");

            migrationBuilder.DropIndex(
                name: "IX_AssginRequestInstance_RequestTransactionId",
                table: "AssginRequestInstance");

            migrationBuilder.DropColumn(
                name: "RequestTransactionId",
                table: "AssginRequestInstance");
        }
    }
}
