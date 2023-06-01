using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace License.Creation.Api.Data
{
    [Table("DWInstallationTypesToLicenseProducts")]
    public class InstallationTypesToLicenseProductsModel
    {
        [Key]
        public int Id { get; set; }

        public int InstallationTypeId { get; set; }
        [ForeignKey("InstallationTypeId")]
        public InstallationType? InstallationType { get; set; }

        public int LicenseProductId { get; set; }
        [ForeignKey("LicenseProductId")]
        public LicenseProduct? LicenseProduct { get; set; }

        public int Count { get; set; }
    }
}
