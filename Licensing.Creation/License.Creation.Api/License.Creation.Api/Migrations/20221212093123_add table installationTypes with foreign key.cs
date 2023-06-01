using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace License.Creation.Api.Migrations
{
    public partial class addtableinstallationTypeswithforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstallationTypeId",
                table: "dwlicenseproducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_dwlicenseproducts_InstallationTypeId",
                table: "dwlicenseproducts",
                column: "InstallationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_dwlicenseproducts_DWInstallationTypes_InstallationTypeId",
                table: "dwlicenseproducts",
                column: "InstallationTypeId",
                principalTable: "DWInstallationTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dwlicenseproducts_DWInstallationTypes_InstallationTypeId",
                table: "dwlicenseproducts");

            migrationBuilder.DropIndex(
                name: "IX_dwlicenseproducts_InstallationTypeId",
                table: "dwlicenseproducts");

            migrationBuilder.DropColumn(
                name: "InstallationTypeId",
                table: "dwlicenseproducts");
        }
    }
}
