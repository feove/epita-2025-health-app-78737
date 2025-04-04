using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorHealthApp2025.Migrations
{
    /// <inheritdoc />
    public partial class AddTempDoctorFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempDoctorId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TempDoctorName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempDoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TempDoctorName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Appointments");
        }
    }
}
