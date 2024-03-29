SELECT [EmployeeID],[FirstName],[LastName],[Salary],
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY [EmployeeID])
FROM Employees
WHERE Salary BETWEEN 10000 and 50000
ORDER BY Salary DESC

