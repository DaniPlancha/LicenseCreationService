using System;
using System.Runtime.Serialization;
using DocuWare.Common.XML;

namespace DocuWare.Settings.Licenses
{
	/// <summary>
	/// Summary description for GeneralInfo.
	/// </summary>
	[XMLTag("GeneralInfo")]
	[Serializable]
	public class GeneralInfo:XMLStorage//,ISerializable
	{
		[XMLAttr("company",Mandatory = true)]
		public string Company { get; set; }

		[XMLAttr("company2")]
		public string Company2 { get; set; }

        [XMLAttr("address1",Mandatory = true)]
		public string Address1 { get; set; }

        [XMLAttr("address2",Mandatory = true)]
		public string Address2 { get; set; }

        [XMLAttr("address3",Mandatory = true)]
		public string Address3 { get; set; }

        [XMLAttr("address4")]
		public string Address4 { get; set; }

        [XMLAttr("systemNumber",Mandatory = true)]
		public string SystemNumber { get; set; }

        [XMLAttr("phone",Mandatory = true)]
		public string Phone { get; set; }

        [XMLAttr("fax")]
		public string Fax { get; set; }

        [XMLAttr("eMail",Mandatory = true)]
		public string EMail { get; set; }

        [XMLAttr("version",Mandatory = true)]
		public string Version { get; set; }

        [XMLAttr("systemAdmin",Mandatory = true)]
		public string Administrator { get; set; }

        [XMLAttr("organizationType", Mandatory = false)]
		public string OrganizationType { get; set; }
	}
}
