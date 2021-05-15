SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name as ProjectName
FROM Employees as e
JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects as p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate is null
ORDER BY e.EmployeeID