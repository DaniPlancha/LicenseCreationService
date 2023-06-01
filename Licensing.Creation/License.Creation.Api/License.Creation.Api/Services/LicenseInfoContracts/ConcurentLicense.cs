using System;
using System.Runtime.Serialization;
using DocuWare.Common.XML;

namespace DocuWare.Settings.Licenses
{
	/// <summary>
	/// Summary description for ConcurentLicense.
	/// </summary>
	[XMLTag("Concurrent")]
	[Serializable]
	public class ConcurentLicense:XMLStorage//,ISerializable
	{
        [XMLAttr("count")] public double Count { get; set; }
	}
}
