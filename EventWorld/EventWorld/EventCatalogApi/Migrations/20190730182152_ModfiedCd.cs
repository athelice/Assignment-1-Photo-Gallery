using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class ModfiedCd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropSequence(
                name: "event_catalog_hilo");

            migrationBuilder.DropSequence(
                name: "event_city_hilo");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "EventCatalog");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventTypeId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventCityId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventCityId");

            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EventCatalog",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "EventCatalog",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.RenameTable(
                name: "EventCatalog",
                newName: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventTypeId",
                table: "Catalog",
                newName: "IX_Catalog_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventCityId",
                table: "Catalog",
                newName: "IX_Catalog_EventCityId");

            migrationBuilder.CreateSequence(
                name: "event_catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_city_hilo",
                incrementBy: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Catalog",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Catalog",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

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
    }
}
