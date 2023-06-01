using System.ComponentModel;
using DocuWare.Common.XML;
using License.Creation.Api.Services.LicenseInfoContracts;

namespace DocuWare.Settings.Licenses
{
	/// <summary>
	/// Summary description for ProductType.
	/// </summary>
	[XMLTag("Type")]
	[Serializable]
	public class ProductType:XMLStorage//,ISerializable
	{
        [XMLAttr("value")]
        public ExpirationLicenseType ExpirationType { get; set; }

        [XMLAttr("expirationDate",Mandatory = false)]
		public DateTime ExpirationDate { get; set; }
    }
    public enum ExpirationLicenseType
    {
        [Description("ExpirationLicenseType.Demo")]
        Demo = 1,
        [Description("ExpirationLicenseType.Test")]
        Test = 2,
        [Description("ExpirationLicenseType.Unlimited")]
        Unlimited = 3,
        [Description("ExpirationLicenseType.TestLateMSG")]
        TestLateMSG = 4
    }
}
