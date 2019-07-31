using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class RenamedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_EventItems_EventTypeId",
                table: "Catalog",
                newName: "IX_Catalog_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventItems_EventCityId",
                table: "Catalog",
                newName: "IX_Catalog_EventCityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_EventCities_EventCityId",
                table: "Catalog",
                column: "EventCityId",
                principalTable: "EventCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_EventTypes_EventTypeId",
                table: "Catalog",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_EventCities_EventCityId",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_EventTypes_EventTypeId",
                table: "Catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "EventItems");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventTypeId",
                table: "EventItems",
                newName: "IX_EventItems_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventCityId",
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
    }
}
