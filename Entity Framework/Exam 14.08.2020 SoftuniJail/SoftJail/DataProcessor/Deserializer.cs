namespace SoftJail.DataProcessor
{

    using Data;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.Json;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var deptCellsDTOs = JsonSerializer.Deserialize<IEnumerable<DepartmentCellsDTO>>(jsonString);

            ICollection<Department> departmentsToAdd = new List<Department>();

            StringBuilder sb = new StringBuilder();

            foreach (var deptCellsDTO in deptCellsDTOs)
            {
                if (!IsValid(deptCellsDTO) || !deptCellsDTO.Cells.All(x => IsValid(x)) || deptCellsDTO.Cells.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                sb.AppendLine($"Imported {deptCellsDTO.Name} with {deptCellsDTO.Cells.Count} cells");

                var department = new Department
                {

                    Name = deptCellsDTO.Name,
                    Cells = deptCellsDTO.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    }).ToArray()

                };
                departmentsToAdd.Add(department);
            }

            context.Departments.AddRange(departmentsToAdd);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersMailsDTOs = JsonSerializer.Deserialize<IEnumerable<PrisonersMalsDTO>>(jsonString);


            List<Prisoner> validPrisoners = new List<Prisoner>();
            StringBuilder sb = new StringBuilder();


            foreach (var prisonersMailsDTO in prisonersMailsDTOs)
            {
                if (!IsValid(prisonersMailsDTO) || !prisonersMailsDTO.Mails.All(m => IsValid(m)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime incarcerationDate;

                var isIncarcerationDateValid = DateTime.TryParseExact(prisonersMailsDTO.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);
                if (isIncarcerationDateValid == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime releaseDate;

                bool isReleaseDateValid = DateTime.TryParseExact(prisonersMailsDTO.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

              
                Prisoner prisoner = new Prisoner
                {
                    FullName = prisonersMailsDTO.FullName,
                    Nickname = prisonersMailsDTO.Nickname,
                    Age = prisonersMailsDTO.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isReleaseDateValid ? (DateTime?)releaseDate : null,
                    Bail = prisonersMailsDTO.Bail,
                    CellId = prisonersMailsDTO.CellId,
                    Mails = prisonersMailsDTO.Mails.Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address
                    }).ToArray()
                  
                };


                validPrisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}