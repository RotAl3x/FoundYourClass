using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleFaculty.Core.Migrations
{
    /// <inheritdoc />
    public partial class Changedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hour_Location_DatesToHourId",
                table: "Hour");

            migrationBuilder.DropIndex(
                name: "IX_Hour_DatesToHourId",
                table: "Hour");

            migrationBuilder.DropColumn(
                name: "DatesToHourId",
                table: "Hour");

            migrationBuilder.RenameColumn(
                name: "startHour",
                table: "Hour",
                newName: "StartHour");

            migrationBuilder.RenameColumn(
                name: "endHour",
                table: "Hour",
                newName: "EndHour");

            migrationBuilder.AddColumn<Guid>(
                name: "HourId",
                table: "DatesToHours",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DatesToHours_HourId",
                table: "DatesToHours",
                column: "HourId");

            migrationBuilder.AddForeignKey(
                name: "FK_DatesToHours_Hour_HourId",
                table: "DatesToHours",
                column: "HourId",
                principalTable: "Hour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatesToHours_Hour_HourId",
                table: "DatesToHours");

            migrationBuilder.DropIndex(
                name: "IX_DatesToHours_HourId",
                table: "DatesToHours");

            migrationBuilder.DropColumn(
                name: "HourId",
                table: "DatesToHours");

            migrationBuilder.RenameColumn(
                name: "StartHour",
                table: "Hour",
                newName: "startHour");

            migrationBuilder.RenameColumn(
                name: "EndHour",
                table: "Hour",
                newName: "endHour");

            migrationBuilder.AddColumn<Guid>(
                name: "DatesToHourId",
                table: "Hour",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Hour_DatesToHourId",
                table: "Hour",
                column: "DatesToHourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hour_Location_DatesToHourId",
                table: "Hour",
                column: "DatesToHourId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
