using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditRequestTransactionRealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssginRequestInstance_RequestTransactionId",
                table: "AssginRequestInstance");

            migrationBuilder.AddColumn<Guid>(
                name: "AssginRequestInstanceId",
                table: "RequestTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestInstance_RequestTransactionId",
                table: "AssginRequestInstance",
                column: "RequestTransactionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssginRequestInstance_RequestTransactionId",
                table: "AssginRequestInstance");

            migrationBuilder.DropColumn(
                name: "AssginRequestInstanceId",
                table: "RequestTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestInstance_RequestTransactionId",
                table: "AssginRequestInstance",
                column: "RequestTransactionId");
        }
    }
}
