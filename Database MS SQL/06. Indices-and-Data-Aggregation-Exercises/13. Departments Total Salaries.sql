SELECT DepartmentID, Sum(Salary) as TotalSalary
FROM Employees
GROUP BY DepartmentID