using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace License.Creation.Api.Migrations
{
    public partial class InstallationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseProductForInstallationType_Model");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseProductForInstallationType_Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(type: "int", nullable: false),
                    InstallationTypeModelId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseProductForInstallationType_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseProductForInstallationType_Model_DWInstallationTypes_~",
                        column: x => x.InstallationTypeModelId,
                        principalTable: "DWInstallationTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseProductForInstallationType_Model_InstallationTypeMode~",
                table: "LicenseProductForInstallationType_Model",
                column: "InstallationTypeModelId");
        }
    }
}
