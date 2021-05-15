SELECT TOP (5) e.EmployeeID, e.FirstName, e.Salary, d.Name as [DepartmentName]
FROM Employees as e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Engineering' AND e.Salary > 15000