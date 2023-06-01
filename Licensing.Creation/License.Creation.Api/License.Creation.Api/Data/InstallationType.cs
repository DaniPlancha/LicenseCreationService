using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace License.Creation.Api.Data
{
    [Table("DWInstallationTypes")]
    public class InstallationType
    {
        public InstallationType(int id, string name)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative");
            }
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<InstallationTypesToLicenseProductsModel>? ProductRelations { get; set; }
    }
}
