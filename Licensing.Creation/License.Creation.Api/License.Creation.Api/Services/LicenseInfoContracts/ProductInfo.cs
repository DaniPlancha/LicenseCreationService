using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DocuWare.Common.XML;

namespace DocuWare.Settings.Licenses
{

	/// <summary>
	/// Summary description for ProductInfo.
	/// </summary>
	[XMLTag("ProductInfo")]
	[Serializable]
	public class ProductInfo : XMLStorage//,ISerializable
	{
        [XMLAttr("product")]
        public string Product { get; set; }

        [XMLAttr("licenseType")]
        public DWLicenseTypes LiceseType { get; set; }

        [XMLAttr("version", Mandatory = true)]
		public long Version { get; set; }

        [XMLAttr("language")]
		public string Language { get; set; }

        [XMLCompound(typeof(ProductType),Mandatory = true)]
		public ProductType InfoType { get; set; }

        [XMLCompound(typeof(Property),Mandatory = false)]
		public List<Property> Properties { get; set; }

        [XMLCompound(typeof(ConcurentLicense),Mandatory = true)]
		public ConcurentLicense ConcurentLicenses { get; set; }

        [XMLCompound(typeof(NamedLicense),Mandatory = true)]
		public List<NamedLicense> NamedLicenses { get; set; }
    }
    public enum DWLicenseTypes
    {
        Free = 0,
        // not used for a long time
        //Site = 1,
        Server = 2,
        ConcurrentClient = 3,
        NamedClient = 4,
        NamedServer = 5,
    }
}
