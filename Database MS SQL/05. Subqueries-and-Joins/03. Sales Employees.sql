SELECT  e.EmployeeID, e.FirstName, e.LastName, d.Name as DepartmentName
FROM Employees as e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
Where d.Name = 'Sales'
ORDER BY e.EmployeeID
 
