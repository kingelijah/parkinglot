using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingLot.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parkingRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkingRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parkingTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursSpent = table.Column<int>(type: "int", nullable: false),
                    AmountToPay = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkingTicket", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parkingRules");

            migrationBuilder.DropTable(
                name: "parkingTicket");
        }
    }
}
