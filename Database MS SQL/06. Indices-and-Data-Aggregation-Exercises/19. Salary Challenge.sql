SELECT TOP (10)FirstName, LastName, DepartmentId
FROM Employees as e
WHERE Salary > (SELECT  AVG(SALARY)
FROM Employees
WHERE DepartmentID = e.DepartmentID
GROUP BY DepartmentID)
ORDER BY DepartmentID

