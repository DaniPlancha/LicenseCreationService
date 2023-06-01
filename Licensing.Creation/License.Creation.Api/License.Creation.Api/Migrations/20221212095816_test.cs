using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace License.Creation.Api.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DWInstallationTypesToLicenseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InstallationTypeId = table.Column<int>(type: "int", nullable: false),
                    LicenseProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DWInstallationTypesToLicenseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DWInstallationTypesToLicenseProducts_DWInstallationTypes_Ins~",
                        column: x => x.InstallationTypeId,
                        principalTable: "DWInstallationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DWInstallationTypesToLicenseProducts_dwlicenseproducts_Licen~",
                        column: x => x.LicenseProductId,
                        principalTable: "dwlicenseproducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DWInstallationTypesToLicenseProducts_InstallationTypeId",
                table: "DWInstallationTypesToLicenseProducts",
                column: "InstallationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DWInstallationTypesToLicenseProducts_LicenseProductId",
                table: "DWInstallationTypesToLicenseProducts",
                column: "LicenseProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DWInstallationTypesToLicenseProducts");

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
    }
}
