using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AssginRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssginRequestTemplateStepId",
                table: "RequestTemplateSteps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssginRequestInstance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionTakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssginRequestInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssginRequestInstance_RequestInstances_RequestInstanceId",
                        column: x => x.RequestInstanceId,
                        principalTable: "RequestInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssginRequestInstance_RequestTemplateSteps_StepId",
                        column: x => x.StepId,
                        principalTable: "RequestTemplateSteps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssginRequestTemplateStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCountTask = table.Column<bool>(type: "bit", nullable: false),
                    CountTask = table.Column<int>(type: "int", nullable: true),
                    ActionAssgin = table.Column<int>(type: "int", nullable: false),
                    RequestTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssginRequestTemplateStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssginRequestTemplateStepAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssginRequestInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssginRequestTemplateStepAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssginRequestTemplateStepAttachment_AssginRequestInstance_AssginRequestInstanceId",
                        column: x => x.AssginRequestInstanceId,
                        principalTable: "AssginRequestInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssginRequestTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    AssginRequestInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssginRequestTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssginRequestTransaction_AssginRequestInstance_AssginRequestInstanceId",
                        column: x => x.AssginRequestInstanceId,
                        principalTable: "AssginRequestInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupAssginActionTacker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionTakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssginRequestInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAssginActionTacker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupAssginActionTacker_AssginRequestInstance_AssginRequestInstanceId",
                        column: x => x.AssginRequestInstanceId,
                        principalTable: "AssginRequestInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssginRequestTransactionAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssginRequestTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssginRequestTransactionAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssginRequestTransactionAttachment_AssginRequestTransaction_AssginRequestTransactionId",
                        column: x => x.AssginRequestTransactionId,
                        principalTable: "AssginRequestTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestTemplateSteps_AssginRequestTemplateStepId",
                table: "RequestTemplateSteps",
                column: "AssginRequestTemplateStepId",
                unique: true,
                filter: "[AssginRequestTemplateStepId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestInstance_RequestInstanceId",
                table: "AssginRequestInstance",
                column: "RequestInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestInstance_StepId",
                table: "AssginRequestInstance",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestTemplateStepAttachment_AssginRequestInstanceId",
                table: "AssginRequestTemplateStepAttachment",
                column: "AssginRequestInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestTransaction_AssginRequestInstanceId",
                table: "AssginRequestTransaction",
                column: "AssginRequestInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestTransactionAttachment_AssginRequestTransactionId",
                table: "AssginRequestTransactionAttachment",
                column: "AssginRequestTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAssginActionTacker_AssginRequestInstanceId",
                table: "GroupAssginActionTacker",
                column: "AssginRequestInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTemplateSteps_AssginRequestTemplateStep_AssginRequestTemplateStepId",
                table: "RequestTemplateSteps",
                column: "AssginRequestTemplateStepId",
                principalTable: "AssginRequestTemplateStep",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestTemplateSteps_AssginRequestTemplateStep_AssginRequestTemplateStepId",
                table: "RequestTemplateSteps");

            migrationBuilder.DropTable(
                name: "AssginRequestTemplateStep");

            migrationBuilder.DropTable(
                name: "AssginRequestTemplateStepAttachment");

            migrationBuilder.DropTable(
                name: "AssginRequestTransactionAttachment");

            migrationBuilder.DropTable(
                name: "GroupAssginActionTacker");

            migrationBuilder.DropTable(
                name: "AssginRequestTransaction");

            migrationBuilder.DropTable(
                name: "AssginRequestInstance");

            migrationBuilder.DropIndex(
                name: "IX_RequestTemplateSteps_AssginRequestTemplateStepId",
                table: "RequestTemplateSteps");

            migrationBuilder.DropColumn(
                name: "AssginRequestTemplateStepId",
                table: "RequestTemplateSteps");
        }
    }
}
