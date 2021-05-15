SELECT e.EmployeeID, e.FirstName,
CASE
WHEN DATEPART(YEAR ,p.StartDate) < 2005 THEN p.Name
ELSE NULL
END as ProjectName
FROM Employees as e
JOIN EmployeesProjects as ep ON ep.EmployeeID = e.EmployeeID
RIGHT JOIN Projects as p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24
