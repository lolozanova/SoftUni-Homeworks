SELECT TOP (1) AVG(Salary) as MinAverageSalary
FROM Employees as e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID
ORDER BY MinAverageSalary
