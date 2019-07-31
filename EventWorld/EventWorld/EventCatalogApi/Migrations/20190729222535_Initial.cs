using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_city_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventCities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: false),
                    EventCityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCatalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCatalog_EventCities_EventCityId",
                        column: x => x.EventCityId,
                        principalTable: "EventCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCatalog_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventCatalog_EventCityId",
                table: "EventCatalog",
                column: "EventCityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCatalog_EventTypeId",
                table: "EventCatalog",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventCatalog");

            migrationBuilder.DropTable(
                name: "EventCities");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropSequence(
                name: "event_catalog_hilo");

            migrationBuilder.DropSequence(
                name: "event_city_hilo");

            migrationBuilder.DropSequence(
                name: "event_type_hilo");
        }
    }
}
