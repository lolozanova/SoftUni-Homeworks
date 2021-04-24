using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DataTransferedObject.Output
{
    [XmlType("User")]
  public  class UserWithSoldProductsOutputModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int? Age { get; set; }

        public SoldPoductOutputModel SoldProducts { get; set; }



    }
}
