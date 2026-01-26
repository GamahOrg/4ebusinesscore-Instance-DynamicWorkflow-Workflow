using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTacker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionTakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTacker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImplementDays = table.Column<int>(type: "int", nullable: false),
                    ImplementHours = table.Column<int>(type: "int", nullable: false),
                    ImplementMinutes = table.Column<int>(type: "int", nullable: false),
                    RespondDays = table.Column<int>(type: "int", nullable: false),
                    RespondHours = table.Column<int>(type: "int", nullable: false),
                    RespondMinutes = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionOptions = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RequestTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestTemplates_RequestCategories_RequestCategoryId",
                        column: x => x.RequestCategoryId,
                        principalTable: "RequestCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EscalationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ResponseMinutes = table.Column<int>(type: "int", nullable: false),
                    ResponseHours = table.Column<int>(type: "int", nullable: false),
                    ResponseDays = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SlaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "RequestTemplateSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    ActionTackerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTemplateSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestTemplateSteps_ActionTacker_ActionTackerId",
                        column: x => x.ActionTackerId,
                        principalTable: "ActionTacker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestTemplateSteps_RequestTemplates_RequestTemplateId",
                        column: x => x.RequestTemplateId,
                        principalTable: "RequestTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestTemplateSteps_Slas_SlaId",
                        column: x => x.SlaId,
                        principalTable: "Slas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    RequestTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestInstances_RequestTemplateSteps_CurrentStepId",
                        column: x => x.CurrentStepId,
                        principalTable: "RequestTemplateSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RequestInstances_RequestTemplates_RequestTemplateId",
                        column: x => x.RequestTemplateId,
                        principalTable: "RequestTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    RequestInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestTemplateStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestTransactions_RequestInstances_RequestInstanceId",
                        column: x => x.RequestInstanceId,
                        principalTable: "RequestInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestTransactions_RequestTemplateSteps_RequestTemplateStepId",
                        column: x => x.RequestTemplateStepId,
                        principalTable: "RequestTemplateSteps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StepToEdit",
                columns: table => new
                {
                    State = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepToEdit", x => new { x.RequestInstanceId, x.StepId, x.State })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_StepToEdit_RequestInstances_RequestInstanceId",
                        column: x => x.RequestInstanceId,
                        principalTable: "RequestInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepToEdit_RequestTemplateSteps_StepId",
                        column: x => x.StepId,
                        principalTable: "RequestTemplateSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EscalationLevels_SlaId",
                table: "EscalationLevels",
                column: "SlaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestInstances_CurrentStepId",
                table: "RequestInstances",
                column: "CurrentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestInstances_RequestTemplateId",
                table: "RequestInstances",
                column: "RequestTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTemplates_RequestCategoryId",
                table: "RequestTemplates",
                column: "RequestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTemplateSteps_ActionTackerId",
                table: "RequestTemplateSteps",
                column: "ActionTackerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTemplateSteps_RequestTemplateId",
                table: "RequestTemplateSteps",
                column: "RequestTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTemplateSteps_SlaId",
                table: "RequestTemplateSteps",
                column: "SlaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTransactions_RequestInstanceId",
                table: "RequestTransactions",
                column: "RequestInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTransactions_RequestTemplateStepId",
                table: "RequestTransactions",
                column: "RequestTemplateStepId");

            migrationBuilder.CreateIndex(
                name: "IX_StepToEdit_StepId",
                table: "StepToEdit",
                column: "StepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalationLevels");

            migrationBuilder.DropTable(
                name: "RequestTransactions");

            migrationBuilder.DropTable(
                name: "StepToEdit");

            migrationBuilder.DropTable(
                name: "RequestInstances");

            migrationBuilder.DropTable(
                name: "RequestTemplateSteps");

            migrationBuilder.DropTable(
                name: "ActionTacker");

            migrationBuilder.DropTable(
                name: "RequestTemplates");

            migrationBuilder.DropTable(
                name: "Slas");

            migrationBuilder.DropTable(
                name: "RequestCategories");
        }
    }
}
