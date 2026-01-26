using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeSlaModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTemplateSteps_Slas_SlaId",
                table: "RequestTemplateSteps");

            migrationBuilder.DropTable(
                name: "EscalationLevels");

            migrationBuilder.DropTable(
                name: "Slas");

            migrationBuilder.DropIndex(
                name: "IX_RequestTemplateSteps_SlaId",
                table: "RequestTemplateSteps");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImplementDays = table.Column<int>(type: "int", nullable: false),
                    ImplementHours = table.Column<int>(type: "int", nullable: false),
                    ImplementMinutes = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondDays = table.Column<int>(type: "int", nullable: false),
                    RespondHours = table.Column<int>(type: "int", nullable: false),
                    RespondMinutes = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EscalationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseDays = table.Column<int>(type: "int", nullable: false),
                    ResponseHours = table.Column<int>(type: "int", nullable: false),
                    ResponseMinutes = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalationLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EscalationLevels_Slas_SlaId",
                        column: x => x.SlaId,
                        principalTable: "Slas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestTemplateSteps_SlaId",
                table: "RequestTemplateSteps",
                column: "SlaId");

            migrationBuilder.CreateIndex(
                name: "IX_EscalationLevels_SlaId",
                table: "EscalationLevels",
                column: "SlaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTemplateSteps_Slas_SlaId",
                table: "RequestTemplateSteps",
                column: "SlaId",
                principalTable: "Slas",
                principalColumn: "Id");
        }
    }
}
