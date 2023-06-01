using DocuWare.Common.XML;
using DocuWare.Settings.Licenses;

namespace License.Creation.Api.Services.LicenseInfoContracts
{
    [XMLTag("LicenseInfo")]
    [Serializable]
    public class LicenseInfo : XMLStorage
    {
        //TODO: Check if necessary, does not exist in license file
        /*[XMLAttr("version", Mandatory = false)]
        public string version { get; set; }*/

        [XMLCompound(typeof(GeneralInfo), Mandatory = true)]
        public GeneralInfo General { get; set; }

        [XMLCompound(typeof(ProductInfos), Mandatory = true)]
        public ProductInfos ProductInfos { get; set; }

        [XMLAttr("organizationKey")]
        public string OrganizationKey { get; set; }

        [XMLTag("DWSignature")]
        [XMLContent]
        public string DWSignature { get; set; }
    }
}

