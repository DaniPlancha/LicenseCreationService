using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DocuWare.Common.XML;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DocuWare.Settings.Licenses
{
	/// <summary>
	/// Summary description for ProductInfos.
	/// </summary>
	[XMLTag("ProductInfos")]
	[Serializable]
	public class ProductInfos:XMLStorage//,ISerializable
	{
        [XMLCompound(typeof(ProductInfo), Mandatory = true)]
        public List<ProductInfo> Items { get; set; }
    }
}
