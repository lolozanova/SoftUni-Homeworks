using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DataTransferedObject.Output
{
    [XmlType("Category")]
    public class CategoryOutputModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]

        public int Count { get; set; }

        [XmlElement("averagePrice")]

        public string AveragePrice { get; set; }

        [XmlElement("totalRevenue")]

        public string TotalRevenue { get; set; }
   
    }
}
