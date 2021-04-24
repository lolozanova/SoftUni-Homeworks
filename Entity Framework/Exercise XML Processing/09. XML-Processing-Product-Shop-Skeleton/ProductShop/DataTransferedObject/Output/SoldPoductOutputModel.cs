using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DataTransferedObject.Output
{
    public class SoldPoductOutputModel
    {
        [XmlElement("count")]

        public int Count { get; set; }

        [XmlArray("products")]
        public ProductOutputModel[] Products { get; set; }
    }
}
