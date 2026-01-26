using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editINAssginRequestInstances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssginRequestInstance_RequestTemplateSteps_StepId",
                table: "AssginRequestInstance");

            migrationBuilder.DropIndex(
                name: "IX_AssginRequestInstance_StepId",
                table: "AssginRequestInstance");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "AssginRequestInstance");

            migrationBuilder.RenameColumn(
                name: "RequestTemplateId",
                table: "AssginRequestInstance",
                newName: "RequestTemplateStepId");

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestInstance_RequestTemplateStepId",
                table: "AssginRequestInstance",
                column: "RequestTemplateStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssginRequestInstance_RequestTemplateSteps_RequestTemplateStepId",
                table: "AssginRequestInstance",
                column: "RequestTemplateStepId",
                principalTable: "RequestTemplateSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssginRequestInstance_RequestTemplateSteps_RequestTemplateStepId",
                table: "AssginRequestInstance");

            migrationBuilder.DropIndex(
                name: "IX_AssginRequestInstance_RequestTemplateStepId",
                table: "AssginRequestInstance");

            migrationBuilder.RenameColumn(
                name: "RequestTemplateStepId",
                table: "AssginRequestInstance",
                newName: "RequestTemplateId");

            migrationBuilder.AddColumn<Guid>(
                name: "StepId",
                table: "AssginRequestInstance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssginRequestInstance_StepId",
                table: "AssginRequestInstance",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssginRequestInstance_RequestTemplateSteps_StepId",
                table: "AssginRequestInstance",
                column: "StepId",
                principalTable: "RequestTemplateSteps",
                principalColumn: "Id");
        }
    }
}
