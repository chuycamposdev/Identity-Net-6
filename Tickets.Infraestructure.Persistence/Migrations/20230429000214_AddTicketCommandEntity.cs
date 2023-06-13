using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Infraestructure.Persistence.Migrations
{
    public partial class AddTicketCommandEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ticket",
                newName: "TicketId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 19, 2, 13, 917, DateTimeKind.Local).AddTicks(3604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 8, 16, 1, 48, 570, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.CreateTable(
                name: "TicketComment",
                columns: table => new
                {
                    TicketCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComment", x => x.TicketCommentId);
                    table.ForeignKey(
                        name: "FK_TicketComment_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketComment_TicketId",
                table: "TicketComment",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketComment");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Ticket",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 8, 16, 1, 48, 570, DateTimeKind.Local).AddTicks(7902),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 28, 19, 2, 13, 917, DateTimeKind.Local).AddTicks(3604));
        }
    }
}
