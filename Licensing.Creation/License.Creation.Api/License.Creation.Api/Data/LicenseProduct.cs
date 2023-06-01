using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace License.Creation.Api.Data
{
    [Table("dwlicenseproducts")]
    public class LicenseProduct
    {
        public LicenseProduct(int id, string name, string issuedType)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IssuedType = issuedType ?? throw new ArgumentNullException(nameof(issuedType));
        }
        
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string IssuedType { get; set; }
    }
}