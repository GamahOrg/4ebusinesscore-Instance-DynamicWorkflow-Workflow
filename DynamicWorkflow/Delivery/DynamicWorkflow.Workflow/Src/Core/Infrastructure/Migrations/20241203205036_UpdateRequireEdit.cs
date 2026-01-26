using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRequireEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditFormStepId",
                table: "RequestTransactions");

            migrationBuilder.RenameColumn(
                name: "RequireEditFormStepId",
                table: "RequestTransactions",
                newName: "RequireEditToStepId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestTransactions_RequireEditFormStepId",
                table: "RequestTransactions",
                newName: "IX_RequestTransactions_RequireEditToStepId");

            migrationBuilder.CreateTable(
                name: "RequireEditFormStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestTransactionFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequireEditFormStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequireEditFormStep_RequestTransactions_RequestTransactionFromId",
                        column: x => x.RequestTransactionFromId,
                        principalTable: "RequestTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequireEditFormStep_RequestTransactionFromId",
                table: "RequireEditFormStep",
                column: "RequestTransactionFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditToStepId",
                table: "RequestTransactions",
                column: "RequireEditToStepId",
                principalTable: "RequestTemplateSteps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditToStepId",
                table: "RequestTransactions");

            migrationBuilder.DropTable(
                name: "RequireEditFormStep");

            migrationBuilder.RenameColumn(
                name: "RequireEditToStepId",
                table: "RequestTransactions",
                newName: "RequireEditFormStepId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestTransactions_RequireEditToStepId",
                table: "RequestTransactions",
                newName: "IX_RequestTransactions_RequireEditFormStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTransactions_RequestTemplateSteps_RequireEditFormStepId",
                table: "RequestTransactions",
                column: "RequireEditFormStepId",
                principalTable: "RequestTemplateSteps",
                principalColumn: "Id");
        }
    }
}
