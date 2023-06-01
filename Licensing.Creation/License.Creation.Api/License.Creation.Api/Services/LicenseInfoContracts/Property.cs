using System;
using System.Runtime.Serialization;
using DocuWare.Common.XML;

namespace DocuWare.Settings.Licenses
{
	/// <summary>
	/// Summary description for Property.
	/// </summary>
	[XMLTag("Property")]
	[Serializable]
	public class Property:XMLStorage//,ISerializable
	{
        [XMLAttr("name")] public string Name { get; set; }

        [XMLAttr("value")]
		public string Value { get; set; }

    }
}
