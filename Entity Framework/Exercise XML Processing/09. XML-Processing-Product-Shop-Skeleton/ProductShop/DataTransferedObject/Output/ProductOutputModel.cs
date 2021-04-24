﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DataTransferedObject.Output
{
    [XmlType("Product")]
    public class ProductOutputModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]

        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string  BuyersName { get; set; }
    }
}
