using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectInputModel
    {
        [Required]
        [StringLength(40, MinimumLength =2)]
        [XmlElement]
        public string Name { get; set; }

        [Required]
        [XmlElement]
        public string OpenDate { get; set; }

        [XmlElement]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TaskInputModel[] Tasks { get; set; }
        
    }

    [XmlType("Task")]
    public class TaskInputModel
    {
        [Required]
        [StringLength(40,MinimumLength =2)]
        [XmlElement]
        public string Name { get; set; }

        [Required]
        [XmlElement]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement]
        public string DueDate { get; set; }

        [Range(0,3)]
        [XmlElement]
        public int ExecutionType { get; set; }

        [Range(0, 4)]
        [XmlElement]
        public int LabelType { get; set; }
       
    }
}
