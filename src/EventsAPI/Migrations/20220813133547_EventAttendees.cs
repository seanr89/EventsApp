using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsAPI.Migrations
{
    public partial class EventAttendees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AttendedEventId",
                table: "Attendees",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_AttendedEventId",
                table: "Attendees",
                column: "AttendedEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Events_AttendedEventId",
                table: "Attendees",
                column: "AttendedEventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Events_AttendedEventId",
                table: "Attendees");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_AttendedEventId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "AttendedEventId",
                table: "Attendees");
        }
    }
}
