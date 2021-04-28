namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectInputModel[]), new XmlRootAttribute("Projects"));

            StringReader textReader = new StringReader(xmlString);

            var projectDTOs = serializer.Deserialize(textReader) as ProjectInputModel[];

            StringBuilder output = new StringBuilder();

            foreach (var projectDTO in projectDTOs)
            {
                if (!IsValid(projectDTO))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                bool tryParseProjectOpenDate = DateTime.TryParseExact(projectDTO.OpenDate,"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var projectOpenDate);
                if (!tryParseProjectOpenDate)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }


                DateTime? projectDueDate;

                if (!String.IsNullOrWhiteSpace(projectDTO.DueDate))
                {

                    bool parseDate = DateTime.TryParseExact(projectDTO.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var projDueDate);

                    if (!parseDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    else
                    {
                        projectDueDate = projDueDate;
                    }
                }
                else
                {
                    projectDueDate = null;
                }


                Project currProject = new Project
                {
                    Name = projectDTO.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };
                foreach (var taskDTO in projectDTO.Tasks)
                {
                    bool tryParseTaskOpenDate  = DateTime.TryParseExact(taskDTO.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out var taskOpenDate);

                    if (!tryParseTaskOpenDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool tryParseTaskDueDate = DateTime.TryParseExact(taskDTO.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var taskDueDate);

                    if (!tryParseTaskDueDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue; 
                    }

                   

                    if (!IsValid(taskDTO) || taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task currTask = new Task
                    {
                        Name = taskDTO.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDTO.ExecutionType,
                        LabelType = (LabelType)taskDTO.LabelType
                    };

                    currProject.Tasks.Add(currTask);

                }

                context.Projects.Add(currProject);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfullyImportedProject, currProject.Name, currProject.Tasks.Count));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
         var employeeDTOs =  JsonConvert.DeserializeObject<ICollection<EmployeeInputModel>>(jsonString);

            StringBuilder output = new StringBuilder();

            foreach (var employeeDTO in employeeDTOs)
            {
                if (!IsValid(employeeDTO))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Employee currEmployee = new Employee
                {
                    Username = employeeDTO.Username,
                    Email = employeeDTO.Email,
                    Phone = employeeDTO.Phone,
                    
                };

                foreach (int taskDTO in employeeDTO.Tasks.Distinct())
                {

                 var currTask = context.Tasks.FirstOrDefault(t => t.Id == taskDTO);

                    if (currTask == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    currEmployee.EmployeesTasks.Add(new EmployeeTask { 
                                                        Task = currTask, 
                                                        Employee = currEmployee
                                                    });
                }

                context.Employees.Add(currEmployee);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfullyImportedEmployee, currEmployee.Username, currEmployee.EmployeesTasks.Count));
            }

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}