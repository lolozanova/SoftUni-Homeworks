using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
   public class ProjectOutputModel
    {
        [XmlElement("ProjectName")]
        public string Name { get; set; }

        [XmlAttribute]
        public int TasksCount { get; set; }

        [XmlElement]
        public string HasEndDate { get; set; }

        [XmlArray]
        public TaskOutputModel[] Tasks { get; set; }
    }

    [XmlType("Task")]
   public class TaskOutputModel
    {
        public string Name { get; set; }

        public string Label { get; set; }
    }
}
