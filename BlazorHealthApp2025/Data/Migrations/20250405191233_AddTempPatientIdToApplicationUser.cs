using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorHealthApp2025.Migrations
{
    /// <inheritdoc />
    public partial class AddTempPatientIdToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempPatientId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempPatientId",
                table: "AspNetUsers");
        }
    }
}
