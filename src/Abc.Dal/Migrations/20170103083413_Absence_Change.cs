using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.Dal.Migrations
{
    public partial class Absence_Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttendeeEmails",
                table: "Absence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Absence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndTimeZone",
                table: "Absence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Absence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recurrence",
                table: "Absence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReminderMethods",
                table: "Absence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartTimeZone",
                table: "Absence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Absence",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendeeEmails",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "EndTimeZone",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "Recurrence",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "ReminderMethods",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "StartTimeZone",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Absence");
        }
    }
}
