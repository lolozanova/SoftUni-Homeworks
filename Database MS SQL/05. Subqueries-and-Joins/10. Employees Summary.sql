SELECT TOP(50) e.EmployeeID,
e.FirstName + ' ' + e.LastName as EmployeeName,
m.FirstName + ' ' + m.LastName as ManagerName,
d.Name as DepartmentName
FROM Employees as e
JOIN Employees as m ON m.EmployeeID = e.ManagerID
JOIN Departments as d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID