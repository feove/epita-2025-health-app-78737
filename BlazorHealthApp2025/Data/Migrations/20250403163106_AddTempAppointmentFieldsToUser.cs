using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorHealthApp2025.Migrations
{
    /// <inheritdoc />
    public partial class AddTempAppointmentFieldsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TempAppointmentDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempAppointmentTime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempAppointmentDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TempAppointmentTime",
                table: "AspNetUsers");
        }
    }
}
