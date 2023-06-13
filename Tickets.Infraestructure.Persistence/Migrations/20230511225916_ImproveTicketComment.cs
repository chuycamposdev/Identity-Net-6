using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infraestructure.Persistence.Migrations
{
    public partial class ImproveTicketComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "TicketComment",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 11, 17, 59, 16, 609, DateTimeKind.Local).AddTicks(2211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 19, 2, 13, 917, DateTimeKind.Local).AddTicks(3604));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "TicketComment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 19, 2, 13, 917, DateTimeKind.Local).AddTicks(3604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 11, 17, 59, 16, 609, DateTimeKind.Local).AddTicks(2211));
        }
    }
}
