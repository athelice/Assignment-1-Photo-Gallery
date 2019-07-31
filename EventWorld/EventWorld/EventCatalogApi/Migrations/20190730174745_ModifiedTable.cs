using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class ModifiedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_EventCities_EventCityId",
                table: "EventCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_EventTypes_EventTypeId",
                table: "EventCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCatalog",
                table: "EventCatalog");

            migrationBuilder.RenameTable(
                name: "EventCatalog",
                newName: "EventItems");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventTypeId",
                table: "EventItems",
                newName: "IX_EventItems_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventCityId",
                table: "EventItems",
                newName: "IX_EventItems_EventCityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventItems",
                table: "EventItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventItems_EventCities_EventCityId",
                table: "EventItems",
                column: "EventCityId",
                principalTable: "EventCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventItems_EventTypes_EventTypeId",
                table: "EventItems",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventItems_EventCities_EventCityId",
                table: "EventItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EventItems_EventTypes_EventTypeId",
                table: "EventItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventItems",
                table: "EventItems");

            migrationBuilder.RenameTable(
                name: "EventItems",
                newName: "EventCatalog");

            migrationBuilder.RenameIndex(
                name: "IX_EventItems_EventTypeId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventItems_EventCityId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventCityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCatalog",
                table: "EventCatalog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCatalog_EventCities_EventCityId",
                table: "EventCatalog",
                column: "EventCityId",
                principalTable: "EventCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCatalog_EventTypes_EventTypeId",
                table: "EventCatalog",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
