
SELECT * INTO AVGSalary 
FROM Employees
WHERE Salary > 30000
DELETE FROM AVGSalary 
WHERE ManagerID = 42
UPDATE AVGSalary
SET Salary += 5000
WHERE DepartmentID = 1
SELECT DepartmentId, AVG(Salary) as AverageSalary
FROM AVGSalary
GROUP BY DepartmentID 

