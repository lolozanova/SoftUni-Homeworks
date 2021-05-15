SELECT e.FirstName, e.LastName, e.HireDate, d.Name as DeptName
FROM Employees as e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Finance' OR d.Name = 'Sales' AND HireDate >'1999-01.01'
ORDER BY e.HireDate