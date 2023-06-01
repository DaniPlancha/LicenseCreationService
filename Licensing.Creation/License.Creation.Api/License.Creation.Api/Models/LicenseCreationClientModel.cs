using System.ComponentModel.DataAnnotations;
using License.Creation.Api.Models;

namespace License.Creation.Api.Data
{
    public class LicenseCreationClientModel
    {
        public ContractType ContractType { get; set; }

        public int InstallationTypeId { get; set; }
        public IEnumerable<LicenseProductClientModel> AllLicenseProducts { get; set; }

        //[RegularExpression(@"^([a-z\d\.-]+)@([a-z\d-]+)\.([a-z]{2,8})(\.[a-z]{2,8})?$", ErrorMessage = "Email is incorrectly formatted")]
        public string  Email { get; set; }

        //[RegularExpression(@"^\d{10,11}$", ErrorMessage = "Phone is incorrectly formatted")]
        public string Phone { get; set; }

        public string Company { get; set; }

        public string Version { get; set; }

        public string OrganizationKey { get; set; }
    }
}
