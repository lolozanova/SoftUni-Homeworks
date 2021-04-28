namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            // Export all projects that have at least one task.
            //For each project, export its name, tasks count, and if it has end(due) date which is represented like "Yes" and "No".
            //For each task, export its name and label type.
            //Order the tasks by name(ascending).Order the projects by tasks count(descending), then by name(ascending).

          var projectDTOs =  context.Projects
                .Where(p => p.Tasks.Any())
                .ToArray()
                .Select(p => new ProjectOutputModel
                {
                    TasksCount = p.Tasks.Count,
                    Name = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                                    .ToArray()
                                    .Select(t => new TaskOutputModel
                                    {
                                        Name = t.Name,
                                        Label = t.LabelType.ToString()
                                    }).OrderBy(t => t.Name)
                    .ToArray()

                }).OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.Name)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ProjectOutputModel[]), new XmlRootAttribute("Projects"));

            var textWriter = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            serializer.Serialize(textWriter, projectDTOs, ns);

            return textWriter.ToString().TrimEnd();

           
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            // Select the top 10 employees who have at least one task that its open date is after or equal to the given date 
            //with their tasks that meet the same requirement(to have their open date after or equal to the giver date).
            //For each employee, export their username and their tasks.
            //For each task, export its name and open date(must be in format "d"), due date(must be in format "d"), label and execution type. 
            //Order the tasks by due date(descending), then by name(ascending).Order the employees by all tasks(meeting above condition) count(descending), then by username(ascending).

           var employeesDTO = context.Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(e => e.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .ToArray()
                    .Where(t => t.Task.OpenDate >= date)
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString()

                    }).ToArray()
                }).OrderByDescending(e => e.Tasks.Length)
                    .ThenBy(e => e.Username)
                    .Take(10)
                    .ToArray();

           var result = JsonConvert.SerializeObject(employeesDTO, Formatting.Indented);

            return result;
        }
    }
}