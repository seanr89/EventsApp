using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsAPI.Migrations
{
    public partial class EventsEdits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");
        }
    }
}
