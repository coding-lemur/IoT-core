using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IoT_Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now','localtime')"),
                    DeviceTimestamp = table.Column<int>(nullable: true),
                    Humidity = table.Column<float>(nullable: false),
                    SoilMoisture = table.Column<int>(nullable: false),
                    Temperature = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watering",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now','localtime')"),
                    Milliseconds = table.Column<int>(nullable: false),
                    SensorsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watering_Sensors_SensorsId",
                        column: x => x.SensorsId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Watering_SensorsId",
                table: "Watering",
                column: "SensorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watering");

            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
