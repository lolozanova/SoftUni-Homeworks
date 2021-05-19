SELECT DISTINCT DepartmentID, Salary as ThirdHighestSalary
FROM
(SELECT DepartmentID, Salary,
DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) as ranked
FROM Employees) as e
WHERE ranked = 3


