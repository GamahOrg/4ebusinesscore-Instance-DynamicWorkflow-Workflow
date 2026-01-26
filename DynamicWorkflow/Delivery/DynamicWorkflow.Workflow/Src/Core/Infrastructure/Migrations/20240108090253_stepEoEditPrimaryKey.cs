using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4EPlatForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class stepEoEditPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StepToEdit",
                table: "StepToEdit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StepToEdit",
                table: "StepToEdit",
                columns: new[] { "RequestInstanceId", "StepId" })
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StepToEdit",
                table: "StepToEdit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StepToEdit",
                table: "StepToEdit",
                columns: new[] { "RequestInstanceId", "StepId", "State" })
                .Annotation("SqlServer:Clustered", true);
        }
    }
}
