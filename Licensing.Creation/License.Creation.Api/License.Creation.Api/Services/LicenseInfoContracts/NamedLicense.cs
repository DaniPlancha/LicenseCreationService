using System;
using System.Runtime.Serialization;
using DocuWare.Common.XML;

namespace DocuWare.Settings.Licenses
{
	/// <summary>
	/// Summary description for NamedLicense.
	/// </summary>
	[XMLTag("Named")]
	[Serializable]
	public class NamedLicense:XMLStorage//,ISerializable
	{
		[XMLAttr("organization")]
		public string Organization { get; set; }

        [XMLAttr("user")]
		public string User { get; set; }

        [XMLAttr("computer", Mandatory= false)]
		public string ComputerName { get; set; }
    }
}
