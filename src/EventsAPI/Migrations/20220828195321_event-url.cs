using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsAPI.Migrations
{
    public partial class eventurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Events_AttendedEventId",
                table: "Attendees");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Events",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AttendedEventId",
                table: "Attendees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Events_AttendedEventId",
                table: "Attendees",
                column: "AttendedEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Events_AttendedEventId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Events");

            migrationBuilder.AlterColumn<Guid>(
                name: "AttendedEventId",
                table: "Attendees",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Events_AttendedEventId",
                table: "Attendees",
                column: "AttendedEventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
